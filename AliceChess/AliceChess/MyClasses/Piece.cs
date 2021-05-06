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


    
    abstract class Piece 
    {
        public PieceType type;
        public PieceColor color;
        public int row;
        public int col;
        public int table;

        public List<Tuple<int, int>> possibleMoves;

        public Piece()
        {
            possibleMoves = new List<Tuple<int, int>>();
            table = 0;
        }
        public abstract void computePossibleMoves(Board board);






    }
}
