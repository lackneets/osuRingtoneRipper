using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;


namespace osuRingtoneRipper
{


    public partial class Form1 : Form
    {
     

        private bool closing = false;
        private Thread playerThread;
        private string playerSong = "F:/Dropbox/Friends/天富❤駿麒❤花爺/supercell feat. HATSUNE MIKU/08 初めての恋が終わる時.mp3";
        private int playerPreviewTime;

        string osuSongsDir = "-1";

        DataTable songlistDataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
            btn_saveRingtone.Enabled = false;
             
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            locateOsuPath(); 
        }

        private void locateOsuPath(){
            string[] candidateDisk = { "C:/", "D:/", "E:/", "F:/", "G:/", "H:/" };
            string[] candidatePath = { "Program Files (x86)/osu!", "Program Files/osu!", "osu!" };
            
            foreach(string disk in candidateDisk){
                foreach (string path in candidatePath) {
                    string songpath = disk + path + "/Songs/";
                    if (Directory.Exists(songpath) || osuSongsDir != "-1"){ 
                        osuSongsDir = songpath;
                        break;
                    }
                }
                if (osuSongsDir != "-1") break;
            }

            if (osuSongsDir == "-1") {
                MessageBox.Show("找不到您的 osu! 請手動選擇 osu! 安裝的目錄！");
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    osuSongsDir = fbd.SelectedPath + "/Songs/";
                }
            }

            if (!Directory.Exists(osuSongsDir)) {
                MessageBox.Show("無法讀取 osu! 歌曲");
                System.Environment.Exit(0);
            }

            try
            {

                string[] songsDirs = Directory.GetDirectories(osuSongsDir);


                songlistDataTable.Columns.Add(new DataColumn("Display", typeof(string)));
                songlistDataTable.Columns.Add(new DataColumn("Song", typeof(string)));

                foreach (string songPath in songsDirs)
                {
                    string song = songPath.Replace(osuSongsDir, "");

                    DataRow row = songlistDataTable.NewRow();
                    row[0] = Regex.Replace(song, "^\\d+\\s*", "");
                    row[1] = song;
                    songlistDataTable.Rows.Add(row);
                }

                songsList.DataSource = songlistDataTable;
                songsList.DisplayMember = "Display";
                songsList.ValueMember = "Song";

                songlistDataTable.DefaultView.Sort = "Display asc";

                selectRandom();
            }
            catch (Exception) {
                MessageBox.Show("無法讀取 osu! 歌曲");
                System.Environment.Exit(0);
            }
        }

        void selectRandom() {
            Random rnd = new Random();
            songsList.SelectedItem = songsList.Items[rnd.Next(0, songsList.Items.Count - 1)];
        }

        void trimMp3(string input, string output, int startOffset, int endOffset){

            using (Mp3FileReader reader = new Mp3FileReader(input)){
                System.IO.FileStream _fs = new System.IO.FileStream(output, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                Mp3Frame mp3Frame;
                do
                {
                    mp3Frame = reader.ReadNextFrame();
                    if (mp3Frame == null) return;
                    if ((int)reader.CurrentTime.TotalSeconds < startOffset) continue;
                    if ((int)reader.CurrentTime.TotalSeconds >= endOffset) break;

                    _fs.Write(mp3Frame.RawData, 0, mp3Frame.RawData.Length);

                } while (mp3Frame != null);
                _fs.Close();
            }
        }



        public void loopMp3()
        {
            try
            {
                using (var ms = File.OpenRead(playerSong))
                using (var rdr = new Mp3FileReader(ms))
                using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
                using (var baStream = new BlockAlignReductionStream(wavStream))
                using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    //rdr.Skip();
                    wavStream.Skip(playerPreviewTime);
                    waveOut.Init(baStream);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing && !closing)
                    {
                        Thread.Sleep(10);

                    }
                }
            }
            catch (Exception) { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            playerThread.Abort();
        }

        private void songSelected(){
            string selected = (songsList.SelectedItem != null) ? songsList.SelectedValue.ToString() : "";
            string songPath = osuSongsDir + selected; if (!Directory.Exists(songPath)) return;
            string[] files = Directory.GetFiles(songPath);


            string audioFilename = "-1";
            string imageFilename = "";
            int previewTime = 0;


            foreach (string file in files)
            {
                if (Regex.IsMatch(file, "osu$"))
                {
                    StreamReader osu = new StreamReader(file);
                    string line;
                    do
                    {
                        line = osu.ReadLine(); if (line == null) break;
                        if (Regex.IsMatch(line, "^AudioFilename:")) audioFilename = Regex.Replace(line, "^AudioFilename:\\s*", "");
                        if (Regex.IsMatch(line, "^PreviewTime:")) previewTime = Int32.Parse(Regex.Replace(line, "^PreviewTime:\\s*", ""));
                        if (Regex.IsMatch(line, "^0,0,")) imageFilename = Regex.Replace(line, "^0,0,\\s*\"(.+)\"$", "$1");

                    } while (line != null);
                    break;
                }
            }
            try
            {
                Image img = new Bitmap(songPath + "/" + imageFilename);
                songImage.Image = img;
            }
            catch (Exception) { songImage.Image = null; }

            btn_saveRingtone.Enabled = (audioFilename != "-1");

            playerPreviewTime = (int)Math.Floor((double)previewTime / 1000);
            string newSong = songPath + "/" + audioFilename;

            if (newSong == playerSong) return;

            playerSong = newSong;

            if (playerThread != null && playerThread.IsAlive) playerThread.Abort();
            playerThread = new Thread(this.loopMp3);
            playerThread.Start();
        }


        private void songsList_SelectedValueChanged(object sender, EventArgs e)
        {
            songSelected();
        }

        private void btn_saveRingtone_Click(object sender, EventArgs e)
        {
            saveAsRingtone();
        }


        private void songsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            saveAsRingtone();
        }

        
        private void saveAsRingtone(){
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = songsList.SelectedValue.ToString();
                saveFileDialog1.DefaultExt = ".mp3";
                saveFileDialog1.Filter = "MP3 files (*.mp3)|*.mp3";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    trimMp3(playerSong, saveFileDialog1.FileName, playerPreviewTime, playerPreviewTime+60);
                }
            }
            catch (Exception) { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //songsList.DataSour
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectRandom();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.plurk.com/Lackneets");
        }


    }
}
