using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEx.ClassLib
{
    public class Flight
    {
        private string arrivalAirport;
        private string departureAirport;

        public DateTime Arrival {
            get
            {
                return Departure.AddMinutes(FlightTimeMinutes);
            } 
        }
        public string ArrivalAirport { 
            get
            {
                return arrivalAirport;
            } 
            set
            {
                if (!IsValidIATA(value))
                {
                    throw new ArgumentException("invalid IATA");
                }

                arrivalAirport = value;
            } 
        }
        public string DepartureAirport
        {
            get
            {
                return departureAirport;
            }
            set
            {
                if (!IsValidIATA(value))
                {
                    throw new ArgumentException("invalid IATA");
                }

                departureAirport = value;
            }
        }

        public DateTime Departure { get; set; }//auto

        public short FlightNumber { get; set; }//auto

        public uint FlightTimeMinutes { private get; set; }//auto


        public Flight(short flightNumber, DateTime departure, 
            string departureAirport, string arrivalAirport)
        {
            this.FlightNumber = flightNumber;
            this.Departure = departure;
            this.DepartureAirport = departureAirport;
            this.ArrivalAirport = arrivalAirport;
        }

        public Flight(short flightNumber, string departureAirport, 
            string arrivalAirport)
        {
            this.FlightNumber = flightNumber;
            this.DepartureAirport = departureAirport;
            this.ArrivalAirport = arrivalAirport;
        }

        public void DelayFlight(uint minutes) 
        {
            FlightTimeMinutes += minutes;
        }

        public bool IsValidIATA(string airport) 
        {
            return airport.Length == 3 && airport == airport.ToUpper();
        }

        public string ToString()
        {
            return $"Flight No: {FlightNumber}\n" +
                $"Departure Airport: {DepartureAirport}\n" +
                $"Arrival Airport: {ArrivalAirport}\n" +
                $"Departure Time: {Departure}\n" +
                $"Arrival Time: {Arrival}";
        }
    }
}
