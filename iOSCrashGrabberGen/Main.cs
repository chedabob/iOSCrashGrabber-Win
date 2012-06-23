using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sonny
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            buildApp();
        }

        private void buildApp()
        {
            String appName = appNameTextBox.Text;

            if (appName.Length == 0)
            {
                MessageBox.Show("Enter an app name");
                return;
            }

            byte[] rawBytes = getBytesFromEmbeddedResource("Rico.exe");


            byte[] filenameBytes = new System.Text.ASCIIEncoding().GetBytes('\0' + appName);

            byte[] outBytes = new byte[filenameBytes.Length + rawBytes.Length];
            Array.Copy(rawBytes, outBytes, rawBytes.Length);
            Array.Copy(filenameBytes, 0, outBytes, rawBytes.Length, filenameBytes.Length);

            File.WriteAllBytes(appName + ".exe", outBytes);

            MessageBox.Show("Created file: " + appName + ".exe");
        }

        private byte[] getBytesFromEmbeddedResource(String resourceName)
        {
            Stream inStream = this.GetType().Assembly.GetManifestResourceStream("Sonny." + resourceName);

            byte[] data = new byte[inStream.Length];
            inStream.Read(data, 0, (int)inStream.Length);

            return data;
        }

        private void appNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                buildApp();
            }
        }

       
    }
}
