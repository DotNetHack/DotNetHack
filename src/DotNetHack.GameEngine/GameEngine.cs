//
//  GameEngine.cs
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

using System;

namespace DotNetHack.Engine
{
    /// <summary>
    /// Game engine.
    /// </summary>
    public class GameEngine : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetHack.GameEngine.GameEngine"/> class.
        /// </summary>
        public GameEngine(GameEngineFlags flags)
        {
            Flags = flags;
        }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The flags.
        /// </value>
        public GameEngineFlags Flags { get; private set; }

        #region IDisposable implementation

        public void Dispose()
        {

        }

        #endregion
    }
}

