using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceEmulator
{
    public interface IDeviceEmulatorManager
    {
        //bool Diode1State { get; set; }
        //bool Diode2State { get; set; }
        //bool Diode3State { get; set; }
        //bool Diode4State { get; set; }
        //bool Diode5State { get; set; }
        //bool Diode6State { get; set; }
        //bool Diode7State { get; set; }
        //bool Diode8State { get; set; }
        //string InfoTextBox1Value { get; set; }
        //string InfoTextBox2Value { get; set; }
        //string InfoTextBox3Value { get; set; }

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
