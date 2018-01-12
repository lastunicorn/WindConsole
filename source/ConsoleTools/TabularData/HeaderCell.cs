// ConsoleTools
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

namespace DustInTheWind.ConsoleTools.TabularData
{
    /// <summary>
    /// Represents the cell that contains a column header.
    /// </summary>
    public class HeaderCell : CellBase
    {
        /// <summary>
        /// Gets the default horizontal alignment.
        /// </summary>
        public static HorizontalAlignment DefaultHorizontalAlignment { get; } = HorizontalAlignment.Left;

        /// <summary>
        /// Gets or sets the column that contains the current cell.
        /// </summary>
        public Column ParentColumn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCell" /> class with
        /// empty content.
        /// </summary>
        public HeaderCell()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCell" /> class with
        /// the text contained by it.
        /// </summary>
        /// <param name="text">The text displayed in the cell.</param>
        public HeaderCell(string text)
            : base(text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCell" /> class with
        /// the text contained by it and its horizontal alignment.
        /// </summary>
        /// <param name="text">The text displayed in the cell.</param>
        /// <param name="horizontalAlignment">The horizontal alignment of the content of the new cell.</param>
        public HeaderCell(string text, HorizontalAlignment horizontalAlignment)
            : base(text, horizontalAlignment)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCell" /> class with
        /// the text contained by it.
        /// </summary>
        /// <param name="text"></param>
        public HeaderCell(MultilineText text)
            : base(text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCell" /> class with
        /// the text contained by it and its horizontal alignment.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="horizontalAlignment">The horizontal alignment of the content of the new cell.</param>
        public HeaderCell(MultilineText text, HorizontalAlignment horizontalAlignment)
            : base(text, horizontalAlignment)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCell" /> class with
        /// an object representing the content.
        /// </summary>
        public HeaderCell(object content)
            : base(content)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCell" /> class with
        /// an object representing the content and its horizontal alignment.
        /// </summary>
        protected HeaderCell(object content, HorizontalAlignment horizontalAlignment)
            : base(content, horizontalAlignment)
        {
        }

        protected override int CalculatePaddingLeft()
        {
            return ParentColumn?.ParentTable?.PaddingLeft ?? 0;
        }

        protected override int CalculatePaddingRight()
        {
            return ParentColumn?.ParentTable?.PaddingRight ?? 0;
        }

        protected override HorizontalAlignment CalculateHorizontalAlignment()
        {
            HorizontalAlignment alignment = HorizontalAlignment;

            if (alignment == HorizontalAlignment.Default)
                alignment = ParentColumn?.CellHorizontalAlignment ?? HorizontalAlignment.Default;

            if (alignment == HorizontalAlignment.Default)
                alignment = ParentColumn?.ParentTable?.CellHorizontalAlignment ?? HorizontalAlignment.Default;

            if (alignment == HorizontalAlignment.Default)
                alignment = DefaultHorizontalAlignment;

            return alignment;
        }

        public static implicit operator HeaderCell(string text)
        {
            MultilineText multilineText = new MultilineText(text);
            return new HeaderCell(multilineText);
        }

        public static implicit operator string(HeaderCell cell)
        {
            return cell.Content?.ToString() ?? string.Empty;
        }
    }
}