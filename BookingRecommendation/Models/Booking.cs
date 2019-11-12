using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace BookingRecommendation.Models
{
    public class Booking
    {
        
        public List<Hotel> Hotels;

        public Booking(List<Hotel> hotels)
        {
            Hotels = hotels;
        }
        public string GetBestResult(string input)
        {
            string[] splitters = { ":"," ",","};
            var arguments = input.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            var clientType = arguments[0];

            List<DateTime> dates = new List<DateTime>();
            CultureInfo culture = new CultureInfo("en-US");
            //Ex: 16Mar2009(mon)
            string format = "ddMMMyyyy";
            for (int i = 1; i< arguments.Length; i++)
            {
                string stringDate = arguments[i].Split('(')[0];
                dates.Add(DateTime.ParseExact(stringDate, format, culture));           
            }

            List<int> values = new List<int>();

            foreach(var hotel in Hotels)
            {
                values.Add(CalculatePrice(dates, clientType, hotel));
            }

            int smallPrice = values[0];
            string hotelName = Hotels[0].Name;
            int hotelId = 0;

            for(int i = 0; i<values.Count;i++)
            {
                if (values[i] < smallPrice)
                {
                    smallPrice = values[i];
                    hotelId = i;
                }

                if (values[i] == smallPrice && Hotels[i].Rating > Hotels[hotelId].Rating)
                {
                        hotelId = i;
                }
            }

            hotelName = Hotels[hotelId].Name;
            return hotelName;
        }

        private int CalculatePrice(List<DateTime> dates, string ClientType, Hotel hotel) {

            int weekdays = 0;
            int weekenddays = 0;
            int price = 0;

            GetDays(ref weekdays, ref weekenddays, dates);

            switch (ClientType)
            {
                case "Regular":
                    price = hotel.WeekDayPrice * weekdays + hotel.WeekEndDayPrice * weekenddays;

                    break;
                case "Rewards":
                    price = hotel.WeekDayRewardPrice * weekdays + hotel.WeekEndDayRewardPrice * weekenddays;
                    break;
                default:
                    break;

            }

            return price;

        }

        private void GetDays(ref int weekdays, ref int weekEnddays, List<DateTime> dates)
        {
            weekdays = 0;
            weekEnddays = 0;
            foreach(var date in dates)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    weekEnddays++;
                else
                    weekdays++;
            }
        }
    }

   
}
