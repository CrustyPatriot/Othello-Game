/* Board.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.Othello
{
    /// <summary>
    /// A representation of an othello board.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The board.
        /// </summary>
        private Player[,] _board = new Player[8, 8];

        /// <summary>
        /// Constructs a new Board representing a new game.
        /// </summary>
        public Board()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    _board[x, y] = Player.None;
                }
            }
        }

        /// <summary>
        /// Gets the Player at the given location, or Player.Invalid if the location
        /// is off the board.
        /// </summary>
        /// <param name="p">The location.</param>
        /// <returns>The board contents at the given location.</returns>
        public Player GetContents(Point p)
        {
            if (p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8)
            {
                return _board[p.X, p.Y];
            }
            else
            {
                return Player.Invalid;
            }
        }
    }
}
