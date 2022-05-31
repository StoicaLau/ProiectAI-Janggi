using Janggi.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Players
{
    //ColorRed
    public class Computer : Player
    {//
        private Player enemy;
        private static int DEPTH = 2;
        private int numTurns;
        public Computer(PieceColor pieceColor, int direction)
        {
            numTurns = 0;
            this.pieceColor = pieceColor;
            this.direction = direction;
            enemy = window_form.players[0];
        }
        public override void turn(bool enable)
        {
            if (enable == true)
            {
               
                makeMove();

                window_form.players[window_form.turnOfPlayer].turn(false);
                window_form.turnOfPlayer = (window_form.turnOfPlayer + 1) % 2;
                window_form.players[window_form.turnOfPlayer].turn(true);

            }
            else
            {
                king.enableMove(enable);
                foreach (Piece piece in pieces)
                {
                    piece.resetSpecialChange();
                    piece.enableMove(enable);

                }
            }

        }
        private void makeMove()
        {
            int bestMoveScore; //score of that best move
            Tuple<Tuple<int, int>, Tuple<int, int>> bestMove;
            Tuple<Tuple<int, int>, Tuple<int, int>> bestMoveInit;
            List<Box[,]> possibleBoards = new List<Box[,]>(); //keeps track of the possible boards (boards with the possible moves made on them)
            List<Tuple<Tuple<int, int>, Tuple<int, int>>> moves = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            List<List<Piece>> redPiecesList=new List<List<Piece>>();
            List<List<Piece>> bluePiecesList = new List<List<Piece>>();
            //la el
            List<Piece> redPiece = new List<Piece>();
            List<Piece> bluePiece = new List<Piece>();
            foreach (Tuple<int, int> change1 in king.getListOfPossibleChanges())
            {
                Tuple<int, int> change2 = new Tuple<int, int>(king.getLine(), king.getColumn());
                if (window_form.board[change1.Item1, change1.Item2].getPiece() != king)
                {
                   redPiece = new List<Piece>();
                   bluePiece = new List<Piece>();
                    moves.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(change1, change2));
                    Box[,] successorBoard = newBoard(window_form.board,redPiece,bluePiece);
                    //window_form.notification.Items.Add("makeMove nu e buba la new");
                    successorBoard[change1.Item1, change1.Item2].movePiece(successorBoard[change2.Item1, change2.Item2].getPiece(),bluePiece,redPiece);//e bine asa
                    possibleBoards.Add(successorBoard);
                    redPiecesList.Add(redPiece);
                    bluePiecesList.Add(bluePiece);
                }
            }
            foreach (Piece piece in getPieces())
            {
                if (piece.getListOfPossibleChanges().Count > 1)
                {
                    Tuple<int, int> change2 = new Tuple<int, int>(piece.getLine(), piece.getColumn());
                    foreach (Tuple<int, int> change1 in piece.getListOfPossibleChanges())
                    {
                        if (window_form.board[change1.Item1, change1.Item2].getPiece() != piece)
                        {
                             redPiece = new List<Piece>();
                             bluePiece = new List<Piece>();
                            moves.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(change1, change2));
                            Box[,] successorBoard = newBoard(window_form.board,redPiece,bluePiece);
                            //window_form.notification.Items.Add("makeMove nu e buba la new");
                            successorBoard[change1.Item1, change1.Item2].movePiece(successorBoard[change2.Item1, change2.Item2].getPiece(), bluePiece, redPiece);//e bine
                            possibleBoards.Add(successorBoard);
                            redPiecesList.Add(redPiece);
                            bluePiecesList.Add(bluePiece);
                        }

                    }
                }
            }

            bestMove = moves[0];
            bestMoveInit = moves[0];
            redPiece = redPiecesList[0];
            bluePiece = bluePiecesList[0];

            bestMoveScore = evaluatePosition(possibleBoards[0], Int32.MinValue, Int32.MaxValue, DEPTH, PieceColor.BLUE,redPiece,bluePiece);
            if (numTurns > 0)
            {
                for (int i = 1; i < possibleBoards.Count; i++)
                {
                    redPiece = redPiecesList[i];
                    bluePiece = bluePiecesList[i];
                    int j = evaluatePosition(possibleBoards[i], Int32.MinValue, Int32.MaxValue, DEPTH, PieceColor.BLUE,redPiece,bluePiece);
                    if (j > bestMoveScore)
                    {
                        bestMove = moves[i];
                        bestMoveScore = j;
                    }
                }
                //if (bestMove == bestMoveInit)
                //{
                //    numTurns = 0;
                //}


            }
            if(numTurns == 0)
            {
                Random generator = new Random();
                int index = generator.Next(moves.Count);
                bestMove = moves[index];
            }
            numTurns++;
            window_form.notification.Items.Add("Computer " + " move " +  "(" + (bestMove.Item2.Item1 + 1) + "," + Convert.ToChar(97 + bestMove.Item2.Item2) + ") to (" + (bestMove.Item1.Item1 + 1) + "," + Convert.ToChar(97 + bestMove.Item1.Item2) + ")");
            window_form.notification.Refresh();
            window_form.board[bestMove.Item1.Item1, bestMove.Item1.Item2].movePiece(window_form.board[bestMove.Item2.Item1, bestMove.Item2.Item2].getPiece());
        }
        public int evaluatePosition(Box[,] board, int alpha, int beta, int depth, PieceColor color, List<Piece> redPieces,List <Piece> bluePieces )
        {
            if (depth == 0)
            {
                return evaluate(redPieces,bluePieces);
            }
                  
            if (color == PieceColor.BLUE)
            {
                List<Tuple<Tuple<int, int>, Tuple<int, int>>> moves = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();

                foreach (Piece piece in bluePieces)
                {
                    if (piece.getListOfPossibleChanges().Count > 1)
                    {
                        Tuple<int, int> change2 = new Tuple<int, int>(piece.getLine(), piece.getColumn());
                        foreach (Tuple<int, int> change1 in piece.getListOfPossibleChanges())
                        {
                            if (board[change1.Item1, change1.Item2].getPiece() != piece)
                            {
                                moves.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(change1, change2));
                            }
                        }
                    }
                }


                int newBeta = beta;


                foreach (Tuple<Tuple<int, int>, Tuple<int, int>> move in moves)
                {

                    if (move.Item1.Item1 != move.Item2.Item1 && move.Item1.Item2 != move.Item2.Item2)
                    {
                        List<Piece> redPiece = new List<Piece>();
                        List<Piece> bluePiece = new List<Piece>();
                        Box[,] successorBoard = newBoard(board,redPiece,bluePiece);
                        successorBoard[move.Item1.Item1, move.Item1.Item2].movePiece(successorBoard[move.Item2.Item1, move.Item2.Item2].getPiece(),bluePiece,redPiece);
                        //int result = evaluatePosition(successorBoard, alpha, beta, depth - 1, PieceColor.RED, redPiece, bluePiece);
                        newBeta = Math.Min(newBeta, evaluatePosition(successorBoard, alpha, beta, depth - 1, PieceColor.RED,redPiece,bluePiece));
                        

                    }
                    if (newBeta <= alpha)
                        break;

                }
                return newBeta;

            }
            else
            {

                List<Tuple<Tuple<int, int>, Tuple<int, int>>> moves = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
                foreach (Piece piece in redPieces)
                {
                    if (piece.getListOfPossibleChanges().Count > 1)
                    {
                        Tuple<int, int> change2 = new Tuple<int, int>(piece.getLine(), piece.getColumn());
                        foreach (Tuple<int, int> change1 in piece.getListOfPossibleChanges())
                        {
                            if (board[change1.Item1, change1.Item2].getPiece() != piece)
                            {
                                moves.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(change1, change2));
                            }
                        }
                    }
                }


                int newAlpha = alpha;


                foreach (Tuple<Tuple<int, int>, Tuple<int, int>> move in moves)
                {
                    if (move.Item1.Item1 != move.Item2.Item1 && move.Item1.Item2 != move.Item2.Item2)
                    {
                        List<Piece> redPiece = new List<Piece>();
                        List<Piece> bluePiece = new List<Piece>();
                        Box[,] successorBoard = newBoard(board,redPiece,bluePiece);
                        successorBoard[move.Item1.Item1, move.Item1.Item2].movePiece(successorBoard[move.Item2.Item1, move.Item2.Item2].getPiece(),bluePiece,redPiece);
                        newAlpha = Math.Max(newAlpha, evaluatePosition(successorBoard, alpha, beta, depth - 1, PieceColor.BLUE,redPiece,bluePiece));
                        //int resultAlpha = evaluatePosition(successorBoard, alpha, beta, depth - 1, PieceColor.BLUE, redPiece, bluePiece);
                       

                    }
                    if (beta <= newAlpha)
                        break;
                }
                return newAlpha;
            }
            return 0;
        }
        private Box[,] newBoard(Box[,] board, List<Piece> redPiece, List<Piece> bluePiece)
        {
            Box[,] boardAux = new Box[10, 9];
            Piece kingRed=new Piece();
            Piece guard1Red=null;
            Piece guard2Red=null;
            Piece kingBlue= new Piece();
            Piece guard1Blue=null;
            Piece guard2Blue=null;

            for (int i =0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boardAux[i, j] = new Box(board[i, j]);
                    if (boardAux[i, j].getPiece() != null)
                    {
                        if (boardAux[i, j].getPiece().getPieceColor() == PieceColor.RED)
                        {
                            redPiece.Add(boardAux[i, j].getPiece());
                            if (boardAux[i, j].getPiece().GetType() == typeof(King))
                            {
                                kingRed = boardAux[i, j].getPiece();
                            }
                            else
                            {
                                if (boardAux[i, j].getPiece().GetType() == typeof(Guard))
                                {
                                    if (guard1Red == null)
                                    {
                                        guard1Red = boardAux[i, j].getPiece();
                                    }
                                    else
                                    {
                                        guard2Red = boardAux[i, j].getPiece();
                                    }
                                }
                            }
                        }
                        else
                        {
                            bluePiece.Add(boardAux[i, j].getPiece());
                            if (boardAux[i, j].getPiece().GetType() == typeof(King))
                            {
                                kingBlue = boardAux[i, j].getPiece();
                            }
                            else
                            {
                                if (boardAux[i, j].getPiece().GetType() == typeof(Guard))
                                {
                                    if (guard1Blue == null)
                                    {
                                        guard1Blue = boardAux[i, j].getPiece();
                                    }
                                    else
                                    {
                                        guard2Blue = boardAux[i, j].getPiece();
                                    }
                                }
                            }

                        }
                    }

                    //boardAux[i,j].Visible = false;
                }
               
            }
            if (kingBlue != null)
            {
                kingRed.setLimit(boardAux[1, 4]);
            }
            if (guard1Red != null)
            {
                guard1Red.setLimit(boardAux[1, 4]);
            }
            if (guard2Red != null)
            {
                guard2Red.setLimit(boardAux[1, 4]);
            }
            if (kingBlue != null)
            {
                kingBlue.setLimit(boardAux[8, 4]);
            }
            if (guard1Blue != null)
            {
                guard1Blue.setLimit(boardAux[8, 4]);
            }
            if (guard2Blue != null)
            {
                guard2Blue.setLimit(boardAux[8, 4]);
            }
            
            
            
            return boardAux;
        }
        private int evaluate(List<Piece> redPiece, List<Piece> bluePiece)
        {
            int redScore = 0;
            int blueScore = 0;
            foreach (Piece piece in redPiece)
            {
                redScore = redScore + piece.getValue();
            }
            foreach (Piece piece in bluePiece)
            {
                blueScore = blueScore + piece.getValue();
            }

            return redScore - blueScore;//calculator maxim pentru red,minim pentru red
        }
    }
}
