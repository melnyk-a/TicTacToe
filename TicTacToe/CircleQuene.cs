using System.Collections.Generic;

namespace TicTacToe
{
    class CircleQuene
    {
        private Queue<Command> _queue = new Queue<Command>();
        public Command Dequeue()
        {
            Command command = _queue.Dequeue();
            Enqueue(command);
            return command;
        }
        public void Enqueue(Command command)
        {
            _queue.Enqueue(command);
        }
    }
}
