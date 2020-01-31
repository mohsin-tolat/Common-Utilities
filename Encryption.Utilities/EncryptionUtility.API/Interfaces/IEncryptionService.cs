namespace EncryptionUtility.API.Interfaces
{
    public interface IEncryptionService
    {
        string ToEncrypt(object plainText);

        string ToDecrypt(string encryptedText);
    }
}