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
        public PieceColor currentTurn;
        public List<Tuple<int, int>> possibleMoves;
        public bool click;
        public Cell tempCell;


        public Game()
        {

            chessboards = new Board[2];
            chessboards[0] = new Board(0, 0);
            chessboards[1] = new Board(500, 0);
            currentTurn = PieceColor.White;
            click = true;

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

        public void displayPossibleMoves(Board board)
        {

            foreach (var newMove in this.possibleMoves)
            {
                board.Table[newMove.Item1][newMove.Item2].DrawCircle();
            }
        }

        public void movePiece(int oldRow, int oldCol, int newRow, int newCol, int table)
        {

            if (chessboards[table].Table[oldRow][oldCol].Piece is Pawn)
            {
                ((Pawn)chessboards[table].Table[oldRow][oldCol].Piece).startingPosition = false;
            }
            chessboards[table].Table[newRow][newCol].Piece = chessboards[table].Table[oldRow][oldCol].Piece;

            chessboards[table].Table[oldRow][oldCol].Piece = null;

            chessboards[table].Table[oldRow][oldCol].LoadImage();
            chessboards[table].Table[newRow][newCol].LoadImage();
        }

        public List<Tuple<int, int>> getPiecesCoordinates(PieceColor color)
        {
            List<Tuple<int, int>> returnedIndexes = new List<Tuple<int, int>>();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (chessboards[0].Table[row][col].containsPiece())
                    {
                        if (chessboards[0].Table[row][col].Piece.color == color)
                        {
                            Tuple<int, int> coordinates = Tuple.Create(row, col);
                            returnedIndexes.Add(coordinates);
                        }

                        //if (chessboards[1].Table[row][col].Piece.color == (white ? PieceColor.White : PieceColor.Black))
                        //{
                        //    Tuple<int, int, int> coordinates = Tuple.Create(row, col, 1);
                        //    returnedIndexes.Add(coordinates);
                        //}
                    }
                }
            }

            return returnedIndexes;
        }
    }
}
