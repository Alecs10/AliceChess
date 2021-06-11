using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceChess
{

    public partial class gameForm : Form
    {
        Game game = new Game();
        Label currentColor = new Label();

        public gameForm()
        {
            InitializeComponent();
            CenterToScreen();

        }

        private void gameForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
            InitializeLabel();

            EnableClick(game.getPiecesCoordinates(game.currentTurn), true);
        }

        private void InitializeForm()
        {
            this.BackColor = Color.Wheat;
            this.Width = 915;
            this.Controls.Add(Game.chessboards[0].Backround);
            this.Controls.Add(Game.chessboards[1].Backround);
        }
        private void InitializeLabel()
        {
            this.currentColor.Location = new Point(412, 100);
            this.currentColor.Text = game.currentTurn.ToString();
            this.currentColor.Visible = true;
            currentColor.Width = 75;
            currentColor.Font = new System.Drawing.Font(currentColor.Font.Name, 16);
            currentColor.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(currentColor);

        }
        private void UpdateLabel()
        {
            this.currentColor.Text = game.currentTurn.ToString();
        }

        private void EnableClick(List<Tuple<int, int, int>> list, bool enable)
        {
            foreach (var item in list)
            {
                var row = item.Item2;
                var col = item.Item3;
                var table = item.Item1;
                if (enable)
                {
                    Game.chessboards[table].Table[row][col].Click += chessBoard1PieceClick;
                }
                else
                {
                    Game.chessboards[table].Table[row][col].Click -= chessBoard1PieceClick;
                }
            }
        }

        private void clearSelections()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Game.chessboards[0].Table[row][col].BorderStyle = BorderStyle.None;
                    Game.chessboards[1].Table[row][col].BorderStyle = BorderStyle.None;
                }
            }
        }

        private void chessBoard1PieceClick(object sender, EventArgs e)
        {

            Cell test = (Cell)sender;
            var possiblePiece = Game.selectedPiece;
            


            if (!game.click)
            {
                if (test.containsPiece()&& test.Piece.color.Equals(game.currentTurn))
                {
                    game.click = !game.click;
                    //Game.chessboards[0].Table[test.Piece.row][test.Piece.col].Click += chessBoard1PieceClick;
                    EnableClick(Game.tempCell.Piece.possibleMoves, false);
                }
                else
                {


                    var oldRow = Game.tempCell.Piece.row;
                    var oldCol = Game.tempCell.Piece.col;
                    int row = 0;
                    int col = 0;

                    for (int r = 0; r < 8; r++)
                    {
                        for (int c = 0; c < 8; c++) // Iterate through chess board
                        {
                            if (Game.chessboards[Game.tempCell.Piece.table].Table[r][c].Equals(sender)) // If the cell clicked is found
                            {
                                row = r;
                                col = c;
                            }
                        }
                    }


                    game.movePiece(oldRow, oldCol, row, col, Game.tempCell.Piece.table);

                    game.click = !game.click;
                    clearSelections();
                    EnableClick(game.possibleMoves, false);
                    EnableClick(game.getPiecesCoordinates(game.currentTurn), false);
                    game.currentTurn = game.currentTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;
                    UpdateLabel();
                    //EnableClick(game.getPiecesCoordinates(game.currentTurn), true);
                    Game.chessboards[0].Table[oldRow][oldCol].Click -= chessBoard1PieceClick;
                    if (game.checkKings())
                    {

                        
                       
                            MessageBox.Show("Sah");
                        
                        
                    }

                    if(game.currentTurn.Equals(PieceColor.Black))
                    {
                        game.artificialIntelligence();
                        EnableClick(game.getPiecesCoordinates(game.currentTurn), false);
                        game.currentTurn = game.currentTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;
                        EnableClick(game.getPiecesCoordinates(game.currentTurn), true);

                        if (game.isTheGameOver())
                        {
                            MessageBox.Show("Game Over! " + (game.whoWon == true? "White": "Black") + " won the game.");
                            Thread.Sleep(3000);
                            Application.Exit();
                        }
                        if (game.checkKings())
                        {

                            //if (game.checkKingMate(PieceColor.White) && game.checkKingMate(PieceColor.Black))
                            //{
                            //    MessageBox.Show("Mat");
                            //}
                            //else
                            //{
                                MessageBox.Show("Sah");
                            //}

                        }


                    }

                }


            }
            if(game.click)
            {
                if (test.containsPiece() && test.Piece.color == game.currentTurn)
                {
                    Game.selectedPieceColor = test.Piece.color;
                    clearSelections();
                    Game.chessboards[test.Piece.table].Table[test.Piece.row][test.Piece.col].BorderStyle = BorderStyle.Fixed3D;

                    test.Piece.computePossibleMoves(Game.chessboards[test.Piece.table]);
                    test.Piece.removeIllegalMoves();
                    game.possibleMoves = test.Piece.possibleMoves;
                    game.displayPossibleMoves(Game.chessboards[test.Piece.table]);
                    Game.tempCell = test;

                    game.click = !game.click;
                    EnableClick(test.Piece.possibleMoves, true);
                    //EnableClick(game.getPiecesCoordinates(game.currentTurn), false);
                    //Game.chessboards[0].Table[test.Piece.row][test.Piece.col].Click -= chessBoard1PieceClick;


                }

            }

        }
    }

}


