using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEx.ClassLib
{
    public class Student
    {
        #region Constants

        public const string DEFAULT_STATUS = "F";
        public const decimal DEFAULT_TUITION_BALANCE = 2600;
        public const bool DEFAULT_IS_TUITION_PAID = false;

        #endregion

        #region Properties

        public int CreditsErned { get; set; }

        public string Status { get; private set; } = DEFAULT_STATUS;

        public string StudentName { get; set; }

        public decimal TuitionBalance { get; private set; } = DEFAULT_TUITION_BALANCE;

        public bool IsTuitionPaid { get; private set; } = DEFAULT_IS_TUITION_PAID;


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

            TuitionBalance -= payment;

            if (TuitionBalance <= 0)
            {
                IsTuitionPaid = true;
                //TuitionBalance = 0;
            }

            return TuitionBalance;

        }

        public void Reinstate()
        {
            if (Status == "S")
            {
                Status = "F";
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
                Status = "S";
            }
            else
            {
                throw new ArgumentException("can suspend full time students only.");
            }

        }

        public void Terminate()
        {
            CreditsErned = 0;
            Status = "T";
        }

        #endregion
    }
}
