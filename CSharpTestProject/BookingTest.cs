using System;
using Xunit;
using BookingRecommendation.Models;
using System.Collections.Generic;

namespace CSharpTestProject
{
    public class BookingTest
    {
        [Fact]
        public void ShouldreturnLakewood()
        {
            //arrange
            List<Hotel> hotels = new List<Hotel>() { 
                                                    new Hotel("Lakewood", 3, 110, 80, 90, 80),
                                                    new Hotel("Bridgewood", 4, 160, 110, 60, 50),
                                                    new Hotel("Ridgewood", 5, 220, 100, 150, 40)
            };
            string output = String.Empty;
            Booking booking = new Booking(hotels);
            // act
            output = booking.GetBestResult("Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)");
            // assert
            Assert.Equal("Lakewood", output);
        }

        [Fact]
        public void ShouldreturnBridgewood()
        {
            //arrange
            List<Hotel> hotels = new List<Hotel>() {
                                                    new Hotel("Lakewood", 3, 110, 80, 90, 80),
                                                    new Hotel("Bridgewood", 4, 160, 110, 60, 50),
                                                    new Hotel("Ridgewood", 5, 220, 100, 150, 40)
            };
            string output = String.Empty;
            Booking booking = new Booking(hotels);
            // act
            output = booking.GetBestResult("Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)");
            // assert
            Assert.Equal("Bridgewood", output);
        }

        [Fact]
        public void ShouldreturnRidgewood()
        {
            //arrange
            List<Hotel> hotels = new List<Hotel>() {
                                                    new Hotel("Lakewood", 3, 110, 80, 90, 80),
                                                    new Hotel("Bridgewood", 4, 160, 110, 60, 50),
                                                    new Hotel("Ridgewood", 5, 220, 100, 150, 40)
            };
            string output = String.Empty;
            Booking booking = new Booking(hotels);
            // act
            output = booking.GetBestResult("Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)");
            // assert
            Assert.Equal("Ridgewood", output);
        }
    }
}
