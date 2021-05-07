using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceChess
{

    public partial class Form1 : Form
    {

        Game game = new Game();
        Label currentColor = new Label();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeForm();
            InitializeLabel();

            EnableClick(game.getPiecesCoordinates(game.currentTurn),true);
        }

        private void InitializeForm()
        {
            this.BackColor = Color.Wheat;
            this.Width = 915;
            this.Controls.Add(game.chessboards[0].Backround);
            this.Controls.Add(game.chessboards[1].Backround);
        }
        private void InitializeLabel()
        {
            this.currentColor.Location = new Point(412, 100);
            this.currentColor.Text = game.currentTurn.ToString();
            this.currentColor.Visible = true;
            currentColor.Width = 75;
            currentColor.Font= new System.Drawing.Font(currentColor.Font.Name, 16);
            currentColor.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(currentColor);
            
        }
        private void UpdateLabel()
        {
            this.currentColor.Text = game.currentTurn.ToString();
        }

        private void EnableClick(List<Tuple<int, int>> list, bool enable)
        {
            foreach (var item in list)
            {
                var row = item.Item1;
                var col = item.Item2;
                if (enable)
                {
                    game.chessboards[0].Table[row][col].Click += chessBoard1PieceClick;
                }
                else
                {
                    game.chessboards[0].Table[row][col].Click -= chessBoard1PieceClick;
                }
            }
        }

        private void clearSelections()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    game.chessboards[0].Table[row][col].BorderStyle = BorderStyle.None;
                    game.chessboards[1].Table[row][col].BorderStyle = BorderStyle.None;
                }
            }
        }

        private void chessBoard1PieceClick(object sender, EventArgs e)
        {

            Cell test = (Cell)sender;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (game.chessboards[0].Table[row][col].Equals(sender))
                    {

                        if (game.click)
                        {
                            if (test.containsPiece())
                            {
                                clearSelections();
                                test.Piece.row = row;
                                test.Piece.col = col;
                                game.chessboards[0].Table[test.Piece.row][test.Piece.col].BorderStyle = BorderStyle.Fixed3D;
                               
                                test.Piece.computePossibleMoves(game.chessboards[0]);
                                game.possibleMoves = test.Piece.possibleMoves;
                                game.displayPossibleMoves(game.chessboards[test.Piece.table]);
                                game.tempCell = test;
                                
                                game.click = !game.click;
                                EnableClick(test.Piece.possibleMoves, true);
                                EnableClick(game.getPiecesCoordinates(game.currentTurn), false);
                                game.chessboards[0].Table[row][col].Click -= chessBoard1PieceClick;


                            }


                        }
                        else
                        {
                            var oldRow = game.tempCell.Piece.row;
                            var oldCol = game.tempCell.Piece.col;


                            game.movePiece(oldRow, oldCol, row, col, 0);

                            game.click = !game.click;
                            clearSelections();
                            EnableClick(test.Piece.possibleMoves, false);
                            game.currentTurn = game.currentTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;
                            UpdateLabel();
                            EnableClick(game.getPiecesCoordinates(game.currentTurn), true);

                        }

                    }
                }


               
                

            }

        }

        public void chessBoard2PieceClick(object sender, EventArgs e)
        {
            Cell test = (Cell)sender;
        }
    }
}
