/* Play.cs
 * Author: Alex Schexnayder
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Othello
{
    /// <summary>
    /// Contains the play class that is used to describe a single play on the board.
    /// </summary>
    class Play
    {
        /// <summary>
        /// Gets the location of the play on the board.
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// Gets the number of pieces this play flips in each of the 8 directions.
        /// </summary>
        public int[] Flipped { get; }

        /// <summary>
        /// Constructor getting the location of the play and the number of pieces this
        /// play flips on the board.
        /// </summary>
        /// <param name="location">the location of the play.</param>
        /// <param name="i">The number of pieces this play flips.</param>
        public Play(Point location, int[] flipped)
        {
            Location = location;
            Flipped = flipped;
        }


    }
}
