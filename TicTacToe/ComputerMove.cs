using System;

namespace TicTacToe
{
    class ComputerMove : IMove
    {
        Random _random = new Random();
        public string Name => "Computer";
        public char Symbol => 'O';
        public int GetNewMove(int maxLength)
        {
            return _random.Next(0, maxLength);
        }
    }
}
