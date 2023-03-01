using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()                             
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        [InlineData("33.810924,-86.820487,Taco Bell Warrio...", -86.820487)]
        [InlineData("33.724109,-84.937891,Taco Bell Villa Ric...", -84.937891)]
        [InlineData("32.827744,-85.174771,Taco Bell Valle...", -85.174771)]
        public void ShouldParseLongitude(string line, double expected)                          //This method is testing the Parse method. 
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange - write the code we need if we want to call and test the method we are calling
            var tacoParserInstance = new TacoParser();  //This is a new instance of TacoParser class. This is how it knows what Parse method to test. 

            //Act - 
            var actual = tacoParserInstance.Parse(line);  //The ShouldParrseLongitude method wants to return a line. 

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);  //expected is the double in the ShouldParseLongitude Method. Actual is both Location.Longitude. expected is an ITrackable which is a tacobell(Latitude and Longitude). 
        }


        //TODO: Create a test ShouldParseLatitude

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]               //The test method will test agianst this data passed in.
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        [InlineData("33.810924,-86.820487,Taco Bell Warrio...", 33.810924)]
        [InlineData("33.724109,-84.937891,Taco Bell Villa Ric...", 33.724109)]
        [InlineData("32.827744,-85.174771,Taco Bell Valle...", 32.827744)]

        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse(line);

            //Assert
            Assert.Equal(expected,actual.Location.Latitude);

        }
    }
}
