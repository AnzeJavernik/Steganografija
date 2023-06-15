using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteganografijaWinForms
{
    class SteganografijaMetode
    {
        public enum Status
        {
            Skrito,
            NapolnjenoNule
        };

        public static Bitmap Skrivanje(string text, Bitmap bitmap)
        {
            try
            {
                // skrivanje podatkov v sliko
                Status Status = Status.Skrito;
                // trenutni element, ki ga moramo skriti
                int mestoElement = 0;
                // vrednost elementa pretvorjena v int
                int elementVrednost = 0;

                // mesto barvnega elementa, ki je v obdelavi
                long elementPixel = 0;

                // število ničel
                int nicle = 0;

                // elementi pixlov
                int R = 0;
                int G = 0;
                int B = 0;

                for (int i = 0; i < bitmap.Height; i++)
                {
                    // gledanje podatkov skozi vrsto
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        // mesto barvnega elementa, ki je v obdelavi
                        Color pixel = bitmap.GetPixel(j, i);

                        // čiščenje najmanj pomembnega pixla
                        R = pixel.R - pixel.R % 2;
                        G = pixel.G - pixel.G % 2;
                        B = pixel.B - pixel.B % 2;

                        // za vsak pixel gledanje čez elemente
                        for (int n = 0; n < 3; n++)
                        {
                            // preverjanje če je bilo procesiranih novih 8 bitov
                            if (elementPixel % 8 == 0)
                            {
                                // pregled, če je proces končan, ko je dodanih 8 ničel
                                if (Status == Status.NapolnjenoNule && nicle == 8)
                                {
                                    // nastavljanje zadnjega pixla
                                    if ((elementPixel - 1) % 3 < 2)
                                    {
                                        bitmap.SetPixel(j, i, Color.FromArgb(R, G, B));
                                    }
                                    return bitmap;
                                }

                                // pregled, če so vsi elementi skriti
                                if (mestoElement >= text.Length)
                                {
                                    // dodajanje ničel za konec texta
                                    Status = Status.NapolnjenoNule;
                                }
                                else
                                {
                                    // premik na naslednji element in ponavljanje procesa
                                    elementVrednost = text[mestoElement++];
                                }
                            }

                            // pregled za nastavljanje najmanj pomembnega bita
                            switch (elementPixel % 3)
                            {
                                case 0:
                                    {
                                        if (Status == Status.Skrito)
                                        {
                                            R += elementVrednost % 2;
                                            elementVrednost /= 2;
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        if (Status == Status.Skrito)
                                        {
                                            G += elementVrednost % 2;
                                            elementVrednost /= 2;
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        if (Status == Status.Skrito)
                                        {
                                            B += elementVrednost % 2;
                                            elementVrednost /= 2;
                                        }
                                        bitmap.SetPixel(j, i, Color.FromArgb(R, G, B));
                                    }
                                    break;
                            }

                            elementPixel++;

                            if (Status == Status.NapolnjenoNule)
                            {
                                // napolni vrednost ničle do 8
                                nicle++;
                            }
                        }
                    }
                }

                return bitmap;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Napaka pri vstavljanju.");
                return null;
            }
        }

        public static string Pridobivanje(Bitmap bitmap)
        {
            int barvaElementa = 0;
            int elementVrednost = 0;

            // text, ki bo prebran iz slike
            string pridobljenText = String.Empty;

            // pregled vrstic
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixel = bitmap.GetPixel(j, i);
                    // pregled elementov pixla
                    for (int n = 0; n < 3; n++)
                    {
                        switch (barvaElementa % 3)
                        {
                            case 0:
                                {
                                    elementVrednost = elementVrednost * 2 + pixel.R % 2;
                                } break;
                            case 1:
                                {
                                    elementVrednost = elementVrednost * 2 + pixel.G % 2;
                                } break;
                            case 2:
                                {
                                    elementVrednost = elementVrednost * 2 + pixel.B % 2;
                                } break;
                        }

                        barvaElementa++;

                        // če je 8 bitov dodanih, dodaj element v pridobljen text
                        if (barvaElementa % 8 == 0)
                        {
                            // obračanje, ker se proces začne vedno na desni
                            elementVrednost = Reverse(elementVrednost);

                            if (elementVrednost == 0)
                            {
                                return pridobljenText;
                            }

                            // pretvarjanje elementa iz int v char
                            char c = (char)elementVrednost;

                            // dodaj element v text
                            pridobljenText += c.ToString();
                        }
                    }
                }
            }

            return pridobljenText;
        }

        public static int Reverse(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }
    }
}
