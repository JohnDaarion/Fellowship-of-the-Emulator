using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InTheHand.Net.Sockets;

namespace DeviceEmulator
{
    public class ReceiverBluetoothService : IDisposable
    {
        private readonly Guid _serviceClassId;
        private BluetoothListener _listener;
        private CancellationTokenSource _cancelSource;
        private readonly Commands _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverBluetoothService" /> class.
        /// </summary>
        public ReceiverBluetoothService(Commands pCommands)
        {
            _commands = pCommands;
            _serviceClassId = new Guid("0e6114d0-8a2e-477a-8502-298d1ff4b4ba");
        }

        /// <summary>
        /// Gets or sets a value indicating whether was started.
        /// </summary>
        /// <value>
        /// The was started.
        /// </value>
        public bool WasStarted { get; set; }

        /// <summary>
        /// Starts the listening from Senders.
        /// </summary>
        public void Start()
        {
            WasStarted = true;

            if (_cancelSource != null && _listener != null)
            {
                Dispose(true);
            }

            _listener = new BluetoothListener(_serviceClassId);
            _listener.Start();
            _cancelSource = new CancellationTokenSource();
            Task.Run(() => Listener(_cancelSource));
        }

        /// <summary>
        /// Stops the listening from Senders.
        /// </summary>
        public void Stop()
        {
            WasStarted = false;
            _cancelSource.Cancel();
        }

        /// <summary>
        /// Listeners the accept bluetooth client.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        private void Listener(CancellationTokenSource token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                using (BluetoothClient client = _listener.AcceptBluetoothClient())
                {
                    var streamwriter = client.GetStream();

                    try
                    {
                        byte[] bufferIn = new byte[1024];
                        streamwriter.Read(bufferIn, 0, bufferIn.Length);
                        string result = Encoding.UTF8.GetString(bufferIn);
                        var bufferOut = Encoding.UTF8.GetBytes(_commands.GetMessage(result.Replace("\0", "")));
                        streamwriter.Write(bufferOut, 0, bufferOut.Length);
                        streamwriter.Flush();
                    }
                    finally
                    {
                        streamwriter.Close();
                        client.Close();
                    }
                }
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_cancelSource != null)
                {
                    _listener.Stop();
                    _listener = null;
                    _cancelSource.Dispose();
                    _cancelSource = null;
                }
            }
        }
    }
}
