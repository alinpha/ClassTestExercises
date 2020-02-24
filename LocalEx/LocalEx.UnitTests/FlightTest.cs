using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocalEx.ClassLib;

namespace LocalEx.UnitTests
{
    [TestClass]
    public class FlightTest
    {
        [TestMethod]
        public void DepartureAirport_Positive()
        {
            Flight target = new Flight(123,"ABC","XYZ");
            Assert.AreEqual(target.DepartureAirport, "ABC");
        }

        [TestMethod]
        public void ArrivalAirport_Positive()
        {
            Flight target = new Flight(123, "ABC", "XYZ");
            Assert.AreEqual(target.ArrivalAirport, "XYZ");
        }

        [TestMethod]
        public void Arrival_Positive()
        {
            Flight target = new Flight(123, "ABC", "XYZ");
            DateTime expected = new DateTime(2019,3,29);
            target.Departure = expected;
            Assert.AreEqual(target.Arrival, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrivalAirport_Negative()
        {
            Flight target = new Flight(123, "abc", "XYZ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepartureAirport_Negative()
        {
            Flight target = new Flight(123, "ABC", "WXYZ");
        }


    }
}
