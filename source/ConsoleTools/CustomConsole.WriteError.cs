﻿// ConsoleTools
// Copyright (C) 2017-2018 Dust in the Wind
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

// --------------------------------------------------------------------------------
// Bugs or fearure requests
// --------------------------------------------------------------------------------
// Note: For any bug or feature request please add a new issue on GitHub: https://github.com/lastunicorn/ConsoleTools/issues/new

using System;

namespace DustInTheWind.ConsoleTools
{
    public partial class CustomConsole
    {
        public static void WriteError(string text)
        {
            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            Console.Write(text);

            Console.ForegroundColor = initialForegroundColor;
            Console.BackgroundColor = initialBackgroundColor;
        }

        public static void WriteError(string format, params object[] arg)
        {
            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            Console.Write(format, arg);

            Console.ForegroundColor = initialForegroundColor;
            Console.BackgroundColor = initialBackgroundColor;
        }

        public static void WriteError(Exception ex)
        {
            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            Console.WriteLine(ex);

            Console.ForegroundColor = initialForegroundColor;
            Console.BackgroundColor = initialBackgroundColor;
        }

        public static void WriteError(object o)
        {
            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            Console.WriteLine(o);

            Console.ForegroundColor = initialForegroundColor;
            Console.BackgroundColor = initialBackgroundColor;
        }

        public static void WriteLineError(string text)
        {
            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            Console.WriteLine(text);

            Console.ForegroundColor = initialForegroundColor;
            Console.BackgroundColor = initialBackgroundColor;
        }

        public static void WriteLineError(string format, params object[] arg)
        {
            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            Console.WriteLine(format, arg);

            Console.ForegroundColor = initialForegroundColor;
            Console.BackgroundColor = initialBackgroundColor;
        }

        public static void WriteLineError(object o)
        {
            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            Console.WriteLine(o);

            Console.ForegroundColor = initialForegroundColor;
            Console.BackgroundColor = initialBackgroundColor;
        }

        public static void WithErrorColors(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;
            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            try
            {
                action();
            }
            finally
            {
                Console.ForegroundColor = initialForegroundColor;
                Console.BackgroundColor = initialBackgroundColor;
            }
        }

        public static T WithErrorColors<T>(Func<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ErrorColor;

            if (ErrorBackgroundColor.HasValue)
                Console.BackgroundColor = ErrorBackgroundColor.Value;

            try
            {
                return action();
            }
            finally
            {
                Console.ForegroundColor = initialForegroundColor;
                Console.BackgroundColor = initialBackgroundColor;
            }
        }
    }
}