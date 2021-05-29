using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class Rook : Piece
    {

        public Rook() { }
        public Rook(PieceColor col)
        {
            this.color = col;
            this.type = PieceType.Rook;
        }

        public override void computePossibleMoves(Board board)
        {
            var chessTable = board == Game.chessboards[0] ? 0 : 1;
            this.possibleMoves.Clear();
            // bottom direction

            var temp = row+1;

            while(temp<=7)
            {
                if (!board.Table[temp][col].containsPiece())
                {
                    Tuple<int, int,int> position = Tuple.Create(chessTable,temp, col);
                    this.possibleMoves.Add(position);
                    temp++;
                }
                else
                {
                    if (board.Table[temp][col].Piece.color!=this.color)
                    {
                        Tuple<int, int, int> position = Tuple.Create(chessTable, temp, col);
                        this.possibleMoves.Add(position);
                    }
                    break;
                }
                
            }

            // up direction

            temp = row - 1;

            while (temp >= 0)
            {
                if (!board.Table[temp][col].containsPiece())
                {
                    Tuple<int, int, int> position = Tuple.Create(chessTable, temp, col);
                    this.possibleMoves.Add(position);
                    temp--;
                }
                else
                {
                    if (board.Table[temp][col].Piece.color != this.color)
                    {
                        Tuple<int, int, int> position = Tuple.Create(chessTable, temp, col);
                        this.possibleMoves.Add(position);
                    }
                    break;
                }

            }

            // left direction

            temp = col - 1;

            while (temp >= 0)
            {
                if (!board.Table[row][temp].containsPiece())
                {
                    Tuple<int, int, int> position = Tuple.Create(chessTable, row, temp);
                    this.possibleMoves.Add(position);
                    temp--;
                }
                else
                {
                    if (board.Table[row][temp].Piece.color != this.color)
                    {
                        Tuple<int, int, int> position = Tuple.Create(chessTable, row, temp);
                        this.possibleMoves.Add(position);
                    }
                    break;
                }

            }

            // right direction

            temp = col + 1;

            while (temp <= 7)
            {
                if (!board.Table[row][temp].containsPiece())
                {
                    Tuple<int, int, int> position = Tuple.Create(chessTable, row, temp);
                    this.possibleMoves.Add(position);
                    temp++;
                }
                else
                {
                    if (board.Table[row][temp].Piece.color != this.color)
                    {
                        Tuple<int, int, int> position = Tuple.Create(chessTable, row, temp);
                        this.possibleMoves.Add(position);
                    }
                    break;
                }

            }
        }
    }
}
