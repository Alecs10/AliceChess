using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceChess
{
    enum PieceType
    {
        Empty=9,

        Pawn = 0,
        Knight = 1,
        Bishop = 2,
        Rook = 3,
        King=4,
        Queen =5

       
    };

    enum PieceColor
    {
        White = 0,
        Black = 1,
    }


    
    class Piece : PictureBox
    {
        public int type;
        public int color;



        public void LoadImage()
        {
            Bitmap[][] Pieces = new Bitmap[2][];

            Pieces[0] = new Bitmap[6] { Properties.Resources.PionAlb, Properties.Resources.CalAlb, Properties.Resources.NebunAlb, Properties.Resources.TurnAlb, Properties.Resources.RegeAlb, Properties.Resources.ReginaAlba };
            Pieces[1] = new Bitmap[6] { Properties.Resources.PionNegru, Properties.Resources.CalNegru, Properties.Resources.NebunNegru, Properties.Resources.TurnNegru, Properties.Resources.RegeNegru, Properties.Resources.ReginaNegru };

            if (this.type == 9)
            {
                this.Image = null;
            }
            else
            {
                this.Image = Pieces[color][type];
            }
            
            
        }
    }
}
