using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using theGameFiles.MapBuilding;


Location goblinHead = new(0, 0, "goblin", 4, 6);
Location defaultPng = new Location();
Console.WriteLine(defaultPng.GetPngName());
Location[] locations = new[] { defaultPng, goblinHead };
MapData mapHolder = new MapData("testLoad",locations);
mapHolder.SaveMapData();
MapData mapHolderTwo = new MapData();
mapHolderTwo.LoadMapData("testLoad");
Location[] printLocations = mapHolder.GetLocationArray();
foreach(Location location in printLocations)
{
    Console.WriteLine(location.ToString());
}