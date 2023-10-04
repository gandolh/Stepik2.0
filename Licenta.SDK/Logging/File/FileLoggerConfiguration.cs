using System.Runtime.InteropServices;

namespace Licenta.SDK.Logging.File
{
    public sealed class FileLoggerConfiguration
    {
        public int EventId { get; set; }


        /// <summary>
        /// usr/share/WebPortal for linux , appdata for windows.
        /// if you run in docker it will write in docker container
        /// </summary>
        public string Path { get; set; }

        public FileLoggerConfiguration()
        {
            EventId = 0;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Path = "/app/WebPortal.logs";
            else Path = System.IO.Path.Join(
            Environment.GetFolderPath
            (Environment.SpecialFolder.Desktop),
            "WebPortal",
            "Logs");
        }

    }
}
