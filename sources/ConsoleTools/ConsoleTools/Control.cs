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
// Bugs or feature requests
// --------------------------------------------------------------------------------
// Note: For any bug or feature request please add a new issue on GitHub: https://github.com/lastunicorn/ConsoleTools/issues/new

using System;

namespace DustInTheWind.ConsoleTools
{
    /// <summary>
    /// Provides base functionality for a control like top/bottom margin,
    /// optionally hides cursor while displaying,
    /// optionally ensures the display of the control on a new line.
    /// </summary>
    public abstract class Control
    {
        /// <summary>
        /// Gets or sets the number of empty lines displayed before the pause text.
        /// Default value: 0
        /// </summary>
        public int MarginTop { get; set; }

        /// <summary>
        /// Gets or sets the number of empty lines displayed after the pause text, after the pause was ended.
        /// Default value: 0
        /// </summary>
        public int MarginBottom { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies if the cursor is visible while the control is displayed.
        /// Default value: <c>true</c>
        /// </summary>
        public bool ShowCursor { get; set; } = true;

        /// <summary>
        /// Event raised at the begining of the <see cref="Display"/> method, before doing anything else.
        /// </summary>
        public event EventHandler BeforeDisplay;

        /// <summary>
        /// Event raised at the very end of the <see cref="Display"/> method, before returning.
        /// </summary>
        public event EventHandler AfterDisplay;

        /// <summary>
        /// Event raised immediately before writting the top margin.
        /// </summary>
        public event EventHandler BeforeTopMargin;

        /// <summary>
        /// Event raised immediately after writting the bottom margin.
        /// </summary>
        public event EventHandler AfterBottomMargin;

        /// <summary>
        /// Displays the control in the console.
        /// </summary>
        public void Display()
        {
            OnBeforeDisplay();

            MoveToNextLineIfNecessary();

            if (ShowCursor)
                DoDisplay();
            else
                CustomConsole.RunWithoutCursor(DoDisplay);

            OnAfterDisplay();
        }

        /// <summary>
        /// Displays the margins and the content of the control.
        /// </summary>
        protected virtual void DoDisplay()
        {
            WriteTopMargin();
            DoDisplayContent();
            WriteBottomMargin();
        }

        private void MoveToNextLineIfNecessary()
        {
            if (Console.CursorLeft != 0)
                Console.WriteLine();
        }

        /// <summary>
        /// When implemented by an inheritor it displays the content of the control to the console.
        /// </summary>
        protected abstract void DoDisplayContent();

        private void WriteTopMargin()
        {
            OnBeforeTopMargin();

            for (int i = 0; i < MarginTop; i++)
                Console.WriteLine();
        }

        private void WriteBottomMargin()
        {
            for (int i = 0; i < MarginBottom; i++)
                Console.WriteLine();

            OnAfterBottomMargin();
        }

        /// <summary>
        /// Method called at the begining of the <see cref="Display"/> method, before doing anything else.
        /// </summary>
        protected virtual void OnBeforeDisplay()
        {
            BeforeDisplay?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method called at the very end of the <see cref="Display"/> method, before returning.
        /// </summary>
        protected virtual void OnAfterDisplay()
        {
            AfterDisplay?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method called immediately before writting the top margin.
        /// </summary>
        protected virtual void OnBeforeTopMargin()
        {
            BeforeTopMargin?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method called immediately after writting the bottom margin.
        /// </summary>
        protected virtual void OnAfterBottomMargin()
        {
            AfterBottomMargin?.Invoke(this, EventArgs.Empty);
        }
    }
}