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
        public Cell[][] Table;


        public Board() { }

        public Board(int x, int y)
        {
            Backround = new Panel();
            Backround.BackgroundImage = Properties.Resources.chessBoard;
            Backround.Location = new Point(x, y);
            Backround.Size = new Size(400, 400);
            Backround.Visible = true;
            Backround.BackColor = Color.Transparent;
            Table = new Cell[8][];

            for (int row = 0; row < 8; row++)
            {
                Table[row] = new Cell[8];
                for (int col = 0; col < 8; col++)
                {
                    Table[row][col] = new Cell();
                    Table[row][col].Location = new Point(col * 50, row * 50);
                    Table[row][col].Size = new Size(50, 50);
                    Table[row][col].Visible = true;
                    Table[row][col].BackColor = Color.Transparent;
                    Table[row][col].Piece = null;
                    Backround.Controls.Add(Table[row][col]);



                }
            }
        }

        
    }
}
