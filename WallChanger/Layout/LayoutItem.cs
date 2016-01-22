using System.Windows.Forms;

namespace WallChanger.Layout
{
    public class LayoutItem
    {
        public enum Type
        {
            Control,
            BeginGroupBox,
            EndGroupBox,
            BeginRow,
            EndRow,
            Anchor,
            OffsetX,
            OffsetY,
            ColumnWidth
        }

        public enum ControlType
        {
            Column,
            GenericControl,
            Label,
            TextBox,
            Button,
            CheckBox,
            RadioButton,
            ComboBox,
            PictureBox
        }

        public class ColumnWidth
        {
            public enum WidthType
            {
                None,
                Scalar,
                Absolute
            }

            public float Offset;
            public WidthType Type;
        }

        public Type ItemType;
        public Control Control;
        public object Data;
    }
}
