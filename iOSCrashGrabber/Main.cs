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

        int currentStep = 0;
        public Main()
        {
            InitializeComponent();

            appName = getExtraDataFromFile(System.Reflection.Assembly.GetAssembly(typeof(Program)).Location);

            this.Text = appName + " crash log grabber (Rico)";

            

            gotoNextStep();
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
            gotoNextStep();
        }

        private void gotoNextStep()
        {
            ImageConverter ic = new ImageConverter();
            switch (currentStep++)
            {
                case 0:

                    Image step1Img = (Image)ic.ConvertFrom(getBytesFromEmbeddedResource("Step1.jpg"));
                    this.stepPictureBox.Image = step1Img;
                    instText.Text = "Connect your iDevice to your computer via USB";
                    nextButton.Text = "Next";
                    break;
                case 1:
                    Image step2Img = (Image)ic.ConvertFrom(getBytesFromEmbeddedResource("Step2.jpg"));
                    this.stepPictureBox.Image = step2Img;
                    instText.Text = "Open iTunes (if it isn't already), then right click your device and click sync";
                    nextButton.Text = "Next";
                    break;
                case 2:
                    instText.Text = "Click go to retrieve crashlogs";
                    nextButton.Text = "Go!";
                    break;
                case 3:
                    getCrashlogs();
                    gotoNextStep();
                    break;
                default:
                    currentStep = 0;
                    gotoNextStep();
                    break;
            }

            
        }

        private void getCrashlogs()
        {
            String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Apple Computer\\Logs\\CrashReporter\\MobileDevice";
            String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            List<String> files = new List<string>();

            traverseDirectoriesForFiles(appDataPath, ref files);
            
            MessageBox.Show(String.Format("Saved {0}-crashlogs-{1}.zip to your desktop. Please email this file to your vendor.", appName, DateTime.Now.ToString("ddMMyy-HHmm"))); 
        }

        private void traverseDirectoriesForFiles(String rootDir, ref List<String> foundFiles)
        {
            foreach (String directory in Directory.GetDirectories(rootDir))
            {
                traverseDirectoriesForFiles(directory, ref foundFiles);
            }

            foreach (String file in Directory.GetFiles(rootDir))
            {
                foundFiles.Add(file);
            }
        }
    }
}
