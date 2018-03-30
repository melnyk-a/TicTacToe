using System.Collections.Generic;

namespace TicTacToe
{
    class Command
    {
        private IMove _receiver;
        protected Stack<char[]> _history = new Stack<char[]>();
        public Command(IMove move)
        {
            _receiver = move;
        }
        public string Name { get => _receiver.Name; }
        public char[] AddNewMove(char[] spaces)
        {
            SaveHistory(spaces);
            int nextMove;
            do
            {
                nextMove = _receiver.GetNewMove(spaces.Length);
            } while (spaces[nextMove] != ' ');
            spaces[nextMove] = _receiver.Symbol; ;

            return spaces;
        }
        public char[] Undo()
        {
            return _history.Count != 0 ? _history.Pop() : null;
        }
        private void SaveHistory(char[] history)
        {
            char[] histroryArray = new char[history.Length];
            history.CopyTo(histroryArray, 0);
            _history.Push(histroryArray);
        }
    }
}
