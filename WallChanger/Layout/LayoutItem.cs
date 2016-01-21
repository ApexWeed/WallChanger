using System.Windows.Forms;

namespace WallChanger.Layout
{
    public class LayoutItem
    {
        public enum Type
        {
            BeginRow,
            EndRow,
            Label,
            TextBox,
            Button,
            CheckBox,
            RadioButton,
            ComboBox,
            PictureBox,
            BeginGroupBox,
            EndGroupBox,
            Column,
            Anchor,
            GenericControl,
            OffsetX,
            OffsetY
        }

        public Type ItemType;
        public Control Control;
        public object Data;
    }
}
