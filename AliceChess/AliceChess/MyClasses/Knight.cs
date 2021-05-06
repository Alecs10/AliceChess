using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class Knight : Piece
    {
        Knight() { }
        public Knight(PieceColor col)
        {
            this.color = col;
            this.type = PieceType.Knight;
        }

        public override void computePossibleMoves(Board board)
        {
            this.possibleMoves.Clear();
            var offsetsToCheck = new List<(int, int)>()
            {
                (-2, 1),
                (-1, 2),
                (1, 2),
                (2, 1),
                (2, -1),
                (1, -2),
                (-1, -2),
                (-2, -1)
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