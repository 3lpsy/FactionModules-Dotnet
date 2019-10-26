﻿using Faction.Modules.Dotnet.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Win32;

namespace WinLibTests
{
    [TestClass]
    public class DriverTests
    {
        [TestMethod]
        public void DriverInitialization()
        {
            List<Command> commands = Faction.Modules.Dotnet.Initialize.GetCommands();
            Faction.Modules.Dotnet.Common.Command driverCommand = commands[6];
            Assert.AreEqual("driver", driverCommand.Name);
        }

        [TestMethod]
        public void DriverEnumerate()
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();
            List<Command> commands = Faction.Modules.Dotnet.Initialize.GetCommands();
            Faction.Modules.Dotnet.Common.Command driverCommand = commands[6];
            Parameters.Add("Operation", "Enumerate");
            CommandOutput results = driverCommand.Execute(Parameters);
            Console.WriteLine(results.Message);
            Assert.AreEqual("driver", driverCommand.Name);
        }
    }
}
