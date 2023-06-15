using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SteganografijaWinForms
{
    public class Enkripcija
    {
        private static byte[] salt = Encoding.ASCII.GetBytes("bigdha7731y9bqur61hvarsfs192");

        public static string EnkripcijaTexta(string besedilo, string geslo)
        {
            if (string.IsNullOrEmpty(besedilo))
                throw new ArgumentNullException("besedilo");
            if (string.IsNullOrEmpty(geslo))
                throw new ArgumentNullException("geslo");

            string text = null;                       // enkriptiran string za return
            RijndaelManaged aes = null;              // RijndaelManaged objekt za enkriptiranje

            try
            {
                //generiranje enkripcije iz podanega salta in gesla
                Rfc2898DeriveBytes kljuc = new Rfc2898DeriveBytes(geslo, salt);

                aes = new RijndaelManaged();
                aes.Key = kljuc.GetBytes(aes.KeySize / 8);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(BitConverter.GetBytes(aes.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aes.IV, 0, aes.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(besedilo);
                        }
                    }
                    text = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                if (aes != null)
                    aes.Clear();
            }
            return text;
        }

        public static string DekripcijaTexta(string enkriptiranoBesedilo, string geslo)
        {
            if (string.IsNullOrEmpty(enkriptiranoBesedilo))
                throw new ArgumentNullException("enkriptiranoBesedilo");
            if (string.IsNullOrEmpty(geslo))
                throw new ArgumentNullException("geslo");

            RijndaelManaged aes = null;

            string dekriptiranoBesedilo = null;

            try
            {
                // generiranje ključa iz salta in gesla
                Rfc2898DeriveBytes kljuc = new Rfc2898DeriveBytes(geslo, salt);
                
                byte[] bytes = Convert.FromBase64String(enkriptiranoBesedilo);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    aes = new RijndaelManaged();
                    aes.Key = kljuc.GetBytes(aes.KeySize / 8);
                    aes.IV = PreberiSalt(msDecrypt);

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            dekriptiranoBesedilo = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                if (aes != null)
                    aes.Clear();
            }
            return dekriptiranoBesedilo;
        }

        private static byte[] PreberiSalt(Stream s)
        {
            byte[] velikost = new byte[sizeof(int)];

            if (s.Read(velikost, 0, velikost.Length) != velikost.Length)
            {
                throw new SystemException("Nepravilen vnos salta.");
            } 

            byte[] buffer = new byte[BitConverter.ToInt32(velikost, 0)];

            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Napaka pri branju");
            }
            return buffer;
        }
    }
}
