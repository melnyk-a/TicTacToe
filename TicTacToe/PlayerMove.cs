using System;

namespace TicTacToe
{
    class PlayerMove : IMove
    {
        public string Name => "Player";
        public char Symbol => 'X';

        public int GetNewMove(int maxLength)
        {
            int index;
            do
            {
                Console.Write("Enter colum: ");
                int colum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter row: ");
                int row = Convert.ToInt32(Console.ReadLine());
                index = colum * Convert.ToInt32(Math.Sqrt(maxLength)) + row;
            } while (index < 0 || index > maxLength);
            return index;
        }
    }
}
