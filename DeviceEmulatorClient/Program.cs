using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceEmulatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(500);
            DeviceEmulator.DeviceEmulatorManager manager = new DeviceEmulator.DeviceEmulatorManager();
            manager.Diode1State = true;
            manager.Diode2State = true;
            manager.Diode6State = true;
            manager.InfoTextBox1Value = "80%";
        }
    }
}
