using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceChess
{
    class Board
    {
        public Panel Backround;
        public Piece[,] Table;


        public Board() {  }

        public Board(int x,int y)
        {
            Backround = new Panel();
            Backround.BackgroundImage = Properties.Resources.chessBoard;
            Backround.Location = new Point(x, y);
            Backround.Size = new Size(400, 400);
            Backround.Visible = true;
            Backround.BackColor = Color.Transparent;
            Table = new Piece[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Table[i, j] = new Piece();
                    Table[i, j].Location = new Point(i * 50, j * 50);
                    Table[i, j].Size = new Size(50, 50);
                    Table[i, j].Visible = true;
                    Table[i, j].BackColor = Color.Transparent;
                    Table[i, j].type =(int) PieceType.Empty;
                    Backround.Controls.Add(Table[i, j]);



                }
            }
        }
        //public static void InitializeBoards()
        //{

        //    //First table

        //    Backround = new Panel();



        //    for (int i = 0; i < 8; i++)
        //    {

        //        ChessBoard1[i, 1].Image = Properties.Resources.PionNegru;
        //        ChessBoard1[i, 1].type = "pawn";
        //        ChessBoard1[i, 1].team = "black";

        //        ChessBoard1[i, 6].Image = Properties.Resources.PionAlb;
        //        ChessBoard1[i, 6].type = "pawn";
        //        ChessBoard1[i, 6].team = "white";

        //    }

        //    ChessBoard1[0, 0].Image = ChessBoard1[7, 0].Image = Properties.Resources.TurnNegru;
        //    ChessBoard1[1, 0].Image = ChessBoard1[6, 0].Image = Properties.Resources.CalNegru;
        //    ChessBoard1[2, 0].Image = ChessBoard1[5, 0].Image = Properties.Resources.NebunNegru;
        //    ChessBoard1[0, 7].Image = ChessBoard1[7, 7].Image = Properties.Resources.TurnAlb;
        //    ChessBoard1[1, 7].Image = ChessBoard1[6, 7].Image = Properties.Resources.CalAlb;
        //    ChessBoard1[2, 7].Image = ChessBoard1[5, 7].Image = Properties.Resources.NebunAlb;
        //    ChessBoard1[4, 7].Image = Properties.Resources.RegeAlb;
        //    ChessBoard1[3, 7].Image = Properties.Resources.ReginaAlba;
        //    ChessBoard1[4, 0].Image = Properties.Resources.RegeNegru;
        //    ChessBoard1[3, 0].Image = Properties.Resources.ReginaNegru;

        //    ChessBoard1[0, 0].type = ChessBoard1[7, 0].type = "rook";
        //    ChessBoard1[0, 0].team = "black";
        //    ChessBoard1[7, 0].team = "black";
        //    ChessBoard1[1, 0].type = ChessBoard1[6, 0].type = "knight";
        //    ChessBoard1[1, 0].team = "black";
        //    ChessBoard1[6, 0].team = "black";

        //    ChessBoard1[2, 0].type = ChessBoard1[5, 0].type = "bishop";
        //    ChessBoard1[2, 0].team = "black";
        //    ChessBoard1[5, 0].team = "black";

        //    ChessBoard1[0, 7].type = ChessBoard1[7, 7].type = "rook";
        //    ChessBoard1[0, 7].team = "white";
        //    ChessBoard1[7, 7].team = "white";

        //    ChessBoard1[1, 7].type = ChessBoard1[6, 7].type = "knight";
        //    ChessBoard1[1, 7].team = "white";
        //    ChessBoard1[6, 7].team = "white";

        //    ChessBoard1[2, 7].type = ChessBoard1[5, 7].type = "bishop";
        //    ChessBoard1[2, 7].team = "white";
        //    ChessBoard1[5, 7].team = "white";


        //    ChessBoard1[4, 7].type = "king";
        //    ChessBoard1[4, 7].team = "white";
        //    ChessBoard1[3, 7].type = "queen";
        //    ChessBoard1[3, 7].team = "white";

        //    ChessBoard1[4, 0].type = "king";
        //    ChessBoard1[4, 0].team = "black";
        //    ChessBoard1[3, 0].type = "queen";
        //    ChessBoard1[3, 0].team = "black";


        //    //Second table

        //    Backround2 = new Panel();
        //    Backround2.BackgroundImage = Properties.Resources.chessBoard;
        //    Backround2.Location = new Point(500, 0);
        //    Backround2.Size = new Size(400, 400);
        //    Backround2.Visible = true;
        //    Backround2.BackColor = Color.Transparent;
        //    ChessBoard2 = new Piece[8, 8];
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            ChessBoard2[i, j] = new Piece();
        //            ChessBoard2[i, j].Location = new Point(i * 50, j * 50);
        //            ChessBoard2[i, j].Size = new Size(50, 50);
        //            ChessBoard2[i, j].Visible = true;
        //            ChessBoard2[i, j].BackColor = Color.Transparent;
        //            Backround2.Controls.Add(ChessBoard2[i, j]);



        //        }
        //    }




        //}


        public static PictureBox FindPieceByCoordinates(int x, int y, PictureBox[,] ChessBoard)
        {

            int i = y / 50;
            int j = x / 50;
            return ChessBoard[i, j];

        }

        public static void StorePiece(Piece pieceToBeMoved)
        {
            Piece temp = pieceToBeMoved;
            
        }

        
    }
}
