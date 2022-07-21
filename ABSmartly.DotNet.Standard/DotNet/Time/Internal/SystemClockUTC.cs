﻿using System;

namespace ABSmartly.DotNet.Time.Internal;

public class SystemClockUTC : Clock
{
    public override long Millis()
    {
        //return System.currentTimeMillis();
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}