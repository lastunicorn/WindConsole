﻿// ConsoleTools
// Copyright (C) 2017 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using DustInTheWind.ConsoleTools.Guard;

namespace DustInTheWind.ConsoleTools.Demo.Guard
{
    internal class Program
    {
        private static MachineLevelGuardian guardian;

        private static int Main()
        {
            DisplayApplicationHeader();

            try
            {
                // Ensure that the application is started only once on the current machine.
                guardian = new MachineLevelGuardian("Alez");

                CustomConsole.WriteLineSuccess("The application was successfully started.");
                CustomConsole.WriteLine();
                CustomConsole.WriteLine("But this application cannot be started twice.");
                CustomConsole.WriteLine("Leave this instance running and try starting another one.");

                CustomConsole.Pause();
            }
            catch (ApplicationException)
            {
                CustomConsole.WriteLineError("Another instace of this application is already running.");
                CustomConsole.WriteLineError("Current instace will shutdown.");
                CustomConsole.Pause();
                return 2;
            }
            catch (Exception ex)
            {
                CustomConsole.WriteLine(string.Format("Error instantiating the guardian instance. {0}", ex.Message), ConsoleColor.Red);
                CustomConsole.Pause();
                return 1;
            }

            return 0;
        }

        private static void DisplayApplicationHeader()
        {
            CustomConsole.WriteLineEmphasies("ConsoleTools Demo - Guard");
            CustomConsole.WriteLineEmphasies("===============================================================================");
            CustomConsole.WriteLine();
            CustomConsole.WriteLine("This demo shows the usage of the Guardian class.");
            CustomConsole.WriteLine();
            CustomConsole.WriteLine("-------------------------------------------------------------------------------");
            CustomConsole.WriteLine();
        }
    }
}