using DeviceEmulator.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceEmulator
{
    public class DeviceEmulatorManager : IDeviceEmulatorManager
    {
        public DeviceEmulatorManager()
        {

        }
        
        public bool Diode1State {
            set
            {
                SetValue("Diode1", value.ToString());
            }
        }
        
        public bool Diode2State
        {
            set
            {
                SetValue("Diode2", value.ToString());
            }
        }

        public bool Diode3State
        {
            set
            {
                SetValue("Diode3", value.ToString());
            }
        }

        public bool Diode4State
        {
            set
            {
                SetValue("Diode4", value.ToString());
            }
        }

        public bool Diode5State
        {
            set
            {
                SetValue("Diode5", value.ToString());
            }
        }

        public bool Diode6State
        {
            set
            {
                SetValue("Diode6", value.ToString());
            }
        }

        public bool Diode7State
        {
            set
            {
                SetValue("Diode7", value.ToString());
            }
        }

        public bool Diode8State
        {
            set
            {
                SetValue("Diode8", value.ToString());
            }
        }

        public string InfoTextBox1Value
        {
            set
            {
                SetValue("infoTextBox1", value.ToString());
            }
        }

        public string InfoTextBox2Value
        {
            set
            {
                SetValue("infoTextBox2", value.ToString());
            }
        }

        public string InfoTextBox3Value
        {
            set
            {
                SetValue("infoTextBox3", value.ToString());
            }
        }

        private void SetValue(string key, string value)
        {
            var source = GetFile(Config.ExchangeFilePath);
            StringBuilder builder = new StringBuilder();

            foreach (var record in source)
            {
                if (String.Equals(record[0], key, StringComparison.OrdinalIgnoreCase))
                {
                    record[1] = value;
                    break;
                }
            }

            foreach(var record in source)
            {
                builder.Append(record[0]);
                builder.Append(";");
                builder.Append(record[1]);
                builder.Append(Environment.NewLine);
            }

            using (FileStream fileStream = File.Open(Config.ExchangeFilePath, FileMode.Open))
            { 
                fileStream.SetLength(0);
                fileStream.Close();
            };

            File.WriteAllText(Config.ExchangeFilePath, builder.ToString());
            
        }

        private List<string[]> GetFile(string path)
        {
            List<string[]> records = null;

            try
            {
                records = File.ReadLines(path)
                              .Select(a => a.Split(';'))
                              .ToList();
            }
            catch (UnauthorizedAccessException)
            {

            }

            return records;
        }
    }
}
