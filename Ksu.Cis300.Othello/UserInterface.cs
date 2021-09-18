/* UserInterface.cs
 * Author: Alex Schexnayder
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.Othello
{
    /// <summary>
    /// A GUI for a program that allows 2 people to play Othello.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The size of a board square in pixels.
        /// </summary>
        private const int _squareSize = 60;

        /// <summary>
        /// The diameter of a piece in pixels.
        /// </summary>
        private const int _pieceDiameter = 55;

        /// <summary>
        /// The margin between board squares in pixels.
        /// </summary>
        private const int _margin = 1;

        /// <summary>
        /// The Othello board.
        /// </summary>
        private Board _board = new Board();

        /// <summary>
        /// The brush to use to fill a white piece.
        /// </summary>
        private Brush _whiteBrush = new SolidBrush(Color.WhiteSmoke);

        /// <summary>
        /// The brush to use to fill a black piece.
        /// </summary>
        private Brush _blackBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            DrawBoard();
            UpdateStatus();
        }

        /// <summary>
        /// Sets up the board.
        /// </summary>
        private void DrawBoard()
        {
            uxBoard.Width = (_squareSize + 2 * _margin) * 8;
            uxBoard.Height = uxBoard.Width;
            Padding p = new Padding();
            p.Left = p.Right = p.Top = p.Bottom = _margin;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    PictureBox square = new PictureBox(); 
                    square.BackColor = Color.DarkSeaGreen;
                    square.Width = square.Height = _squareSize;
                    square.Margin = p;
                    square.BorderStyle = BorderStyle.FixedSingle;
                    square.Name = x + "," + y;
                    uxSquareLocation.SetToolTip(square, square.Name);
                    square.Click += new EventHandler(BoardSquare_Click);
                    square.Paint += new PaintEventHandler(BoardSquare_Paint);
                    uxBoard.Controls.Add(square); 
                }
            }
            Size = new Size(Width, Height + uxStatusBar.Height);
        }

        /// <summary>
        /// Converts a string of the form "x,y", where x and y are single digits, to
        /// a Point.
        /// </summary>
        /// <param name="squareName">The string to convert.</param>
        /// <returns>The Point representation of the given string.</returns>
        private Point GetPoint(string squareName)
        {
            int x = Convert.ToInt32(squareName.Substring(0, 1)); 
            int y = Convert.ToInt32(squareName.Substring(2, 1));
            return new Point(x, y);
        }

        /// <summary>
        /// Handles a Paint event on one of the board squares. Draws any piece that belongs
        /// on this square.
        /// </summary>
        /// <param name="sender">The PictureBox that needs redrawing.</param>
        /// <param name="e">Arguments for the Paint event.</param>
        private void BoardSquare_Paint(object sender, PaintEventArgs e)
        {
            PictureBox square = (PictureBox)sender;
            Point p = GetPoint(square.Name);
            Graphics g = e.Graphics; 

            switch (_board.GetContents(p)) 
            {
                case Player.Black:                    
                    g.FillEllipse(_blackBrush, _margin, _margin, _pieceDiameter, _pieceDiameter);
                    break;
                case Player.White:
                    g.FillEllipse(_whiteBrush, _margin, _margin, _pieceDiameter, _pieceDiameter);
                    break;
                default: 
                    break;
            }
        }

        /// <summary>
        /// Handles a Click event on a board square.
        /// </summary>
        /// <param name="sender">The PictureBox that was clicked.</param>
        /// <param name="e"></param>
        private void BoardSquare_Click(object sender, EventArgs e)
        {
            Point square = GetPoint(((PictureBox)sender).Name);
            MakePlay(square);
        }

        /// <summary>
        /// Updates all of the information on the GUI.
        /// </summary>
        private void UpdateStatus()
        {
            uxBlackScore.Text = _board.BlackScore.ToString();
            uxWhiteScore.Text = _board.WhiteScore.ToString();

            uxBoard.Enabled = !_board.IsOver;
            uxPass.Enabled = !_board.IsOver;
            uxUndo.Enabled = _board.CanUndo;
            if(_board.IsOver)
            {
                if (_board.BlackScore < _board.WhiteScore)
                {
                    uxStatus.Text = "Black wins";
                }
                else if(_board.WhiteScore < _board.BlackScore)
                {
                    uxStatus.Text = "White wins";
                }
                else
                {
                    uxStatus.Text = "Tie";
                }
            }
            else if (_board.CurrentPlayer == Player.Black)
            {
                uxStatus.Text = "Black's turn";
            }
            else
            {
                uxStatus.Text = "White's turn";
            }

            foreach (Control c in uxBoard.Controls)
            {
                c.Invalidate();
            }
            Update();
        }

        /// <summary>
        /// Tries to make a play at the given location. If the play is invalid,
        /// shows an appropriate message.
        /// </summary>
        /// <param name="play">The location of the play.</param>
        private void MakePlay(Point play)
        {
            if (_board.MakePlay(play))
            {
                UpdateStatus();
            }
            else
            {
                MessageBox.Show("Invalid Move");
            }
        }

        /// <summary>
        /// Handles a click event for the "New Game" Button.
        /// </summary>
        /// <param name="sender">THe button that was clicked.</param>
        /// <param name="e"></param>
        private void uxNewGame_Click(object sender, EventArgs e)
        {
            _board = new Board();
            UpdateStatus();
        }

        /// <summary>
        /// Handles a click event handler for the "Undo" button.
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e"></param>
        private void uxUndo_Click(object sender, EventArgs e)
        {
            _board.Undo();
            UpdateStatus();
        }

        /// <summary>
        /// Handles a click event handler for the "Pass" button.
        /// </summary>
        /// <param name="sender">The button that was clicked.</param>
        /// <param name="e"></param>
        private void uxPass_Click(object sender, EventArgs e)
        {
            MakePlay(Board.Pass);
        }
    }
}
