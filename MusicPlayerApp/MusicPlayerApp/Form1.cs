using AxWMPLib;
using Guna.UI2.WinForms;
using WMPLib;
using static System.Net.WebRequestMethods;

namespace MusicPlayerApp
{
    public partial class Form1 : Form
    {
        private bool isDarkTheme = false;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        string s;
        string[] paths, files;

        public Form1()
        {
            InitializeComponent();
            ApplyLightTheme();

        }
        private void sesbtn_Click(object sender, EventArgs e)
        {

        }



        private void guna2Button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            progressBar1.Value = 0;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {


        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }
        }

        private void fýlebtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                label2.Text = listBox1.SelectedItem.ToString();
            }
            axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
            radyo = false;
            progressBar1.Enabled = true;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            label3.Text = trackBar1.Value.ToString();
        }

        private void voludme_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sesbarý_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
            guna2ComboBox1.Visible = false;
            listBox1.Visible = false;
            guna2Button10.Visible = false;
            foreach (var radyo in radyoIstasyonlari)
            {
                guna2ComboBox1.Items.Add(radyo.Key);
            }
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                if (!radyo)
                    timer1.Start();
                else
                    timer1.Stop();
            }
            else if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                progressBar1.Value = 0;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            guna2Button5.Visible = false;
            guna2Button8.Visible = false;
            guna2Button6.Visible = false;
            guna2Button9.Visible = false;
            guna2Button7.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            guna2PictureBox1.Visible = false;
            pictureBox2.Visible = false;
            trackBar1.Visible = false;
            progressBar1.Visible = false;
            guna2Button10.Visible = true;
            guna2ComboBox1.Visible = false;
            label6.Visible = false;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            guna2Button5.Visible = true;
            guna2Button8.Visible = true;
            guna2Button6.Visible = true;
            guna2Button9.Visible = true;
            guna2Button7.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            guna2PictureBox1.Visible = true;
            pictureBox2.Visible = true;
            trackBar1.Visible = true;
            progressBar1.Visible = true;
            guna2Button10.Visible = false;
            label6.Visible = false;
            guna2ComboBox1.Visible = false;
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (isDarkTheme)
            {
                ApplyLightTheme();
                guna2Button3.Text = "Koyu Tema";
                guna2Button3.BackColor = Color.FromArgb(42, 45, 52);
            }
            else
            {
                ApplyDarkTheme();
                guna2Button3.Text = "Açýk Tema";
                guna2Button3.BackColor = Color.White;
            }
            isDarkTheme = !isDarkTheme;
        }
        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;

        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            guna2Button5.Visible = false;
            guna2Button8.Visible = false;
            guna2Button6.Visible = false;
            guna2Button9.Visible = false;
            guna2Button7.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            guna2PictureBox1.Visible = false;
            pictureBox2.Visible = false;
            trackBar1.Visible = false;
            progressBar1.Visible = false;
            guna2Button10.Visible = true;
            label6.Visible = false;
        }
        Dictionary<string, string> radyoIstasyonlari = new Dictionary<string, string>()
        {
             { "Alem FM", "http://turkmedya.radyotvonline.com/turkmedya/alemfm.stream/playlist.m3u8" },
             { "Kral FM", "http://46.20.3.204:80" },
             { "Power Türk", "http://icast.powergroup.com.tr/PowerTurk/mpeg/128/home" },
             { "A SPOR RADYO", "https://trkvz-radyolar.ercdn.net/asporradyo/playlist.m3u8" },
             { "A HABER RADYO", "https://trkvz-radyolar.ercdn.net/ahaberradyo/playlist.m3u8" },
             { "A NEWS RADYO", "https://trkvz-radyolar.ercdn.net/anewsradyo/playlist.m3u8" },
             { "A PARA RADYO", "https://trkvz-radyolar.ercdn.net/apararadyo/playlist.m3u8\r\n" },
             { "TGRT FM", "https://b01c02nl.mediatriple.net/videoonlylive/mtsxxkzwwuqtglive/broadcast_5fead000e2128.smil/playlist.m3u8" },
             { "TRT FM", "https://trt.radyotvonline.net/trtfm" },
             { "Slow Türk", "https://r3.rocketcdn.com/slowturk/abr/playlist.m3u8" },
             { "Karadeniz Radyo", "http://radyo.yayin.com.tr:6134" },
             { "Fenomen", "http://fenomen.listenfenomen.com/fenomen/256/icecast.audio" },
             { "Fenomen Türk", "http://fenomen.listenfenomen.com/fenomenturk/256/icecast.audio" },
             { "Kral Pop", "http://radyo.yayin.com.tr:6134" },
             { "Ankara Havasý", "http://37.247.98.8/listen.pls?sid=30" },
             { "Metro FM", " http://provisioning.streamtheworld.com/pls/METRO_FMAAC.pls" },
             { "Damar Türk FM", "https://live.radyositesihazir.com:10997" },
             { "Lig Radyo-1", " https://ligradyo.radyotvonline.net/ligradyo" },
             { "Lig Radyo-2", "https://turkmedya.radyotvonline.com/turkmedya/ligradyo.stream/playlist.m3" },
             { "Lig Radyo-3", "http://46.20.3.246/stream/105/" },
             { "ARABESK DAMAR FM", "https://yayin.damarfm.com:8080/" }
        };

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = guna2ComboBox1.SelectedItem.ToString();

            axWindowsMediaPlayer1.URL = radyoIstasyonlari[label2.Text];
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            label4.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }
        }
        Boolean radyo = false;
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2ComboBox1.Visible = true;
            listBox1.Visible = false;
            guna2Button10.Visible = true;
            guna2PictureBox1.Visible = true;
            guna2Button5.Visible = true;
            guna2Button8.Visible = false;
            guna2Button6.Visible = true;
            guna2Button9.Visible = false;
            guna2Button7.Visible = true;
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            pictureBox2.Visible = true;
            trackBar1.Visible = true;
            label6.Visible = true;
            progressBar1.Visible = false;
            progressBar1.Enabled = false;
            radyo = true;
        }

        private void guna2ControlBox1_MouseEnter(object sender, EventArgs e)
        {
            guna2ControlBox1.FillColor = Color.Red;
        }

        private void guna2ControlBox1_MouseLeave(object sender, EventArgs e)
        {
            guna2ControlBox1.FillColor = Color.FromArgb(42, 45, 52);
        }

        private void guna2Panel1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void fýlebtn_MouseEnter(object sender, EventArgs e)
        {
            fýlebtn.FillColor = Color.FromArgb(42, 45, 52);
            guna2Panel1.FillColor = Color.ForestGreen;
            guna2Panel1.BackColor = Color.ForestGreen;
            guna2Panel1.BorderColor = Color.ForestGreen;
        }

        private void fýlebtn_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = Color.FromArgb(42, 45, 52);
            guna2Panel1.BackColor = Color.FromArgb(42, 45, 52);
            guna2Panel1.BorderColor = Color.FromArgb(42, 45, 52);
        }

        private void guna2Button2_MouseEnter(object sender, EventArgs e)
        {
            guna2Panel2.FillColor = Color.ForestGreen;
            guna2Panel2.BackColor = Color.ForestGreen;
            guna2Panel2.BorderColor = Color.ForestGreen;
        }

        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel2.FillColor = Color.FromArgb(42, 45, 52);
            guna2Panel2.BackColor = Color.FromArgb(42, 45, 52);
            guna2Panel2.BorderColor = Color.FromArgb(42, 45, 52);
        }

        private void guna2Button4_MouseEnter(object sender, EventArgs e)
        {
            guna2Panel3.FillColor = Color.ForestGreen;
            guna2Panel3.BackColor = Color.ForestGreen;
            guna2Panel3.BorderColor = Color.ForestGreen;
        }

        private void guna2Button4_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel3.FillColor = Color.FromArgb(42, 45, 52);
            guna2Panel3.BackColor = Color.FromArgb(42, 45, 52);
            guna2Panel3.BorderColor = Color.FromArgb(42, 45, 52);
        }

        private void guna2Button3_MouseEnter(object sender, EventArgs e)
        {
            guna2Panel4.FillColor = Color.ForestGreen;
            guna2Panel4.BackColor = Color.ForestGreen;
            guna2Panel4.BorderColor = Color.ForestGreen;
        }

        private void guna2Button3_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel4.FillColor = Color.FromArgb(42, 45, 52);
            guna2Panel4.BackColor = Color.FromArgb(42, 45, 52);
            guna2Panel4.BorderColor = Color.FromArgb(42, 45, 52);
        }

        private void guna2Button1_MouseEnter(object sender, EventArgs e)
        {
            guna2Panel5.FillColor = Color.ForestGreen;
            guna2Panel5.BackColor = Color.ForestGreen;
            guna2Panel5.BorderColor = Color.ForestGreen;
        }

        private void guna2Button1_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel5.FillColor = Color.FromArgb(42, 45, 52);
            guna2Panel5.BackColor = Color.FromArgb(42, 45, 52);
            guna2Panel5.BorderColor = Color.FromArgb(42, 45, 52);
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }

}
