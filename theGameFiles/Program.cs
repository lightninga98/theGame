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
Console.WriteLine(goblinHead.GetLocationPath());