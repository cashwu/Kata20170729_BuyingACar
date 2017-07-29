using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170729_BuyingACar
{
    [TestClass]
    public class BuyingACarTests
    {
        [TestMethod]
        public void oldcar_12000_newcar_8000_save_1000_loss_1point5()
        {
            var buyCar = new BuyCar();
            var actual = buyCar.nbMonths(12000, 8000, 1000, 1.5);
            AssertBuyingCarLeftMoney(new[] {0, 4000}, actual);
        }

        private static void AssertBuyingCarLeftMoney(int[] expected, int[] actual)
        {
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    public class BuyCar
    {
        public int[] nbMonths(int startPriceOld, int startPriceNew, int savingperMonth, double percentLossByMonth)
        {
            var leftMoney = 0;
            if (startPriceOld > startPriceNew)
            {
                leftMoney = startPriceOld - startPriceNew;
            }

            return new[] { 0, leftMoney };
        }
    }
}
