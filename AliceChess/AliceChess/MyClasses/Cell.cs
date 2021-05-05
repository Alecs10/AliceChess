using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceChess
{
    class Cell: PictureBox
    {
        public Piece Piece;

        public Cell()
        {
            if (Piece != null)
            {
                this.Piece.col = this.Location.X / 50;
                this.Piece.row = this.Location.Y / 50;
            }
        }

        public void LoadImage()
        {
            Bitmap[][] Pieces = new Bitmap[2][];

            Pieces[0] = new Bitmap[6] { Properties.Resources.PionAlb, Properties.Resources.CalAlb, Properties.Resources.NebunAlb, Properties.Resources.TurnAlb, Properties.Resources.RegeAlb, Properties.Resources.ReginaAlba };
            Pieces[1] = new Bitmap[6] { Properties.Resources.PionNegru, Properties.Resources.CalNegru, Properties.Resources.NebunNegru, Properties.Resources.TurnNegru, Properties.Resources.RegeNegru, Properties.Resources.ReginaNegru };

            if (this.Piece != null) { 
            
                this.Image = Pieces[(int)this.Piece.color][(int)this.Piece.type];
            }


        }

        public void DrawCircle()
        {

            
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        public bool containsPiece()
        {
            if (Piece != null)
            {
                return true;
            }
            else return false;
        }
    }
}
