 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirPortRomanOOP
{   
    public enum Sex
    {
        Male,
        Female
    }
    public enum TicketClass
    {
        Business,
        Economy
    }
    public enum TicketCategory
    {
        CategoryA,
        CategoryB,
        CategoryC
    }
    public enum KindOfFlight
    {
        Arrival,
        Departure
    }
    public enum FlightStatus
    {
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Canceled,
        ExpectedAt,
        Delayed
    }

    class Program
    {       
        static Airline[] airlineArray;
        static Airline chosenLine;
        static string readAirline;
        static int incrementAirlinearray;
        public delegate void PrintCurrentLine(string s);
        public static event PrintCurrentLine SomeEvent;   
            
        static Func<string, Airline> lambdaair = airlname =>
        {
            for (int i = 0; i < airlineArray.Length; i++)
            {
                if (airlineArray[i]?.AirlineName != null)
                    if (airlineArray[i].AirlineName == airlname)
                    {
                        if (SomeEvent!=null)
                        SomeEvent(airlname);
                        return airlineArray[i];
                    }
            }
            return null;
        };

        static void Main(string[] args)
        {
            Console.Clear();
            Flight flighttoadd;
            Flight flighttosearch;
            Additionalservice.PassFlight? passengertosearch;           
            string LogFile = "log.txt";
            string logmessage = "The program starts at :" + DateTime.Now;
            using (StreamWriter writer = new StreamWriter(LogFile, true, Encoding.UTF8))
            {
                writer.Write(logmessage);
            }
            PrintCurrentLine pc = new PrintCurrentLine(Print1);            
            SomeEvent += new PrintCurrentLine(pc);                 
            incrementAirlinearray = 4;
            airlineArray = new Airline[10];
            airlineArray[0] = new Airline("AirFrance", "A45678", true, new DateTime(2028, 3, 15));
            flighttoadd = new Flight(new DateTime(2016, 09, 24), 183, "Paris", "8", KindOfFlight.Arrival,
            FlightStatus.CheckIn, new List<Ticket>(),  false);            
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1200.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1050.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 900.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 850.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 700.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 550.00m));
            flighttoadd.Customers = new Passenger [40];
            flighttoadd.Customers[0] = new Passenger("Oleg", "Vasin", "russian", new DateTime(1970, 8, 18), "MF946941", 653656565, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[1] = new Passenger("Anna", "Mohnach", "ukrainian", new DateTime(1988, 9, 11), "MK172693", 568345671, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Salam", "Abdelkadir", "arab", new DateTime(1987, 11, 23), "YE689856", 183873891, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[3] = new Passenger("Sirik", "Sergei", "jew", new DateTime(1975, 8, 18), "MP894512", 825433489, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));           
            airlineArray[0].ArrivalList = new List<Flight>();
            airlineArray[0].DepartureFlightlist = new List<Flight>();
            airlineArray[0].AddToArray(KindOfFlight.Arrival, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 09, 07), 211, "London", "21", KindOfFlight.Departure,
            FlightStatus.CheckIn, new List<Ticket>(), false);            
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1240.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1050.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 950.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 820.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 600.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 350.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Pablo", "Alonso", "spain", new DateTime(), "uT782768", 451798061, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory== TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[1] = new Passenger("Roman", "Zelensky", "ukrainian", new DateTime(), "MK885561", 917623019, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Oleg", "Shliahtin", "ukrainian", new DateTime(), "MK096714567", 861245013, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[3] = new Passenger("Bubu", "Camara", "african", new DateTime(), "ZX735612", 984503781, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            airlineArray[0].AddToArray(KindOfFlight.Departure, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 10, 01), 132, "Nashville", "14", KindOfFlight.Departure,
            FlightStatus.CheckIn, new List<Ticket>(), false);            
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1880.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1500.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 1350.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 900.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 700.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 550.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Karina", "Shilova", "ukrainian", new DateTime(), "MK156789", 614581904, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[1] = new Passenger("Yuriy", "Pavlenko", "ukrainian", new DateTime(), "MK451245", 498123087, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Us", "Pavel", "ukrainian", new DateTime(), "MK290190", 124518901, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[3] = new Passenger("Us", "Natalia", "ukrainian", new DateTime(), "MK497712", 498123087, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            airlineArray[0].AddToArray(KindOfFlight.Departure, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 11, 26), 120, "Montreal", "7", KindOfFlight.Arrival,
            FlightStatus.Delayed, new List<Ticket>(), false);           
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1740.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1500.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 1200.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 850.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 700.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 400.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Mario", "Balotelli", "italian", new DateTime(), "CY561823", 501756891, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[1] = new Passenger("Fedor", "Zinchenko", "belorussian", new DateTime(), "MK667712", 981234561, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Yuriy", "Scherbak", "greek", new DateTime(), "MK615478", 990145679, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Economy))));
            airlineArray[0].AddToArray(KindOfFlight.Arrival, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 10, 01), 177, "Sydney", "7", KindOfFlight.Departure, FlightStatus.Delayed, new List<Ticket>(), false);           
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 2450.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 2200.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 2000.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 1650.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 1300.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 850.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Vitaliy", "Bolshak", "portugal", new DateTime(), "FF567890", 322554354, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[1] = new Passenger("Ekaterina", "Golshtein", "german", new DateTime(), "MK780544", 836256813, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            airlineArray[0].AddToArray(KindOfFlight.Departure, flighttoadd);
            airlineArray[1] = new Airline("Luftganza", "B45678", true, new DateTime(2024, 7, 25));
            airlineArray[2] = new Airline("Aerosweet", "B47326", true, new DateTime(2020, 11, 1));
            airlineArray[3] = new Airline("FlyEmirates", "B67890", true, new DateTime(2038, 4, 9));
            airlineArray[4] = new Airline("RoyalLines", "Y45678", true, new DateTime(2028, 6, 8));
            //choose a current airline       
            CheckAirline();           
            Console.ReadLine();            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.CHOOSE A CURRENT AIRLINE/ADD A NEW ONE");
                Console.WriteLine("2.EDIT A CURRENT AIRLINE");
                Console.WriteLine("3.DELETE A CURRENT AIRLINE ");
                Console.WriteLine("4.ADD A FLIGHT TO A CURRENT AIRLINE");
                Console.WriteLine("5.EDIT A FLIGHT IN A CURRENT AIRLINE");
                Console.WriteLine("6.DELETE A FLIGHT IN A CURRENT AIRLINE");
                Console.WriteLine("7.PRINT ALL FLIGHTS");
                Console.WriteLine("8.PRINT ALL FLIGHTS OF THE CURRENT AIRLINE");
                Console.WriteLine("9.PRINT ALL PASSENGERS OF SOME FLIGHT");
                Console.WriteLine("10.PRINT ALL PASSENGERS");
                Console.WriteLine("11.ADD A PASSENGER");
                Console.WriteLine("12.EDIT A PASSENGER");
                Console.WriteLine("13.DELETE A PASSENGER");
                Console.WriteLine("14.SEARCH  OF A PASSENGER");                
                Console.WriteLine("15.SEARCH BY MINIMUM PRICE");                
                Console.WriteLine("16.PRICELIST");
                Console.WriteLine("17.SORT BY DATE");
                Console.WriteLine("18.EXIT A PROJECT");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            CheckAirline();
                            break;
                        }
                    case 2:
                        {
                            Additionalservice.EditAirline(chosenLine);
                            break;
                        }
                    case 3:
                        {
                            Additionalservice.DeleteAirline(chosenLine);
                            break;
                        }
                    case 4:
                        {
                            chosenLine?.AddItem();
                            break;
                        }
                    case 5:
                        {
                            flighttosearch = chosenLine.SearchFlight();
                            if (flighttosearch != null)                            
                                flighttosearch = chosenLine.EditItem(flighttosearch);
                            break;
                        }
                    case 6:
                        {
                            flighttosearch = chosenLine.SearchFlight();
                            if (flighttosearch != null)
                                chosenLine.DeleteItem(flighttosearch);
                            break;
                        }
                    case 7:
                        {                            
                            for (int i = 0; i < airlineArray.Length; i++)
                            {
                                airlineArray[i]?.PrintAllFlights(airlineArray[i]?.ArrivalList);
                                airlineArray[i]?.PrintAllFlights(airlineArray[i]?.DepartureFlightlist);
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 8:
                        {
                            chosenLine?.PrintAllFlights(chosenLine?.ArrivalList);
                            chosenLine?.PrintAllFlights(chosenLine?.DepartureFlightlist);
                            Console.ReadLine();
                            break;
                        }
                    case 9:
                        {
                            flighttosearch = chosenLine.SearchFlight();
                            for (int i = 0; i < flighttosearch?.Customers?.Length; i++)
                            {
                                Console.WriteLine(flighttosearch?.Customers[i]?.ToString());
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 10:
                        {
                            //Airline
                            for (int i = 0; i < airlineArray.Length; i++)
                            {
                                //Flights arrive
                                if (airlineArray[i]?.ArrivalList!=null)
                                {
                                    foreach (var item in airlineArray[i]?.ArrivalList)
                                    {
                                        //Customers
                                        for (int j = 0; j < item.Customers.Length; j++)
                                        {
                                            Console.WriteLine(item.Customers[j]?.ToString());
                                        }
                                    }

                                }
                                //Flights departure
                                if (airlineArray[i] ?.DepartureFlightlist!=null)
                                {
                                    foreach (var item in airlineArray[i]?.DepartureFlightlist)
                                    {
                                        //Customers
                                        for (int j = 0; j < item.Customers.Length; j++)
                                        {
                                            Console.WriteLine(item.Customers[j]?.ToString());
                                        }
                                    }

                                }
                                
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 11:
                        {
                            /*
                             Add a passenger ONLY to a current Airline 
                             */
                            flighttosearch = chosenLine.SearchFlight();
                            flighttosearch?.AddItem();                            
                            break;
                        }
                    case 12:
                        {
                            passengertosearch = Additionalservice.SearchOfppassengers(airlineArray);
                            if (passengertosearch != null)
                            {
                                Additionalservice.PassFlight tovonv = (Additionalservice.PassFlight)passengertosearch;
                                tovonv.passenger = tovonv.flight.EditItem(tovonv.passenger);
                            }
                            break;
                        }
                    case 13:
                        {
                            passengertosearch = Additionalservice.SearchOfppassengers(airlineArray);
                            if (passengertosearch != null)
                            {
                                Additionalservice.PassFlight tovonv = (Additionalservice.PassFlight)passengertosearch;
                                tovonv.flight.DeleteItem(tovonv.passenger);
                            }
                            break;
                        }
                    case 14:
                        {
                            Console.Clear();
                            passengertosearch = Additionalservice.SearchOfppassengers(airlineArray);
                            if (passengertosearch != null)
                            {
                                Additionalservice.PassFlight tovonv = (Additionalservice.PassFlight)passengertosearch;
                                Console.WriteLine("Found a passenger:{0}  {1}", tovonv.passenger.Firstname, tovonv.passenger.Lastname);
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 15:
                        {
                            //MINIMUM PRICE
                            Console.Clear();
                            Console.WriteLine("ENTER A MINIMUM PRICE TO COMPARE TO");
                            int minimumprice = int.Parse(Console.ReadLine());
                            for (int i = 0; i < airlineArray?.Length; i++)
                            {
                                if (airlineArray[i]?.ArrivalList == null)
                                    continue;
                                foreach (var item in airlineArray[i]?.ArrivalList)
                                {
                                    if (item is Flight)
                                    {
                                        foreach (var item1 in item.TicketList.FindAll(
                                                    (Ticket tc) =>
                                                    {
                                                        return tc.Price < minimumprice;
                                                    }))
                                        {
                                            Console.WriteLine("The number of flight:{0}, the price:{1}", item.Number, item1.Price);
                                        }



                                    }
                                }
                            }
                            Console.WriteLine("Press any key");
                            Console.ReadLine();
                            break;
                        }
                    case 16:
                        {
                            //PRICELIST
                            Console.Clear();
                            Console.WriteLine("PRICELIST OF THE CURRENT LINE OR TOTAL PRICE LIST(1-2)");
                            int  choicepricelist =int.Parse(Console.ReadLine());
                            switch (choicepricelist)
                            {
                                case 1:
                                {
                                        //chosenLine.ArrivalList
                                        //chosenLine.DepartureFlightlist
                                        PriceList(chosenLine);                                        
                                        break;
                                    }
                                default:
                                {
                                        for (int i = 0; i < airlineArray.Length; i++)
                                        {
                                            PriceList(airlineArray[i]);
                                        }                                   
                                        break;
                                }                                    
                            }
                            Console.WriteLine("Press any key");
                            Console.ReadLine();
                            break;
                        }
                    //Sort all passengers by date of birth
                    case 17:
                        {
                            for (int i = 0; i < airlineArray.Length; i++)
                            {
                                if (airlineArray[i]?.ArrivalList != null)
                                {
                                    foreach (Flight item in airlineArray[i]?.ArrivalList)
                                    {
                                        //Additionalservice.
                                        item.Customers = Additionalservice.Sortbyage(item?.Customers);
                                        Console.WriteLine("Ok!!");
                                    }
                                }

                                if (airlineArray[i]?.DepartureFlightlist != null)
                                {
                                    foreach (Flight item in airlineArray[i]?.DepartureFlightlist)
                                    {
                                        item.Customers = Additionalservice.Sortbyage(item?.Customers);
                                    }
                                }

                            }
                            break;
                        }

                    case 18:
                        {
                            logmessage = "The program ends at :" + DateTime.Now;
                            using (StreamWriter writer = new StreamWriter(LogFile, true, Encoding.UTF8))
                            {
                                writer.WriteLine(logmessage);
                                writer.WriteLine();
                            }
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("A wrong choice!!!Repeat");
                            break;
                        }
                }
            }
        }

        static Airline FindAnAirline(Func<string, Airline> smthtodo)
        {
            Console.WriteLine("Enter an Airline to work with:");
            readAirline = Console.ReadLine();
            Console.Clear();
            return smthtodo(readAirline);
        }


        static void Print1(string message)
        {
            Console.Clear();
            Console.WriteLine("Remember the current airline:{0}, press any key to continue!", message);
            Console.ReadLine();
        }

        static void PriceList(Airline chosenline)
        {
            if (chosenline==null)
            {
                return;
            }
            int maxlength = ((chosenLine.ArrivalList.Count > chosenLine.DepartureFlightlist.Count) ?
                                        chosenLine.ArrivalList.Count : chosenLine.DepartureFlightlist.Count);
            int controlpointarrive = 0;
            int controlpointdeparture = 0;
            if (chosenLine.ArrivalList.Count == maxlength)
            {
                controlpointarrive = maxlength;
                controlpointdeparture = chosenLine.DepartureFlightlist.Count;
            }
            else
            {
                controlpointarrive = chosenLine.ArrivalList.Count;
                controlpointdeparture = maxlength;

            }
            for (int i = 0; i < maxlength; i++)
            {
                if ((i < controlpointarrive) && (chosenLine.ArrivalList.ElementAt(i) != null))
                {                   
                    foreach (var item in chosenLine.ArrivalList.ElementAt(i)?.TicketList)
                    {
                        Console.WriteLine("Airline {0}, fligt № {1}, class {2}, category {3}, price {4}",
                        chosenLine.AirlineName, chosenLine.ArrivalList.ElementAt(i).Number,
                        item.ClassofTicket, item.TicketCategory, item.Price);
                    }
                }
                if ((i < controlpointdeparture) && (chosenLine.DepartureFlightlist.ElementAt(i) != null))
                {                  
                    foreach (var item in chosenLine.DepartureFlightlist.ElementAt(i)?.TicketList)
                    {
                        Console.WriteLine("Airline {0}, fligt № {1}, class {2}, category {3}, price {4}",
                        chosenLine.AirlineName, chosenLine.DepartureFlightlist.ElementAt(i).Number,
                        item.ClassofTicket, item.TicketCategory, item.Price);
                    }
                }
            }
        }

        static void CheckAirline()
        {
            string licensenumber;
            string airlinename;
            chosenLine = FindAnAirline(lambdaair);
            if (chosenLine == null)
            {
                Console.WriteLine("The airline you have selected doesn't exist." +
                "Do you wish to fill a new one (Y/N)");
                bool yn = ("Y" == Console.ReadLine() ? true : false);
                if (yn)
                {
                    Console.WriteLine("Enter a name of AirLine");
                    incrementAirlinearray++;
                    try
                    {
                        Console.WriteLine("Enter a license nimber of an airlinecompany");
                        licensenumber = Console.ReadLine();
                        airlinename = Console.ReadLine();
                        airlineArray[incrementAirlinearray] = new Airline(airlinename, licensenumber,
                        true, Additionalservice.TimeEnter());                        
                        while (true)
                        {
                            Console.WriteLine("To continue filling an information of a current airline press /Y/ or N to stop");
                            string choice = Console.ReadLine();
                            if (choice.ToUpper() != "Y")
                                break;
                            airlineArray[incrementAirlinearray].AddItem();
                        }
                        chosenLine = airlineArray[incrementAirlinearray];
                    }
                    catch (IndexOutOfRangeException excep)
                    {
                        Console.WriteLine(excep.Message);
                    }
                }
            }           
        }       
    }
}
