using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Story_Feature_SDL
{
    public partial class Story_Feature : Form
    {

        List<string> filteredFiles;
        FolderBrowserDialog FolderBrowser = new FolderBrowserDialog() ;

        int count = -1;
        int timerInterval = 2000;
        bool isPlaying = false;



        public Story_Feature()
        {

            InitializeComponent();


            radioButton1.Checked = true;
            slideTimer.Interval = timerInterval;

        }

        private void browseFolder(object sender, EventArgs e)
        {
            count = -1;
            isPlaying = false;
            slideTimer.Stop();
            btnPlay.Text = "Play";


            DialogResult result= FolderBrowser.ShowDialog();

            filteredFiles = Directory.GetFiles(FolderBrowser.SelectedPath, "*.*")
                .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("gif")).ToList();

            btnInfo.Text = "Folder Loaded - Now Press Play!";




        }

        private void playStopSlide(object sender, EventArgs e)
        {

            if(isPlaying == false)
            {
                btnPlay.Text = "Stop";
                isPlaying = true;
                slideTimer.Start();

            }
            else
            {
                btnPlay.Text = "Play";
                isPlaying = false;
                slideTimer.Stop();
            }


        }

        private void playTimer(object sender, EventArgs e)
        {

            count++;

            if (count >= filteredFiles.Count)
            {
                count = -1;
            }
            else
            {
                imageViewer.Image= Image.FromFile(filteredFiles[count]);
                btnInfo.Text=filteredFiles[count].ToString();
            }



        }

        private void SpeedChange(object sender, EventArgs e)
        {

            RadioButton radio = sender as RadioButton;

            switch (radio.Text.ToString())
            {
                case "1x":
                    timerInterval = 2000;
                    break;

                case "2x":
                    timerInterval = 1000;
                    break;

                case "4x":
                    timerInterval = 500;
                    break;
            }

            slideTimer.Interval = timerInterval;

        }
    }
}