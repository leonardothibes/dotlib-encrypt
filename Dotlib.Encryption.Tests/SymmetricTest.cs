using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotlib.Encryption.Tests
{
    [TestClass]
    public class SymmetricTest
    {
        [TestMethod]
        public void Encrypt()
        {
            var plainText = "this is my plain text";
            var passPhrase = "this is my pass phrase";

            var encrypted = Symmetric.Encrypt(plainText, passPhrase);
            Assert.AreNotEqual(plainText, encrypted);
        }

        [TestMethod]
        public void DecryptSuccess()
        {
            var encryptedText = "VVBXjy/jCQsBjv8hlyl0lrhcRuyaWzorLcLp86Zkqx8=";
            var plainText = "this is my plain text";
            var passPhrase = "this is my pass phrase";

            var decrypted = Symmetric.Decrypt(encryptedText, passPhrase);
            Assert.AreEqual(plainText, decrypted);
        }
    }
}
