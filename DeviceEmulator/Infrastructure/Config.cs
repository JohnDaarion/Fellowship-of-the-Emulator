using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceEmulator.Infrastructure
{
    /// <summary>
    /// Klasa reprezentująca konfigurację wielu różnych opcji dla tego projektu.
    /// </summary>
    public static class Config
    {
        public const string InfoTextBox1Key = "Poziom naładowania baterii: ";
        public const string InfoTextBox2Key = "Temperatura: ";
        public const string InfoTextBox3Key = "Poziom wilgotności: ";
        public static readonly Color DisabledDiodeColor = Color.White;
        public static readonly Color EnabledDiodeColor = Color.Green;
        public const int RandomValuesGeneratorInterval = 10_000;
    }
}
