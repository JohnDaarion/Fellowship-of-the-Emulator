﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceEmulator.Infrastructure;
using QRCoder;
using System.Management;
using System.Net.NetworkInformation;

namespace DeviceEmulator
{
    public partial class DeviceEmulator : Form
    {
        private string _infoTextBox1Key;
        private string _infoTextBox2Key;
        private string _infoTextBox3Key;
        private CancellationTokenSource _cancelSource;
        private Commands _commands;
        private ReceiverBluetoothService _receiver;

        public DeviceEmulator()
        {
            InitializeComponent();
            _infoTextBox1Key = Config.InfoTextBox1Key;
            infoTextBox1.Text = _infoTextBox1Key;
            _infoTextBox2Key = Config.InfoTextBox2Key;
            infoTextBox2.Text = _infoTextBox2Key;
            _infoTextBox3Key = Config.InfoTextBox3Key;
            infoTextBox3.Text = _infoTextBox3Key;
            fileSystemWatcher1.Path = Config.ExchangeFileDir;
            _commands = new Commands(this);
            _receiver = new ReceiverBluetoothService(_commands);
            pictureBox1.Image = makeQr();
        }

        private Image makeQr()
        {
            var qrGenerator = new QRCodeGenerator();
            var address = GetBTMacAddress()
                .ToString()
                .ToUpper()
                .Insert(2, ":")
                .Insert(5, ":")
                .Insert(8, ":")
                .Insert(11, ":")
                .Insert(14, ":");
            var qrCodeData = qrGenerator.CreateQrCode(address, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }

        private static PhysicalAddress GetBTMacAddress()
        {

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.FastEthernetFx &&
                    nic.NetworkInterfaceType != NetworkInterfaceType.Wireless80211)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

        public bool Diode1State
        {
            get
            {
                return CheckDiodeState(diode1);
            }
            set
            {
                SetDiodeState(diode1, value);
            }
        }

        public bool Diode2State
        {
            get
            {
                return CheckDiodeState(diode2);
            }
            set
            {
                SetDiodeState(diode2, value);
            }
        }

        public bool Diode3State
        {
            get
            {
                return CheckDiodeState(diode3);
            }
            set
            {
                SetDiodeState(diode3, value);
            }
        }

        public bool Diode4State
        {
            get
            {
                return CheckDiodeState(diode4);
            }
            set
            {
                SetDiodeState(diode4, value);
            }
        }

        public bool Diode5State
        {
            get
            {
                return CheckDiodeState(diode5);
            }
            set
            {
                SetDiodeState(diode5, value);
            }
        }

        public bool Diode6State
        {
            get
            {
                return CheckDiodeState(diode6);
            }
            set
            {
                SetDiodeState(diode6, value);
            }
        }

        public bool Diode7State
        {
            get
            {
                return CheckDiodeState(diode7);
            }
            set
            {
                SetDiodeState(diode7, value);
            }
        }

        public bool Diode8State
        {
            get
            {
                return CheckDiodeState(diode8);
            }
            set
            {
                SetDiodeState(diode8, value);
            }
        }

        public string InfoTextBox1Value
        {
            get
            {
                return infoTextBox1.Text;
            }
            set
            {
                infoTextBox1.Invoke((MethodInvoker)(() => infoTextBox1.Text = _infoTextBox1Key + " " + value));
                //infoTextBox1.Text = _infoTextBox1Key + " " + value;
            }
        }

        public string InfoTextBox2Value
        {
            get
            {
                return infoTextBox2.Text;
            }
            set
            {
                infoTextBox2.Invoke((MethodInvoker)(() => infoTextBox2.Text = _infoTextBox2Key + " " + value));
                //infoTextBox2.Text = _infoTextBox2Key + " " + value;
            }
        }

        public string InfoTextBox3Value
        {
            get
            {
                return infoTextBox3.Text;
            }
            set
            {
                infoTextBox3.Invoke((MethodInvoker)(() => infoTextBox3.Text = _infoTextBox3Key + " " + value));
                //infoTextBox3.Text = _infoTextBox3Key + " " + value;
            }
        }

        private void SetDiodeState(TextBox diode, bool state)
        {
            if (state)
            {
                diode.Invoke((MethodInvoker)(() => diode.BackColor = Config.EnabledDiodeColor));
                //diode.BackColor = Config.EnabledDiodeColor;
            }
            else
            {
                diode.Invoke((MethodInvoker)(() => diode.BackColor = Config.DisabledDiodeColor));
                //diode.BackColor = Config.DisabledDiodeColor;
            }
        }

        private bool CheckDiodeState(TextBox diode)
        {
            var color = diode.BackColor;

            if (color == Config.EnabledDiodeColor)
            {
                return true;
            }

            if (color == Config.DisabledDiodeColor)
            {
                return false;
            }

            throw new InvalidOperationException("Stan diody jest nieprawidłowy.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void infoTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            Thread.Sleep(100);

            List<string[]> records = null;

            try
            {
                records = File.ReadLines(Infrastructure.Config.ExchangeFilePath)
                              .Select(a => a.Split(';'))
                              .ToList();
            }
            catch (UnauthorizedAccessException)
            {

            }

            //records.RemoveAt(0);

            foreach(var record in records)
            {
                if( record[0] == nameof(diode1) ) {
                    bool value = bool.Parse(record[1]);
                    Diode1State = value;
                }

                if (record[0] == nameof(diode2))
                {
                    bool value = bool.Parse(record[1]);
                    Diode2State = value;
                }
                if (record[0] == nameof(diode3))
                {
                    bool value = bool.Parse(record[1]);
                    Diode3State = value;
                }

                if (record[0] == nameof(diode4))
                {
                    bool value = bool.Parse(record[1]);
                    Diode4State = value;
                }
                if (record[0] == nameof(diode5))
                {
                    bool value = bool.Parse(record[1]);
                    Diode5State = value;
                }

                if (record[0] == nameof(diode6))
                {
                    bool value = bool.Parse(record[1]);
                    Diode6State = value;
                }
                if (record[0] == nameof(diode7))
                {
                    bool value = bool.Parse(record[1]);
                    Diode7State = value;
                }

                if (record[0] == nameof(diode8))
                {
                    bool value = bool.Parse(record[1]);
                    Diode8State = value;
                }

                if (record[0] == nameof(infoTextBox1))
                {
                    InfoTextBox1Value = record[1];
                }

                if (record[0] == nameof(infoTextBox2))
                {
                    InfoTextBox2Value = record[1];
                }

                if (record[0] == nameof(infoTextBox3))
                {
                    InfoTextBox3Value = record[1];
                }
            }
        }

        private void DeviceEmulator_Load(object sender, EventArgs e)
        {
            
        }

        private void diode8_TextChanged(object sender, EventArgs e)
        {

        }

        private void diode5_TextChanged(object sender, EventArgs e)
        {

        }

        public void GenerateNewValues(CancellationTokenSource token)
        {
            Random random = new Random();

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                
                InfoTextBox1Value = random.Next(101).ToString();
                InfoTextBox2Value = random.Next(101).ToString();
                InfoTextBox3Value = random.Next(101).ToString();
                Thread.Sleep(10000);
            }
        }

        private void RBGeneratorOn_CheckedChanged(object sender, EventArgs e)
        {
            if (RBGeneratorOn.Checked)
            {
                _cancelSource = new CancellationTokenSource();
                Task.Run(() => GenerateNewValues(_cancelSource));
            }
            else
            {
                _cancelSource.Cancel();
            }
        }

        private void RBBluetoothOff_CheckedChanged(object sender, EventArgs e)
        {
            if (RBBluetoothOn.Checked)
            {
                _receiver.Start();
            }
            else
            {
                _receiver.Stop();
            }
        }
    }
}
