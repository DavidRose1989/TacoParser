using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Reflection.Emit;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();     //This will allow us to log. Logger Methods.
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");              //This allows us to Loginfo. 

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);     //This Readalllines will read everyline and turn it into a string. Will store all lines and place in Array "lines". 
                                                        //.Readalllines Will look at csv files and read each and every line and turn them into collection of strings. 

            if (lines.Length == 0)                      //inside if statements indicates what will happen if there are 0 and or 1 line.
            {

                logger.LogError("file has no input");   

            }
            if (lines.Length == 1)
            {
                logger.LogWarning("file only has one line of input");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray(); //lines is a collection of strings. locations is collection of lines after it is parsed into strings.
                                                                  //.Select method takes each line from lines and Parse it into a string.
                                                                  //Linq using system extends IEnumerable 
                                                                  //.Parse method returns an ITrackable. 
                                                                  //.Select is saying foreach line in lines we will need to Parse.



            //Below is equivalent to the Parse method above. 
            //var tacoList = new List<ITrackable>();

            //foreach(var line in lines)
           // {
               //tacoList.Add(parser.Parse(lines)):
            //}


            // DON'T FORGET TO LOG YOUR STEPS 

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable tacoBell = null; //These two Itrackable variables are for the two tacobells furthest apart from one another. Once we find those taco bell they are stored there.
            ITrackable tacoBell2= null;
            double distance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`    //GeoCoordinatePortable is a using statement. Need this to use .distance method. 

            //HINT NESTED LOOPS SECTION---------------------

            for (int i = 0; i < locations.Length; i++)              //while is less than locations.length we will increment by i++. while i is less than collection of locations.  
            {                                                       //keep running loop and increment by i until it is not less than collection of locations. Basically once it filters through the entire list of locations. 

            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

                var locA = locations[i];     //i is equal to location A based on loop created above. This locations[i] just equals the one we are currently on as we filter through list. 

                // Create a new corA Coordinate with your locA's lat and long

                var corA = new GeoCoordinate();                     //This coordination will be used to compare two locations. 
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

                for (int t = 0; t < locations.Length; t++)      //What the loop inside the for loop is doing:          
                {                                               //for loop at index i will allow you to look at each tacobell. 

                    // Create a new Coordinate with your locB's lat and long

                    // Now, compare the two using `.GetDistanceTo()`, which returns a double

                    var locB = locations[t];                  //The reason for the for loop inside of first loop is for for loop at index t.
                    var corB = new GeoCoordinate();           //t will filter through all locations before i will move to next location. Then process will start over once again.
                    corB.Latitude = locB.Location.Latitude;     //all of the taco bells in i will compare distance to the tacobells in t. Once for loop t loops through all locations 
                    corB.Longitude = locB.Location.Longitude;   //and compares them to i then for loop i will move on to the next location and compare to every location in t once again.

                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell = locA;
                        tacoBell2 = locB;
                    }

                }

                // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

                logger.LogInfo($"{tacoBell.Name} and {tacoBell2.Name} have greatest seperating distance");
                


            

            

            }


    }
    }
}
