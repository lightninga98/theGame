using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theGameFiles.MapBuilding
{
    /// <summary>
    /// The MapData Class keeps track of Locations and the map name, and provides methods for saving
    /// and loading that information.
    /// </summary>
    public class MapData
    {
        private string mapName;
        private Location[] locationArray;
        /// <summary>
        /// The Main Constructor of the MapData class.
        /// </summary>
        /// <param name="newMapName">(string) The name of the MapData save file without .txt.</param>
        /// <param name="newLocationArray">(Location[]) The Locations stored on the MapData save file.</param>
        public MapData(string newMapName, Location[] newLocationArray) 
        {
            SetMapName(newMapName);
            SetLocationArray(newLocationArray);
        }
        /// <summary>
        /// The Default Constructor of the MapData class.
        /// </summary>
        public MapData()
        {
            SetMapName("default");
        }
        /// <summary>
        /// Sets the mapName used for the MapData save file without the .txt.
        /// </summary>
        /// <param name="newMapName">(string) The name of the MapData save file (without .txt).</param>
        public void SetMapName(string newMapName)
        {
            if (newMapName == null)
            {
                Console.WriteLine("Map Name is Null. Setting to default.");
                mapName = "default";
            }
            else
            {
                mapName = newMapName;
            }
        }
        /// <summary>
        /// Saves the MapData to a text file in the MapData folder.
        /// </summary>
        /// <returns>(int) 0 for success. -1 for failure. </returns>
        public int SaveMapData()
        {
            int result = 0;
            FileStream stream = new(GetMapDataPath(), FileMode.OpenOrCreate);
            try
            {
                using StreamWriter writer = new(stream, Encoding.ASCII);
                writer.Write(mapName + " " + DateTime.Now.ToString("MM / dd / yyyy hh: mm tt"));
                foreach (Location location in locationArray)
                {
                    writer.Write("\n" + location.ToString());
                }
            }
            catch
            {
                result = -1;
                Console.WriteLine(GetMapName() + "failed to save.");
            }
            finally
            {
                stream.Dispose();
            }
            return result;
        }
        /// <summary>
        /// Loads information from a saved .txt file in the MapData folder to the MapData object.
        /// </summary>
        /// <param name="mapName">(string) The name of the save file without the .txt</param>
        /// <returns>(int) 0 for success. -1 for failure.</returns>
        public int LoadMapData(string mapName)
        {
            int result = 0;
            try
            {
                SetMapName(mapName);
                string mapLocations = File.ReadAllText(GetMapDataPath()).Trim();
                string[] mapLoadedStrings = mapLocations.Split(Environment.NewLine);
                int emptyEntries = 0;                           //Accounting for empty lines at end of file.
                foreach (string possibleLocation in mapLoadedStrings)
                {
                    if(possibleLocation.Equals(""))
                    {
                        emptyEntries++;
                    }
                }
                Location[] newMapLocationArray = new Location[mapLoadedStrings.Length - emptyEntries -1]; //Not first line
                Location loadable = new Location();
                for (int i = 1; i < mapLoadedStrings.Length - emptyEntries; i++)
                {
                    if (loadable.LoadFromString(mapLoadedStrings[i]) != 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        newMapLocationArray[i-1] = loadable.Clone();
                    }
                }
                SetLocationArray(newMapLocationArray);
            }
            catch
            {
                result= -1;
                Console.WriteLine(GetMapName() + "failed to load.");
            }

            return result;
        }
        /// <summary>
        /// Sets the locationArray variable for the MapData class.
        /// </summary>
        /// <param name="newLocationArray"></param>
        public void SetLocationArray(Location[] newLocationArray)
        {
            locationArray = newLocationArray;
        }
        /// <summary>
        /// Returns the MapData save file name without the .txt.
        /// </summary>
        /// <returns>(string) MapData save file name (without .txt)</returns>
        public string GetMapName()
        {
            return mapName;
        }
        /// <summary>
        /// Returns the locationArray of the MapData object.
        /// </summary>
        /// <returns>(Location[]) the locationArray of the MapData</returns>
        public Location[] GetLocationArray() 
        { 
            return locationArray; 
        }

        /// <summary>
        /// Gets a MapData save file's projected path. Written based off:
        /// https://stackoverflow.com/questions/14899422/how-to-navigate-a-few-folders-up
        /// </summary>
        /// <returns>(string) Projected MapData save file path path</returns>
        public string GetMapDataPath()
        {
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"))
                + "MapBuilding\\MapData\\" + GetMapName() + ".txt";
        }
    }
}
