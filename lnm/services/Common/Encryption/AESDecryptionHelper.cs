using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace services.Common.Encryption
{
    public static class AESDecryptionHelper
    {
        private static readonly string Key = "lnmsecretkey"; // 32-byte key only 11 characters for now , make it to 16 or 32
        private static readonly string IV = "1234567890123456"; // 16-byte IV

        public static string Decrypt(string encryptedText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            byte[] buffer = Convert.FromBase64String(encryptedText);

            using MemoryStream memoryStream = new(buffer);
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader streamReader = new(cryptoStream); // this reads the decrypted text from the cryptostream

            return streamReader.ReadToEnd();

            /*
             memory stream acts like a virtual file in memory helping in storing bytes in RAM
            Crypto Stream is where it applies encry and decry
            streamReader and streamWriter are used to read text data , converting bytes to string
             
             Stream Writer will write plain text which gets encrypted in cryptostream
             
            CreateEncryptor and Decryptor will be knowing how to encrypt or derypt data using aes algo with KEY AND IV
             
             
             */

            /*
                             using System;
                            using System.Security.Cryptography;
                            using System.Text;
                            using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

                            namespace EncryptionDecryption.Services
                            {
                                public static class InfoSec
                                {
                                    // preder to use a custom key
                                    public static string GenerateKey() {

                                        string base64Key = "";
                                        using (Aes aes = Aes.Create())
                                        {
                                            aes.KeySize = 256;
                                            aes.GenerateKey();
                                            base64Key = Convert.ToBase64String(aes.Key);
                
                                        }
                                        return base64Key;
                                    }

                                    //IVKey will be generated inside the method itself

                                    // out paramter is used to return an additional value form a method besides main return value
                                    /*
                                     takes input text and key for encryption and then thr IV used for encryption will be returned as well
                                    the IV is need so as to decrypt the message with that specific IV key along with the main KEY
                                    ex ------------
                                                string myText = "Hello Aditi!";
                                                string key = "1234567890123456";

                                                string encrypted = Encrypt(myText, key, out string ivUsed);

                                                Console.WriteLine($"Encrypted Text: {encrypted}");
                                                Console.WriteLine($"IV used: {ivUsed}");

         
                            public static string Encrypt(string plainText, string key, out string IVKey)
                            {
                                using (Aes aes = Aes.Create())
                                {
                                    aes.Padding = PaddingMode.Zeros;
                                    aes.Key = Convert.FromBase64String(key);
                                    aes.GenerateIV();
                                    IVKey = Convert.ToBase64String(aes.IV);
                                    ICryptoTransform encrptor = aes.CreateEncryptor();
                                    byte[] encryptedData;
                                    ICryptoTransform encryptor = aes.CreateEncryptor();
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                                        {
                                            using (StreamWriter sw = new StreamWriter(cs))
                                            {
                                                sw.Write(plainText);
                                            }
                                            encryptedData = ms.ToArray();
                                        }
                                    }
                                    return Convert.ToBase64String(encryptedData);
                                }
                            }



                            public static string Decrypt(string cipherText, string key, string IVKey)
                            {
                                using (Aes aes = Aes.Create())
                                {
                                    aes.Padding = PaddingMode.Zeros;
                                    aes.Key = Convert.FromBase64String(key);
                                    aes.IV = Convert.FromBase64String(IVKey);

                                    IVKey = Convert.ToBase64String(aes.IV);
                                    ICryptoTransform decryptor = aes.CreateEncryptor();


                                    string PlainText = "";
                                    byte[] cipher = Convert.FromBase64String(cipherText);

                                    using (MemoryStream ms = new MemoryStream(cipher))
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                                        {
                                            using (StreamReader sr = new StreamReader(cs))
                                            {
                                                PlainText = sr.ReadToEnd();
                                            }
                                        }
                                    }
                                    return PlainText;
                                }
                            }

                                }
}
*/
        }
    }
}
