namespace TicTacToe
{
    interface IMove
    {
        string Name { get; }
        char Symbol { get; }
        int GetNewMove(int maxLength);
    }
}
