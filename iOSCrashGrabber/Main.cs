using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Rico
{
    public partial class Main : Form
    {
        String appName = "";
        public Main()
        {
            InitializeComponent();

            appName = getExtraDataFromFile(System.Reflection.Assembly.GetAssembly(typeof(Program)).Location);

            this.Text = appName + " crash log grabber (Rico)";

            ImageConverter ic = new ImageConverter();

            Image img = (Image)ic.ConvertFrom(getBytesFromEmbeddedResource("Step1.jpg"));
            this.stepPictureBox.Image = img;
        }

        private String getExtraDataFromFile(String filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);

            int i = data.Length - 1;
            String extraData = "";
            while (i >= 0 && data[i] != '\0')
            {
                extraData = (char)data[i] + extraData;
                i--;
            }

            return extraData;
        }

        private byte[] getBytesFromEmbeddedResource(String resourceName)
        {
            Stream inStream = this.GetType().Assembly.GetManifestResourceStream("Rico.Images." + resourceName);

            byte[] data = new byte[inStream.Length];
            inStream.Read(data, 0, (int)inStream.Length);

            return data;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }
    }
}
