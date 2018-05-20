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
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode1", value.ToString());
            }
        }


        public bool Diode2State
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode2", value.ToString());
            }
        }

        public bool Diode3State
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode3", value.ToString());
            }
        }

        public bool Diode4State
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode4", value.ToString());
            }
        }

        public bool Diode5State
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode5", value.ToString());
            }
        }

        public bool Diode6State
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode6", value.ToString());
            }
        }

        public bool Diode7State
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode7", value.ToString());
            }
        }

        public bool Diode8State
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "Diode8", value.ToString());
            }
        }

        public string InfoTextBox1Value
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "infoTextBox1", value.ToString());
            }
        }

        public string InfoTextBox2Value
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "infoTextBox2", value.ToString());
            }
        }

        public string InfoTextBox3Value
        {
            set
            {
                var file = GetFile(Config.ExchangeFilePath);
                SetValue(file, "infoTextBox3", value.ToString());
            }
        }

        private void SetValue(List<string[]> source , string key, string value)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var record in source)
            {
                if (String.Equals(record[0], key, StringComparison.OrdinalIgnoreCase))
                {
                    //bool value = bool.Parse(record[1]);
                    //Diode1State = value;
                    record[1] = value;
                    break;
                }
            }

            foreach(var record in source)
            {
                //record = record[0] + ";" + record[1];
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
