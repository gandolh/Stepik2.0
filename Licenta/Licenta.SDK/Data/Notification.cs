﻿namespace Licenta.SDK.Data
{
    public class Notification
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime Emitted { get; set; }
    }
}