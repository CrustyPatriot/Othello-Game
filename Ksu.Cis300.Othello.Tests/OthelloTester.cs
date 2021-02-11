/* OthelloTester.cs
 * Author: Rod Howell
 */
using System;
using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace Ksu.Cis300.Othello.Tests
{
    /// <summary>
    /// A suite of tests for the Board class in Ksu.Cis300.Othello.
    /// </summary>
    [TestFixture]
    public class OthelloTester
    {
        /// <summary>
        /// A sequence used to test various cases at the beginning of a game.
        /// </summary>
        private Point[] _shortSequence = new Point[]
        {
            new Point(2, 3), new Point(2, 2), new Point(3, 2), new Point(4, 2),
                new Point(5, 4), new Point(5, 5), new Point(5, 6), new Point(6, 6), new Point(7, 6)
        };

        /// <summary>
        /// A sequence of plays ending in a Pass.
        /// </summary>
        private Point[] _passSequence = new Point[]
        {
            new Point(5, 4), new Point(5, 3), new Point(3, 2), new Point(3, 5), new Point(5, 2),
            new Point(3, 1), new Point(2, 5), new Point(4, 2), new Point(3, 0), new Point(1, 5),
            new Point(5, 5), new Point(2, 1), new Point(2, 2), new Point(4, 5), new Point(4, 6),
            new Point(2, 3), new Point(1, 2), new Point(6, 5), new Point(5, 6), new Point(5, 7),
            new Point(3, 7), new Point(5, 1), new Point(7, 6), new Point(7, 4), new Point(6, 1),
            new Point(7, 1), new Point(5, 0), new Point(1, 0), new Point(3, 6), new Point(0, 3),
            new Point(1, 6), new Point(1, 3), new Point(7, 2), new Point(2, 7), new Point(6, 4),
            new Point(4, 7), new Point(7, 0), new Point(1, 7), new Point(1, 1), new Point(6, 3),
            new Point(2, 4), new Point(2, 0), new Point(7, 5), new Point(4, 0), new Point(0, 0),
            new Point(2, 6), new Point(6, 7), new Point(6, 6), new Point(7, 3), new Point(0, 1),
            new Point(0, 5), new Point(6, 2), new Point(0, 2), new Point(0, 6), new Point(1, 4),
            new Point(0, 4), new Point(0, 7), new Point(6, 0), new Point(7, 7), Board.Pass
        };

        /// <summary>
        /// The white pieces after _passSequence is played.
        /// </summary>
        private Point[] _whiteAfterPassSequence = new Point[]
        {
            new Point(6, 0), new Point(2, 1), new Point(3, 1), new Point(5, 1), new Point(6, 1),
            new Point(3, 2), new Point(4, 2), new Point(5, 2), new Point(6, 2), new Point(1, 3),
            new Point(5, 3), new Point(6, 3), new Point(1, 4), new Point(2, 4), new Point(3, 4),
            new Point(5, 4), new Point(6, 4), new Point(1, 5), new Point(3, 5), new Point(6, 5),
            new Point(2, 6), new Point(3, 6), new Point(4, 6), new Point(5, 6)
        };

        /// <summary>
        /// The black pieces after _passSequence is played.
        /// </summary>
        private Point[] _blackAfterPassSequence = new Point[]
        {
            new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0),
            new Point(5, 0), new Point(7, 0), new Point(0, 1), new Point(1, 1), new Point(7, 1),
            new Point(0, 2), new Point(1, 2), new Point(2, 2), new Point(7, 2), new Point(0, 3),
            new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(7, 3), new Point(0, 4),
            new Point(4, 4), new Point(7, 4), new Point(0, 5), new Point(2, 5), new Point(4, 5),
            new Point(5, 5), new Point(7, 5), new Point(0, 6), new Point(1, 6), new Point(6, 6),
            new Point(7, 6), new Point(0, 7), new Point(1, 7), new Point(2, 7), new Point(3, 7),
            new Point(4, 7), new Point(5, 7), new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// A game that white wins.
        /// </summary>
        private Point[] _whiteWinSequence = new Point[]
        {
            new Point(4, 5), new Point(5, 5), new Point(6, 5), new Point(5, 3), new Point(3, 2),
            new Point(2, 5), new Point(6, 3), new Point(5, 6), new Point(4, 7), new Point(5, 2),
            new Point(3, 5), new Point(7, 4), new Point(7, 3), new Point(4, 6), new Point(6, 1),
            new Point(2, 2), new Point(1, 1), new Point(7, 0), new Point(1, 5), new Point(6, 4),
            new Point(5, 7), new Point(3, 7), new Point(2, 7), new Point(4, 2), new Point(6, 2),
            new Point(3, 1), new Point(4, 0), new Point(7, 1), new Point(7, 5), new Point(5, 4),
            new Point(2, 3), new Point(2, 6), new Point(6, 6), new Point(3, 0), new Point(5, 1),
            new Point(1, 3), new Point(2, 4), new Point(1, 6), new Point(1, 2), new Point(0, 5),
            new Point(0, 2), new Point(6, 0), new Point(4, 1), new Point(7, 2), new Point(0, 7),
            new Point(1, 7), new Point(5, 0), new Point(6, 7), new Point(7, 6), new Point(2, 1),
            new Point(2, 0), new Point(7, 7), new Point(0, 6), new Point(1, 0), new Point(3, 6),
            new Point(0, 3), new Point(0, 4), new Point(0, 1), new Point(0, 0), new Point(1, 4)
        };

        /// <summary>
        /// The white pieces after _whiteWinSequence is played.
        /// </summary>
        private Point[] _whiteWinWhitePieces = new Point[]
        {
            new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0),
            new Point(6, 0), new Point(7, 0), new Point(2, 1), new Point(6, 1), new Point(7, 1),
            new Point(1, 2), new Point(3, 2), new Point(7, 2), new Point(1, 3), new Point(2, 3),
            new Point(3, 3), new Point(4, 3), new Point(6, 3), new Point(7, 3), new Point(1, 4),
            new Point(2, 4), new Point(3, 4), new Point(4, 4), new Point(5, 4), new Point(6, 4),
            new Point(7, 4), new Point(1, 5), new Point(2, 5), new Point(5, 5), new Point(6, 5),
            new Point(7, 5), new Point(1, 6), new Point(3, 6), new Point(6, 6), new Point(7, 6),
            new Point(1, 7), new Point(2, 7), new Point(3, 7), new Point(4, 7), new Point(5, 7),
            new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// The black pieces after _whiteWinSequence is played.
        /// </summary>
        private Point[] _whiteWinBlackPieces = new Point[]
        {
            new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(3, 1), new Point(4, 1),
            new Point(5, 1), new Point(0, 2), new Point(2, 2), new Point(4, 2), new Point(5, 2),
            new Point(6, 2), new Point(0, 3), new Point(5, 3), new Point(0, 4), new Point(0, 5),
            new Point(3, 5), new Point(4, 5), new Point(0, 6), new Point(2, 6), new Point(4, 6),
            new Point(5, 6), new Point(0, 7)
        };

        /// <summary>
        /// A game that black wins with the board not completely filled.
        /// </summary>
        private Point[] _blackWinSequence = new Point[]
        {
            new Point(4, 5), new Point(5, 3), new Point(6, 2), new Point(5, 5), new Point(3, 5),
            new Point(2, 5), new Point(4, 6), new Point(5, 6), new Point(2, 6), new Point(6, 3),
            new Point(3, 2), new Point(7, 1), new Point(5, 2), new Point(3, 6), new Point(3, 7),
            new Point(2, 4), new Point(6, 7), new Point(3, 1), new Point(3, 0), new Point(1, 6),
            new Point(1, 5), new Point(5, 4), new Point(7, 3), new Point(1, 3), new Point(2, 3),
            new Point(6, 6), new Point(0, 3), new Point(2, 1), new Point(2, 7), new Point(4, 1),
            new Point(1, 0), new Point(5, 1), new Point(1, 7), new Point(1, 2), new Point(7, 6),
            new Point(7, 2), new Point(5, 0), new Point(4, 0), new Point(0, 1), new Point(7, 4),
            new Point(6, 1), new Point(1, 1), new Point(6, 4), new Point(0, 2), new Point(1, 4),
            new Point(0, 0), Board.Pass, new Point(4, 2), new Point(2, 0), new Point(5, 7),
            new Point(2, 2), new Point(7, 5), new Point(7, 7), new Point(0, 6), new Point(0, 5),
            new Point(6, 0), new Point(7, 0), new Point(0, 4), new Point(4, 7), new Point(6, 5)
        };

        /// <summary>
        /// The white pieces after _blackWinSequence is played.
        /// </summary>
        private Point[] _blackWinWhitePieces = new Point[]
        {
            new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(4, 1), new Point(5, 1),
            new Point(0, 2), new Point(4, 2), new Point(6, 2), new Point(0, 3), new Point(3, 3),
            new Point(5, 3), new Point(0, 4), new Point(1, 4), new Point(2, 4), new Point(5, 4),
            new Point(6, 4), new Point(0, 5), new Point(1, 5), new Point(3, 5), new Point(4, 5),
            new Point(5, 5), new Point(6, 5), new Point(0, 6), new Point(2, 6), new Point(5, 6)
        };

        /// <summary>
        /// The black pieces after _blackWinSequence is played.
        /// </summary>
        private Point[] _blackWinBlackPieces = new Point[]
        {
            new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0),
            new Point(6, 0), new Point(7, 0), new Point(2, 1), new Point(3, 1), new Point(6, 1),
            new Point(7, 1), new Point(1, 2), new Point(2, 2), new Point(3, 2), new Point(5, 2),
            new Point(7, 2), new Point(1, 3), new Point(2, 3), new Point(4, 3), new Point(6, 3),
            new Point(7, 3), new Point(3, 4), new Point(4, 4), new Point(7, 4), new Point(2, 5),
            new Point(7, 5), new Point(1, 6), new Point(3, 6), new Point(4, 6), new Point(6, 6),
            new Point(7, 6), new Point(1, 7), new Point(2, 7), new Point(3, 7), new Point(4, 7),
            new Point(5, 7), new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// A game that ends in a tie.
        /// </summary>
        private Point[] _tieSequence = new Point[]
        {
            new Point(4, 5), new Point(3, 5), new Point(2, 4), new Point(5, 5), new Point(4, 6),
            new Point(1, 5), new Point(6, 4), new Point(3, 6), new Point(2, 6), new Point(5, 4),
            new Point(2, 2), new Point(5, 2), new Point(6, 3), new Point(4, 7), new Point(3, 7),
            new Point(1, 7), new Point(2, 5), new Point(2, 7), new Point(1, 6), new Point(6, 6),
            new Point(0, 5), new Point(7, 3), new Point(6, 5), new Point(3, 2), new Point(5, 3),
            new Point(5, 6), new Point(7, 7), new Point(1, 2), new Point(1, 3), new Point(7, 5),
            new Point(4, 1), new Point(7, 6), new Point(6, 7), new Point(2, 3), new Point(1, 1),
            new Point(6, 1), new Point(1, 4), new Point(5, 7), new Point(4, 2), new Point(0, 6),
            new Point(0, 7), new Point(3, 1), new Point(6, 2), new Point(0, 1), new Point(4, 0),
            new Point(0, 0), new Point(7, 0), new Point(7, 1), new Point(0, 2), new Point(6, 0),
            new Point(1, 0), new Point(3, 0), new Point(5, 0), new Point(0, 4), new Point(0, 3),
            new Point(7, 2), new Point(2, 0), new Point(7, 4), new Point(2, 1), new Point(5, 1)
        };

        /// <summary>
        /// The white pieces after _tieSequence is played.
        /// </summary>
        private Point[] _tieWhitePieces = new Point[]
        {
            new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(3, 1),
            new Point(4, 1), new Point(5, 1), new Point(6, 1), new Point(7, 1), new Point(4, 2),
            new Point(5, 2), new Point(6, 2), new Point(7, 2), new Point(3, 3), new Point(5, 3),
            new Point(6, 3), new Point(7, 3), new Point(2, 4), new Point(3, 4), new Point(4, 4),
            new Point(5, 4), new Point(6, 4), new Point(7, 4), new Point(1, 5), new Point(4, 5),
            new Point(5, 5), new Point(6, 5), new Point(7, 5), new Point(2, 6), new Point(5, 6),
            new Point(6, 6), new Point(7, 6)
        };

        /// <summary>
        /// The black pieces after _tieSequence is played.
        /// </summary>
        private Point[] _tieBlackPieces = new Point[]
        {
            new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0),
            new Point(6, 0), new Point(7, 0), new Point(0, 2), new Point(1, 2), new Point(2, 2),
            new Point(3, 2), new Point(0, 3), new Point(1, 3), new Point(2, 3), new Point(4, 3),
            new Point(0, 4), new Point(1, 4), new Point(0, 5), new Point(2, 5), new Point(3, 5),
            new Point(0, 6), new Point(1, 6), new Point(3, 6), new Point(4, 6), new Point(0, 7),
            new Point(1, 7), new Point(2, 7), new Point(3, 7), new Point(4, 7), new Point(5, 7),
            new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// This method is used by several of the tests to check that the state of the
        /// board is correct.
        /// </summary>
        /// <param name="b">The board to check.</param>
        /// <param name="correctWhite">The expected locations of the white pieces.</param>
        /// <param name="correctBlack">The expected locations of hte black pieces.</param>
        /// <param name="current">The expected current player.</param>
        /// <param name="hasPlay">The expected value of HasPlay.</param>
        /// <param name="isOver">The expected value of IsOver.</param>
        /// <param name="canUndo">The expected value of CanUndo.</param>
        private void TestContents(Board b, Point[] correctWhite, Point[] correctBlack,
            Player current, bool hasPlay, bool isOver, bool canUndo)
        {
            List<Point> whitePieces = new List<Point>();
            List<Point> blackPieces = new List<Point>();
            bool invalid = false;

            // Get the locations of all the pieces.
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Point loc = new Point(x, y);
                    switch (b.GetContents(loc))
                    {
                        case Player.White:
                            whitePieces.Add(loc);
                            break;
                        case Player.Black:
                            blackPieces.Add(loc);
                            break;
                        case Player.None:
                            break;
                        default:
                            invalid = true; // A value other than White, Black, or None was found.
                            break;
                    }
                }
            }
            Assert.Multiple(() =>
            {
                Assert.That(invalid, Is.False); // No values other than White, Black, or None

                // These two checks ignore the order that the Points are listed.
                Assert.That(whitePieces, Is.EquivalentTo(correctWhite), "The set of white pieces is incorrect.");
                Assert.That(blackPieces, Is.EquivalentTo(correctBlack), "The set of black pieces is incorrect.");

                Assert.That(b.WhiteScore, Is.EqualTo(correctWhite.Length), "WhiteScore is incorrect.");
                Assert.That(b.BlackScore, Is.EqualTo(correctBlack.Length), "BlackScore is incorrect.");
                Assert.That(b.CurrentPlayer, Is.EqualTo(current), "CurrentPlayer is incorrect.");
                Assert.That(b.OtherPlayer, Is.EqualTo(1 - current), "OtherPlayer is incorrect.");
                Assert.That(b.HasPlay, Is.EqualTo(hasPlay), "HasPlay is incorrect.");
                Assert.That(b.IsOver, Is.EqualTo(isOver), "IsOver is incorrect.");
                Assert.That(b.CanUndo, Is.EqualTo(canUndo), "CanUndo is incorrect.");
            });
        }

        /// <summary>
        /// This method is used by several tests to construct a new board and
        /// make a given sequence of plays on it.
        /// </summary>
        /// <param name="plays">The plays.</param>
        /// <param name="n">The number of plays to make from the given array.</param>
        /// <returns>The resulting board.</returns>
        private Board PlaySequence(Point[] plays, int n)
        {
            Board b = new Board();
            for (int i = 0; i < n; i++)
            {
                b.MakePlay(plays[i]);
            }
            return b;
        }

        /// <summary>
        /// Tests that the GetContents method returns Player.Invalid when the given
        /// location is off the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAInvalidContents()
        {
            Board b = new Board();
            Assert.That(b.GetContents(new Point(8, 8)), Is.EqualTo(Player.Invalid));
        }

        /// <summary>
        /// Tests that the initial board setup is correct.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBInitialBoard()
        {
            Board b = new Board();
            TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(3, 4), new Point(4, 3) },
                Player.Black, true, false, false);
        }

        /// <summary>
        /// Tests that making the first play at (2, 3) returns true.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCValidPlay()
        {
            Board b = new Board();
            Assert.That(b.MakePlay(new Point(2, 3)), Is.True);
        }

        /// <summary>
        /// Tests that trying to play at (2, 4) on a new game returns false.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCInvalidPlay()
        {
            Board b = new Board();
            Assert.That(b.MakePlay(new Point(2, 4)), Is.False);
        }

        /// <summary>
        /// Tests that passing in a new game returns false.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCInitialPass()
        {
            Board b = new Board();
            Assert.That(b.MakePlay(Board.Pass), Is.False);
        }

        /// <summary>
        /// Tests that the board is correct after one play.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDOnePlay()
        {
            Board b = new Board();
            b.MakePlay(new Point(2, 3));
            TestContents(b, new Point[] { new Point(4, 4) }, new Point[] { new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(3, 4) },
                Player.White, true, false, true);
        }

        /// <summary>
        /// Tests that making an invalid play doesn't change the board contents.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDInvalidPlayNoChange()
        {
            Board b = new Board();
            b.MakePlay(new Point(2, 4));
            TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(3, 4), new Point(4, 3) }, Player.Black,
                true, false, false);
        }

        /// <summary>
        /// Tests an Undo after playing (2, 4).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEOnePlayUndo()
        {
            Board b = new Board();
            b.MakePlay(new Point(2, 4));
            b.Undo();
            TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(3, 4), new Point(4, 3) }, Player.Black,
                true, false, false);
        }

        /// <summary>
        /// Tests the play sequence (2, 3), (2, 2).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestETwoPlays()
        {
            Board b = PlaySequence(_shortSequence, 2);
            TestContents(b, new Point[] { new Point(2, 2), new Point(3, 3), new Point(4, 4) },
                new Point[] { new Point(2, 3), new Point(4, 3), new Point(3, 4) }, Player.Black, true, false, true);
        }

        /// <summary>
        /// Test an Undo after the play sequence (2, 3), (2, 2).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFTwoPlaysOneUndo()
        {
            Board b = PlaySequence(_shortSequence, 2);
            b.Undo();
            TestContents(b, new Point[] { new Point(4, 4) }, new Point[] { new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(3, 4) },
                Player.White, true, false, true);
        }

        /// <summary>
        /// Tests the play sequence (2, 3), (2, 2), followed by two Undos.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestGTwoPlaysTwoUndos()
        {
            Board b = PlaySequence(_shortSequence, 2);
            b.Undo();
            b.Undo();
            TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(3, 4), new Point(4, 3) }, Player.Black,
                true, false, false);
        }

        /// <summary>
        /// Tests the sequence (2, 3), (2, 2), (3, 2), (4, 2).
        /// The last play of this sequence should flip a piece in two directions.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHFlipTwoDirections()
        {
            Board b = PlaySequence(_shortSequence, 4);
            TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(4, 3), new Point(4, 4) },
                new Point[] { new Point(2, 3), new Point(3, 3), new Point(3, 4) }, Player.Black, true, false, true);
        }

        /// <summary>
        /// Tests the sequence (2, 3), (2, 2), (3, 2), (4, 2), followed by an Undo.
        /// The Undo will need to flip pieces in two directions.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestIUndoTwoDirections()
        {
            Board b = PlaySequence(_shortSequence, 4);
            b.Undo();
            TestContents(b, new Point[] { new Point(2, 2), new Point(4, 4) },
                new Point[] { new Point(3, 2), new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(3, 4) },
                Player.White, true, false, true);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5).
        /// The last play should flip two pieces in a line.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestIFlipTwoInLine()
        {
            Board b = PlaySequence(_shortSequence, 6);
            TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(3, 3),
                new Point(4, 3), new Point(4, 4), new Point(5, 5) },
                new Point[] { new Point(2, 3), new Point(3, 4), new Point(5, 4) }, Player.Black, true, false, true);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), followed by an Undo.
        /// The Undo will need to flip two pieces in a line.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestJUndoTwoInLine()
        {
            Board b = PlaySequence(_shortSequence, 6);
            b.Undo();
            TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(4, 3) },
                new Point[] { new Point(2, 3), new Point(3, 3), new Point(3, 4), new Point(4, 4), new Point(5, 4) },
                Player.White, true, false, true);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), (5, 6), (6, 6), (7, 6).
        /// The last play is at an edge.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestJPlayAtEdge()
        {
            Board b = PlaySequence(_shortSequence, 9);
            TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(3, 3), new Point(4, 3), new Point(4, 4), new Point(5, 5) },
                new Point[] { new Point(2, 3), new Point(3, 4), new Point(5, 4), new Point(5, 6), new Point(6, 6), new Point(7, 6) },
                Player.White, true, false, true);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), (5, 6), (6, 6), (7, 6),
        /// followed by an Undo. This Undoes a play at the edge.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestKUndoAtEdge()
        {
            Board b = PlaySequence(_shortSequence, 9);
            b.Undo();
            TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(3, 3),
                new Point(4, 3), new Point(4, 4), new Point(5, 5), new Point(6, 6) },
                new Point[] { new Point(2, 3), new Point(3, 4), new Point(5, 4), new Point(5, 6) },
                Player.Black, true, false, true);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), (5, 6), (6, 6), (7, 6),
        /// followed by an attempt to play at (4, 6). This play is invalid, but it must check a sequence
        /// that runs to the edge of the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestKInvalidPlayNearEdge()
        {
            Board b = PlaySequence(_shortSequence, 9);
            Assert.That(b.MakePlay(new Point(4, 6)), Is.False);
        }

        /// <summary>
        /// Tests that the Pass at the end of _passSequence is a valid play.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestLValidPass()
        {
            Board b = PlaySequence(_passSequence, _passSequence.Length - 1);
            Assert.That(b.MakePlay(Board.Pass), Is.EqualTo(true));
        }

        /// <summary>
        /// Tests the board contents after a sequence that results in no valid play
        /// to the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestLContentBeforePass()
        {
            Board b = PlaySequence(_passSequence, _passSequence.Length - 1);
            TestContents(b, _whiteAfterPassSequence, _blackAfterPassSequence, Player.White, false, false, true);
        }

        /// <summary>
        /// Tests a sequence ending with a valid pass.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestMContentAfterPass()
        {
            Board b = PlaySequence(_passSequence, _passSequence.Length);
            TestContents(b, _whiteAfterPassSequence, _blackAfterPassSequence, Player.Black, true, false, true);
        }

        /// <summary>
        /// Tests an Undo of a Pass.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNUndoPass()
        {
            Board b = PlaySequence(_passSequence, _passSequence.Length);
            b.Undo();
            TestContents(b, _whiteAfterPassSequence, _blackAfterPassSequence, Player.White, false, false, true);
        }

        /// <summary>
        /// Tests a game that white wins.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNWhiteWin()
        {
            Board b = PlaySequence(_whiteWinSequence, _whiteWinSequence.Length);
            TestContents(b, _whiteWinWhitePieces, _whiteWinBlackPieces, Player.Black, false, true, true);
        }

        /// <summary>
        /// Tests a game that black wins without filling the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNBlackWin()
        {
            Board b = PlaySequence(_blackWinSequence, _blackWinSequence.Length);
            TestContents(b, _blackWinWhitePieces, _blackWinBlackPieces, Player.Black, false, true, true);
        }

        /// <summary>
        /// Tests a game that ends in a tie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNTie()
        {
            Board b = PlaySequence(_tieSequence, _tieSequence.Length);
            TestContents(b, _tieWhitePieces, _tieBlackPieces, Player.Black, false, true, true);
        }

        /// <summary>
        /// Tests Undoing all but the first play in a full game.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestOUndoGame()
        {
            Board b = PlaySequence(_blackWinSequence, _blackWinSequence.Length);
            for (int i = 0; i < _blackWinSequence.Length - 1; i++)
            {
                b.Undo();
            }
            TestContents(b, new Point[] { new Point(3, 3) }, new Point[] { new Point(4, 3), new Point(3, 4), new Point(4, 4), new Point(4, 5) },
                Player.White, true, false, true);
        }
    }
}
