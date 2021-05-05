using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceChess
{
    class Game
    {
        public Board[] chessboards;

        public Game()
        {

            chessboards = new Board[2];
            chessboards[0] = new Board(0, 0);
            chessboards[1] = new Board(500, 0);
        }

        public static void InitializeBoardBasedOnFEN(string FENTable, Cell[][] table)
        {
            char[] separators = new char[] { ' ' };

            string[] ElementsFEM = FENTable.Split(separators);

            int row = 0;
            int col = 0;


            foreach (char c in ElementsFEM[0])
            {
                PieceColor color = PieceColor.White;
                if (Char.IsLetter(c))
                {
                    color = (PieceColor)Convert.ToInt32(!Char.IsUpper(c));
                }

                string tempElem = c.ToString().ToLower();

                switch (tempElem)
                {
                    case ("p"):

                        table[row][col].Piece = new Pawn(color);
           
                        break;

                    case ("n"):

                        table[row][col].Piece = new Knight(color);
                        
                        break;

                    case ("b"):

                        table[row][col].Piece = new Bishop(color);
                        
                        break;

                    case ("r"):

                        table[row][col].Piece = new Rook(color);
                        
                        break;

                    case ("q"):

                        table[row][col].Piece = new Queen(color);
                        
                        break;

                    case ("k"):

                        table[row][col].Piece = new King(color);
                        
                        break;

                }

                

                if (Char.IsDigit(c))
                {
                    int tempInt = c - '0';
                    int final = col + tempInt;
                    while (tempInt - 1 != 0)
                    {

                        table[row][col].Piece = null;
                        col++;
                        tempInt--;
                    }



                }
                table[row][col].LoadImage();

                if (row == 8)
                {
                    break;
                }

                if (c.Equals('/'))
                {
                    row++;
                    col = 0;
                }
                else
                {
                    col++;
                    if (col == 8)
                    {
                        col = 0;
                    }
                }

            }

            }

        public static void displayPossibleMoves(Piece piece,Board board)
        {
            
            foreach (var newMove in piece.possibleMoves)
            {
                board.Table[newMove.Item1][newMove.Item2].DrawCircle();
            }
        }

       
    }
}
