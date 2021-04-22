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

        public static bool turn = true; //true = white, false = black
        public static bool move = false; // false = select a piece, true = select where to move the piece

        static PictureBox temp = new Piece();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game game = new Game();
            this.Controls.Add(game.chessboards[0].Backround);
            this.Controls.Add(game.chessboards[1].Backround);

            Game.InitializeBoardBasedOnFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", game.chessboards[0].Table);
            Game.InitializeBoardBasedOnFEN("rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq -1 2", game.chessboards[1].Table);
            


        }

        //private void EnableClick()
        //{

            
        //    // Enable the click event for for all the pieces

        //    foreach (Piece p in Board.Backround1.Controls)
        //    {

        //        p.Click += chessBoard1PieceClick;

        //    }

        //    foreach (Piece p in Board.Backround2.Controls)
        //    {

        //        p.Click += chessBoard2PieceClick;

        //    }

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

      

        //private void chessBoard1PieceClick(object sender, EventArgs e)
        //{
            
        //    Piece test = (Piece)sender;
        //    temp.Image = test.Image;
        //    test.Image = null;
        //    String test1 = test.type + " " + test.team;
        //    MessageBox.Show(test1);
        //    EnableClick();

        //}

        //public void chessBoard2PieceClick(object sender, EventArgs e)
        //{
        //    Piece test = (Piece)sender;
        //    test.Image = temp.Image;
        //    EnableClick();

        //}
    }
}
