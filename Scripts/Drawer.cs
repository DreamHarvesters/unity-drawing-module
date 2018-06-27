namespace DH.Drawing
{
    public class Drawer : IDrawer
    {

        protected IInputReader inputReader;

        public Drawer(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        public Line CurrentLine { get; set; }
        public LineProperty LineProperty { get; set; }

        public virtual bool StartDrawing()
        {
            return false;
        }

        public virtual bool StopDrawing()
        {
            return false;
        }

        ~Drawer()
        {
            OnLineCreated = null;
        }

        public virtual bool IsActive { get; set; }
        public LineFactory LineFactory { get; set; }
        public LineEvent OnLineCreated { get; set; }
    }
}