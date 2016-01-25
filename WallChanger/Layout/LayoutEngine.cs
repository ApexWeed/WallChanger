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
            Fill,
            Left,
            Right
        }

        /// <summary>
        /// The default anchor setting to use when starting the layout.
        /// </summary>
        public Anchor DefaultAnchor;
        /// <summary>
        /// Whether to update the height of the container after the layout has completed.
        /// </summary>
        public bool UpdateContainerSize;
        /// <summary>
        /// Whether to clear the containers controls before starting layout.
        /// </summary>
        public bool ClearOnProcess;
        /// <summary>
        /// The padding to use for the layout.
        /// </summary>
        public Padding Padding;

        /// <summary>
        /// Initialises a new LayoutEngine.
        /// </summary>
        /// <param name="Container">The container to layout controls into.</param>
        public LayoutEngine(Control Container)
        {
            LayoutItems = new List<LayoutItem>();
            this.Container = Container;
            this.UpdateContainerSize = false;
            this.DefaultAnchor = Anchor.Fill;
            this.ClearOnProcess = false;
        }

        /// <summary>
        /// Clears the current list of layout commands.
        /// </summary>
        public void ClearLayout()
        {
            LayoutItems.Clear();
        }

        /// <summary>
        /// Adds a control to the layout list.
        /// </summary>
        /// <param name="Control">The control to add to the list.</param>
        public void AddControl(Control Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.GenericControl });
        }

        /// <summary>
        /// Adds a label to the layout list.
        /// </summary>
        /// <param name="Control">The label to add to the list.</param>
        public void AddControl(Label Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.Label });
        }

        /// <summary>
        /// Adds a textbox to the layout list.
        /// </summary>
        /// <param name="Control">The textbox to add to the list.</param>
        public void AddControl(TextBox Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.TextBox });
        }

        /// <summary>
        /// Adds a button to the layout list.
        /// </summary>
        /// <param name="Control">The button to add to the list.</param>
        public void AddControl(Button Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.Button });
        }

        /// <summary>
        /// Adds a check box to the layout list.
        /// </summary>
        /// <param name="Control">The check box to add to the list.</param>
        public void AddControl(CheckBox Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.CheckBox });
        }

        /// <summary>
        /// Adds a radio button to the layout list.
        /// </summary>
        /// <param name="Control">The radio button to add to the list.</param>
        public void AddControl(RadioButton Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.RadioButton });
        }

        /// <summary>
        /// Adds a combo box to the layout list.
        /// </summary>
        /// <param name="Control">The control to add to the list.</param>
        public void AddControl(ComboBox Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.ComboBox });
        }

        /// <summary>
        /// Adds a picture box to the layout list.
        /// </summary>
        /// <param name="Control">The picture box to add to the list.</param>
        public void AddControl(PictureBox Control)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Control = Control, Data = LayoutItem.ControlType.PictureBox });
        }

        /// <summary>
        /// Adds a group box and starts layout inside it.
        /// </summary>
        /// <param name="GroupBox">The GroupBox to add.</param>
        /// <returns>A LayoutEndStub to facilitate using (BeginGroupBox()) { } usage.</returns>
        public LayoutEndStub BeginGroupBox(GroupBox GroupBox)
        {
            LayoutItems.Add(new LayoutItem { Control = GroupBox, ItemType = LayoutItem.Type.BeginGroupBox });
            return new LayoutEndStub(this, LayoutEndStub.StubType.GroupBox);
        }

        /// <summary>
        /// Ends the current group box and continues layout one level higher.
        /// </summary>
        public void EndGroupBox()
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.EndGroupBox });
        }

        /// <summary>
        /// Adds a row and starts layout inside it.
        /// </summary>
        /// <returns>A LayoutEndStub to facilitate using (BeginRow()) { } usage.</returns>
        public LayoutEndStub BeginRow()
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.BeginRow });
            return new LayoutEndStub(this, LayoutEndStub.StubType.Row);
        }

        /// <summary>
        /// Ends the current row and continues layout one level higher.
        /// </summary>
        public void EndRow()
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.EndRow });
        }

        /// <summary>
        /// Skips the specified number of columns within a row.
        /// </summary>
        /// <param name="Count">The number of rows to skip. Defaults to 1.</param>
        public void SkipColumns(int Count = 1)
        {
            for (int i = 0; i < Count; i++)
            { 
                LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Control, Data = LayoutItem.ControlType.Column });
            }
        }

        /// <summary>
        /// Sets the anchor for the controls.
        /// </summary>
        /// <param name="Side">The side to anchor controls to.</param>
        public void SetAnchor(Anchor Side)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.Anchor, Data = Side });
        }

        /// <summary>
        /// Offset the X position of controls.
        /// </summary>
        /// <param name="X">How many pixels to offset by.</param>
        public void OffsetX(int X)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.OffsetX, Data = X });
        }

        /// <summary>
        /// Offset the Y position of controls.
        /// </summary>
        /// <param name="Y">How many pixels to offset by.</param>
        public void OffsetY(int Y)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.OffsetY, Data = Y });
        }

        public void ColumnWidth(float Width, LayoutItem.ColumnWidth.WidthType WidthType = LayoutItem.ColumnWidth.WidthType.Scalar)
        {
            LayoutItems.Add(new LayoutItem { ItemType = LayoutItem.Type.ColumnWidth, Data = new LayoutItem.ColumnWidth { Offset = Width, Type = WidthType } });
        }

        /// <summary>
        /// Adds the previously specified controls to the container.
        /// </summary>
        public void ProcessLayout()
        {
            if (ClearOnProcess)
            {
                Container.Controls.Clear();
            }
            
            // Create state to pass down to children.
            var index = 0;
            var currentState = new LayoutState
            {
                Width = Container.DisplayRectangle.Width - Padding.Horizontal,
                Height = Container.DisplayRectangle.Height - Padding.Vertical,
                XOffset = Padding.Left,
                YOffset = Padding.Top,
                Anchor = DefaultAnchor,
                Controls = Container.Controls
            };

            for (; index < LayoutItems.Count; index++)
            {
                switch (LayoutItems[index].ItemType)
                {
                    case LayoutItem.Type.BeginRow:
                        {
                            ProcessRow(ref index, ref currentState);
                            break;
                        }
                    case LayoutItem.Type.Control:
                        {
                            ProcessControl(ref index, ref currentState);
                            break;
                        }
                    case LayoutItem.Type.BeginGroupBox:
                        {
                            ProcessGroupBox(ref index, ref currentState);
                            break;
                        }
                    case LayoutItem.Type.Anchor:
                        {
                            currentState.Anchor = (Anchor)LayoutItems[index].Data;
                            break;
                        }
                    case LayoutItem.Type.OffsetX:
                        {
                            currentState.XOffset += (int)LayoutItems[index].Data;
                            break;
                        }
                    case LayoutItem.Type.OffsetY:
                        {
                            currentState.YOffset += (int)LayoutItems[index].Data;
                            break;
                        }
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                    default:
                        {
                            MessageBox.Show($"Error with layout engine, unexpected '{LayoutItems[index].ItemType}' in {nameof(ProcessLayout)}().");
                            break;
                        }
                }
            }

            if (UpdateContainerSize)
            {
                Container.Height = currentState.YOffset - currentState.LastYSpacing + Container.Height - Container.DisplayRectangle.Height + Padding.Bottom;
            }
        }

        /// <summary>
        /// Adds a control to the current container.
        /// </summary>
        /// <param name="Index">The index into the list of LayoutItems to get the control from.</param>
        /// <param name="CurrentState">The current state informatiob.</param>
        private void ProcessControl(ref int Index, ref LayoutState CurrentState)
        {
            if ((LayoutItem.ControlType)LayoutItems[Index].Data == LayoutItem.ControlType.Column)
            {
                return;
            }
            // TODO: process controls differently based on type.
            var control = LayoutItems[Index].Control;
            control.Top = CurrentState.YOffset;
            switch (CurrentState.Anchor)
            {
                case Anchor.Fill:
                    {
                        control.Width = CurrentState.Width;
                        control.Left = CurrentState.XOffset;
                        break;
                    }
                case Anchor.Left:
                    {
                        control.Left = CurrentState.XOffset;
                        break;
                    }
                case Anchor.Right:
                    {
                        control.Left = CurrentState.Width - control.Width;
                        break;
                    }
            }
            // Handle any control specific changes to behaviour.
            switch ((LayoutItem.ControlType)LayoutItems[Index].Data)
            {
                case LayoutItem.ControlType.Label:
                    {
                        break;
                    }
                case LayoutItem.ControlType.TextBox:
                    {
                        break;
                    }
                case LayoutItem.ControlType.Button:
                    {
                        break;
                    }
                case LayoutItem.ControlType.CheckBox:
                    {
                        break;
                    }
                case LayoutItem.ControlType.RadioButton:
                    {
                        break;
                    }
                case LayoutItem.ControlType.ComboBox:
                    {
                        break;
                    }
                case LayoutItem.ControlType.PictureBox:
                    {
                        control.Top += 1;
                        break;
                    }
                case LayoutItem.ControlType.GenericControl:
                    {
                        break;
                    }
                case LayoutItem.ControlType.Column:
                    {
                        break;
                    }
                default:
                    {
                        MessageBox.Show($"Error with layout engine, unexpected '{LayoutItems[Index].ItemType}' in {nameof(ProcessControl)}().");
                        break;
                    }
            }
            CurrentState.Controls.Add(control);
            CurrentState.YOffset += control.Height + Padding.Bottom;
            CurrentState.LastYSpacing = Padding.Bottom;
            CurrentState.LastXSpacing = 0;
        }

        /// <summary>
        /// Processes the controls within a group box.
        /// </summary>
        /// <param name="Index">The index into the list of LayoutItems to get the group box from.</param>
        /// <param name="CurrentState">The current state information.</param>
        private void ProcessGroupBox(ref int Index, ref LayoutState CurrentState)
        {
            if (ClearOnProcess)
            {
                Container.Controls.Clear();
            }

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
                        {
                            ProcessRow(ref Index, ref groupBoxState);
                            break;
                        }
                    case LayoutItem.Type.Control:
                        {
                            ProcessControl(ref Index, ref groupBoxState);
                            break;
                        }
                    case LayoutItem.Type.BeginGroupBox:
                        {
                            ProcessGroupBox(ref Index, ref groupBoxState);
                            break;
                        }
                    case LayoutItem.Type.Anchor:
                        {
                            groupBoxState.Anchor = (Anchor)LayoutItems[Index].Data;
                            break;
                        }
                    case LayoutItem.Type.OffsetX:
                        {
                            groupBoxState.XOffset += (int)LayoutItems[Index].Data;
                            break;
                        }
                    case LayoutItem.Type.OffsetY:
                        {
                            groupBoxState.YOffset += (int)LayoutItems[Index].Data;
                            break;
                        }
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                    default:
                        {
                            MessageBox.Show($"Error with layout engine, unexpected '{LayoutItems[Index].ItemType}' in {nameof(ProcessGroupBox)}().");
                            break;
                        }
                }
            }

            // Notify the parent of the changes to the state.
            groupBox.Height = groupBoxState.YOffset + 7 - groupBoxState.LastYSpacing;
            CurrentState.YOffset += groupBox.Height + Padding.Horizontal;
            CurrentState.LastYSpacing = Padding.Horizontal;
            CurrentState.LastXSpacing = 0;
        }

        private class Column
        {
            public int Width;
            public LayoutItem.ColumnWidth DesiredWidth;

            public Column()
            {
                DesiredWidth = new LayoutItem.ColumnWidth();
            }
        }

        /// <summary>
        /// Processes the controls within a row.
        /// </summary>
        /// <param name="Index">The index into the LayoutItems list to get the row from.</param>
        /// <param name="CurrentState">The current state information.</param>
        private void ProcessRow(ref int Index, ref LayoutState CurrentState)
        {
            // Loop until the matching EndRow() is found and count the columns.
            Index++;
            var oldIndex = Index;
            var columns = new List<Column>();
            var currentColumn = new Column();
            var currentRecursionLevel = 1;

            while (currentRecursionLevel > 0 && Index < LayoutItems.Count)
            {
                switch (LayoutItems[Index].ItemType)
                {
                    case LayoutItem.Type.BeginRow:
                        {
                            if (currentRecursionLevel == 1)
                            {
                                columns.Add(currentColumn);
                                currentColumn = new Column();
                            }
                            currentRecursionLevel++;
                            break;
                        }
                    case LayoutItem.Type.Control:
                        {
                            if (currentRecursionLevel == 1)
                            {
                                columns.Add(currentColumn);
                                currentColumn = new Column();
                            }
                            break;
                        }
                    case LayoutItem.Type.BeginGroupBox:
                        {
                            if (currentRecursionLevel == 1)
                            {
                                columns.Add(currentColumn);
                                currentColumn = new Column();
                            }
                            currentRecursionLevel++;
                            break;
                        }
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                        {
                            currentRecursionLevel--;
                            break;
                        }
                    case LayoutItem.Type.ColumnWidth:
                        {
                            currentColumn.DesiredWidth = (LayoutItem.ColumnWidth)LayoutItems[Index].Data;
                            break;
                        }
                    case LayoutItem.Type.Anchor:
                    case LayoutItem.Type.OffsetX:
                    case LayoutItem.Type.OffsetY:
                    default:
                        {
                            break;
                        }
                }
                Index++;
            }
            Index = oldIndex;

            if (columns.Count == 0)
            {
                return;
            }

            // Split the width into n columns and process items.
            var currentColumnIndex = 0;
            var maxOffset = 0;
            var totalPadding = Padding.Left * (columns.Count - 1);
            var userReservedWidth = 0;
            var userReservedCount = 0;

            // First pass, set the user defined widths.
            for (int i = 0; i < columns.Count; i++)
            {
                switch (columns[i].DesiredWidth.Type)
                {
                    case LayoutItem.ColumnWidth.WidthType.None:
                        {
                            break;
                        }
                    case LayoutItem.ColumnWidth.WidthType.Scalar:
                        {
                            columns[i].Width += (int)(columns[i].DesiredWidth.Offset * CurrentState.Width / 100);
                            userReservedCount++;
                            userReservedWidth += columns[i].Width;
                            break;
                        }
                    case LayoutItem.ColumnWidth.WidthType.Absolute:
                        {
                            columns[i].Width += (int)columns[i].DesiredWidth.Offset;
                            userReservedCount++;
                            userReservedWidth += columns[i].Width;
                            break;
                        }
                }
            }

            if (userReservedWidth + totalPadding > CurrentState.Width)
            {
                return;
            }

            // Second pass, fill in remaining widths.
            if (columns.Count > userReservedCount)
            {
                var remainingWidth = CurrentState.Width - userReservedWidth - totalPadding;
                var totalFilled = userReservedCount;
                var assignedWidth = 0;
                for (int i = 0; i < columns.Count; i++)
                {
                    if (columns[i].Width == 0)
                    {
                        columns[i].Width = remainingWidth / (columns.Count - userReservedCount);
                        assignedWidth += columns[i].Width;
                        totalFilled++;
                        // Fix unallocated width from float -> int conversion loss.
                        if (totalFilled == columns.Count)
                        {
                            columns[i].Width += remainingWidth - assignedWidth;
                        }
                    }
                }
            }
            
            var columnState = new LayoutState
            {
                Height = CurrentState.Height,
                Anchor = CurrentState.Anchor,
                Controls = CurrentState.Controls
            };
            var currentTotalWidth = 0;
            for (; Index < LayoutItems.Count; Index++)
            {
                // Finalise group box and yield control to parent item.
                if (LayoutItems[Index].ItemType == LayoutItem.Type.EndRow)
                {
                    break;
                }
                switch (LayoutItems[Index].ItemType)
                {
                    case LayoutItem.Type.Control:
                    case LayoutItem.Type.BeginGroupBox:
                    case LayoutItem.Type.BeginRow:
                        {
                            columnState.Width = columns[currentColumnIndex].Width;
                            columnState.XOffset = CurrentState.XOffset + (currentColumnIndex > 0 ? Padding.Left : 0) + currentTotalWidth;
                            columnState.YOffset = CurrentState.YOffset;

                            switch (LayoutItems[Index].ItemType)
                            {
                                case LayoutItem.Type.Control:
                                    {
                                        ProcessControl(ref Index, ref columnState);
                                        break;
                                    }
                                case LayoutItem.Type.BeginGroupBox:
                                    {
                                        ProcessGroupBox(ref Index, ref columnState);
                                        break;
                                    }
                                case LayoutItem.Type.BeginRow:
                                    {
                                        columnState.XOffset -= Padding.Left;
                                        columnState.Width += Padding.Left;
                                        ProcessRow(ref Index, ref columnState);
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                            
                            currentColumnIndex++;
                            if (columnState.YOffset > maxOffset)
                            {
                                maxOffset = columnState.YOffset;
                            }
                            columnState.Anchor = CurrentState.Anchor;
                            currentTotalWidth += columnState.Width + (currentColumnIndex > 1 ? Padding.Left : 0);
                            break;
                        }
                    case LayoutItem.Type.Anchor:
                        {
                            columnState.Anchor = (Anchor)LayoutItems[Index].Data;
                            break;
                        }
                    case LayoutItem.Type.OffsetX:
                        {
                            columnState.XOffset += (int)LayoutItems[Index].Data;
                            break;
                        }
                    case LayoutItem.Type.OffsetY:
                        {
                            columnState.YOffset += (int)LayoutItems[Index].Data;
                            break;
                        }
                    case LayoutItem.Type.ColumnWidth:
                        {
                            // Handled in a previous phase of row layout.
                            break;
                        }
                    case LayoutItem.Type.EndGroupBox:
                    case LayoutItem.Type.EndRow:
                    default:
                        {
                            MessageBox.Show($"Error with layout engine, unexpected '{LayoutItems[Index].ItemType}' in {nameof(ProcessRow)}().");
                            break;
                        }
                }
            }

            // Notify parent of the changes to the state.
            CurrentState.YOffset = maxOffset;
            CurrentState.LastXSpacing = 0;
            CurrentState.LastYSpacing = columnState.LastYSpacing;
        }
    }
}
