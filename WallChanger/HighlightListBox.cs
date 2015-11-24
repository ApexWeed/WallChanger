using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallChanger
{
    public class HighlightListBox : ListBox
    {
        private Color highlightColour = Color.LightBlue;
        private HighlightMode highlightMode = HighlightMode.Background;

        private readonly Color selectedBackColour = Color.FromArgb(051, 153, 255);
        private readonly Color selectedForeColour = Color.White;
        public enum HighlightMode
        {
            Bold,
            Italic,
            Foreground,
            Background,
            None
        }

#pragma warning disable CC0017 // Use auto property
        [Description("Colour to use if HighlightMode is set to Foreground or Background.")]
#pragma warning restore CC0017 // Use auto property
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "LightBlue")]
        public Color HighlightColour
        {
            get { return highlightColour; }
            set { highlightColour = value; }
        }

#pragma warning disable CC0017 // Use auto property
        [Description("Mode to use when highlighting items.")]
#pragma warning restore CC0017 // Use auto property
        [Category("Appearance")]
        [DefaultValue(typeof(HighlightMode), "Background")]
        public HighlightMode HighlightingMode
        {
            get { return highlightMode; }
            set { highlightMode = value; }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count)
                return;

            if (Items[e.Index].ToString() == "Archive")
                return;

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
                var Highlight = false;
                var Fields = Items[e.Index].GetType().GetFields();
                foreach (var Field in Fields)
                {
                    if (Field.Name == nameof(Highlight))
                    {
                        Highlight = (bool)Field.GetValue(Items[e.Index]);
                        break;
                    }
                }

                // Text bounds.
                var textBounds = new Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height);

                if (Highlight)
                {
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        switch (HighlightingMode)
                        {
                            case HighlightMode.Bold:
                                {
                                    e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                    var font = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), font, selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                    font.Dispose();
                                    break;
                                }
                            case HighlightMode.Italic:
                                {
                                    e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                    var font = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Italic);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), font, selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                    font.Dispose();
                                    break;
                                }
                            case HighlightMode.Foreground:
                                {
                                    e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, highlightBrush, textBounds, StringFormat.GenericDefault);
                                    break;
                                }
                            case HighlightMode.Background:
                                {
                                    e.Graphics.FillRectangle(highlightBrush, e.Bounds);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                    break;
                                }
                            case HighlightMode.None:
                                {
                                    e.Graphics.FillRectangle(selectedBackBrush, e.Bounds);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, selectedForeBrush, textBounds, StringFormat.GenericDefault);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (HighlightingMode)
                        {
                            case HighlightMode.Bold:
                                {
                                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                                    var font = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), font, foreBrush, textBounds, StringFormat.GenericDefault);
                                    font.Dispose();
                                    break;
                                }
                            case HighlightMode.Italic:
                                {
                                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                                    var font = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Italic);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), font, foreBrush, textBounds, StringFormat.GenericDefault);
                                    font.Dispose();
                                    break;
                                }
                            case HighlightMode.Foreground:
                                {
                                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, highlightBrush, textBounds, StringFormat.GenericDefault);
                                    break;
                                }
                            case HighlightMode.Background:
                                {
                                    e.Graphics.FillRectangle(highlightBrush, e.Bounds);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, foreBrush, textBounds, StringFormat.GenericDefault);
                                    break;
                                }
                            case HighlightMode.None:
                                {
                                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, foreBrush, textBounds, StringFormat.GenericDefault);
                                    break;
                                }
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
            selectedForeBrush.Dispose();
            selectedBackBrush.Dispose();
            highlightBrush.Dispose();
            base.OnDrawItem(e);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (DesignMode)
            {
                base.OnMeasureItem(e);
            }
            else
            {
                switch (HighlightingMode)
                {
                    case HighlightMode.Bold:
                        {
                            var font = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Bold);
                            e.ItemWidth = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), font).Width;
                            e.ItemHeight = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), font).Height;
                            font.Dispose();
                            break;
                        }
                    case HighlightMode.Italic:
                        {
                            var font = new Font(Font.FontFamily, Font.SizeInPoints, FontStyle.Italic);
                            e.ItemWidth = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), font).Width;
                            e.ItemHeight = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), font).Height;
                            font.Dispose();
                            break;
                        }
                    default:
                        e.ItemWidth = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), Font).Width;
                        e.ItemHeight = (int)e.Graphics.MeasureString(Items[e.Index].ToString(), Font).Height;
                        break;
                }

                if (e.ItemWidth > HorizontalExtent)
                    HorizontalExtent = e.ItemWidth;
            }
        }
    }
}
