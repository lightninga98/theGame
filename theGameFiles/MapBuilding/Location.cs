using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace theGameFiles.MapBuilding
{
    /// <summary>
    /// This class keeps track of one picture's location on (x,y), the height and width
    /// of the picture, and the pictures' name.
    /// </summary>
    public class Location
    {
        private float x;
        private float y;
        private string pngName;
        private float width;
        private float height;
        /// <summary>
        /// The Main Constructor for the Location Class
        /// </summary>
        /// <param name="newX">(float) The x coordinate of the center of the picture </param>
        /// <param name="newY">(float) The y coordinate of the center of the picture </param>
        /// <param name="newPngName">(string) The file name without the .png of the picture </param> 
        /// <param name="newWidth">(float) The intended width of the picture </param> 
        /// <param name="newHeight">(float) The intended height of the picture </param> 
        public Location(float newX, float newY, string newPngName, float newWidth, float newHeight)
        {
            SetX(newX);
            SetY(newY);
            SetNewWidth(newWidth);
            SetNewHeight(newHeight);
            SetPngName(newPngName);
        }
        /// <summary>
        /// The Empty Constructor for the Location Class
        /// </summary>
        public Location()
        {
            SetX(0);
            SetY(0);
            SetNewWidth(10);
            SetNewHeight(10);
            SetPngName("cheese");
        }
        /// <summary>
        /// Sets the x coordinate of the center of a Location's picture
        /// </summary>
        /// <param name="newX">(float) The intended x coordinate of the center of the picture </param>
        public void SetX(float newX)
        {
            x = newX;
        }
        /// <summary>
        /// Sets the y coordinate of the center of a Location's picture
        /// </summary>
        /// <param name="newY">(float) The intended y coordinate of the center of the picture </param>
        public void SetY(float newY)
        {
            y = newY;
        }
        /// <summary>
        /// Sets the file name of a Location's picture (Don't include .png) 
        /// Defaults on null and when file not found
        /// </summary>
        /// <param name="newPngName">(string) The intended file name of the picture. (Don't use .png) </param>
        public void SetPngName(string newPngName)
        {
            pngName = newPngName;
            if (newPngName == null)                                                
            {
                Console.WriteLine("Image Name is Null. Leaving at default.");
                pngName = "cheese";
            }
            else if (!File.Exists(GetLocationPath()))
            {
                Console.WriteLine("Image is not found in file. Leaving at default." + GetLocationPath());
                pngName = "cheese";
            }
        }
        /// <summary>
        /// Sets the width of a Location's picture.
        /// </summary>
        /// <param name="newWidth">(float) The intended picture width</param>
        public void SetNewWidth(float newWidth) { width = newWidth;}
        /// <summary>
        /// Sets the height of a Location's picture.
        /// </summary>
        /// <param name="newHeight">(float) The intended picture height</param>
        public void SetNewHeight(float newHeight) {  height = newHeight;}
        /// <summary>
        /// Sets the center position of a Location's picture on the (x,y) grid.
        /// </summary>
        /// <param name="newX">(float) The intended picture x coordinate.</param>
        /// <param name="newY">(float) The intended picture y coordinate.</param>
        public void SetPosition(float newX, float newY)
        {
            SetX(newX);
            SetY(newY);
        }
        /// <summary>
        /// Gets a Location's picture's central x coordinate.
        /// </summary>
        /// <returns>(float) picture central x coordinate</returns>
        public float GetX() => x;
        /// <summary>
        /// Gets a Location's picture's central y coordinate.
        /// </summary>
        /// <returns>(float) picture central y coordinate</returns>
        public float GetY() => y;
        /// <summary>
        /// Gets a Location's picture file name (without .png)
        /// </summary>
        /// <returns>(string) picture file name (without .png)</returns>
        public string GetPngName() => pngName;
        /// <summary>
        /// Gets a Location's picture width.
        /// </summary>
        /// <returns>(float) picture width</returns>
        public float GetWidth() => width;
        /// <summary>
        /// Gets a Location's picture height.
        /// </summary>
        /// <returns>(float) picture height</returns>
        public float GetHeight() => height;
        /// <summary>
        /// Gets a Location Picture's projected path. Written based off:
        /// https://stackoverflow.com/questions/14899422/how-to-navigate-a-few-folders-up
        /// </summary>
        /// <returns>(string) Projected picture path</returns>
        public string GetLocationPath()
        {
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"))
                + "MapBuilding\\Images\\" + GetPngName() + ".png";
        }
        /// <summary>
        /// Gets a saveable string used for the MapData class. Overrides the default ToString().
        /// </summary>
        /// <returns>(string) A loadable string for the MapData class.</returns>
        override public string ToString()
        {
            return GetPngName() + "|" + GetWidth() + "|" + GetHeight() + "|" + GetX() + "|" + GetY();
        }
        /// <summary>
        /// Rebuilds the Location based on input string from the MapData Class
        /// </summary>
        /// <param name="loadedString">(string) The input string from the MapData Class.</param>
        /// <returns>(int) 0 for success. -1 for failure.</returns>
        public int LoadFromString(string loadedString)
        {
            int result = 0;
            try
            {
                loadedString = loadedString.Trim();
                string[] locationVar = loadedString.Split('|');
                Console.WriteLine("PngName: " + locationVar[0]);
                Console.WriteLine("Width: " + locationVar[1]);
                Console.WriteLine("Height: " + locationVar[2]);
                Console.WriteLine("X: " + locationVar[3]);
                Console.WriteLine("Y: " + locationVar[4]);
                SetPngName(locationVar[0]);
                SetNewWidth(float.Parse(locationVar[1]));
                SetNewHeight(float.Parse(locationVar[2]));
                SetX(float.Parse(locationVar[3]));
                SetY(float.Parse(locationVar[4]));
            }
            catch 
            {
                result = -1;
            }
            return result;
        }

        public Location Clone()
        {
            Location cloned = new(GetX(), GetY(), GetPngName(), GetWidth(), GetHeight());
            return cloned;
        }

    }
}
