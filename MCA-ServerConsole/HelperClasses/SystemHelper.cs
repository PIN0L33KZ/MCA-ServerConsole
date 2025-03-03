using Microsoft.VisualBasic.Devices;

namespace MCA_ServerConsole.HelperClasses
{
    internal class SystemHelper
    {

        public static int GetAvailableRAM()
        {
            var ci = new ComputerInfo();
            var totalRam = ci.TotalPhysicalMemory / (1024.0 * 1024 * 1024);
            return (int)Math.Round(totalRam, 0);
        }
    }
}