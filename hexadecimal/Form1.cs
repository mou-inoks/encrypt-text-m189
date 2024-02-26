using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace hexadecimal
{
    public partial class Form1 : Form
    {
        public byte[] aesKey { get; set; } = new byte[32];
        public byte[] aesIV { get; set; } = new byte[16];
        public byte[] encryptedByte { get;set; }
        public byte[] encodedInput { get;set; }
        public Aes aesAlg { get;set; }

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
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        string CalculateSHA512Hash(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha512.ComputeHash(bytes);
                Buffer.BlockCopy(hash, 0, aesKey, 0, 32);
                Buffer.BlockCopy(hash, 0, aesIV, 0, 16);

                return Convert.ToBase64String(aesKey);
            }
        }

        private void generatehash_Click(object sender, EventArgs e)
        {
            encodedInput = Encoding.UTF8.GetBytes(key.Text);
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
            //aesAlg = Aes.Create();
            //encryptedByte = EncryptStringToBytes_Aes(textToChiffr.Text, aesAlg.Key, aesAlg.IV);
            encryptedByte = EncryptStringToBytes_Aes(textToChiffr.Text, aesKey, aesIV);
            textToChiffr.Text = Convert.ToBase64String(encryptedByte);
        }

        private void dechiffre_Click(object sender, EventArgs e)
        {
            //textToChiffr.Text = DecryptStringFromBytes_Aes(encryptedByte, aesAlg.Key, aesAlg.IV);
            textToChiffr.Text = DecryptStringFromBytes_Aes(encryptedByte, aesKey, aesIV);
        }
    }
}
