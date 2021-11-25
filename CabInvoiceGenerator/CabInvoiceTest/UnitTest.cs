using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;

namespace CabInvoiceTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            double expected = 25;
            double distance = 2.0;
            int time = 5;

            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);

            double fare = invoice.calculateFare(distance, time);

            Assert.AreEqual(expected, fare);
        }
        [TestMethod]
        public void TestMethod2()
        {
            double expected = 80;
            double distance = 4.0;
            int time = 10;

            InvoiceGenerator invoice1 = new InvoiceGenerator(RideType.PREMIUM);

            double fare1 = invoice1.calculateFare(distance, time);

            Assert.AreEqual(expected, fare1);
        }
        //UC2-given multiple rides should return invoice summary
        [TestMethod]
        public void GivenMultipleRidesReturnTotalFare()
        {


            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary expected = new InvoiceSummary(rides.Length, 60);

            InvoiceSummary actual = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(actual, expected);
        }
    }
}