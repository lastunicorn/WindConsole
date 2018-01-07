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

using System;

namespace DustInTheWind.ConsoleTools
{
    public static partial class CustomConsole
    {
        /// <summary>
        /// Writes the specified text to the Console.
        /// Additional parameters can be specified for the foreground color, background color and the horizontal alignment in the Console's buffer.
        /// </summary>
        /// <param name="horizontalAlignment">The horizontal alignment in the Console's buffer.</param>
        /// <param name="foregroundColor">The foreground color used to write the text.</param>
        /// <param name="backgroundColor">The background color used to write the text.</param>
        /// <param name="text">The text to be written to the Console.</param>
        public static void Write(HorizontalAlignment horizontalAlignment, ConsoleColor foregroundColor, ConsoleColor backgroundColor, string text)
        {
            Console.CursorLeft = CalculateStartPosition(text, horizontalAlignment);
            Write(foregroundColor, backgroundColor, text);
        }

        public static void Write(HorizontalAlignment horizontalAlignment, ConsoleColor foregroundColor, ConsoleColor backgroundColor, string format, params object[] arg)
        {
            string text = string.Format(format, arg);

            Console.CursorLeft = CalculateStartPosition(text, horizontalAlignment);
            Write(foregroundColor, backgroundColor, text);
        }

        public static void Write(HorizontalAlignment horizontalAlignment, ConsoleColor foregroundColor, ConsoleColor backgroundColor, object o)
        {
            string text = o?.ToString() ?? string.Empty;

            Console.CursorLeft = CalculateStartPosition(text, horizontalAlignment);
            Write(foregroundColor, backgroundColor, text);
        }

        /// <summary>
        /// Writes the specified text to the Console, followed by the current line terminator.
        /// Additional parameters can be specified for the foreground color, background color and the horizontal alignment in the Console's buffer.
        /// </summary>
        /// <param name="horizontalAlignment">The horizontal alignment in the Console's buffer.</param>
        /// <param name="foregroundColor">The foreground color used to write the text.</param>
        /// <param name="backgroundColor">The background color used to write the text.</param>
        /// <param name="text">The text to be written to the Console.</param>
        public static void WriteLine(HorizontalAlignment horizontalAlignment, ConsoleColor foregroundColor, ConsoleColor backgroundColor, string text)
        {
            Console.CursorLeft = CalculateStartPosition(text, horizontalAlignment);
            WriteLine(foregroundColor, backgroundColor, text);
        }

        public static void WriteLine(HorizontalAlignment horizontalAlignment, ConsoleColor foregroundColor, ConsoleColor backgroundColor, string format, params object[] arg)
        {
            string text = string.Format(format, arg);

            Console.CursorLeft = CalculateStartPosition(text, horizontalAlignment);
            WriteLine(foregroundColor, backgroundColor, text);
        }

        public static void WriteLine(HorizontalAlignment horizontalAlignment, ConsoleColor foregroundColor, ConsoleColor backgroundColor, object o)
        {
            string text = o?.ToString() ?? string.Empty;

            Console.CursorLeft = CalculateStartPosition(text, horizontalAlignment);
            WriteLine(foregroundColor, backgroundColor, text);
        }
    }
}