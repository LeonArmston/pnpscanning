﻿namespace PnP.Scanning.Core.Storage
{
    internal enum ScanStatus
    {
        Queued = 1,
        Running = 2,
        Finished = 3,
        Paused = 4,
        Failed = 5,
    }
}
