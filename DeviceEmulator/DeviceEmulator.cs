using System;
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
    /// <summary>
    /// Klasa odpowiedzialna za interfejs użytkownika emulatora.
    /// </summary>
    public partial class DeviceEmulator : Form
    {
        /// <summary>
        /// Klucz pierwszego pola tekstowego, inaczej opis wartości jaką reprezentuje.
        /// </summary>
        private string _infoTextBox1Key;

        /// <summary>
        /// Klucz drugiego pola tekstowego, inaczej opis wartości jaką reprezentuje.
        /// </summary>
        private string _infoTextBox2Key;

        /// <summary>
        /// Klucz trzeciego pola tekstowego, inaczej opis wartości jaką reprezentuje.
        /// </summary>
        private string _infoTextBox3Key;

        /// <summary>
        /// Wartość interwału z którym będą generowane losowe wartości w interfejsie użytkownika.
        /// </summary>
        private int _randomValuesGeneratorInterval;

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
            _randomValuesGeneratorInterval = Config.RandomValuesGeneratorInterval;

            _commands = new Commands(this);
            _receiver = new ReceiverBluetoothService(_commands);

            pictureBox1.Image = makeQr();
        }

        /// <summary>
        /// Metoda odpowiedzialna za generowanie kodu QR na podstawie adresu MAC karty sieciowej (Bluetooth) na którym emulator jest uruchomiony.
        /// </summary>
        /// <returns> Wygenerowany kod QR reprezentujący adres MAC </returns>
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

        /// <summary>
        /// Metoda odpowiedzialna za zwrócenie adresu MAC karty sieciowej interfejsu Bluetooth
        /// </summary>
        /// <returns> Adres MAC karty sieciowej Bluetooth </returns>
        private PhysicalAddress GetBTMacAddress()
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


        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu pierwszej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu pierwszej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu drugiej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu drugiej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu trzeciej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu trzeciej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu czwartej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu czwartej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu piatej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu piątej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu szóstej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu szóstej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu siódmej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu siódmej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie stanu ósmej diody na włączoną (dla wartości true) lub wyłączoną (dla wartości false)
        /// oraz pobieranie stanu ósmej diody (true = włączona, false == wyłączona)
        /// </summary>
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

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie wartości tekstowej pierwszego pola tekstowego
        /// oraz za pobieranie wartości tekstowej pierwszego pola tekstowego
        /// </summary>
        public string InfoTextBox1Value
        {
            get
            {
                return infoTextBox1.Text;
            }
            set
            {
                infoTextBox1.Invoke((MethodInvoker)(() => infoTextBox1.Text = _infoTextBox1Key + " " + value));
            }
        }

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie wartości tekstowej drugiego pola tekstowego
        /// oraz za pobieranie wartości tekstowej drugiego pola tekstowego
        /// </summary>
        public string InfoTextBox2Value
        {
            get
            {
                return infoTextBox2.Text;
            }
            set
            {
                infoTextBox2.Invoke((MethodInvoker)(() => infoTextBox2.Text = _infoTextBox2Key + " " + value));
            }
        }

        /// <summary>
        /// Właściowść odpowiedzialna za ustawienie wartości tekstowej trzeciego pola tekstowego
        /// oraz za pobieranie wartości tekstowej trzeciego pola tekstowego
        /// </summary>
        public string InfoTextBox3Value
        {
            get
            {
                return infoTextBox3.Text;
            }
            set
            {
                infoTextBox3.Invoke((MethodInvoker)(() => infoTextBox3.Text = _infoTextBox3Key + " " + value));
            }
        }

        /// <summary>
        /// Metoda pomocnicza ustawiająca kolor diody (przekazanej jako argument "diode")
        /// na wartości (zdefiniowane w pliku Config.cs) w zależności od argumentu "state".
        /// </summary>
        /// <param name="diode"> Referencja do obiektu diody. </param>
        /// <param name="state"> Stan diody jaki chcemy ustawić (true = włączona, false = wyłączona). </param>
        private void SetDiodeState(TextBox diode, bool state)
        {
            if (state)
            {
                diode.Invoke((MethodInvoker)(() => diode.BackColor = Config.EnabledDiodeColor));
            }
            else
            {
                diode.Invoke((MethodInvoker)(() => diode.BackColor = Config.DisabledDiodeColor));
            }
        }

        /// <summary>
        /// Metoda pomocnicza pobierająca stan diody (przekazanej jako argument "diode"). 
        /// </summary>
        /// <param name="diode"> Referencja do obiektu diody. </param>
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

        /// <summary>
        /// Metoda generująca losowe wartości dla elementów interfejsu użytkownika.
        /// </summary>
        /// <param name="token"> Cancellation token </param>
        private void GenerateNewValues(CancellationToken token)
        {
            Random random = new Random();

            while (!token.IsCancellationRequested)
            {
                InfoTextBox1Value = random.Next(101).ToString();
                InfoTextBox2Value = random.Next(101).ToString();
                InfoTextBox3Value = random.Next(101).ToString();

                Thread.Sleep(_randomValuesGeneratorInterval);
            }
        }

        /// <summary>
        /// Metoda wywoływana podczas przełączenia switcha (sekcja "Generator").
        /// </summary>
        private void RBGeneratorOn_CheckedChanged(object sender, EventArgs e)
        {
            if (RBGeneratorOn.Checked)
            {
                _cancelSource = new CancellationTokenSource();
                Task.Run(() => GenerateNewValues(_cancelSource.Token));
            }
            else
            {
                _cancelSource.Cancel();
            }
        }

        /// <summary>
        /// Metoda wywoływana podczas przełączenia switcha (sekcja "Bluetooth").
        /// </summary>
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

        private void DeviceEmulator_Load(object sender, EventArgs e)
        {

        }
    }
}
