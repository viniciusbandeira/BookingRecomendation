using System;
using System.Collections.Generic;
using System.Text;

namespace BookingRecommendation.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int WeekDayPrice { get; set; }
        public int WeekDayRewardPrice { get; set; }
        public int WeekEndDayPrice { get; set; }
        public int WeekEndDayRewardPrice { get; set; }

        public Hotel(string name, int rating, int weekDayPrice, int weekDayRewardPrice, int weekEndDayPrice, int weekEndDayRewardPrice)
        {
            Name = name;
            Rating = rating;
            WeekDayPrice = weekDayPrice;
            WeekDayRewardPrice = weekDayRewardPrice;
            WeekEndDayPrice = weekEndDayPrice;
            WeekEndDayRewardPrice = weekEndDayRewardPrice;
        }
    }
}
