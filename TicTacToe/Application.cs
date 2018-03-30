using System;

namespace TicTacToe
{
    class Application
    {
        private GameBoard board = new GameBoard();
        private Command _currentCommand;
        private CircleQuene _commandQueue = new CircleQuene();
        public Application()
        {
            _commandQueue.Enqueue(new Command(new PlayerMove()));
            _commandQueue.Enqueue(new Command(new ComputerMove()));
            _currentCommand = _commandQueue.Dequeue();
        }
        public void Run()
        {
            do
            {
                board.ShowBoard();
                Console.WriteLine("Press 'Enter' to do next move and 'ESC' to cancel move");
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.Enter)
                {
                    _currentCommand.AddNewMove(board.Board);
                    if (IsGameOver())
                    {
                        break;
                    }
                }
                else if (pressed.Key == ConsoleKey.Escape)
                {
                    UpdateCommand();
                    char[] historyBoard = _currentCommand.Undo();
                    if (historyBoard != null)
                    {
                        board.Board = historyBoard;
                        UpdateCommand();
                    }
                }
                else
                {
                    Console.Clear();
                    continue;
                }
                UpdateCommand();
                Console.Clear();
            } while (true);
        }
        private void UpdateCommand()
        {
            _currentCommand = _commandQueue.Dequeue();
        }
        private bool IsGameOver()
        {
            bool isGameOver = true;
            if (!board.IsEmptyMovesLeft())
            {
                Console.WriteLine("Friendship win!");
                return isGameOver;
            }
            if (board.IsWinSequencesMatch())
            {
                Console.Clear();
                board.ShowBoard();
                Console.WriteLine(_currentCommand.Name + " win");
                return isGameOver;
            }
            isGameOver = false;

            return isGameOver;
        }
    }
}
