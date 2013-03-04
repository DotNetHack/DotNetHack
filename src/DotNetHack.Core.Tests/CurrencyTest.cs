using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetHack.Core.Game.Objects;
using DotNetHack.TestLib;
namespace DotNetHack.Core.Tests.Objects
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        public void IsValueType()
        {
            Assert.IsTrue(typeof(Currency).IsValueType);
        }

        [TestMethod]
        public void ParameterlessConstructor()
        {
            var tmpCurrency = new Currency();

            tmpCurrency.Copper.Eq(0);
            tmpCurrency.Silver.Eq(0);
            tmpCurrency.Gold.Eq(0);
        }

        [TestMethod]
        public void ExplicitConstructor()
        {
            const int CopperAmt = 10;
            const int SilverAmt = 100;
            const int GoldAmt = 1000;

            var tmpCurrency = new Currency(CopperAmt);
            tmpCurrency.Amount.Eq(CopperAmt);
            tmpCurrency.Gold.Eq(0);
            tmpCurrency.Silver.Eq(0);

            tmpCurrency = new Currency(SilverAmt, Currency.MODIFIER_SILVER);
            tmpCurrency.Gold.Eq(1);
        }
    }
}
