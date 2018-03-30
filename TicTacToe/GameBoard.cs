using System;

namespace TicTacToe
{
    class GameBoard
    {
        private int[,] _winSequences = { { 0, 1, 2 },
                                         { 3, 4, 5 },
                                         { 6, 7, 8 },
                                         { 0, 3, 6 },
                                         { 1, 4, 7 },
                                         { 2, 5, 8 },
                                         { 0, 4, 8 },
                                         { 2, 4, 6 }};
        public GameBoard()
        {
            Board = new char[Convert.ToInt32(Math.Pow(Size, 2))];
            Array.Fill(Board, ' ');
        }
        private int Size { get; } = 3;
        public char[] Board
        {
            get;
            set;
        }
        public bool IsEmptyMovesLeft()
        {
            return Array.IndexOf(Board, ' ') != -1;
        }
        public bool IsWinSequencesMatch()
        {
            bool isMatch = false;
            for (int i = 0; i < _winSequences.GetLength(0); ++i)
            {
                for (int j = 0; j < _winSequences.GetLength(1) - 1; ++j)
                {
                    if (Board[_winSequences[i, j]] != ' ')
                    {
                        isMatch = Board[_winSequences[i, j]] == Board[_winSequences[i, j + 1]];
                        if (!isMatch)
                        {
                            break;
                        }
                    }
                    else
                        break;
                }
                if (isMatch)
                    break;
            }
            return isMatch;
        }
        public void ShowBoard()
        {
            Console.Write("   ");
            for (int i = 0; i < Size; i++)
            {
                Console.Write("  {0} ", i);
            }
            ShowIntermediateLine();
            for (int i = 0; i < Size; i++)
            {
                Console.Write(" {0} |", i);
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(" {0} |", Board[i * Size + j]);
                }
                ShowIntermediateLine();
            }
        }
        private void ShowIntermediateLine()
        {
            Console.WriteLine();
            Console.Write("   +");
            for (int k = 0; k < Size; k++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }
    }
}
