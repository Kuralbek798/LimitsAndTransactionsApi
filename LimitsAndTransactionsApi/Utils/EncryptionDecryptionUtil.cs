using System.Security.Cryptography;
using System.Text;
namespace LimitsAndTransactionsApi.Utils
{

    public class EncryptionDecryptionUtil : IEncryptionDecryptionUtil
    {
        public string GetDecryptedApiKey(string guidKey, string encrypteeApiKey)
        {
            try
            {
                var masterKey = GenerateKeyFromguidString(guidKey);
                return Decrypt(encrypteeApiKey, masterKey);
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw new Exception("An error occurred in method GetDecryptedApiKey: " + e.Message, e);
            }
        }

        public  byte[] GenerateKeyFromguidString(string guidString)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] key = sha.ComputeHash(Encoding.UTF8.GetBytes(guidString)); // Генерация хеша SHA-256 из guidString
                byte[] aesKey = new byte[16];
                Array.Copy(key, aesKey, 16); // Создание ключа AES длиной 128 бит
                return aesKey;
            }
        }

        public string Encrypt(string data, byte[] key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (var ms = new System.IO.MemoryStream())
                    {
                        ms.Write(aes.IV, 0, aes.IV.Length); // Сохраняем IV вместе с зашифрованными данными
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new System.IO.StreamWriter(cs))
                            {
                                sw.Write(data);
                            }
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public string Decrypt(string encryptedData, byte[] key)
        {
            byte[] fullCipher = Convert.FromBase64String(encryptedData);
            byte[] iv = new byte[16];
            Array.Copy(fullCipher, 0, iv, 0, iv.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new System.IO.MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new System.IO.StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}


