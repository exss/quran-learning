using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Saba
{
    public partial class FormMain : Form
    {
        #region Global Variables

        Audio backMusic;
        Audio audioSoreh;
        Boolean PlayState = false,paused = false;
        int AyehCounter,RepeatCounter,sorehNumber,TotlalNumAyeh,TotalRepeat;

        //Voice Arrays *****************************************************
                                //فاتحه
        double[][] voiceArray = { new double[] { 8,
                                                 30, 36.7, 43, 49, 53, 56, 62.5, 67.5,
                                                 80 },
                                //******************************************
                                //یس
                              new double[] { 84,
                                             0, 5, 10, 14, 18, 22, 26.5, 37.5, 45, 56, 70, 81.5,
                                             95, 111, 122, 139, 155.8, 163.5, 169, 186.5, 199, 210.5, 219,
                                             226.5, 243.5, 251, 258.5, 266.5, 275.5, 296, 307, 320.5, 331, 339,
                                             351, 365, 374.5, 389, 398.7, 409, 416.5, 433, 442.5, 449, 457.5,
                                             464, 474, 486, 523, 531, 541.7, 551, 560.5, 573.5, 585, 596,
                                             604.5, 612.5, 619.5, 625, 630, 643.5, 651, 660, 667.7, 673, 686.7, 699,
                                             711.5, 720, 732.5, 742, 757, 766, 773, 781, 790.5, 800.5, 813,
                                             822.5, 834.5, 846.5, 862.5, 876 ,
                                             887},
                                //******************************************
                                //واقعه
                              new double[] { 97, 
                                             0, 5, 8.3, 11.8, 14.3, 18.2, 21.7, 27.5, 31.7, 37.3, 42.5, 46.3,
                                             50.2, 54, 57.2, 60.5, 64, 68.2, 73.5, 80.5, 86, 91.2, 96.2,
                                             98.5, 102, 109, 114.55, 119, 124.8, 128, 131.5, 134.5, 139, 142.2,
                                             147, 150.3, 159, 163, 164.9, 167.8, 172.1, 176, 181, 184.5, 188,
                                             192.5, 198, 204, 215, 220, 224, 229, 238, 243.8, 246.8, 250.8,
                                             253.5, 259, 263.5, 266.8, 273.8, 279.1, 287.8, 294.2, 298.3, 304, 312.3,
                                             314.8, 317.2, 323, 331.5, 338.5, 343.2, 351, 356.8, 362, 367.6, 372.8,
                                             377, 381.1, 385.8, 390.7, 395.9, 401, 405.3, 411, 417, 422.2, 428,
                                             435.1, 440.8, 446.5, 450.8, 460, 462.7, 465.2, 469.4,
                                             474},
                                //******************************************
                                //حشر
                              new double[] { 25,
                                             0, 6.5, 14.5, 62, 76, 92, 108, 137, 178, 205, 238, 264.5,
                                             295, 313, 328, 355.5, 366, 386.5, 401.3, 420.5, 434.2, 449, 470.8,
                                             482.5, 501.5, 
                                             521},
                                //******************************************
                                //قیامة
                              new double[] { 41,
                                             0, 5, 9.8, 15, 22.5, 28.5, 34, 38, 41, 43, 46, 51.5,
                                             53.7, 58, 65, 69.8, 73.2, 78, 83.7, 88.2, 93.5, 98.5,
                                             101, 106, 109, 114, 119, 124.5, 128, 133, 137, 141, 144,
                                             148.2, 154.3, 157, 161, 167, 173, 178.7, 184.4,
                                             193},
                                //******************************************
                                //انسان
                              new double[] { 32, 
                                             0, 6, 17, 31, 40.8, 50.7, 61, 70.5, 80.5, 89.5, 102, 111,
                                             120, 129.2, 141, 150, 163, 170, 178.5, 186, 198, 207, 224,
                                             234, 241.5, 249.5, 255.5, 262.5, 276.8, 288.2, 301, 318,
                                             332},
                                //******************************************
                                //مرسلات
                              new double[] { 51,
                                             0, 5.2, 8.7, 12.3, 16.7, 20, 23.5, 26.2, 31.5, 35.7, 39.7, 43.3,
                                             46, 50, 53.5, 58.3, 64, 68, 73, 77, 83, 92, 97.5,
                                             101, 106, 110.5, 115, 120, 133, 138.5, 146.7, 154, 159, 165,
                                             170, 176, 181.5, 186, 191, 197, 203.5, 208.4, 215, 220, 228.5,
                                             233.5, 238.2, 244.5, 249, 253.7, 258.7,
                                             263.7},
                                //******************************************
                                //نازعات
                              new double[] { 47,
                                             0, 4, 7.8, 11.2, 14.2, 17, 20, 23, 26.3, 31, 34.3, 41,
                                             46.5, 51.3, 57, 62, 66.7, 72.5, 77.5, 82.8, 87, 90.5, 93,
                                             96.7, 99.1, 103, 108.5, 114.3, 123.8, 128, 132.3, 137, 143, 145.7,
                                             150, 158.5, 163.8, 168, 171.7, 175.4, 180, 188.5, 194, 199.5, 204,
                                             207.5, 215.5,
                                             226},
                                //******************************************
                                //کوثر
                              new double[] { 4,
                                             0, 4.7, 9.5, 13,
                                             17.5},
                                //******************************************
                                //اخلاص
                              new double[] { 5, 
                                             0, 6, 9.2, 11.5, 15,
                                             20} };
        //******************************************************************

        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            picture_Ayeh.Image = Image.FromFile(@"Image\1\1.png");

            backMusic = new Audio(@"Voice\1.MP3");
            audioSoreh = new Audio(@"Voice\1.MP3");
            audioSoreh.CurrentPosition = 30;
            backMusic.Play();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            backMusic.Stop();
            timer1.Stop();
            timer1.Enabled = false;
        }

        #region Menu Items

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frmAbout = new FormAbout();
            frmAbout.ShowDialog();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp frmHelp = new FormHelp();
            frmHelp.ShowDialog();
        }

        #endregion 

        #region Soreh Buttons

        private void BtnSoreh1_Click(object sender, EventArgs e)
        {
            PlaySoreh(1, "الفاتحه");
        }

        private void BtnSoreh2_Click(object sender, EventArgs e)
        {
            PlaySoreh(2,"یس");
        }

        private void BtnSoreh3_Click(object sender, EventArgs e)
        {
            PlaySoreh(3, "الواقعه");
        }

        private void BtnSoreh4_Click(object sender, EventArgs e)
        {
            PlaySoreh(4, "الحشر");
        }

        private void BtnSoreh5_Click(object sender, EventArgs e)
        {
            PlaySoreh(5, "القیامة");
        }

        private void BtnSoreh6_Click(object sender, EventArgs e)
        {
            PlaySoreh(6, "الانسان");
        }

        private void BtnSoreh7_Click(object sender, EventArgs e)
        {
            PlaySoreh(7, "المرسلات");
        }

        private void BtnSoreh8_Click(object sender, EventArgs e)
        {
            PlaySoreh(8, "النازعات");
        }

        private void BtnSoreh9_Click(object sender, EventArgs e)
        {
            PlaySoreh(9, "کوثر");
        }

        private void BtnSoreh10_Click(object sender, EventArgs e)
        {
            PlaySoreh(10, "الاخلاص");
        }

        #endregion

        private void PlaySoreh(int SorehNum, string SorehName)
        {
            backMusic.Stop();
            timer1.Stop();
            timer1.Enabled = false;
            timer_Ayeh.Stop();
            timer_Ayeh.Enabled = false;
            audioSoreh.Stop();
            audioSoreh = null;

            BtnPlay.BackgroundImage = global::Saba.Properties.Resources.Pause;
            PlayState = true;

            sorehNumber = SorehNum - 1;         
            FormPlaySetting frmPlaySetting = new FormPlaySetting();
            frmPlaySetting.NumOfAyeh = Convert.ToInt32(voiceArray[sorehNumber][0]) - 1;
            frmPlaySetting.setCombo();
            frmPlaySetting.ShowDialog();
            TotalRepeat =  frmPlaySetting.repeatNum;
            RepeatCounter = TotalRepeat;
            AyehCounter = Convert.ToInt32(voiceArray[sorehNumber][0]) - frmPlaySetting.SelectedAyeh;
            TotlalNumAyeh = Convert.ToInt32(voiceArray[sorehNumber][0]);
            this.label_SorehName.Text = SorehName;
            audioSoreh = new Audio(@"Voice\" + SorehNum + ".MP3");
            audioSoreh.CurrentPosition = voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 1];
            picture_Ayeh.Image = Image.FromFile(@"Image\" + (sorehNumber + 1).ToString() + @"\" + (TotlalNumAyeh - AyehCounter + 1).ToString() + ".png");            
            timer_Ayeh.Interval = Convert.ToInt32((voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 2] - voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 1]) * 1000);
            RepeatCounter--;
            txtCounter.Text = RepeatCounter.ToString();
            AyehCounter--;
            timer_Ayeh.Enabled = true;
            audioSoreh.Play();
            timer_Ayeh.Start();
        }

        private void timer_Ayeh_Tick(object sender, EventArgs e)
        {
            audioSoreh.Stop();
            timer_Ayeh.Stop();
            timer_Ayeh.Enabled = false;

            if (AyehCounter == TotlalNumAyeh - 1)
            {
                audioSoreh.CurrentPosition = voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 1];
                timer_Ayeh.Interval = Convert.ToInt32((voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 2] - voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 1]) * 1000);
                RepeatCounter = TotalRepeat;
                picture_Ayeh.Image = Image.FromFile(@"Image\" + (sorehNumber+1).ToString() + @"\" + (TotlalNumAyeh - AyehCounter + 1).ToString() + ".png");
                AyehCounter--;
                RepeatCounter--;
                txtCounter.Text = RepeatCounter.ToString();
                audioSoreh.Play();
                timer_Ayeh.Enabled = true;
                timer_Ayeh.Start();
            }
            else if (RepeatCounter != 0)
            {
                audioSoreh.CurrentPosition = voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter];
                RepeatCounter--;
                txtCounter.Text = RepeatCounter.ToString();
                audioSoreh.Play();
                timer_Ayeh.Enabled = true;
                timer_Ayeh.Start();
            }
            else if (RepeatCounter == 0 && AyehCounter != 0)
            {
                audioSoreh.CurrentPosition = voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 1];
                timer_Ayeh.Interval = Convert.ToInt32((voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 2] - voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter + 1]) * 1000);
                RepeatCounter = TotalRepeat;
                picture_Ayeh.Image = Image.FromFile(@"Image\" + (sorehNumber + 1).ToString() + @"\" + (TotlalNumAyeh - AyehCounter + 1).ToString() + ".png");
                AyehCounter--;
                RepeatCounter--;
                txtCounter.Text = RepeatCounter.ToString();
                audioSoreh.Play();
                timer_Ayeh.Enabled = true;
                timer_Ayeh.Start();
            }
            else if (RepeatCounter == 0 && AyehCounter == 0)
            {
                BtnPlay.BackgroundImage = global::Saba.Properties.Resources.Play;
                PlayState = false;
                timer_Ayeh.Stop();
                timer_Ayeh.Enabled = false;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            audioSoreh.Stop();
            timer_Ayeh.Stop();
            timer_Ayeh.Enabled = false;
            picture_Ayeh.Image = Image.FromFile(@"Image\" + (sorehNumber + 1).ToString() + @"\1.png");
            BtnPlay.BackgroundImage = global::Saba.Properties.Resources.Play;
            PlayState = false;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (PlayState == true)
            {
                if (paused == true)
                {
                    paused = false;
                    BtnPlay.BackgroundImage = global::Saba.Properties.Resources.Pause;
                    audioSoreh.CurrentPosition = voiceArray[sorehNumber][TotlalNumAyeh - AyehCounter];
                    timer_Ayeh.Enabled = true;
                    timer_Ayeh.Start();
                    audioSoreh.Play();
                }
                else if (paused == false)
                {
                    paused = true;
                    BtnPlay.BackgroundImage = global::Saba.Properties.Resources.Play;

                    audioSoreh.Stop();
                    timer_Ayeh.Stop();
                    timer_Ayeh.Enabled = false;
                    
                }
            }
        }

        private void BtnRepeat_Click(object sender, EventArgs e)
        {
            RepeatCounter++;
            txtCounter.Text = RepeatCounter.ToString();
        }



        

    }
}
