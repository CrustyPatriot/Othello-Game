/* Board.cs
 * Author: Rod Howell
 * Modified by: Alex Schexnayder
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
        /// Stores the current score.
        /// </summary>
        private int[] _score = new int[2];

        /// <summary>
        /// Gives the values that need to be added to go from a given Point in a given direction.
        /// </summary>
        private Point[] _directions =
        {
            new Point(-1,-1),  //Northwest
            new Point(0,-1),   //North
            new Point(1,-1),   //Northeast
            new Point(1,0),    //East
            new Point(1,1),    //Southeast
            new Point(0,1),    //South
            new Point(-1,1),   //Southwest
            new Point(-1,0),   //West
        };

        /// <summary>
        /// Contains the history of plays made.
        /// </summary>
        private Stack<Play> _history = new Stack<Play>();

        /// <summary>
        /// The board.
        /// </summary>
        private Player[,] _board = new Player[8, 8];

        /// <summary>
        /// Gets the player whose turn it is to play.
        /// </summary>
        public Player CurrentPlayer { get; private set; } = Player.Black;

        /// <summary>
        /// Gets the Opponent of the player whose turn it is to play.
        /// </summary>
        public Player OtherPlayer { get; private set; } = Player.White;

        /// <summary>
        /// Gets the current score for black.
        /// </summary>
        public int BlackScore => _score[(int)Player.Black];

        /// <summary>
        /// Gets the current score for white.
        /// </summary>
        public int WhiteScore => _score[(int)Player.White];

        /// <summary>
        /// Gets whether the current player has a legal play to the board.
        /// </summary>
        public bool HasPlay { get; private set; } = true;

        /// <summary>
        /// Gets whether the game is over.
        /// </summary>
        public bool IsOver { get; private set; } = false;

        /// <summary>
        /// Gets whether there is a play that can be undone.
        /// </summary>
        public bool CanUndo  => _history.Count > 0;

        /// <summary>
        /// Gets a value that can be used to represent a pass.
        /// </summary>
        public static Point Pass
        {
            get
            {
                return new Point(-9,-9);
            }
        }

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
            AddPiece(Player.White, new Point(3,3));
            AddPiece(Player.White, new Point(4,4));
            AddPiece(Player.Black, new Point(3,4));
            AddPiece(Player.Black, new Point(4,3));
        }

        /// <summary>
        /// Adds a piece to the board.
        /// </summary>
        /// <param name="p">The owner of the piece to be added.</param>
        /// <param name="i">Gives the location at which to add the piece.</param>
        private void AddPiece(Player owner, Point p)
        {            
            _board[p.X, p.Y] = owner;
            _score[(int)owner]++;
        }

        /// <summary>
        /// Removes a piece from the board.
        /// </summary>
        /// <param name="i">Gives the location from which to remove the piece.</param>
        private void RemovePiece(Point p)
        {
            _score[(int)_board[p.X, p.Y]]--;
            _board[p.X, p.Y] = Player.None;
            
        }

        /// <summary>
        /// Gets the square that is a given distance and direction from a given square.
        /// </summary>
        /// <param name="p">Square on the board.</param>
        /// <param name="d">The direction to move from the above square.</param>
        /// <param name="distance">The distance to move from the above square.</param>
        /// <returns>
        /// Returns the point that results from moving the given distance in the given direction from the given square.
        /// </returns>
        private Point GetSquare(Point p, Direction d, int distance)
        {
            Point temp = _directions[(int)d];
            return new Point(p.X + distance * temp.X, p.Y + distance * temp.Y);
        }

        /// <summary>
        /// Gets the length of a chain of pieces belonging to a given player.
        /// </summary>
        /// <param name="owner">The owner of the pieces in the chain.</param>
        /// <param name="startLocation">The start location on the board.</param>
        /// <param name="d">The direction of the chain from the starting location.</param>
        /// <returns>
        /// Returns the length of the chain.
        /// </returns>
        private int GetLength(Player owner, Point startLocation, Direction d)
        {
            Point current;
            int count = 0;
            for (current = GetSquare(startLocation, d, 1); owner == GetContents(current); current = GetSquare(current, d, 1))
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Flips a chain of pieces to the current player.
        /// </summary>
        /// <param name="numPieces">The number of pieces to flip.</param>
        /// <param name="start">The starting location.</param>
        /// <param name="d">The direction of the chain from the starting location.</param>
        private void FlipPieces(int numPieces, Point start, Direction d)
        {
            for (int i = 0; i < numPieces; i++)
            {
                start = GetSquare(start, d, 1);
                _board[start.X,start.Y] = CurrentPlayer;
            }
            _score[(int)OtherPlayer] -= numPieces;
            _score[(int)CurrentPlayer] += numPieces;
        }
        
        /// <summary>
        /// Counts all flips that result from playing at a given location.
        /// </summary>
        /// <param name="location">The location of the play.</param>
        /// <param name="numFlips">The number of flips made in each direction.</param>
        /// <returns>
        /// Returns true if any pieces were flipped, otherwise returns false.
        /// </returns>
        private bool MakeFlips(Point location, int[] numFlips)
        {
            bool flipped = false;
            for (Direction d = 0; d < Direction.None; d++)
            {               
                int g = GetLength(OtherPlayer,location,d);

                if (g > 0 && GetContents(GetSquare(location,d,g + 1)) == CurrentPlayer)
                {
                    flipped = true;
                    FlipPieces(g,location, d);
                    numFlips[(int)d] = g;
                }
            }
            return flipped;
        }

        /// <summary>
        /// Determines whether a given location is a valid play for the given player.
        /// </summary>
        /// <param name="owner">The player involved.</param>
        /// <param name="p">The square on the board.</param>
        /// <returns>
        /// Returns true if the player can legally play at the given location, otherwise returns false.
        /// </returns>
        private bool ValidPlay(Player owner, Point p)
        {
            if(_board[p.X,p.Y] == Player.None)
            {
                for (Direction d = 0; d < Direction.None; d++)
                {
                    int g = GetLength(1 - owner, p, d);

                    if (g > 0 && GetContents(GetSquare(p, d, g + 1)) == owner)
                    {
                        return true;
                    }
                }
            }          
            return false;
        }

        /// <summary>
        /// Determines whether a given player has a legal play.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        private bool LegalPlay(Player owner)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (ValidPlay(owner, new Point (x,y)) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Swaps the values stored in the properties CurrentPlayer and OtherPlayer.
        /// </summary>
        private void Swap()
        {
            Player temp = CurrentPlayer;
            CurrentPlayer = OtherPlayer;
            OtherPlayer = temp;
        }

        /// <summary>
        /// Ends the current turn.
        /// </summary>
        private void EndCurrentTurn()
        {
            Swap();
            HasPlay = LegalPlay(CurrentPlayer);
            if (!HasPlay)
            {
                IsOver = !LegalPlay(CurrentPlayer);
            }
        }

        /// <summary>
        /// Makes a play on the given square.
        /// </summary>
        /// <param name="p">The given square.</param>
        /// <returns>
        /// Returns whether the attempted play was illegal.
        /// </returns>
        public bool MakePlay(Point p)
        {
            Player player = GetContents(p);
            if (player == Player.None)
            {
                int[] numFlips = new int[8];
               if( MakeFlips(p,numFlips))
                {
                    AddPiece(CurrentPlayer,p);
                    _history.Push(new Play(p,numFlips));
                    EndCurrentTurn();
                    return true;
                }
                return false;
            }            
            else if (p == Pass && HasPlay == false && IsOver == false)
            {
                _history.Push(new Play(Pass, new int[8]));
                EndCurrentTurn();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Undoes the most recent play.
        /// </summary>
        public void Undo()
        {
            if (CanUndo == true)
            {
                Play p = _history.Pop();
                Point point = p.Location;
                if (point == Pass)
                {
                    HasPlay = false;
                }
                else
                {
                    HasPlay = true;
                    RemovePiece(point);
                    for(Direction d = 0; d < Direction.None; d++)
                    {
                        FlipPieces(p.Flipped[(int)d],point,d);
                    }
                }
                IsOver = false;
                Swap();
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
