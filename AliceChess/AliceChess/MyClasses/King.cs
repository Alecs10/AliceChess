using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class King : Piece
    {
        King() { }
        public King(PieceColor col)
        {
            this.color = col;
            this.type = PieceType.King;
        }

        public override void computePossibleMoves(Board board)
        {
            var offsetsToCheck = new List<(int, int)>()
            {
                (1, 0),
                (0, 1),
                (-1, 0),
                (0, -1),
                (1, 1),
                (-1, 1),
                (-1, -1),
                (1, -1)
            };

            foreach (var item in offsetsToCheck)
            {
                Tuple<int, int> newCoord = Tuple.Create(this.row + item.Item1, this.col + item.Item2);
                if (newCoord.Item1 >= 0 && newCoord.Item1 <= 7 && newCoord.Item2 >= 0 && newCoord.Item2 <= 7)
                {
                    if ((board.Table[newCoord.Item1][newCoord.Item2].containsPiece() && board.Table[newCoord.Item1][newCoord.Item2].Piece.color != this.color) || !board.Table[newCoord.Item1][newCoord.Item2].containsPiece())
                    {
                        this.possibleMoves.Add(newCoord);
                    }
                }

            }
        }
    }
}
