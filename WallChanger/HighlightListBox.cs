using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallChanger
{
    public class HighlightListBox : ListBox
    {
        public enum HighlightMode_
        {
            Bold,
            Italic,
            Foreground,
            Background,
            None
        }

        [Description("Colour to use if HighlightMode is set to Foreground or Background.")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "LightBlue")]
        public Color HighlightColour
        {
            get { return highlightColour; }
            set { highlightColour = value; }
        }
        private Color highlightColour = Color.LightBlue;

        [Description("Mode to use when highlighting items.")]
        [Category("Appearance")]
        [DefaultValue(typeof(HighlightMode_), "Background")]
        public HighlightMode_ HighlightMode
        {
            get { return highlightMode; }
            set { highlightMode = value; }
        }
        private HighlightMode_ highlightMode = HighlightMode_.Background;

        private Color selectedBackColour = Color.FromArgb(051, 153, 255);
        private Color selectedForeColour = Color.White;

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (DesignMode)
            {
                base.OnMeasureItem(e);
            }
            else
            {
                switch (HighlightMode)
                {
                    case HighlightMode_.Bold:
                        e.ItemWidth = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold)).Width;
                        e.ItemHeight = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold)).Height;
                        break;
                    case HighlightMode_.Italic:
                        e.ItemWidth = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Italic)).Width;
                        e.ItemHeight = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Italic)).Height;
                        break;
                    default:
                        e.ItemWidth = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), Font).Width;
                        e.ItemHeight = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), Font).Height;
                        break;
                }

                if (e.ItemWidth > HorizontalExtent)
                    HorizontalExtent = e.ItemWidth;
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Brush foreBrush = new SolidBrush(ForeColor);
            Brush backBrush = new SolidBrush(BackColor);
            Brush selectedBackBrush = new SolidBrush(selectedBackColour);
            Brush selectedForeBrush = new SolidBrush(selectedForeColour);
            Brush highlightBrush = new SolidBrush(HighlightColour);

            if (DesignMode)
            {
                e.Graphics.DrawString(this.Name, Font, foreBrush, new Point(0, 0));
            }
            else
            {
                if (Items[e.Index].ToString() == "Archive")
                    return;

                bool Highlight = false;
                var Fields = Items[e.Index].GetType().GetFields();
                foreach (var Field in Fields)
                {
                    if (Field.Name == "Highlight")
                    {
                        Highlight = (bool)Field.GetValue(Items[e.Index]);
                        break;
                    }
                }

                // Text bounds.
                Rectangle textBounds = new Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height);

                if (Highlight)
                {
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        switch (HighlightMode)
                        {
                            case HighlightMode_.Bold:
                                e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold), selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.Italic:
                                e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Italic), selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.Foreground:
                                e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), Font, highlightBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.Background:
                                e.Graphics.FillRectangle(highlightBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), Font, selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.None:
                                e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), Font, selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                break;
                        }
                    }
                    else
                    {
                        switch (HighlightMode)
                        {
                            case HighlightMode_.Bold:
                                e.Graphics.FillRectangle(backBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold), foreBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.Italic:
                                e.Graphics.FillRectangle(backBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Italic), foreBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.Foreground:
                                e.Graphics.FillRectangle(backBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), Font, highlightBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.Background:
                                e.Graphics.FillRectangle(highlightBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), Font, foreBrush, textBounds, StringFormat.GenericDefault);
                                break;
                            case HighlightMode_.None:
                                e.Graphics.FillRectangle(backBrush, e.Bounds);
                                e.Graphics.DrawString(Items[e.Index].ToString(), Font, foreBrush, textBounds, StringFormat.GenericDefault);
                                break;
                        }
                    }
                }
                else
                {
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                        e.Graphics.DrawString(Items[e.Index].ToString(), Font, selectedForeBrush, textBounds, StringFormat.GenericDefault);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(backBrush, e.Bounds);
                        e.Graphics.DrawString(Items[e.Index].ToString(), Font, foreBrush, textBounds, StringFormat.GenericDefault);
                    }
                }
                

                // Such focus.
                e.DrawFocusRectangle();
            }

            foreBrush.Dispose();
            backBrush.Dispose();
            base.OnDrawItem(e);
        }
    }
}
