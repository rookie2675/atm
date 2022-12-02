using Xunit.Sdk;
using Library.Models;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CreateAccountWithNegativeBalance()
        {
            _ = new Account() { Card = new() { Number = "654778214", Pin = "366548"}, Balance = -500};
        }
    }
}