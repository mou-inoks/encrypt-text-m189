using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace hexadecimal
{
    public partial class Form1 : Form
    {
        public byte[] encryptedByte { get;set; }
        public byte[] aesKey { get;set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void key_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key)
        {
            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                byte[] iv = new byte[aesAlg.BlockSize / 8];
                Array.Copy(cipherText, iv, iv.Length);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream(cipherText, iv.Length, cipherText.Length - iv.Length))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.StreamReader srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        static byte[] GenerateAESKeyFromSHA512Hash(string hash)
        {
            int keySize = 256; // Clé AES de 256 bits
            int iterations = 10000; // Nombre d'itérations recommandées pour PBKDF2
            byte[] salt = Encoding.UTF8.GetBytes("Sel");

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(hash, salt, iterations))
            {
                return pbkdf2.GetBytes(keySize / 8);
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key)
        {
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            return encrypted;
        }


        static string CalculateSHA512Hash(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha512.ComputeHash(bytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

        private void generatehash_Click(object sender, EventArgs e)
        {
            hashbox.Text = CalculateSHA512Hash(key.Text);
        }

        private void hashbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textToChiffr_TextChanged(object sender, EventArgs e)
        {

        }

        private void chiffrer_Click(object sender, EventArgs e)
        {

            aesKey = GenerateAESKeyFromSHA512Hash(hashbox.Text);

            encryptedByte = EncryptStringToBytes_Aes(textToChiffr.Text, aesKey);

            textToChiffr.Text = BitConverter.ToString(encryptedByte).Replace("-", "");

        }

        private void dechiffre_Click(object sender, EventArgs e)
        {
            textToChiffr.Text = DecryptStringFromBytes_Aes(encryptedByte, aesKey);
        }
    }
}
