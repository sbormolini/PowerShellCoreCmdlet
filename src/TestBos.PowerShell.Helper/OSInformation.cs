using System;
using System.Runtime.InteropServices;

namespace TestBos.PowerShell.Helper
{
    class OSInformation
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public Version Version { get; set; }
        public string Architecture { get; set; }

        public OSInformation(string manufacturer, string name, Version version, string architecture)
        {
            Manufacturer = manufacturer;
            Name = name;
            Version = version;
            Architecture = architecture;
        }

        public OSInformation(string manufacturer, string name, string version, string architecture)
        {
            Manufacturer = manufacturer;
            Name = name;
            Version = new Version(version);
            Architecture = architecture;
        }

        static public OSInformation ParseFromFile()
        {
            return new OSInformation(
                "Microsaft",
                "TestOS",
                "10.0.19043",
                "X64");
        }

        static public OSInformation ParseFromRuntimeInformation()
        {
            string osDescription = RuntimeInformation.OSDescription;
            return new OSInformation(
                osDescription.Split(' ')[0],
                osDescription.Split(' ')[1],
                osDescription.Split(' ')[2],
                RuntimeInformation.OSArchitecture.ToString());
        }
    }
}
