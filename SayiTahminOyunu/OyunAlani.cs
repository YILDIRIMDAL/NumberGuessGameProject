using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahminOyunu
{
    public partial class OyunAlani : Form
    {
        public OyunAlani()
        {
            InitializeComponent();
        }

        int sure = 20;
        int tahmin;
        int hak = 10;
        int sayi;
        public void sayitahmin()
        {
            if (hak>0)
            {
                tahmin = Convert.ToInt16(txtTahmin.Text);
                lblHak.Text = hak.ToString();
                if (sayi<tahmin)
                {
                    lblipucu.Text = "Tahmini Küçült";
                    hak--;
                }
                else if (sayi>tahmin)
                {
                    lblipucu.Text = "Tahmini Büyüt";
                    hak--;
                }
                else
                {
                    MessageBox.Show("Tebrikler oyunu "+sure+" Saniye Kala Kazandınız");
                    timer1.Stop();
                    lblipucu.Text = "Oyunu Kazandınız";
                    txtAd.Enabled = true;
                    txtSoyad.Enabled = true;
                    btnSkor.Enabled = true;
                    timer1.Stop();
                }
            }
            else
            {
                MessageBox.Show("Hakkınızı Bitirdiniz!");
                hak--;
                timer1.Stop();
                txtTahmin.Enabled = false;
            }
        }


        private void OyunAlani_Load(object sender, EventArgs e)
        {
            lblipucu.Visible = false;
            Random rst = new Random();
            sayi = rst.Next(1,21);
            label6.Text = sayi.ToString();
            txtAd.Enabled = false;
            txtSoyad.Enabled = false;
            btnSkor.Enabled = false;
            lblHak.Text = hak.ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSure.Text = sure.ToString();
            sure--;
            if (sure==0)
            {
                txtTahmin.Enabled = false;
                timer1.Stop();
                MessageBox.Show("Süreniz Doldu");
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            sayitahmin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblipucu.Visible = true;
            btnipucu.Enabled = false;
        }

        private void btnSkor_Click(object sender, EventArgs e)
        {
            Form1.ad = txtAd.Text;
            Form1.soyad = txtSoyad.Text;
            Form1.kalanhak = hak;
            Form1.kalansure = sure;
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
