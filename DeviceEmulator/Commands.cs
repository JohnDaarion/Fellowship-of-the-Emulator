namespace DeviceEmulator
{
    public class Commands
    {
        private DeviceEmulator _emulator;

        public Commands(DeviceEmulator pEmulator)
        {
            _emulator = pEmulator;
        }

        public string GetMessage(string pCommand)
        {
            switch (pCommand)
            {
                case "DIODA1_ON":
                    _emulator.Diode1State = true;
                    return "DIODA 1 ON";
                case "DIODA1_OFF":
                    _emulator.Diode1State = false;
                    return "DIODA 1 OFF";
                case "DIODA2_ON":
                    _emulator.Diode2State = true;
                    return "DIODA 2 ON";
                case "DIODE2_OFF":
                    _emulator.Diode2State = false;
                    return "DIODA 2 OFF";
                case "DIODA3_ON":
                    _emulator.Diode3State = true;
                    return "DIODA 3 ON";
                case "DIODA3_OFF":
                    _emulator.Diode3State = false;
                    return "DIODA 3 OFF";
                case "DIODA4_ON":
                    _emulator.Diode4State = true;
                    return "DIODA 4 ON";
                case "DIODA4_OFF":
                    _emulator.Diode4State = false;
                    return "DIODA 4 OFF";
                case "DIODA5_ON":
                    _emulator.Diode5State = true;
                    return "DIODA 5 ON";
                case "DIODA5_OFF":
                    _emulator.Diode5State = false;
                    return "DIODA 5 OFF";
                case "DIODA6_ON":
                    _emulator.Diode6State = true;
                    return "DIODA 6 ON";
                case "DIODA6_OFF":
                    _emulator.Diode6State = false;
                    return "DIODA 6 OFF";
                case "DIODA7_ON":
                    _emulator.Diode7State = true;
                    return "DIODA 7 ON";
                case "DIODA7_OFF":
                    _emulator.Diode7State = false;
                    return "DIODE 7 OFF";
                case "DIODA8_ON":
                    _emulator.Diode8State = true;
                    return "DIODA 8 ON";
                case "DIODA8_OFF":
                    _emulator.Diode8State = false;
                    return "DIODA 8 OFF";
                case "GET_BATTERY_STATUS":
                    return _emulator.InfoTextBox1Value;
                case "GET_TEMPERATURE":
                    return _emulator.InfoTextBox2Value;
                case "GET_HUMIDITY":
                    return _emulator.InfoTextBox3Value;
                default:
                    return "Error";
            }
        }
    }
}
