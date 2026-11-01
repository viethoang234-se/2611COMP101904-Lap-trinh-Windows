namespace COMP1019_Lab08_SimplePaint
{
    /// <summary>Panel bật DoubleBuffered để giảm nhấp nháy khi vẽ.</summary>
    public class DrawSurface : Panel
    {
        public DrawSurface()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
        }
    }
}
