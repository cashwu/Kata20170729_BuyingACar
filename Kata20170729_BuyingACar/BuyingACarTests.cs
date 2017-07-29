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

        [TestMethod]
        public void oldcar_7000_newcar_8000_save_1000_loss_1point5()
        {
            var buyCar = new BuyCar();
            var actual = buyCar.nbMonths(7000, 8000, 1000, 1.5);
            AssertBuyingCarLeftMoney(new []{ 1, 15 }, actual);
        }

        [TestMethod]
        public void oldcar_6000_newcar_8000_save_1000_loss_1point5()
        {
            var buyCar = new BuyCar();
            var actual = buyCar.nbMonths(6000, 8000, 1000, 1.5);
            AssertBuyingCarLeftMoney(new[] { 2, 69 }, actual);
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
            if (startPriceOld > startPriceNew)
            {
                return new[] { 0, startPriceOld - startPriceNew };
            }

            int leftMoney;
            var leftMonth = 0;
            do
            {
                leftMonth++;
                percentLossByMonth = PercentLossByMonth(percentLossByMonth, leftMonth);
                startPriceOld = CarPriceEndMonth(startPriceOld, percentLossByMonth);
                startPriceNew = CarPriceEndMonth(startPriceNew, percentLossByMonth);
                leftMoney = LeftMoney(startPriceNew, startPriceOld, SaveMoney(savingperMonth, leftMonth));
            } while (leftMoney < 0);

            return new[] { leftMonth, leftMoney };
        }

        private static int SaveMoney(int savingperMonth, int leftMonth)
        {
            return savingperMonth * leftMonth;
        }

        private static double PercentLossByMonth(double percentLossByMonth, int leftMonth)
        {
            return leftMonth % 2 == 0 ? percentLossByMonth + 0.5 : percentLossByMonth;
        }

        private static int LeftMoney(int startPriceNew, int startPriceOld, int saveMoney)
        {
            return startPriceOld + saveMoney - startPriceNew;
        }

        private static int CarPriceEndMonth(int startPriceOld, double percentLossByMonth)
        {
            return (int)(startPriceOld * (100 - percentLossByMonth) / 100);
        }
    }
}
