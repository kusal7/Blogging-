using System.Security.Cryptography;
using System.Text;

namespace KushalBlogWebApp
{
    /// <summary>
    /// The key generator.
    /// </summary>
    public static class KeyGenerator
    {
        private static readonly int _saltSize = 32;
        private static string decryptKEY = "1234567890000000";
        private static string decryptIV = "1234567890000000";
        /// <summary>
        /// Encrypts the by a e s.
        /// </summary>
        /// <param name="InputData">The input data.</param>
        /// <returns>A string.</returns>
        public static string EncryptByAES(string InputData)
        {
            if (string.IsNullOrWhiteSpace(InputData))
            {
                return InputData;
            }
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
#pragma warning disable
                rijndaelManaged.Mode = CipherMode.ECB;
#pragma warning restore
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.FeedbackSize = 128;

                rijndaelManaged.IV = Encoding.UTF8.GetBytes(decryptIV); // CRB mode uses an empty IV
                rijndaelManaged.Key = Encoding.UTF8.GetBytes(decryptKEY);

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(InputData);
                        }
                        byte[] bytes = msEncrypt.ToArray();
                        return Convert.ToBase64String(bytes);
                    }
                }
            }
        }
        /// <summary>
        /// Decrypts the by a e s.
        /// </summary>
        /// <param name="InputData">The input data.</param>
        /// <returns>A string.</returns>
        public static string DecryptByAES(string InputData)
        {
            if (string.IsNullOrWhiteSpace(InputData))
            {
                return InputData;
            }
            var CipherText = Convert.FromBase64String(InputData);
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
#pragma warning disable
                rijndaelManaged.Mode = CipherMode.ECB;
#pragma warning restore
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.FeedbackSize = 128;

                rijndaelManaged.Key = Encoding.UTF8.GetBytes(decryptKEY);
                rijndaelManaged.IV = Encoding.UTF8.GetBytes(decryptIV);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(CipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
