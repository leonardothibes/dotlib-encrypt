using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotlib.Encryption.Tests
{
    [TestClass]
    public class SymmetricTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var plainText = "this is my plain text";
            var passPhrase = "this is my pass phrase";

            var encrypted = Symmetric.Encrypt(plainText, passPhrase);
            Assert.AreNotEqual(plainText, encrypted);
        }
    }
}
