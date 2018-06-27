using System;

namespace DH.Drawing
{
    public class InputReader : IInputReader
    {
        private InputEvent _onDown;
        private InputEvent _onUp;
        private InputEvent _onMove;

        InputEvent IInputReader.OnDown
        {
            get { return _onDown; }
            set { _onDown = value; }
        }

        InputEvent IInputReader.OnUp
        {
            get { return _onUp; }
            set { _onUp = value; }
        }

        InputEvent IInputReader.OnMove
        {
            get { return _onMove; }
            set { _onMove = value; }
        }

        public bool IsActive { get; set; }
    }
}