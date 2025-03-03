using Microsoft.VisualBasic.Devices;

namespace MCA_ServerConsole.HelperClasses
{
    internal class SystemHelper
    {

        public static int GetAvailableRAM()
        {
            ComputerInfo ci = new();
            double totalRam = ci.TotalPhysicalMemory / (1024.0 * 1024 * 1024);
            return (int)Math.Round(totalRam, 0);
        }
    }
}