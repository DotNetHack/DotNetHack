//
//  Main.cs
//
//  Author:
//       PJensen <jensen.petej@gmail.com>
//
//  Copyright (c) 2012 Peter J. Jensen
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using DotNetHack.Data;

namespace DotNetHack.Server
{
    class EntryPoint
    {
        public static void Main(string[] args)
        {
            Database db = new Database("localhost", "DNH", "pjensen");

            db.Open();

            db.Close();
        }
    }
}
