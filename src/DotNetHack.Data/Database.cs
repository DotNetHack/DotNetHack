//
//  Database.cs
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

using MySql.Data.MySqlClient;

namespace DotNetHack.Data
{
    /// <summary>
    /// DB
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetHack.Data.Database"/> class.
        /// </summary>
        public Database(string aServer, string aCatalog, string aUser, string aPassword = "")
        {
            SqlConnection = new MySqlConnection(
                string.Format("Server={0};Database={1};Uid={2};Pwd={3};"));
        }

        /// <summary>
        /// Gets the sql connection.
        /// </summary>
        /// <value>
        /// The sql connection.
        /// </value>
        public MySqlConnection SqlConnection{ get; private set; }
    }
}

