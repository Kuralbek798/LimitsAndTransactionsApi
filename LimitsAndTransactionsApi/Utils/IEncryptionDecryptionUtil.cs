namespace LimitsAndTransactionsApi.Utils
{
    public interface IEncryptionDecryptionUtil
    {
        string GetDecryptedApiKey(string guidKey, string encrypteeApiKey);
        byte[] GenerateKeyFromguidString(string guidString);
        string Encrypt(string data, byte[] key);
        string Decrypt(string encryptedData, byte[] key);
    }
}
