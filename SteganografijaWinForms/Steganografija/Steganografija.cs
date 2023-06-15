using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace SteganografijaWinForms
{
    public partial class Steganografija : Form
    {
        private Bitmap bitmap = null;
        private string text = string.Empty;

        public Steganografija()
        {
            InitializeComponent();
        }

        private void SkrijBesediloClick(object sender, EventArgs e)
        {
            bitmap = (Bitmap)slikaBox.Image;

            string text = podatkiText.Text;

            if (text.Equals(""))
            {
                MessageBox.Show("Besedilo ne more biti prazno.");

                return;
            }

            if (gesloCheckBox.Checked)
            {
                if (gesloText.Text.Length < 3)
                {
                    MessageBox.Show("Geslo mora imeti vsaj 4 znake");

                    return;
                }
                else
                {
                    text = Enkripcija.EnkripcijaTexta(text, gesloText.Text);
                }
            }

            bitmap = SteganografijaMetode.Skrivanje(text, bitmap);


            if (bitmap != null)
            {
                MessageBox.Show("Podatki skriti v sliko.");
            }

        }

        private void PridobiPodatkeClick(object sender, EventArgs e)
        {
            bitmap = (Bitmap)slikaBox.Image;

            string pridobljenText = SteganografijaMetode.Pridobivanje(bitmap);

            if (gesloCheckBox.Checked)
            {
                try
                {
                    pridobljenText = Enkripcija.DekripcijaTexta(pridobljenText, gesloText.Text);
                }
                catch
                {
                    MessageBox.Show("Napačno geslo.");

                    return;
                }
            }

            podatkiText.Text = pridobljenText;
        }

        private void NaloziSlikoClick(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Slikovne datoteke (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                slikaBox.Image = Image.FromFile(open_dialog.FileName);
            }
        }

        private void ShraniSlikoClick(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Png datoteka|*.png|Bitmap datoteka|*.bmp";

            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                switch (save_dialog.FilterIndex)
                {
                    case 0:
                        {
                            bitmap.Save(save_dialog.FileName, ImageFormat.Png);
                        }break;
                    case 1:
                        {
                            bitmap.Save(save_dialog.FileName, ImageFormat.Bmp);
                        } break;
                }
            }
        }
    }
}