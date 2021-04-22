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
            chessboards[0] = new Board(0,0);
            chessboards[1] = new Board(500,0);
        }

        public static void InitializeBoardBasedOnFEN(string FENTable, Piece[,] table)
        {
            char[] separators = new char[] { ' ', '/' };

            string[] ElementsFEM = FENTable.Split(separators);

            for (int i = 0; i < 8; i++)
            {
                int col = 0;
                for (int j = 0; j < ElementsFEM[i].Length; j++)
                {
                    var elem = ElementsFEM[i][j];
                    if (Char.IsLetter(elem))
                    {
                        if (Char.IsUpper(elem))
                        {
                            table[col, i].color = (int)PieceColor.White;
                        }
                        if (Char.IsLower(elem))
                        {
                            table[col, i].color = (int)PieceColor.Black;
                        }
                        if (!Char.IsDigit(elem))
                        {
                            string elemAsString = elem.ToString().ToLower();

                            switch (elemAsString)
                            {
                                case ("p"):

                                    table[col, i].type = (int)PieceType.Pawn;

                                    break;

                                case ("n"):

                                    table[col, i].type = (int)PieceType.Knight;
                                    break;

                                case ("b"):

                                    table[col, i].type = (int)PieceType.Bishop;
                                    break;

                                case ("r"):

                                    table[col, i].type = (int)PieceType.Rook;
                                    break;

                                case ("q"):

                                    table[col, i].type = (int)PieceType.Queen;
                                    break;

                                case ("k"):

                                    table[col, i].type = (int)PieceType.King;
                                    break;

                            }

                            col++;
                        }

                        if (Char.IsDigit(elem))
                        {
                            var tempInt = Convert.ToInt32(elem);
                            int k;
                            for(k = col; k < tempInt; k++)
                            {
                                table[k,i].type = (int)PieceType.Empty;
                            }
                            col = k;

                        }
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    table[i, j].LoadImage();
                }
            }

        }
    }
}
