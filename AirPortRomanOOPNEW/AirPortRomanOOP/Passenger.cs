using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Passenger:  IComparable<Passenger>
    {
        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }

        }

        private  string lastname;
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }

        }

        private string nationality;
        public string Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
            }

        }

        private DateTime birthday;
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                 birthday = value;
            }
        }

        private string passport;
        public string Passport
        {
            get
            {
                return passport;
            }
            set
            {
                passport = value;
            }
        }

        private int identicalcode;
        public int Identicalcode
        {
            get
            {
                return identicalcode;
            }
            set
            {
                identicalcode = value;
            }
        }

        private Sex sex;
        public Sex Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }

        }

        private Ticket tct;
        public Ticket Tct
        {
            get
            {
                return tct;
            }
            set
            {
                tct = value;            }

        }

        public Passenger(string firstname, string lastname, string nationality,
        DateTime birthday, string passport, int identicalcode, Sex sex, Ticket tct)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.nationality = nationality;
            this.birthday = birthday;
            this.passport = passport;
            this.identicalcode = identicalcode;
            this.sex = sex;
            this.tct = tct;

        }
                
        public override string ToString()
        {
            return string.Format("The first name af a passenger {0}, the last name:{1}, the nationality  {2}, the birthday: {3}" +
            "the passport: {4}, the identicalcode: {5}, the sex:{6}",
            this.firstname, this.lastname, this.nationality, this.birthday, this.passport, this.identicalcode, this.sex);
        }

        public int CompareTo(Passenger customer)
        {
            if (customer != null)
                return this.Identicalcode.CompareTo(customer.Identicalcode);
            else
                throw new NullReferenceException("Imposibble to compare because of null!!!");
        }
    }
}
