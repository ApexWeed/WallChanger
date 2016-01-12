using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LanguageEditor
{
    public class ColourableTreeView : TreeView
    {
        public enum ColourMode
        {
            None,
            Primary,
            Secondary,
            Tertiary
        }

        public class ColourableNode
        {
            ColourMode ColourMode;
            object Data;
        }

        [Description("The primary colour.")]
        [Category(nameof(Appearance))]
        [DefaultValue(typeof(Color), "Lime")]
        public Color PrimaryColour
        {
            get { return primaryColour; }
            set { primaryColour = value; }
        }
        private Color primaryColour = Color.Lime;

        [Description("The secondary colour.")]
        [Category(nameof(Appearance))]
        [DefaultValue(typeof(Color), "Red")]
        public Color SecondaryColour
        {
            get { return secondaryColour; }
            set { secondaryColour = value; }
        }
        private Color secondaryColour = Color.Red;

        [Description("The tertiary colour.")]
        [Category(nameof(Appearance))]
        [DefaultValue(typeof(Color), "Blue")]
        public Color TertiaryColour
        {
            get { return tertiaryColour; }
            set { tertiaryColour = value; }
        }
        private Color tertiaryColour = Color.Blue;

        [Description("Default colour to use when the node tag doesn't contain one.")]
        [Category(nameof(Appearance))]
        [DefaultValue(typeof(ColourMode), "None")]
        public ColourMode DefaultColourMode
        {
            get { return defaultColourMode; }
            set { defaultColourMode = value; }
        }
        private ColourMode defaultColourMode = ColourMode.None;

        [Description("Whether to emphasise text when the node tag doesn't specify.")]
        [Category(nameof(Appearance))]
        [DefaultValue(false)]
        public bool EmphasisByDefault
        {
            get { return emphasisByDefault; }
            set { emphasisByDefault = value; }
        }
        private bool emphasisByDefault;

        [Description("The font to use for emphasised text.")]
        [Category(nameof(Appearance))]
        [DefaultValue(typeof(Font), "MS UI Gothic, 9pt, style=Italic")]
        public Font EmphasisFont
        {
            get { return emphasisFont; }
            set { emphasisFont = value; }
        }
        private Font emphasisFont = new Font(new FontFamily("MS UI Gothic"), 9, FontStyle.Italic);

        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            // Ignore text colour in designer mode.
            if (DesignMode)
            {
                TextRenderer.DrawText(e.Graphics, this.Name, Font, e.Node.Bounds, ForeColor);
            }
            else
            {
                var mode = DefaultColourMode;
                var emphasise = EmphasisByDefault;
                // Find the mode and emphasis settings through reflection.
                if (e.Node.Tag != null)
                {
                    var fields = e.Node.Tag.GetType().GetFields();
                    foreach (var field in fields)
                    {
                        if (field.Name == nameof(ColourMode))
                        {
                            mode = (ColourMode)field.GetValue(e.Node.Tag);
                        }
                        if (field.Name == "Emphasise")
                        {
                            emphasise = (bool)field.GetValue(e.Node.Tag);
                        }
                    }
                }

                // Text bounds.
                var bounds = new Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height);

                // Draw text.
                switch (mode)
                {
                    case ColourMode.None:
                        {
                            if (emphasise)
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, EmphasisFont, e.Node.Bounds, ForeColor);
                            }
                            else
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Node.Bounds, ForeColor);
                            }
                            break;
                        }
                    case ColourMode.Primary:
                        {
                            if (emphasise)
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, EmphasisFont, e.Node.Bounds, PrimaryColour);
                            }
                            else
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Node.Bounds, PrimaryColour);
                            }
                            break;
                        }
                    case ColourMode.Secondary:
                        {
                            if (emphasise)
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, EmphasisFont, e.Node.Bounds, SecondaryColour);
                            }
                            else
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Node.Bounds, SecondaryColour);
                            }
                            break;
                        }
                    case ColourMode.Tertiary:
                        {
                            if (emphasise)
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, EmphasisFont, e.Node.Bounds, TertiaryColour);
                            }
                            else
                            {
                                TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Node.Bounds, TertiaryColour);
                            }
                            break;
                        }
                }
            }
            
            base.OnDrawNode(e);
        }

        public new void Dispose()
        {
            base.Dispose();
            emphasisFont.Dispose();
        }
    }
}
