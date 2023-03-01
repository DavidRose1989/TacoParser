namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
                                              //ITrackable has Name and location. Itrackable is taco bell. Itrackable is a interface.
        public ITrackable Parse(string line)  //This Parse method will turn all line after Readalllines method turns them into ITrackable and Parse into string. Will call one taco bells at a time 237 times. 
        {                                     //Each line in lines will be Parsed individually.
            logger.LogInfo("Begin parsing");  //Everytime a string is parsed it will say Begin parsing to indicate the process has started. 
                                              //Taco Bell class conforms to ITrackable. .Parse method returns anything that conforms to ITrackable. 

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)   //This if statement ensures array is not less than three. 
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0

            var latlat = double.Parse(cells[0]);    //This is pulled from cell at index 0 from csv file
                                                 //cells is a collection of string. Basically the entire row from csv file. There are 237 cells.

            // grab the longitude from your array at index 1

            var longlong = double.Parse(cells[1]); //This is pulled from cell at index 1 from csv file

            // grab the name from your array at index 2

            var name = cells[2];    //This is pulled from cell at index 2 from csv file. Name doesn't need to Parse because it is already a string. 

            // done - Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // done -You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            var point = new Point();            //in order to create tacoBell.Location you first need to create and instance of Point struct. 
            point.Latitude = latlat;            //You need to do this because latitude and Longitude both fall in Point class which is the location.
            point.Longitude = longlong;
            
            var tacoBell = new Taco_Bell();     //Made instance of the tacobell class
            tacoBell.Name = name;               //Used dot notation to set properties and build tacobell. 
            tacoBell.Location = point;          //Now that we instanciated Point class we can create Location dot notation.


            

            return tacoBell;   // Then, return the instance of your TacoBell class
                               // Since it conforms to ITrackable
        }
    }
}