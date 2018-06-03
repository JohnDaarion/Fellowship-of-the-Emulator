﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceEmulator.Infrastructure
{
    public static class Config
    {
        public static readonly string ExchangeFileDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + 
                                                        "/" + 
                                                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + @"/Infrastructure";

        public static readonly string ExchangeFilePath = ExchangeFileDir + @"/SharedVariables.csv";
        public const string InfoTextBox1Key = "Poziom naładowania baterii: ";
        public const string InfoTextBox2Key = "Temperatura: ";
        public const string InfoTextBox3Key = "Poziom wilgotności: ";
        public static readonly Color DisabledDiodeColor = Color.White;
        public static readonly Color EnabledDiodeColor = Color.Green;
    }
}
