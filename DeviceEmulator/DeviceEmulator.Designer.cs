﻿namespace DeviceEmulator
{
    partial class DeviceEmulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diode1 = new System.Windows.Forms.TextBox();
            this.diode2 = new System.Windows.Forms.TextBox();
            this.diode8 = new System.Windows.Forms.TextBox();
            this.diode7 = new System.Windows.Forms.TextBox();
            this.diode6 = new System.Windows.Forms.TextBox();
            this.diode5 = new System.Windows.Forms.TextBox();
            this.diode4 = new System.Windows.Forms.TextBox();
            this.diode3 = new System.Windows.Forms.TextBox();
            this.infoTextBox1 = new System.Windows.Forms.TextBox();
            this.infoTextBox2 = new System.Windows.Forms.TextBox();
            this.infoTextBox3 = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // diode1
            // 
            this.diode1.BackColor = System.Drawing.Color.White;
            this.diode1.Location = new System.Drawing.Point(13, 13);
            this.diode1.Name = "diode1";
            this.diode1.ReadOnly = true;
            this.diode1.Size = new System.Drawing.Size(20, 20);
            this.diode1.TabIndex = 0;
            this.diode1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // diode2
            // 
            this.diode2.BackColor = System.Drawing.Color.White;
            this.diode2.Location = new System.Drawing.Point(49, 13);
            this.diode2.Name = "diode2";
            this.diode2.ReadOnly = true;
            this.diode2.Size = new System.Drawing.Size(20, 20);
            this.diode2.TabIndex = 1;
            // 
            // diode8
            // 
            this.diode8.BackColor = System.Drawing.Color.White;
            this.diode8.Location = new System.Drawing.Point(279, 13);
            this.diode8.Name = "diode8";
            this.diode8.ReadOnly = true;
            this.diode8.Size = new System.Drawing.Size(20, 20);
            this.diode8.TabIndex = 2;
            this.diode8.TextChanged += new System.EventHandler(this.diode8_TextChanged);
            // 
            // diode7
            // 
            this.diode7.BackColor = System.Drawing.Color.White;
            this.diode7.Location = new System.Drawing.Point(240, 13);
            this.diode7.Name = "diode7";
            this.diode7.ReadOnly = true;
            this.diode7.Size = new System.Drawing.Size(20, 20);
            this.diode7.TabIndex = 3;
            // 
            // diode6
            // 
            this.diode6.BackColor = System.Drawing.Color.White;
            this.diode6.Location = new System.Drawing.Point(200, 13);
            this.diode6.Name = "diode6";
            this.diode6.ReadOnly = true;
            this.diode6.Size = new System.Drawing.Size(20, 20);
            this.diode6.TabIndex = 4;
            this.diode6.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // diode5
            // 
            this.diode5.BackColor = System.Drawing.Color.White;
            this.diode5.Location = new System.Drawing.Point(161, 13);
            this.diode5.Name = "diode5";
            this.diode5.ReadOnly = true;
            this.diode5.Size = new System.Drawing.Size(20, 20);
            this.diode5.TabIndex = 5;
            this.diode5.TextChanged += new System.EventHandler(this.diode5_TextChanged);
            // 
            // diode4
            // 
            this.diode4.BackColor = System.Drawing.Color.White;
            this.diode4.Location = new System.Drawing.Point(124, 13);
            this.diode4.Name = "diode4";
            this.diode4.ReadOnly = true;
            this.diode4.Size = new System.Drawing.Size(20, 20);
            this.diode4.TabIndex = 6;
            // 
            // diode3
            // 
            this.diode3.BackColor = System.Drawing.Color.White;
            this.diode3.Location = new System.Drawing.Point(87, 13);
            this.diode3.Name = "diode3";
            this.diode3.ReadOnly = true;
            this.diode3.Size = new System.Drawing.Size(20, 20);
            this.diode3.TabIndex = 7;
            this.diode3.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // infoTextBox1
            // 
            this.infoTextBox1.Location = new System.Drawing.Point(26, 70);
            this.infoTextBox1.Name = "infoTextBox1";
            this.infoTextBox1.ReadOnly = true;
            this.infoTextBox1.Size = new System.Drawing.Size(263, 20);
            this.infoTextBox1.TabIndex = 8;
            this.infoTextBox1.TextChanged += new System.EventHandler(this.infoTextBox1_TextChanged);
            // 
            // infoTextBox2
            // 
            this.infoTextBox2.Location = new System.Drawing.Point(26, 108);
            this.infoTextBox2.Name = "infoTextBox2";
            this.infoTextBox2.ReadOnly = true;
            this.infoTextBox2.Size = new System.Drawing.Size(263, 20);
            this.infoTextBox2.TabIndex = 9;
            // 
            // infoTextBox3
            // 
            this.infoTextBox3.Location = new System.Drawing.Point(26, 147);
            this.infoTextBox3.Name = "infoTextBox3";
            this.infoTextBox3.ReadOnly = true;
            this.infoTextBox3.Size = new System.Drawing.Size(263, 20);
            this.infoTextBox3.TabIndex = 10;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcher1.Path = "E:\\Repozytoria\\DeviceEmulatorGroup\\DeviceEmulator\\Infrastructure";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // DeviceEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 262);
            this.Controls.Add(this.infoTextBox3);
            this.Controls.Add(this.infoTextBox2);
            this.Controls.Add(this.infoTextBox1);
            this.Controls.Add(this.diode3);
            this.Controls.Add(this.diode4);
            this.Controls.Add(this.diode5);
            this.Controls.Add(this.diode6);
            this.Controls.Add(this.diode7);
            this.Controls.Add(this.diode8);
            this.Controls.Add(this.diode2);
            this.Controls.Add(this.diode1);
            this.Name = "DeviceEmulator";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DeviceEmulator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox diode1;
        private System.Windows.Forms.TextBox diode2;
        private System.Windows.Forms.TextBox diode8;
        private System.Windows.Forms.TextBox diode7;
        private System.Windows.Forms.TextBox diode6;
        private System.Windows.Forms.TextBox diode5;
        private System.Windows.Forms.TextBox diode4;
        private System.Windows.Forms.TextBox diode3;
        private System.Windows.Forms.TextBox infoTextBox1;
        private System.Windows.Forms.TextBox infoTextBox2;
        private System.Windows.Forms.TextBox infoTextBox3;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}
