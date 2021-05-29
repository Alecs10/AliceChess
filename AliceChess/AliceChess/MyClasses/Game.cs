using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliceChess
{
    class Game
    {
        static public Board[] chessboards;
        public PieceColor currentTurn;
        public List<Tuple<int, int, int>> possibleMoves;
        public bool click;
        public static Cell tempCell;
        public static int boardTemp;
        public static List<Piece> blackPiecesKilled;
        public static List<Piece> whitePiecesKilled;
        public static Piece selectedPiece;
        public static int row, col;
        public static Tuple<int, int, int> blackKingCoordinates, whiteKingCoordinates;
        public Boolean check;
        public static PieceColor selectedPieceColor;





        public Game()
        {

            chessboards = new Board[2];
            chessboards[0] = new Board(0, 0);
            chessboards[1] = new Board(500, 0);
            currentTurn = PieceColor.White;
            click = true;
            blackPiecesKilled = new List<Piece>();
            whitePiecesKilled = new List<Piece>();
            blackKingCoordinates = Tuple.Create(0, 0, 4);
            whiteKingCoordinates = Tuple.Create(0, 7, 4);
            check = false;



            InitializeKilledPieces();
            InitializeBoardBasedOnFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", chessboards[0].Table);
            InitializeBoardBasedOnFEN("8/8/8/8/8/8/8/8", chessboards[1].Table);

        }

        void InitializeKilledPieces()
        {
            Piece temp;

            temp = new Knight(PieceColor.Black);
            blackPiecesKilled.Add(temp);
            temp = new Bishop(PieceColor.Black);
            blackPiecesKilled.Add(temp);
            temp = new Rook(PieceColor.Black);
            blackPiecesKilled.Add(temp);
            temp = new Queen(PieceColor.Black);
            blackPiecesKilled.Add(temp);

            temp = new Knight(PieceColor.White);
            whitePiecesKilled.Add(temp);
            temp = new Bishop(PieceColor.White);
            whitePiecesKilled.Add(temp);
            temp = new Rook(PieceColor.White);
            whitePiecesKilled.Add(temp);
            temp = new Queen(PieceColor.White);
            whitePiecesKilled.Add(temp);
        }
        public void InitializeBoardBasedOnFEN(string FENTable, Cell[][] table)
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
                if (table[row][col].containsPiece())
                {
                    table[row][col].Piece.row = row;
                    table[row][col].Piece.col = col;
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
                board.Table[newMove.Item2][newMove.Item3].DrawCircle();
            }
        }

        public Piece movePiece(int oldRow, int oldCol, int newRow, int newCol, int currentTable)
        {

            int nextTable = currentTable == 0 ? 1 : 0;
            //daca e pion, dupa prima mutare nu mai poate merge 2 patratele in fata

            if (chessboards[currentTable].Table[oldRow][oldCol].Piece is Pawn)
            {
                ((Pawn)chessboards[currentTable].Table[oldRow][oldCol].Piece).startingPosition = false;
            }

            //daca e rege, memoreaza i coordonatele in variabilele din Game pentru a putea verifica daca se afla in sah

            if (chessboards[currentTable].Table[oldRow][oldCol].Piece is King)
            {

                var color = chessboards[currentTable].Table[oldRow][oldCol].Piece.color;

                if (color == PieceColor.Black)
                {
                    blackKingCoordinates = Tuple.Create(nextTable, newRow, newCol);
                }
                else
                {
                    whiteKingCoordinates = Tuple.Create(nextTable, newRow, newCol);
                }

            }

            // mutam piesa la noua locatie

            chessboards[nextTable].Table[newRow][newCol].Piece = chessboards[currentTable].Table[oldRow][oldCol].Piece;

            // stergem piesa de la vechea locatie
            chessboards[currentTable].Table[oldRow][oldCol].Piece = null;

            // stergem piesa de la noua locatie(daca exista)

            if (chessboards[currentTable].Table[newRow][newCol].containsPiece())
            {
                chessboards[currentTable].Table[newRow][newCol].Piece = null;
                chessboards[currentTable].Table[newRow][newCol].LoadImage();
            }


            // daca piesa e pion si a ajuns pana pe ultimul rand al tablei, arata-i optiunile si promoveaza-l
            if (chessboards[nextTable].Table[newRow][newCol].Piece is Pawn)
            {
                if (chessboards[nextTable].Table[newRow][newCol].Piece.color == PieceColor.Black)
                {
                    if (newRow == 7)
                    {
                        Game.boardTemp = chessboards[nextTable].Table[newRow][newCol].Piece.table;
                        killedPieces kill = new killedPieces();
                        Game.col = newCol;
                        Game.row = newRow;
                        kill.showKilledPieces(PieceColor.Black);



                    }
                }
                else
                {
                    if (newRow == 0)
                    {
                        Game.boardTemp = chessboards[nextTable].Table[newRow][newCol].Piece.table;
                        killedPieces kill = new killedPieces();
                        Game.col = newCol;
                        Game.row = newRow;
                        kill.showKilledPieces(PieceColor.White);

                    }
                }

            }

            // incarca imaginea pt noua piesa / sterge imaginea din vechea piesa 
            chessboards[currentTable].Table[oldRow][oldCol].LoadImage();
            chessboards[nextTable].Table[newRow][newCol].LoadImage();

            // actualizeaza coordonatele in piesa noua
            chessboards[nextTable].Table[newRow][newCol].Piece.col = newCol;
            chessboards[nextTable].Table[newRow][newCol].Piece.row = newRow;
            chessboards[nextTable].Table[newRow][newCol].Piece.table = nextTable;


            return null;
        }



        public List<Tuple<int, int, int>> getPiecesCoordinates(PieceColor color)
        {
            List<Tuple<int, int, int>> returnedIndexes = new List<Tuple<int, int, int>>();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {

                    if (chessboards[0].Table[row][col].containsPiece())
                    {
                        if (chessboards[0].Table[row][col].Piece.color == color)
                        {
                            Tuple<int, int, int> coordinates = Tuple.Create(0, row, col);
                            returnedIndexes.Add(coordinates);
                        }
                    }
                   
                    if (chessboards[1].Table[row][col].containsPiece())
                    {
                        if (chessboards[1].Table[row][col].Piece.color == color)
                        {
                            Tuple<int, int, int> coordinates = Tuple.Create(1, row, col);
                            returnedIndexes.Add(coordinates);
                        }
                    }

                }
            }
            return returnedIndexes;
        }


        public Boolean checkKings()
        {

            return (checkBlackKing() || checkWhiteKing());
        }

        public Boolean checkBlackKing()
        {

            var flag = false;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (chessboards[blackKingCoordinates.Item1].Table[row][col].containsPiece())
                    {
                        chessboards[blackKingCoordinates.Item1].Table[row][col].Piece.computePossibleMoves(Game.chessboards[blackKingCoordinates.Item1]);
                        foreach (var move in chessboards[blackKingCoordinates.Item1].Table[row][col].Piece.possibleMoves)
                        {
                            if (move.Equals(blackKingCoordinates))
                            {
                                flag = true;
                            }
                        }
                        chessboards[blackKingCoordinates.Item1].Table[row][col].Piece.possibleMoves.Clear();
                    }


                }
            }

            this.check = flag;
            return flag;
        }

        public Boolean checkWhiteKing()
        {
            var flag = false;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (chessboards[whiteKingCoordinates.Item1].Table[row][col].containsPiece())
                    {
                        chessboards[whiteKingCoordinates.Item1].Table[row][col].Piece.computePossibleMoves(Game.chessboards[whiteKingCoordinates.Item1]);
                        foreach (var move in chessboards[whiteKingCoordinates.Item1].Table[row][col].Piece.possibleMoves)
                        {
                            if (move.Equals(whiteKingCoordinates))
                            {
                                flag = true;
                            }
                        }
                        chessboards[whiteKingCoordinates.Item1].Table[row][col].Piece.possibleMoves.Clear();
                    }


                }
            }

            this.check = flag;
            return flag;
        }

    }
}
