using Janggi.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janggi.Players
{
    //ColorRed
    public class Computer : Player
    {//
        private Player enemy;
        private static int DEPTH = 1;
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
                //Random random = new Random();
                //Piece piece = this.pieces[random.Next(0, Convert.ToInt32(pieces.Count))];
                //while (piece.getListOfPossibleChanges().Count == 1 || piece.getListOfPossibleChanges().Count == 0)
                //{
                //    piece = this.pieces[random.Next(0, Convert.ToInt32(pieces.Count))];
                //}

                //Tuple<int, int> move = piece.getListOfPossibleChanges()[random.Next(0, Convert.ToInt32(piece.getListOfPossibleChanges().Count))];
                //while (move.Item1 == piece.getLine() && move.Item2 == piece.getColumn())
                //{
                //    move = piece.getListOfPossibleChanges()[random.Next(0, Convert.ToInt32(piece.getListOfPossibleChanges().Count))];
                //}
                //window_form.board[move.Item1, move.Item2].movePiece(piece);
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

            List<Box[,]> possibleBoards = new List<Box[,]>(); //keeps track of the possible boards (boards with the possible moves made on them)
            List<Tuple<Tuple<int, int>, Tuple<int, int>>> moves = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            foreach (Piece piece in getPieces())
            {
                if (piece.getListOfPossibleChanges().Count > 1)
                {
                    Tuple<int, int> change2 = new Tuple<int, int>(piece.getLine(), piece.getColumn());
                    foreach (Tuple<int, int> change1 in piece.getListOfPossibleChanges())
                    {
                        if (window_form.board[change1.Item1, change1.Item2].getPiece() != piece)
                        {
                            moves.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(change1, change2));
                            Box[,] successorBoard = newBoard(window_form.board);
                            //window_form.notification.Items.Add("makeMove nu e buba la new");
                            successorBoard[change1.Item1, change1.Item2].movePiece(successorBoard[change2.Item1, change2.Item2].getPiece());
                            possibleBoards.Add(successorBoard);
                        }

                    }
                }
            }
            bestMove = moves[0];
            bestMoveScore = evaluatePosition(possibleBoards[0], Int32.MinValue, Int32.MaxValue, DEPTH, PieceColor.BLUE);
            if (numTurns > 0)
            {
                for (int i = 1; i < possibleBoards.Count; i++)
                {
                    int j = evaluatePosition(possibleBoards[i], Int32.MinValue, Int32.MaxValue, DEPTH, PieceColor.BLUE);
                    if (j >= bestMoveScore)
                    {
                        bestMove = moves[i];
                        bestMoveScore = j;
                    }
                }
            }
            else
            {
                Random generator = new Random();
                int index = generator.Next(moves.Count);
                bestMove = moves[index];
            }
            window_form.board[bestMove.Item1.Item1, bestMove.Item1.Item2].movePiece(window_form.board[bestMove.Item2.Item1, bestMove.Item2.Item2].getPiece());
        }
        public int evaluatePosition(Box[,] board, int alpha, int beta, int depth, PieceColor color)
        {
            if (depth == 0)
            {
                return evaluate(board);
            }
            List<Tuple<Tuple<int, int>, Tuple<int, int>>> moves = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            if (color == PieceColor.BLUE)
            {
                foreach (Piece piece in enemy.getPieces())
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

                    if (move.Item1.Item1 != move.Item2.Item1 && move.Item1.Item2 != move.Item2.Item1)
                    {
                        Box[,] successorBoard = newBoard(board);
                        successorBoard[move.Item1.Item1, move.Item1.Item2].movePiece(successorBoard[move.Item2.Item1, move.Item2.Item2].getPiece());
                        newBeta = Math.Min(newBeta, evaluatePosition(successorBoard, alpha, beta, depth - 1, PieceColor.RED));
                        if (newBeta <= alpha)
                            break;
                    }

                }
                return newBeta;

            }
            else
            {
                foreach (Piece piece in getPieces())
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
                    if (move.Item1.Item1 != move.Item2.Item1 && move.Item1.Item2 != move.Item2.Item1)
                    {
                        Box[,] successorBoard = newBoard(board);
                        successorBoard[move.Item1.Item1, move.Item1.Item2].movePiece(successorBoard[move.Item2.Item1, move.Item2.Item2].getPiece());
                        newAlpha = Math.Max(newAlpha, evaluatePosition(successorBoard, alpha, beta, depth - 1, PieceColor.RED));
                        if (beta <= newAlpha)
                            break;
                    }

                }
                return newAlpha;
            }
            return 0;
        }
        private Box[,] newBoard(Box[,] board)
        {
            Box[,] boardAux = new Box[10, 9];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boardAux[i, j] = new Box(board[i, j]);
                    //boardAux[i,j].Visible = false;
                }
            }
            return boardAux;
        }
        private int evaluate(Box[,] board)
        {
            int redScore = 0;
            int blueScore = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Piece piece = board[i, j].getPiece();
                    if (piece != null )
                    {
                        if (piece.GetType() != typeof(King))
                        {
                            if (piece.getPieceColor() == PieceColor.RED)
                            {
                                redScore = redScore + piece.getValue();
                            }
                            else
                            {
                                blueScore = blueScore + piece.getValue();
                            }
                        }
                    }
                }
            }

            return redScore - blueScore;//calculator maxim pentru red,minim pentru red
        }
    }
}
