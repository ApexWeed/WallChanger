using System.Collections.Generic;
using System.Windows.Forms;

namespace WallChanger.Layout
{
    public class LayoutEngine
    {
        List<LayoutItem> LayoutItems;
        Control Container;

        public enum Anchor
        {
            Centre,
            Left,
            Right
        }

        public Padding Padding;
        public bool UpdateContainerSize;

        public LayoutEngine(Control Container)
        {
            LayoutItems = new List<LayoutItem>();
            this.Container = Container;
            this.UpdateContainerSize = false;
        }

        public void ClearLayout()
        {
            LayoutItems.Clear();
        }

        public void AddControl(Control Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.GenericControl, Control = Control });
        }

        public LayoutEndStub BeginGroupBox(GroupBox GroupBox)
        {
            LayoutItems.Add(new LayoutItem { Control = GroupBox, ItemType = LayoutItem.Type.BeginGroupBox });
            return new LayoutEndStub(this, LayoutEndStub.StubType.GroupBox);
        }

        public void EndGroupBox()
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.EndGroupBox });
        }

        public LayoutEndStub BeginRow()
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.BeginRow });
            return new LayoutEndStub(this, LayoutEndStub.StubType.Row);
        }

        public void EndRow()
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.EndRow });
        }

        public void SkipColumns(int Count = 1)
        {
            for (int i = 0; i < Count; i++)
            { 
                LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Column });
            }
        }

        public void SetAnchor(Anchor Side)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Anchor, Data = Side });
        }

        public void OffsetX(int X)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.OffsetX, Data = X });
        }

        public void OffsetY(int Y)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.OffsetY, Data = Y });
        }

        public void ProcessLayout()
        {
            var index = 0;
            var currentState = new LayoutState
            {
                Width = Container.DisplayRectangle.Width - Padding.Horizontal,
                Height = Container.DisplayRectangle.Height - Padding.Vertical,
                XOffset = Padding.Left,
                YOffset = Padding.Top,
                Anchor = Anchor.Left,
                Controls = Container.Controls
            };

            for (; index < LayoutItems.Count; index++)
            {
                switch (LayoutItems[index].ItemType)
                {
                    case LayoutItem.Type.BeginRow:
                        ProcessRow(ref index, ref currentState);
                        break;
                    case LayoutItem.Type.Column:
                    case LayoutItem.Type.Label:
                    case LayoutItem.Type.TextBox:
                    case LayoutItem.Type.Button:
                    case LayoutItem.Type.CheckBox:
                    case LayoutItem.Type.RadioButton:
                    case LayoutItem.Type.ComboBox:
                    case LayoutItem.Type.PictureBox:
                    case LayoutItem.Type.GenericControl:
                        ProcessControl(ref index, ref currentState);
                        break;
                    case LayoutItem.Type.BeginGroupBox:
                        ProcessGroupBox(ref index, ref currentState);
                        break;
                    case LayoutItem.Type.Anchor:
                        currentState.Anchor = (Anchor)LayoutItems[index].Data;
                        break;
                    case LayoutItem.Type.OffsetX:
                        currentState.XOffset += (int)LayoutItems[index].Data;
                        break;
                    case LayoutItem.Type.OffsetY:
                        currentState.YOffset += (int)LayoutItems[index].Data;
                        break;
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                    default:
                        MessageBox.Show($"Error with layout engine, unexpected '{LayoutItems[index].ItemType}' in {nameof(ProcessLayout)}().");
                        break;
                }
            }

            if (UpdateContainerSize)
            {
                Container.Height = currentState.YOffset - currentState.LastYSpacing + Container.Height - Container.DisplayRectangle.Height + Padding.Bottom;
            }
        }

        private void ProcessControl(ref int Index, ref LayoutState CurrentState)
        {
            // TODO: process controls differently based on type.
            if (LayoutItems[Index].ItemType == LayoutItem.Type.Column)
            {
                return;
            }
            var control = LayoutItems[Index].Control;
            control.Left = CurrentState.XOffset;
            control.Top = CurrentState.YOffset;
            control.Width = CurrentState.Width;
            //control.Height = 20;
            CurrentState.Controls.Add(control);
            CurrentState.YOffset += control.Height + Padding.Bottom;
            CurrentState.LastYSpacing = Padding.Bottom;
            CurrentState.LastXSpacing = 0;
        }

        private void ProcessGroupBox(ref int Index, ref LayoutState CurrentState)
        {
            var groupBox = (GroupBox)LayoutItems[Index].Control;
            groupBox.Left = CurrentState.XOffset;
            groupBox.Top = CurrentState.YOffset;
            groupBox.Width = CurrentState.Width;
            groupBox.Height = 50;
            CurrentState.Controls.Add(groupBox);
            Index++;

            // Create a new state for the children of the group box.
            var groupBoxState = new LayoutState
            {
                Width = groupBox.ClientSize.Width - Padding.Horizontal - 2,
                Height = groupBox.ClientSize.Height - Padding.Vertical - 2,
                XOffset = Padding.Left + 1,
                YOffset = Padding.Top + 10 + 1,
                Anchor = CurrentState.Anchor,
                Controls = groupBox.Controls
            };
            // Continue processing items until we find an EndGroupBox item.
            for (; Index < LayoutItems.Count; Index++)
            {
                // Finalise group box and yield control to parent item.
                if (LayoutItems[Index].ItemType == LayoutItem.Type.EndGroupBox)
                {
                    break;
                }
                switch (LayoutItems[Index].ItemType)
                {
                    case LayoutItem.Type.BeginRow:
                        ProcessRow(ref Index, ref groupBoxState);
                        break;
                    case LayoutItem.Type.Column:
                    case LayoutItem.Type.Label:
                    case LayoutItem.Type.TextBox:
                    case LayoutItem.Type.Button:
                    case LayoutItem.Type.CheckBox:
                    case LayoutItem.Type.RadioButton:
                    case LayoutItem.Type.ComboBox:
                    case LayoutItem.Type.PictureBox:
                    case LayoutItem.Type.GenericControl:
                        ProcessControl(ref Index, ref groupBoxState);
                        break;
                    case LayoutItem.Type.BeginGroupBox:
                        ProcessGroupBox(ref Index, ref groupBoxState);
                        break;
                    case LayoutItem.Type.Anchor:
                        groupBoxState.Anchor = (Anchor)LayoutItems[Index].Data;
                        break;
                    case LayoutItem.Type.OffsetX:
                        groupBoxState.XOffset += (int)LayoutItems[Index].Data;
                        break;
                    case LayoutItem.Type.OffsetY:
                        groupBoxState.YOffset += (int)LayoutItems[Index].Data;
                        break;
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                    default:
                        MessageBox.Show($"Error with layout engine, unexpected '{LayoutItems[Index].ItemType}' in {nameof(ProcessGroupBox)}().");
                        break;
                }
            }

            // Notify the parent of the changes to the state.
            groupBox.Height = groupBoxState.YOffset + 7 - groupBoxState.LastYSpacing;
            CurrentState.YOffset += groupBox.Height + Padding.Horizontal;
            CurrentState.LastYSpacing = Padding.Horizontal;
            CurrentState.LastXSpacing = 0;
        }

        private void ProcessRow(ref int Index, ref LayoutState CurrentState)
        {
            // Loop until the matching EndRow() is found and count the columns.
            Index++;
            var oldIndex = Index;
            var columns = 0;
            var currentRecursionLevel = 1;

            while (currentRecursionLevel > 0 && Index < LayoutItems.Count)
            {
                switch (LayoutItems[Index].ItemType)
                {
                    case LayoutItem.Type.BeginRow:
                        currentRecursionLevel++;
                        break;
                    case LayoutItem.Type.Column:
                    case LayoutItem.Type.Label:
                    case LayoutItem.Type.TextBox:
                    case LayoutItem.Type.Button:
                    case LayoutItem.Type.CheckBox:
                    case LayoutItem.Type.RadioButton:
                    case LayoutItem.Type.ComboBox:
                    case LayoutItem.Type.PictureBox:
                    case LayoutItem.Type.GenericControl:
                        columns++;
                        break;
                    case LayoutItem.Type.BeginGroupBox:
                        columns++;
                        currentRecursionLevel++;
                        break;
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                        currentRecursionLevel--;
                        break;
                    case LayoutItem.Type.Anchor:
                    case LayoutItem.Type.OffsetX:
                    case LayoutItem.Type.OffsetY:
                    default:
                        break;
                }
                Index++;
            }
            Index = oldIndex;

            // Split the width into n columns and process items.
            var currentColumn = 0;
            var maxOffset = 0;
            if (columns == 0)
            {
                return;
            }
            var columnState = new LayoutState
            {
                Width = (CurrentState.Width) / columns,
                Height = CurrentState.Height,
                Anchor = CurrentState.Anchor,
                Controls = CurrentState.Controls
            };
            for (; Index < LayoutItems.Count; Index++)
            {
                // Finalise group box and yield control to parent item.
                if (LayoutItems[Index].ItemType == LayoutItem.Type.EndRow)
                {
                    break;
                }
                switch (LayoutItems[Index].ItemType)
                {
                    case LayoutItem.Type.BeginRow:
                        columnState.XOffset = Padding.Left + columnState.Width * currentColumn;
                        columnState.YOffset = Padding.Top;
                        ProcessRow(ref Index, ref columnState);
                        currentColumn++;
                        if (columnState.YOffset > maxOffset)
                        {
                            maxOffset = columnState.YOffset;
                        }
                        columnState.Anchor = CurrentState.Anchor;
                        break;
                    case LayoutItem.Type.Column:
                    case LayoutItem.Type.Label:
                    case LayoutItem.Type.TextBox:
                    case LayoutItem.Type.Button:
                    case LayoutItem.Type.CheckBox:
                    case LayoutItem.Type.RadioButton:
                    case LayoutItem.Type.ComboBox:
                    case LayoutItem.Type.PictureBox:
                    case LayoutItem.Type.GenericControl:
                        columnState.XOffset = CurrentState.XOffset + columnState.Width * currentColumn;
                        columnState.YOffset = CurrentState.YOffset;
                        ProcessControl(ref Index, ref columnState);
                        currentColumn++;
                        if (columnState.YOffset > maxOffset)
                        {
                            maxOffset = columnState.YOffset;
                        }
                        columnState.Anchor = CurrentState.Anchor;
                        break;
                    case LayoutItem.Type.BeginGroupBox:
                        columnState.XOffset = (Padding.Horizontal + columnState.Width) * currentColumn;
                        columnState.YOffset = Padding.Top;
                        ProcessGroupBox(ref Index, ref columnState);
                        currentColumn++;
                        if (columnState.YOffset > maxOffset)
                        {
                            maxOffset = columnState.YOffset;
                        }
                        columnState.Anchor = CurrentState.Anchor;
                        break;
                    case LayoutItem.Type.Anchor:
                        columnState.Anchor = (Anchor)LayoutItems[Index].Data;
                        break;
                    case LayoutItem.Type.OffsetX:
                        columnState.XOffset += (int)LayoutItems[Index].Data;
                        break;
                    case LayoutItem.Type.OffsetY:
                        columnState.YOffset += (int)LayoutItems[Index].Data;
                        break;
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                    default:
                        MessageBox.Show($"Error with layout engine, unexpected '{LayoutItems[Index].ItemType}' in {nameof(ProcessRow)}().");
                        break;
                }
            }

            // Notify parent of the changes to the state.
            CurrentState.YOffset = maxOffset;
            CurrentState.LastXSpacing = 0;
            CurrentState.LastYSpacing = columnState.LastYSpacing;
        }
    }
}
