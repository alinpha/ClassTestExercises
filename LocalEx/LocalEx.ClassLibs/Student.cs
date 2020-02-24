using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEx.ClassLibs
{
    public class Student
    {
        #region Constants

        public const string DEFAULT_STATUS = "F";
        public const decimal DEFAULT_TUITION_BALANCE = 2600;
        public const bool DEFAULT_TUITION_PAID = false;

        #endregion

        #region Private Fields

        private int creditsEarned;
        private string status = DEFAULT_STATUS;
        private string studentName;
        private decimal tuitionBalance;
        private bool tuitionPaid;

        #endregion

        #region Properties

        public int CreditsErned { get; set; }

        public string Status { get { return status; } }

        public string StudentName { get; set; }

        public decimal TuitionBalance { get; } = DEFAULT_TUITION_BALANCE;

        public bool TuitionPaid { get; } = DEFAULT_TUITION_PAID;


        #endregion

        #region Constructor

        public Student(string studentName, int studentCredits)
        {
            StudentName = studentName;
            CreditsErned = studentCredits;

        }

        #endregion

        #region Methods

        public decimal MakeTuitionPayment(decimal payment)
        {
            if (payment <= 0)
            {
                throw new ArgumentException("payment cannot be less thank zero.");
            }

            tuitionBalance -= payment;

            if (TuitionBalance <= 0)
            {
                tuitionPaid = true;
                return 0;
            }

            return TuitionBalance;

        }

        public void Reinstate()
        {
            if (Status == "S")
            {
                status = "F";
            }
            else
            {
                throw new ArgumentException("can reinitiate suspended students only.");
            }
        }

        public void Suspend()
        {
            if (Status == "F")
            {
                CreditsErned /= 2;
                status = "S";
            }
            else
            {
                throw new ArgumentException("can suspend full time students only.");
            }

        }

        public void Terminate()
        {
            CreditsErned = 0;
            status = "T";
        }

        #endregion
    }
}
