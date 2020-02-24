using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocalEx.ClassLibs;

namespace LocalEx.UnitTests
{
    [TestClass]
    public class StudentTest
    {
        #region Properties Tests

        [TestMethod]
        public void Status_Default_Positive()
        {
            Student target = new Student("Name", 0);
            Assert.AreEqual(target.Status, Student.DEFAULT_STATUS);
        }

        [TestMethod]
        public void TuitionPaid_Default_Positive()
        {
            Student target = new Student("Name", 0);
            Assert.AreEqual(target.TuitionPaid, Student.DEFAULT_TUITION_PAID);
        }

        [TestMethod]
        public void TuitionBalance_Default_Positive()
        {
            Student target = new Student("Name", 0);
            Assert.AreEqual(target.TuitionBalance, Student.DEFAULT_TUITION_BALANCE);
        }

        #endregion

        #region Methods Tests

        [TestMethod]
        public void MakeTuitionPayment_Portion_Positive()
        {
            Student target = new Student("Name", 0);
            decimal expected = target.MakeTuitionPayment(1000);
            Assert.AreEqual(target.TuitionBalance, expected);
        }

        [TestMethod]
        public void MakeTuitionPayment_Entire_Positive()
        {
            Student target = new Student("Name", 0);
            decimal expected = target.MakeTuitionPayment(Student.DEFAULT_TUITION_BALANCE);
            Assert.AreEqual(target.TuitionBalance, expected);
        }

        [TestMethod]
        public void MakeTuitionPayment_EntireMore_Positive()
        {
            Student target = new Student("Name", 0);
            decimal expected = target.MakeTuitionPayment(Student.DEFAULT_TUITION_BALANCE + 1);
            Assert.AreEqual(target.TuitionBalance, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MakeTuitionPayment_Zero_Negative()
        {
            Student target = new Student("Name", 0);
            decimal expected = target.MakeTuitionPayment(0);
        }

        [TestMethod]
        public void Terminate_Positive()
        {
            Student target = new Student("Name", 0);
            target.Terminate();
            Assert.AreEqual(target.Status, "T");
            Assert.AreEqual(target.CreditsErned, 0);
        }

        [TestMethod]
        public void Suspend_Positive()
        {
            Student target = new Student("Name", 0);
            target.Suspend();
            Assert.AreEqual(target.Status, "S");
            Assert.AreEqual(target.CreditsErned, target.CreditsErned / 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Suspend_Negative()
        {
            Student target = new Student("Name", 0);
            target.Suspend();
            target.Suspend();
        }

        [TestMethod]
        public void Reinstate_Positive()
        {
            Student target = new Student("Name", 0);
            target.Suspend();
            target.Reinstate();
            Assert.AreEqual(target.Status, "F");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Reinstate_Negative()
        {
            Student target = new Student("Name", 0);
            target.Reinstate();
        }

        [TestMethod]
        public void Constructor_Positive()
        {
            Student target = new Student("Name", 0);
            Assert.AreEqual(target.StudentName, "Name");
            Assert.AreEqual(target.CreditsErned, 0);
        }

        #endregion
    }
}
