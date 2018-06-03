using DeviceEmulator.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceEmulator
{
    public class DeviceEmulatorManager : IDeviceEmulatorManager
    {
        public bool Diode1State
        {
            get
            {
                var result = GetValue("Diode1");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode1", value.ToString());
            }
        }


        public bool Diode2State
        {
            get
            {
                var result = GetValue("Diode2");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode2", value.ToString());
            }
        }

        public bool Diode3State
        {
            get
            {
                var result = GetValue("Diode3");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode3", value.ToString());
            }
        }

        public bool Diode4State
        {
            get
            {
                var result = GetValue("Diode4");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode4", value.ToString());
            }
        }

        public bool Diode5State
        {
            get
            {
                var result = GetValue("Diode5");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode5", value.ToString());
            }
        }

        public bool Diode6State
        {
            get
            {
                var result = GetValue("Diode6");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode6", value.ToString());
            }
        }

        public bool Diode7State
        {
            get
            {
                var result = GetValue("Diode7");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode7", value.ToString());
            }
        }

        public bool Diode8State
        {
            get
            {
                var result = GetValue("Diode8");
                return bool.Parse(result);
            }
            set
            {
                SetValue("Diode8", value.ToString());
            }
        }

        public string InfoTextBox1Value
        {
            get
            {
                return GetValue("infoTextBox1");
            }
            set
            {
                SetValue("infoTextBox1", value.ToString());
            }
        }

        public string InfoTextBox2Value
        {
            get
            {
                return GetValue("infoTextBox2");
            }
            set
            {
                SetValue("infoTextBox2", value.ToString());
            }
        }

        public string InfoTextBox3Value
        {
            get
            {
                return GetValue("infoTextBox3");
            }
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

            foreach (var record in source)
            {
                builder.Append(record[0]);
                builder.Append(";");
                builder.Append(record[1]);
                builder.Append(Environment.NewLine);
            }

            using (FileStream fileStream = File.Open(Config.ExchangeFilePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                try
                {
                    var bytes = Encoding.ASCII.GetBytes(builder.ToString());
                    fileStream.SetLength(0);
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Close();
                    Debug.WriteLine("OK");
                }
                catch (Exception)
                {
                    Debug.WriteLine("Error");
                }
            }
        }

        private string GetValue(string key)
        {
            var source = GetFile(Config.ExchangeFileDir);
            StringBuilder builder = new StringBuilder();

            foreach (var record in source)
            {
                if (String.Equals(record[0], key, StringComparison.OrdinalIgnoreCase))
                {
                    return record[1];
                }
            }

            return null;
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
