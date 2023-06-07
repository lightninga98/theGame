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
Location defaultPng = new();
Location[] locations = new[] { defaultPng, goblinHead };
MapData mapHolder = new("testLoad", locations);
mapHolder.SaveMapData();
MapData mapHolderTwo = new();
mapHolderTwo.LoadMapData("testLoad");
Location[] printLocations = mapHolder.GetLocationArray();
Console.Write(printLocations.Length);
foreach(Location location in printLocations)
{
    Console.Write("\n" + location.ToString());
}