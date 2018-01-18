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

using DustInTheWind.ConsoleTools.TabularData;
using NUnit.Framework;

namespace DustInTheWind.ConsoleTools.Tests.TabularData.TableTests
{
    [TestFixture]
    public class TitleAlignmentTests
    {
        [Test]
        public void by_default_title_content_is_aligned_to_left()
        {
            Table table = new Table("Title");
            table.Rows.Add(new[] {"Cell 0,0", "Cell 0,1", "Cell 0,2" });

            string expected =
@"+--------------------------------+
| Title                          |
+----------+----------+----------+
| Cell 0,0 | Cell 0,1 | Cell 0,2 |
+----------+----------+----------+
";
            CustomAssert.TableRender(table, expected);
        }

        [Test]
        public void title_alignment_Default()
        {
            Table table = new Table("Title");
            table.Rows.Add(new[] { "Cell 0,0", "Cell 0,1", "Cell 0,2" });
            table.TitleRow.HorizontalAlignment = HorizontalAlignment.Default;

            string expected =
@"+--------------------------------+
| Title                          |
+----------+----------+----------+
| Cell 0,0 | Cell 0,1 | Cell 0,2 |
+----------+----------+----------+
";
            CustomAssert.TableRender(table, expected);
        }

        [Test]
        public void title_alignment_Left()
        {
            Table table = new Table("Title");
            table.Rows.Add(new[] { "Cell 0,0", "Cell 0,1", "Cell 0,2" });
            table.TitleRow.HorizontalAlignment = HorizontalAlignment.Left;

            string expected =
@"+--------------------------------+
| Title                          |
+----------+----------+----------+
| Cell 0,0 | Cell 0,1 | Cell 0,2 |
+----------+----------+----------+
";
            CustomAssert.TableRender(table, expected);
        }

        [Test]
        public void title_alignment_Center()
        {
            Table table = new Table("Title");
            table.Rows.Add(new[] { "Cell 0,0", "Cell 0,1", "Cell 0,2" });
            table.TitleRow.HorizontalAlignment = HorizontalAlignment.Center;

            string expected =
@"+--------------------------------+
|             Title              |
+----------+----------+----------+
| Cell 0,0 | Cell 0,1 | Cell 0,2 |
+----------+----------+----------+
";
            CustomAssert.TableRender(table, expected);
        }

        [Test]
        public void title_alignment_Right()
        {
            Table table = new Table("Title");
            table.Rows.Add(new[] { "Cell 0,0", "Cell 0,1", "Cell 0,2" });
            table.TitleRow.HorizontalAlignment = HorizontalAlignment.Right;

            string expected =
@"+--------------------------------+
|                          Title |
+----------+----------+----------+
| Cell 0,0 | Cell 0,1 | Cell 0,2 |
+----------+----------+----------+
";
            CustomAssert.TableRender(table, expected);
        }
    }
}