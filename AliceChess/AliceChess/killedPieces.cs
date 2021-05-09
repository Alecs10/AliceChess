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
    public partial class killedPieces : Form
    {

        List<Cell> cells;
        int index = 0;

        public killedPieces()
        {
            InitializeComponent();

            Width = Math.Max(Game.blackPiecesKilled.Count, Game.whitePiecesKilled.Count) * 50;
            Height = 100;
            cells = new List<Cell>();
            CenterToScreen();
        }

        public void showKilledPieces(PieceColor color)
        {


            foreach (var elem in color == PieceColor.Black ? Game.blackPiecesKilled : Game.whitePiecesKilled)
            {
                Cell temp = new Cell();
                temp.Piece = elem;
                temp.Location = new Point(index, 0);
                temp.Size = new Size(50, 50);
                cells.Add(temp);
                index += 50;
            }

            foreach (var elem in cells)
            {
                Controls.Add(elem);
                elem.LoadImage();
                elem.Click += pieceClick;
            }

            this.Show();


        }

        public void pieceClick(object sender, EventArgs e)
        {
            switch (((Cell)sender).Piece.type)
            {

                case PieceType.Bishop:
                    Game.selectedPiece = new Bishop();
                    break;

                case PieceType.Queen:
                    Game.selectedPiece = new Queen();

                    break;
                case PieceType.Rook:
                    Game.selectedPiece = new Rook();
                    break;
                case PieceType.Knight:
                    Game.selectedPiece = new Knight();
                    break;

            }

            Game.selectedPiece.type = ((Cell)sender).Piece.type;
            Game.selectedPiece.color = ((Cell)sender).Piece.color;
            Game.chessboards[0].Table[Game.row][Game.col].Piece = Game.selectedPiece;
            Game.chessboards[0].Table[Game.row][Game.col].LoadImage();
            
            for(int i=0;i< Game.blackPiecesKilled.Count(); i++)
            {
                if (Game.blackPiecesKilled[i].Equals(((Cell)sender).Piece))
                {
                    Game.blackPiecesKilled.RemoveAt(i);
                }
                if (Game.whitePiecesKilled[i].Equals(((Cell)sender).Piece))
                {
                    Game.whitePiecesKilled.RemoveAt(i);
                }
            }
            this.Close();
        }




    }
}
