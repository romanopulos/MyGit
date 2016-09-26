using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Menu
    {
        static Airline chosenLine;
        static Flight flighttosearch;
        public int MyProperty { get; set; }
        public int Choice { get; private set; }  
             
        private int GetMenu()
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
            Console.WriteLine("15.SEARCH BY MINIMUM Price");
            Console.WriteLine("16.PriceLIST");
            Console.WriteLine("17.SORT BY DATE");
            Console.WriteLine("18.EXIT A PROJECT");
            int Choice = int.Parse(Console.ReadLine());
            Console.Clear();
            return Choice;
        }

        private Flight FlightSeek()
        {
            return chosenLine?.SearchFlight();
        }

        private void PrintAllFlights(Generator gn)
        {
            for (int i = 0; i < gn.AirlineArray.Length; i++)
            {
                gn.AirlineArray[i]?.PrintAllFlights(gn.AirlineArray[i]?.ArrivalFlightlist);
                gn.AirlineArray[i]?.PrintAllFlights(gn.AirlineArray[i]?.DepartureFlightlist);
            }
            Console.ReadLine();
        }

        private void PrintAllFlightsOfCurrentLine()
        {
            chosenLine?.PrintAllFlights(chosenLine?.ArrivalFlightlist);
            chosenLine?.PrintAllFlights(chosenLine?.DepartureFlightlist);
            Console.ReadLine();
        }

        private void PrintFlighpassengers()
        {
            flighttosearch = chosenLine.SearchFlight();
            for (int i = 0; i < flighttosearch?.Customers?.Length; i++)
            {
                Console.WriteLine(flighttosearch?.Customers[i]?.ToString());
            }
            Console.ReadLine();
        }

        private void PrintAllPassengers(Generator gn)
        {
            //Airline
            for (int i = 0; i < gn.AirlineArray.Length; i++)
            {
                //Flights arrive
                if (gn.AirlineArray[i]?.ArrivalFlightlist != null)
                {
                    foreach (var item in gn.AirlineArray[i]?.ArrivalFlightlist)
                    {
                        //Customers
                        for (int j = 0; j < item.Customers.Length; j++)
                        {
                            Console.WriteLine(item.Customers[j]?.ToString());
                        }
                    }
                }
                //Flights departure
                if (gn.AirlineArray[i]?.DepartureFlightlist != null)
                {
                    foreach (var item in gn.AirlineArray[i]?.DepartureFlightlist)
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
        }

        private void MinimumPrice(Generator gn)
        {
            //MINIMUM Price                           
            Console.WriteLine("ENTER A MINIMUM Price TO COMPARE TO");
            int minimumPrice = int.Parse(Console.ReadLine());
            for (int i = 0; i < gn.AirlineArray?.Length; i++)
            {
                if (gn.AirlineArray[i]?.ArrivalFlightlist == null)
                    continue;
                foreach (var item in gn.AirlineArray[i]?.ArrivalFlightlist)
                {
                    if (item is Flight)
                    {
                        foreach (var item1 in item.TicketList.FindAll(
                                    (Ticket tc) =>
                                    {
                                        return tc.Price < minimumPrice;
                                    }))
                        {
                            Console.WriteLine("The number of flight:{0}, the Price:{1}", item.Number, item1.Price);
                        }
                    }
                }
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        private void PriceList(Generator gn)
        {
            //PriceLIST
            Console.Clear();
            Console.WriteLine("PriceLIST OF THE CURRENT LINE OR TOTAL Price LIST(1-2)");
            int choicePricelist = int.Parse(Console.ReadLine());
            switch (choicePricelist)
            {
                case 1:
                    {
                        chosenLine.PriceList();
                        break;
                    }
                default:
                    {
                        for (int i = 0; i < gn.AirlineArray.Length; i++)
                        {
                            gn.AirlineArray[i].PriceList();
                        }
                        break;
                    }
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        private void Sorting(Generator gn)
        {
            for (int i = 0; i < gn.AirlineArray.Length; i++)
            {
                if (gn.AirlineArray[i]?.ArrivalFlightlist != null)
                {
                    foreach (Flight item in gn.AirlineArray[i]?.ArrivalFlightlist)
                    {
                        //InputUtil.
                        item.Customers = Passenger.Sortbyage(item?.Customers);
                        Console.WriteLine("Ok!!");
                    }
                }
                if (gn.AirlineArray[i]?.DepartureFlightlist != null)
                {
                    foreach (Flight item in gn.AirlineArray[i]?.DepartureFlightlist)
                    {
                        item.Customers = Passenger.Sortbyage(item?.Customers);
                    }
                }
            }
        }

        public void ApplicationAll(Generator gn)
        {             
            Loging loger = new Loging();
            loger.StartProgram();
            chosenLine = Airline.CheckAirline(gn.AirlineArray);
            while (true)
            {
                Choice = GetMenu();
                switch (Choice)
                {
                    case 1:
                        {
                            chosenLine = Airline.CheckAirline(gn.AirlineArray);
                            break;
                        }
                    case 2:
                        {
                            Airline.EditAirline(chosenLine);
                            break;
                        }
                    case 3:
                        {
                            Airline.DeleteAirline(chosenLine);
                            break;
                        }
                    case 4:
                        {
                            chosenLine?.AddItem();
                            break;
                        }
                    case 5:
                        {
                            flighttosearch = FlightSeek();
                            if (flighttosearch != null)
                                flighttosearch = chosenLine?.EditItem(flighttosearch);
                            break;
                        }
                    case 6:
                        {
                            flighttosearch = FlightSeek();
                            if (flighttosearch != null)
                                chosenLine?.DeleteItem(flighttosearch);
                            break;
                        }
                    case 7:
                        {
                            PrintAllFlights(gn);
                            break;
                        }
                    case 8:
                        {
                            PrintAllFlightsOfCurrentLine();
                            break;
                        }
                    case 9:
                        {
                            PrintFlighpassengers();
                            break;
                        }
                    case 10:
                        {
                            PrintAllPassengers(gn);
                            break;
                        }
                    case 11:
                        {                            
                            flighttosearch = FlightSeek();
                            flighttosearch?.AddItem();
                            break;
                        }
                    case 12:
                        {                                                      
                            dynamic infpassenger = Passenger.getAvalueOfstructure<int>(gn.AirlineArray);                            
                            if (infpassenger.flight != null)                            
                                infpassenger.flight.EditItem(infpassenger.passenger);                            
                            break;
                        }
                    case 13:
                        {
                            dynamic infpassenger = Passenger.getAvalueOfstructure<int>(gn.AirlineArray);
                            if (infpassenger.flight != null)                            
                                infpassenger.flight.DeleteItem(infpassenger.passenger);                            
                            break;
                        }
                    case 14:
                        {
                            Console.Clear();                            
                            var infpassenger = (Passenger)Passenger.getAvalueOfstructure<Passenger>(gn.AirlineArray);
                            if (infpassenger != null)                                                           
                                Console.WriteLine("Found a passenger:{0}  {1}", infpassenger.Firstname, infpassenger.Lastname);                            
                            Console.ReadLine();
                            break;
                        }
                    case 15:
                        {
                            MinimumPrice(gn);
                            break;
                        }
                    case 16:
                        {
                            PriceList(gn);
                            break;
                        }
                    //Sort all passengers by date of birth
                    case 17:
                        {
                            Sorting(gn);
                            break;
                        }
                    case 18:
                        {
                            loger.EndProgram();
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
    }
}
