using System.Windows.Forms;

namespace WallChanger.Layout
{
    public class LayoutState
    {
        public LayoutEngine.Anchor Anchor;
        public int XOffset;
        public int YOffset;
        public int LastXSpacing;
        public int LastYSpacing;
        public int Width;
        public int Height;
        public Control.ControlCollection Controls;
    }
}
