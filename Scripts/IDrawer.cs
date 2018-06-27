namespace DH.Drawing
{
    public interface IDrawer
    {
        Line CurrentLine { get; set; }
        LineProperty LineProperty { get; set; }
        bool StartDrawing();
        bool StopDrawing();
        bool IsActive { get; set; }
        LineFactory LineFactory { get; set; }
    }
    

}