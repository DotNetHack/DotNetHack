//  EntryPoint.cs
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

namespace DotNetHack
{
    using Engine;
	
    class EntryPoint
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name='args'>
        /// The command-line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            GameEngineFlags flags = GameEngineFlags.Default;
			
            if (!ParseArgs(args, ref flags))
            {
                throw new ArgumentException("Invalid arguments");
            }
			
            // Note: This setup will change

            using (GameEngine ge = new GameEngine(flags))
            {
				
            }
        }
		
        /// <summary>
        /// Parses the arguments.
        /// </summary>
        /// <returns>
        /// The arguments.
        /// </returns>
        /// <param name='argv'>
        /// If set to <c>true</c> argv.
        /// </param>
        /// <param name='flags'>
        /// If set to <c>true</c> flags.
        /// </param>
        public static bool ParseArgs(string[] argv, ref GameEngineFlags flags)
        {
            for (int index = 0; index < argv.Length; ++index)
            {
                var arg = argv [index];

                if ("-debug".Equals(arg))
                {
                    flags |= GameEngineFlags.Debug;
                }
                else if ("-editor".Equals(arg))
                {
                    flags |= GameEngineFlags.Editor;
                }
                else if ("--no-clip".Equals(arg))
                {
                    flags |= GameEngineFlags.NoClip;
                }
                else if ("--iddqd".Equals(arg))
                {
                    flags |= GameEngineFlags.GodMode;
                }

                if (index + 1 < argv.Length)
                {
                    var next_arg = argv [index + 1];

                    if (next_arg != null)
                    {
                        // Note: Args that require a second parameter
                        // (e.g.) --set-to 5 are set here.
                    }
                }
            }
			
            return true;
        }
		
    }
}
