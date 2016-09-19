using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    static class Additionalservice
    {
        static int choisofanswer;
        static string @subject;
        public struct PassFlight
        {
            public Airline airline;
            public Flight flight;
            public Passenger passenger;
        }

        //Enter a date with time
        public static DateTime TimeEnter()
        {
            Console.WriteLine("Enter a year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a month(1-12):");
            int montrh = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a day(1-30):");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an hour(0-23):");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an minute(0-59):");
            int minute = int.Parse(Console.ReadLine());
            DateTime timedata = new DateTime(year, montrh, day, hour, minute, 0);
            return timedata;
        }

        //The implementation of sort by merge
        public static Passenger[] Sortbyage(Passenger[] somearray)
        {
            if (somearray.Length == 1)
                return somearray;
            int halflength = somearray.Length / 2;
            return Unite(Sortbyage(somearray.Take(halflength).ToArray()),
                Sortbyage(somearray.Skip(halflength).ToArray()));
        }

        public static Passenger[] Unite(Passenger[] array1, Passenger[] array2)
        {
            int a = 0, b = 0;
            Passenger[] unitedArray = new Passenger[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                    if ((array1[a]?.Birthday.CompareTo(array2[b]?.Birthday) >=0)&& b<array2.Length)
                        unitedArray[i] = array2[b++];                        
                    else
                        unitedArray[i] = array1[a++];
                else
                    if (b < array2.Length)
                    unitedArray[i] = array2[b++];
                else
                    unitedArray[i] = array1[a++];
            }
            return unitedArray;
        }

        public static void EditAirline(Airline company)
        {
            string valuestring;
            DateTime valuedDatetime;
            Console.WriteLine("Enter the new name of Airline:(#) - remain one");
            valuestring = Console.ReadLine();
            company.AirlineName = ((valuestring == "#") ? company.AirlineName : valuestring);
            Console.WriteLine("Enter the new LicenseNumber of Airline:(#) - remain one");
            valuestring = Console.ReadLine();
            company.LicenseNumber = ((valuestring == "#") ? company.LicenseNumber : valuestring);
            Console.WriteLine("Enter the new expiration date of Airline: (#) - remain one");
            valuestring = Console.ReadLine();
            valuedDatetime = ((valuestring == "#") ? company.DateExpired : TimeEnter());
            company.DateExpired = valuedDatetime;
            //
        }

        public static void DeleteAirline(Airline company)
        {
            company.CancelLicense();
        }

        public static PassFlight? SearchOfppassengers(Airline[] airlineArray)
        {
            PassFlight? pf = new PassFlight();
            Console.WriteLine("Choose a kind of search:1- by number(ID), 2 - by a last name" +
            ",3 - by a name, 4 - by passport");
            choisofanswer = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a criteria of your search");
            @subject = Console.ReadLine();
            for (int i = 0; i < airlineArray?.Length; i++)
            {                
                pf = SubSearch(airlineArray[i]?.ArrivalList);
                if (pf!=null)
                {
                    return pf;
                }
                else
                {
                    pf = SubSearch(airlineArray[i]?.DepartureFlightlist);
                    if (pf != null)
                    {
                        return pf;
                    }
                }
            }
            return null;
        }

        public static PassFlight? SubSearch(List<Flight> listofflight)
        {
            Passenger passtofind;
            foreach (var item in listofflight)
            {
                if (item is Flight)
                {
                    passtofind = item.PassengerSearch(choisofanswer, @subject);
                    if (passtofind != null)
                    {
                        PassFlight pf = new PassFlight();                       
                        pf.flight = item;
                        pf.passenger = passtofind;
                        return pf;
                    }
                }
            }
            return null;
        }
    }
}
