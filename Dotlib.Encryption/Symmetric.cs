using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Dotlib.Encryption
{
    /// <summary>Biblioteca de criptografia e descriptofrafia simétrica de strings</summary>
    public static class Symmetric
    {
        /// <summary>Criptografa uma string</summary>
        ///
        /// <param name="plainText">Texto a ser criptografado</param>
        /// <param name="passPhrase">Chave de criptografia</param>
        public static string Encrypt(string plainText, string passPhrase)
        {
            var objInitVectorBytes = Encoding.UTF8.GetBytes("HR$2pIjHR$2pIj12");
            var objPlainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var objPassword = new PasswordDeriveBytes(passPhrase, null);
            var objKeyBytes = objPassword.GetBytes(256 / 8);

            var objSymmetricKey = new RijndaelManaged();
            objSymmetricKey.Mode = CipherMode.CBC;

            var objEncryptor = objSymmetricKey.CreateEncryptor(objKeyBytes, objInitVectorBytes);
            var objMemoryStream = new MemoryStream();
            var objCryptoStream = new CryptoStream(objMemoryStream, objEncryptor, CryptoStreamMode.Write);

            objCryptoStream.Write(objPlainTextBytes, 0, objPlainTextBytes.Length);
            objCryptoStream.FlushFinalBlock();
            var objEncrypted = objMemoryStream.ToArray();

            objMemoryStream.Close();
            objCryptoStream.Close();

            return Convert.ToBase64String(objEncrypted);
        }

        /// <summary>Descriptografa uma string</summary>
        ///
        /// <param name="encryptedText">Texto criptografado</param>
        /// <param name="passPhrase">Chave para descriptografia</param>
        public static string Decrypt(string encryptedText, string passPhrase)
        {
            var objInitVectorBytes = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");
            var objDeEncryptedText = Convert.FromBase64String(encryptedText);

            var objPassword = new PasswordDeriveBytes(passPhrase, null);
            var objKeyBytes = objPassword.GetBytes(256 / 8);

            var objSymmetricKey = new RijndaelManaged();
            objSymmetricKey.Mode = CipherMode.CBC;

            var objDecryptor = objSymmetricKey.CreateDecryptor(objKeyBytes, objInitVectorBytes);
            var objMemoryStream = new MemoryStream(objDeEncryptedText);
            var objCryptoStream = new CryptoStream(objMemoryStream, objDecryptor, CryptoStreamMode.Read);

            var objPlainTextBytes = new byte[objDeEncryptedText.Length];
            var objDecryptedByteCount = objCryptoStream.Read(objPlainTextBytes, 0, objPlainTextBytes.Length);

            objMemoryStream.Close();
            objCryptoStream.Close();

            return Encoding.UTF8.GetString(objPlainTextBytes, 0, objDecryptedByteCount);
        }
    }
}
