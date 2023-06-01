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
        private string name;
        private float width;
        private float height;
        /// <summary>
        /// The Constructor for the Location Class
        /// </summary>
        /// <param name="newX">(float) The x coordinate of the center of the picture </param>
        /// <param name="newY">(float) The y coordinate of the center of the picture </param>
        /// <param name="newName">(string) The file name without the .png of the picture </param> 
        /// <param name="newWidth">(float) The intended width of the picture </param> 
        /// <param name="newHeight">(float) The intended height of the picture </param> 
        public Location(float newX, float newY, string newName, float newWidth, float newHeight)
        {
            SetX(newX);
            SetY(newY);
            SetNewWidth(newWidth);
            SetNewHeight(newHeight);
            SetName(newName);
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
        /// <param name="newName">(string) The intended file name of the picture. (Don't use .png) </param>
        public void SetName(string newName)
        {
            string loadName = "default";
            if (newName == null)                                                
            {
                Console.WriteLine("Image Name is Null. Leaving at default.");
            }
            else if (!File.Exists(@"c:theGame/theGameFiles/MapBuilding/Images/" + newName + ".png"))
            {
                Console.WriteLine("Image is not found in file. Leaving at default.");
            }
            else
            {
                loadName = newName;
            }
            name = loadName;
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
        public string GetName() => name;
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
        /// Gets a Location Picture's projected path.
        /// </summary>
        /// <returns>(string) Projected picture path</returns>
        public string GetLocationPath()
        {
            return "C:\\MapBuilding\\Images\\" + name + ".png";
        }

    }
}
