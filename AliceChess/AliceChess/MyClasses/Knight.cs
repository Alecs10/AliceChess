using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class Knight : Piece
    {
        public Knight() { }
        public Knight(PieceColor col)
        {
            this.color = col;
            this.type = PieceType.Knight;
        }

        public override void computePossibleMoves(Board board)
        {
            this.possibleMoves.Clear();
            var chessTable = board == Game.chessboards[0] ? 0 : 1;
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
                Tuple<int, int,int> newCoord = Tuple.Create(chessTable,this.row + item.Item1, this.col + item.Item2);
                if (newCoord.Item2 >= 0 && newCoord.Item2 <= 7 && newCoord.Item3 >= 0 && newCoord.Item3 <= 7)
                {
                    if ((board.Table[newCoord.Item2][newCoord.Item3].containsPiece() && board.Table[newCoord.Item2][newCoord.Item3].Piece.color != this.color) || !board.Table[newCoord.Item2][newCoord.Item3].containsPiece())
                    {
                        this.possibleMoves.Add(newCoord);
                    }
                }

            }
        }
    }
}