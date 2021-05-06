using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class Bishop : Piece
    {

        public Bishop() { }
        public Bishop(PieceColor col)
        {
            this.color = col;
            this.type = PieceType.Bishop;
        }

        public override void computePossibleMoves(Board board)
        {
            this.possibleMoves.Clear();
            // NW direction

            var r = row-1;
            var c = col-1;

            while(r>=0 && c >= 0)
            {
                if (board.Table[r][c].containsPiece())
                {
                    if (board.Table[r][c].Piece.color != this.color)
                    {
                        possibleMoves.Add(Tuple.Create(r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(r, c));
                    r--;
                    c--;
                }
            }

            // SE direction 

            r = row + 1;
            c = col + 1;

            while (r <= 7 && c <= 7)
            {
                if (board.Table[r][c].containsPiece())
                {
                    if (board.Table[r][c].Piece.color != this.color)
                    {
                        possibleMoves.Add(Tuple.Create(r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(r, c));
                    r++;
                    c++;
                }
            }

            // NE direction

            r = row - 1;
            c = col + 1;

            while (r >= 0 && c <= 7)
            {
                if (board.Table[r][c].containsPiece())
                {
                    if (board.Table[r][c].Piece.color != this.color)
                    {
                        possibleMoves.Add(Tuple.Create(r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(r, c));
                    r--;
                    c++;
                }
            }


            // SW direction

            r = row + 1;
            c = col - 1;

            while (r <= 7 && c >= 0)
            {
                if (board.Table[r][c].containsPiece())
                {
                    if (board.Table[r][c].Piece.color != this.color)
                    {
                        possibleMoves.Add(Tuple.Create(r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(r, c));
                    r++;
                    c--;
                }
            }
        }
    }
}
