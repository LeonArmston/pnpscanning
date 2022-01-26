﻿using PnP.Scanning.Core.Scanners;
using PnP.Scanning.Core.Storage;
using Serilog;

namespace PnP.Scanning.Core.Services
{
    internal sealed class SiteEnumerationManager
    {

        public SiteEnumerationManager(StorageManager storageManager)
        {
            StorageManager = storageManager;
        }

        internal StorageManager StorageManager { get; private set; }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<List<string>> EnumerateSiteCollectionsToScanAsync(StartRequest start)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            List<string> list = new();

            Log.Information("Building list of site collections to scan");

            if (!string.IsNullOrEmpty(start.SitesList))
            {
                Log.Information("Building list of site collections: using sites list");
                foreach (var site in LoadSitesFromList(start.SitesList, new char[] { ',' }))
                {
                    list.Add(site.TrimEnd('/'));
                }
            }
            else if (!string.IsNullOrEmpty(start.SitesFile))
            {
                Log.Information("Building list of site collections: using sites file");
                foreach (var row in LoadSitesFromCsv(start.SitesFile, new char[] { ',' }))
                {
                    if (!string.IsNullOrEmpty(row[0]))
                    {
                        list.Add(row[0].ToString().TrimEnd('/'));
                    }
                }
            }
            else if (!string.IsNullOrEmpty(start.Tenant))
            {
                Log.Information("Building list of site collections: using tenant scope");

            }

#if DEBUG
            // Insert a set of dummy site collections for testing purposes
            if (!string.IsNullOrEmpty(start.Mode) && 
                start.Mode.Equals("test", StringComparison.OrdinalIgnoreCase) &&
                list.Count == 0)
            {
                int sitesToScan = 10;
                var numberOfSitesProperty = start.Properties.FirstOrDefault(p => p.Property == Constants.StartTestNumberOfSites);

                if (numberOfSitesProperty != null)
                {
                    sitesToScan = int.Parse(numberOfSitesProperty.Value);
                }

                for (int i = 0; i < sitesToScan; i++)
                {
                    list.Add($"https://bertonline.sharepoint.com/sites/prov-{i}");
                }
            }
#endif
            Log.Information("Scan scope defined: {SitesToScan} site collections will be scanned", list.Count);

            return list;
        }

        internal async Task<List<EnumeratedWeb>> EnumerateWebsToScanAsync(Guid scanId, string siteCollectionUrl, OptionsBase options, bool isRestart)
        {
            List<EnumeratedWeb> webUrlsToScan = new();
            
            if (isRestart)
            {
                // When we're enumerating webs for a scan restart we might already have done this 
                // previously and so only the webs not processed should be handled again
                var websToRestart = await StorageManager.WebsToRestartScanningAsync(scanId, siteCollectionUrl);
                if (websToRestart != null && websToRestart.Count > 0)
                {
                    return websToRestart;
                }
            }

#if DEBUG
            // Insert dummy webs
            if (options is TestOptions testOptions)
            {
                // Add root web
                webUrlsToScan.Add(new EnumeratedWeb { WebUrl = "/", WebTemplate = "STS#0"});

                int numberOfWebs = new Random().Next(10);
                Log.Information("Number of webs to scan: {WebsToScan}", numberOfWebs + 1);

                for (int i = 0; i < numberOfWebs; i++)
                {
                    webUrlsToScan.Add(new EnumeratedWeb { WebUrl = $"/subsite{i}", WebTemplate = "STS#0" });
                }
            }
#endif

            return webUrlsToScan;
        }

        /// <summary>
        /// Load csv file and return data
        /// </summary>
        /// <param name="path">Path to CSV file</param>
        /// <param name="separator">Separator used in the CSV file</param>
        /// <returns>List of site collections</returns>
        private static IEnumerable<string[]> LoadSitesFromCsv(string path, params char[] separator)
        {
            return from line in File.ReadLines(path)
                   let parts = from p in line.Split(separator, StringSplitOptions.RemoveEmptyEntries) select p
                   select parts.ToArray();
        }

        private static string[] LoadSitesFromList(string list, params char[] separator)
        {
            return list.Split(separator, StringSplitOptions.RemoveEmptyEntries);                   
        }
    }
}
