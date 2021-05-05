using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class Pawn : Piece
    {
        bool startingPosition;

        Pawn() {
           
        }
        public Pawn(PieceColor col) {
            this.color = col;
            this.type = PieceType.Pawn;
            startingPosition = true;

        }

        public override void computePossibleMoves(Board board)
        {

            if (this.color == PieceColor.Black) // for the black pawns
            {
                if(!board.Table[row + 1][col].containsPiece()) // if the next square is free
                {
                    this.possibleMoves.Add(Tuple.Create(row + 1, col)); // add it to the possible moves list
                    if (startingPosition == true && !board.Table[row + 2][col].containsPiece()) // if the pawn is in its starting pos and the square after the next is free, add it as well
                    {
                        this.possibleMoves.Add(Tuple.Create(row + 2, col));
                    }
                }
                
                //check if the pawn can capture a piece

                if (col!=0 && board.Table[row + 1][col-1].containsPiece()) //check left side as long as you are not on the leftmost column
                {
                    if (board.Table[row + 1][col - 1].Piece.color != this.color)
                    {
                        this.possibleMoves.Add(Tuple.Create(row + 1, col - 1));
                    }
                }
                if (col !=7 && board.Table[row + 1][col+1].containsPiece()) // check right side  as long as you are not on the rightmost column
                {
                    if (board.Table[row + 1][col + 1].Piece.color != this.color)
                    {
                        this.possibleMoves.Add(Tuple.Create(row + 1, col + 1));
                    }
                }
            }
            else // same logic as the above for the white pawns
            {
                if (!board.Table[row - 1][col].containsPiece()) 
                {
                    this.possibleMoves.Add(Tuple.Create(row - 1, col));
                    if (startingPosition == true && !board.Table[row - 2][col].containsPiece()) 
                    {
                        this.possibleMoves.Add(Tuple.Create(row - 2, col));
                    }
                }

                if (col != 0 && board.Table[row - 1][col - 1].containsPiece())
                {
                    if (board.Table[row - 1][col - 1].Piece.color != this.color)
                    {
                        this.possibleMoves.Add(Tuple.Create(row - 1, col - 1));
                    }
                }
                if (col != 7 && board.Table[row - 1][col + 1].containsPiece())
                {
                    if (board.Table[row - 1][col + 1].Piece.color != this.color)
                    {
                        this.possibleMoves.Add(Tuple.Create(row - 1, col + 1));
                    }
                }
            }
        }
    }
}
