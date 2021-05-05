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
        public static bool turn = true; //true = white, false = black
        public static bool move = false; // false = select a piece, true = select where to move the piece

     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.Width = 950;
            this.Controls.Add(game.chessboards[0].Backround);
            this.Controls.Add(game.chessboards[1].Backround);

            Game.InitializeBoardBasedOnFEN("rnbqkbnr/pppppppp/2rR3/2QP4/4B3/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", game.chessboards[0].Table);
            Game.InitializeBoardBasedOnFEN("8/8/8/8/8/8/8/8", game.chessboards[1].Table);
            EnableClick();


        }

        private void EnableClick()
        {


            // Enable the click event for for all the pieces

            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {

                    game.chessboards[0].Table[i][j].Click += chessBoard1PieceClick;

                }
            }

            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {

                    game.chessboards[1].Table[i][j].Click += chessBoard1PieceClick;

                }
            }
        }

        //    // Remove the click event for the pieces you should not be able to click based on turn/move

        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (turn && !move) // if white has to pick a piece to move
        //            {
        //                if (Board.ChessBoard1[j, i].team != "white")
        //                {
        //                    Board.ChessBoard1[j, i].Click -= chessBoard1PieceClick;
        //                    Board.ChessBoard2[j, i].Click -= chessBoard2PieceClick;
        //                }

        //                move = true;

        //            }
        //            else if (turn && move) // if white has to pick where to move the already selected piece
        //            {
        //                if (Board.ChessBoard1[j, i].team == "white")
        //                {
        //                    Board.ChessBoard1[j, i].Click -= chessBoard1PieceClick;
        //                    Board.ChessBoard2[j, i].Click -= chessBoard2PieceClick;
        //                }

        //                turn = false;
        //                move = false;
        //            }
        //            else if (!turn && !move) // if black has to pick a piece to move
        //            {
        //                if (Board.ChessBoard1[j, i].team != "black")
        //                {
        //                    Board.ChessBoard1[j, i].Click -= chessBoard1PieceClick;
        //                    Board.ChessBoard2[j, i].Click -= chessBoard2PieceClick;
        //                }


        //                move = true;
        //            }
        //            else if (!turn && move) // if black has to pick where to move the already selected piece
        //            {
        //                if (Board.ChessBoard1[j, i].team == "black")
        //                {
        //                    Board.ChessBoard1[j, i].Click -= chessBoard1PieceClick;
        //                    Board.ChessBoard2[j, i].Click -= chessBoard2PieceClick;
        //                }

        //                turn = true;
        //                move = false;
        //            }
        //        }
        //    }


        //}


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

                        if (test.Piece != null)
                        {
                            
                            clearSelections();
                            game.chessboards[0].Table[row][col].BorderStyle = BorderStyle.Fixed3D;
                            test.Piece.col = col;
                            test.Piece.row = row;
                            test.Piece.computePossibleMoves(game.chessboards[0]);
                            Game.displayPossibleMoves(test.Piece, game.chessboards[0]);
                            
                            //MessageBox.Show(test.Piece.positionX.ToString()+" "+ (test.Piece.positionY.ToString()));
                        }
                        else
                        {
                            MessageBox.Show("Empty");
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
