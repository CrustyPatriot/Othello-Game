/* Direction.cs
 * Author: Alex Schexnayder
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Othello
{
    /// <summary>
    /// The directions the pieces can move on the board.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Northwest direction
        /// </summary>
        Northwest,

        /// <summary>
        /// North direction
        /// </summary>
        North,

        /// <summary>
        /// Northeast direction
        /// </summary>
        Northeast,

        /// <summary>
        /// East direction
        /// </summary>
        East, 

        /// <summary>
        /// Southeast direction
        /// </summary>
        Southeast,
        
        /// <summary>
        /// South direction
        /// </summary>
        South,

        /// <summary>
        /// Southwest direction
        /// </summary>
        Southwest,

        /// <summary>
        /// West direction
        /// </summary>
        West,

        /// <summary>
        /// No direction
        /// </summary>
        None
    }
}
