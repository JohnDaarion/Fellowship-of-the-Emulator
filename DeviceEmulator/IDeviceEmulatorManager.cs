using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceEmulator
{
    public interface IDeviceEmulatorManager
    {
        bool Diode1State { set; }
        bool Diode2State { set; }
        bool Diode3State { set; }
        bool Diode4State { set; }
        bool Diode5State { set; }
        bool Diode6State { set; }
        bool Diode7State { set; }
        bool Diode8State { set; }
        string InfoTextBox1Value { set; }
        string InfoTextBox2Value { set; }
        string InfoTextBox3Value { set; }
    }
}
