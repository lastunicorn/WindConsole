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

namespace DustInTheWind.ConsoleTools
{
    public static partial class CustomConsole
    {
        public static void Write(string text, ConsoleColor color, HorizontalAlign horizontalAlign)
        {
            Console.CursorLeft = CalculateStartPosition(text, horizontalAlign);

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = oldColor;
        }

        public static void WriteLine(string text, ConsoleColor color, HorizontalAlign horizontalAlign)
        {
            Console.CursorLeft = CalculateStartPosition(text, horizontalAlign);

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        private static int CalculateStartPosition(string text, HorizontalAlign horizontalAlign)
        {
            int startPosition;

            switch (horizontalAlign)
            {
                case HorizontalAlign.Left:
                    startPosition = 0;
                    break;

                case HorizontalAlign.Center:
                    int bufferCenter = Console.BufferWidth / 2 - 2;
                    startPosition = bufferCenter - text.Length / 2;
                    break;

                case HorizontalAlign.Right:
                    int bufferRight = Console.BufferWidth - 1;
                    startPosition = bufferRight - text.Length;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(horizontalAlign), horizontalAlign, null);
            }
            return startPosition;
        }
    }
}