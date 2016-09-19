using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Airline: Commercialorganisation, IAirpotr<Flight>, IComparable<Airline>
    {
        private string airlineName;
        public string AirlineName
        {
            get
            {
                return airlineName;
            }
            set
            {
                airlineName = value;
            }

         }

        private List<Flight> arrivalFlightlist;        
        public List<Flight> ArrivalList
        {
            get
            {
                return arrivalFlightlist;
            }
            set
            {

                arrivalFlightlist = new List<Flight>();
            }
        }

        private List<Flight> departureFlightlist;
        public List<Flight> DepartureFlightlist
        {
            get
            {
                return departureFlightlist;
            }
            set
            {
                departureFlightlist = new List<Flight>();
            }
        }

        public Airline(string airlineName, string LicenseNumber, bool IsLicenseValid, 
        DateTime DateExpired) : base(LicenseNumber, IsLicenseValid, DateExpired)
        {
            this.airlineName = airlineName;
            
        }

        public override void GetLicense()
        {
            this.DateExpired = Additionalservice.TimeEnter();
            this.IsLicenseValid = true;
        }

        public override void CancelLicense()
        {
            DateTime date1 = new DateTime();
            this.DateExpired = date1;
            this.IsLicenseValid = false;
        }

        public static FlightStatus ChoiceFlightstatus()
        {
            Console.WriteLine("Enter a status of a flight: 0 - CheckIn, 1 - GateClosed,2 - Arrived, 3 - DepartedAt, 4 - Unknown, 5 - Canceled, 6 - ExpectedAt, 7 - Delayed ");
            int choice = int.Parse(Console.ReadLine());
            if ((choice >= 0) && (choice <= 7))
                return (FlightStatus)choice;
            else
                return FlightStatus.Unknown;
        }
        
        public  void AddItem()
        {
            byte choiceFlight =0;
            Flight newflight;
            try
            {              
                Console.WriteLine("Enter a kind of flight:1 - arrival; 2 - departure");
                choiceFlight = byte.Parse(Console.ReadLine());
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);                
            }
            if ((choiceFlight<=0)|| (choiceFlight>=3))
            {
                Console.WriteLine("You entered a wrong choice!!!");                
            }
            DateTime timeofFlight = Additionalservice.TimeEnter();
            Console.WriteLine("Flight number:");
            int ourflightnumber = int.Parse(Console.ReadLine());
            Console.WriteLine("City:");
            string ourflightcity = Console.ReadLine();
            Console.WriteLine("Terminal:");
            string ourflightterminal = Console.ReadLine();            
            KindOfFlight ourflightkind = (KindOfFlight)choiceFlight;
            FlightStatus ourflightstatus = ChoiceFlightstatus();            
            newflight = new Flight(timeofFlight, ourflightnumber, ourflightcity, 
            ourflightterminal, ourflightkind, ourflightstatus, new List<Ticket>(), true);
            AddToArray(ourflightkind, newflight);            
        }

        public Flight EditItem( Flight editflight)
        {
            editflight.At = Additionalservice.TimeEnter();
            Console.WriteLine("Terminal:");
            editflight.Terminalandgate = Console.ReadLine();
            editflight.Status = ChoiceFlightstatus();
            return editflight;
        }

        public void DeleteItem(Flight deleteflight)
        {
            deleteflight.Status = FlightStatus.Canceled;
        }

        public void AddToArray(KindOfFlight ourflightkind, Flight newflight)
        {
            if(ourflightkind == KindOfFlight.Arrival)
            {
                this.arrivalFlightlist?.Add(newflight);

            }
            else
            {
                this.departureFlightlist?.Add(newflight);

            }           
        }

        public Flight SearchFlight()
        {
            Console.WriteLine("Enter a number of a flight");
            int flightnumber = int.Parse(Console.ReadLine());
            foreach (var item in arrivalFlightlist)
            {
                if (item.Number == flightnumber)
                    return item;

            }
            foreach (var item in departureFlightlist)
            {
                if (item.Number == flightnumber)
                    return item;

            }
            return null;
        }

        public void PrintAllFlights(List<Flight> FlightList)
        {
            
            if (!(FlightList==null))
            foreach (var item in FlightList)
            {
                Console.WriteLine(item.ToString());
                
            }
        }

        public int CompareTo(Airline airline)
        {
             if (airline != null)
                return this.airlineName.CompareTo(airline.AirlineName);
            else
                throw new NullReferenceException("Imposibble to compare because of null!!!");
        }

        public override string ToString()
        {
            return string.Format("The airline name: {0,15}, the license number:{1}, the license expiration date  {2}," +
            "the license is valid: ", this.airlineName, this.LicenseNumber, this.DateExpired, this.IsLicenseValid);
        }
    }
}
