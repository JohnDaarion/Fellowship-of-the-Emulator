using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceEmulator
{
    public class DaviceEmulatorManagerValuesSetter
    {
        private IDeviceEmulatorManager _deviceEmulatorManager;
        private int _interval;


        public DaviceEmulatorManagerValuesSetter(IDeviceEmulatorManager deviceEmulatorManager, int interval)
        {
            _deviceEmulatorManager = deviceEmulatorManager;
            _interval = interval;
        }


        public void Start()
        {
            Task.Run(() => StartGeneratingRandomValues());
        }

        public void StartGeneratingRandomValues()
        {
            int counter = 0;
            while(counter < 30)
            {
                Thread.Sleep(_interval);
                _deviceEmulatorManager.Diode1State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.Diode2State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.Diode3State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.Diode4State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.Diode5State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.Diode6State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.Diode7State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.Diode8State = GenerateRandomBoolValues();

                Thread.Sleep(200);
                _deviceEmulatorManager.InfoTextBox2Value = GenerateRandomIntegerValues().ToString();

                Thread.Sleep(200);
                _deviceEmulatorManager.InfoTextBox3Value = GenerateRandomIntegerValues().ToString();

                counter++;
            }
        }

        private bool GenerateRandomBoolValues()
        {
            Random random = new Random();
            return random.NextDouble() < 0.5;
        }

        private int GenerateRandomIntegerValues(int min = 0 , int max = 100)
        {
            Random random = new Random();
            return random.Next(min , max);
        }
    }
}
