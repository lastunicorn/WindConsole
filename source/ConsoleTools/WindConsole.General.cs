﻿// WindConsole
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
using System.Collections.Generic;

namespace DustInTheWind.ConsoleTools
{
    public static partial class WindConsole
    {
        private const ConsoleColor SuccessColor = ConsoleColor.Green;
        private const ConsoleColor WarningColor = ConsoleColor.Yellow;
        private const ConsoleColor ErrorColor = ConsoleColor.Red;
        private const ConsoleColor EmphasiesColor = ConsoleColor.White;

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }

        public static int Ask(Dictionary<int, string> items, string question = "Your choice: ")
        {
            foreach (KeyValuePair<int, string> item in items)
                Console.WriteLine($"{item.Key} - {item.Value}");

            while (true)
            {
                Console.WriteLine();
                Console.Write(question);
                string inputValueRaw = Console.ReadLine();

                int inputValue;
                if (int.TryParse(inputValueRaw, out inputValue))
                    return inputValue;
            }
        }
    }
}