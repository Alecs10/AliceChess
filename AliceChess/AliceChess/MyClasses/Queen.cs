using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class Queen : Piece
    {
        public Queen() { }
        public Queen(PieceColor col)
        {
            this.color = col;
            this.type = PieceType.Queen;
        }

        public override void computePossibleMoves(Board board)
        {
            this.possibleMoves.Clear();
            var chessTable = board == Game.chessboards[0] ? 0 : 1;
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
                Tuple<int, int, int> newCoord = Tuple.Create(chessTable, this.row + item.Item1, this.col + item.Item2);
                if (newCoord.Item2 >= 0 && newCoord.Item2 <= 7 && newCoord.Item3 >= 0 && newCoord.Item3 <= 7)
                {
                    if ((board.Table[newCoord.Item2][newCoord.Item3].containsPiece() && board.Table[newCoord.Item2][newCoord.Item3].Piece.color != this.color) || !board.Table[newCoord.Item2][newCoord.Item3].containsPiece())
                    {
                        this.possibleMoves.Add(newCoord);
                    }
                }

            }

            // NW direction

            var r = row - 1;
            var c = col - 1;

            while (r >= 0 && c >= 0)
            {
                if (board.Table[r][c].containsPiece())
                {
                    if (board.Table[r][c].Piece.color != this.color)
                    {
                        possibleMoves.Add(Tuple.Create(chessTable, r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(chessTable, r, c));
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
                        possibleMoves.Add(Tuple.Create(chessTable, r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(chessTable, r, c));
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
                        possibleMoves.Add(Tuple.Create(chessTable, r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(chessTable, r, c));
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
                        possibleMoves.Add(Tuple.Create(chessTable, r, c));
                    }
                    break;
                }
                else
                {
                    possibleMoves.Add(Tuple.Create(chessTable, r, c));
                    r++;
                    c--;
                }
            }

            // bottom direction

            var temp = row + 1;

            while (temp <= 7)
            {
                if (!board.Table[temp][col].containsPiece())
                {
                    Tuple<int, int, int> position = Tuple.Create(chessTable, temp, col);
                    this.possibleMoves.Add(position);
                    temp++;
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

            List<Tuple<int,int, int>> newList = possibleMoves.Distinct().ToList();
            possibleMoves = newList;
        }
    }
}
