using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class LibraryForm : Form
    {
        bool ComboBoxLocked = false;

        List<string> Categories;
        List<string> ShowNames;
        List<string> CharacterNames;
        List<string> Tags;
        
        public LibraryForm(Form Owner)
        {
            InitializeComponent();

            this.Owner = Owner;
            Categories = new List<string>();
            ShowNames = new List<string>();
            CharacterNames = new List<string>();
            Tags = new List<string>();
            UpdateList();
        }

        private void LibraryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner is MainForm)
                (Owner as MainForm).ChildClosed(this);
        }

        public void UpdateList()
        {
            lstImages.Items.Clear();
            foreach (var libraryItem in GlobalVars.LibraryItems)
            {
                lstImages.Items.Add(libraryItem.Filename);
                Categories.AddDistinct(libraryItem.Category);
                ShowNames.AddDistinct(libraryItem.ShowName);
                CharacterNames.AddDistinct(libraryItem.CharacterNames);
                Tags.AddDistinct(libraryItem.Tags);
            }
        }

        private void UpdateComboBoxes()
        {
            cmbCategory.DataSource = null;
            cmbShowName.DataSource = null;
            cmbCategory.DataSource = Categories;
            cmbShowName.DataSource = ShowNames;
        }

        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxLocked = true;
            Image preview = Image.FromFile(lstImages.SelectedItem as string);
            lblImageSize.Text = string.Format("Image Size: {0}x{1}px", preview.Width, preview.Height);
            picPreview.Image = preview;
            UpdateComboBoxes();
            LibraryItem item = GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string);

            if (!string.IsNullOrWhiteSpace(item.Category))
                cmbCategory.Text = item.Category;
            else
                cmbCategory.Text = "";

            if (!string.IsNullOrWhiteSpace(item.ShowName))
                cmbShowName.Text = item.ShowName;
            else
                cmbShowName.Text = "";

            lstCharacters.Items.Clear();
            lstCharacters.Items.AddRange(item.CharacterNames.ToArray());
            lstTags.Items.Clear();
            lstTags.Items.AddRange(item.Tags.ToArray());
            ComboBoxLocked = false;
        }

        #region "Category"
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the name for the category or use a pre existing value.", "Enter Category", Categories.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Categories.AddDistinct(Value);
            UpdateComboBoxes();
            cmbCategory.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = Value;
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = "";
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = cmbCategory.Text;
        }
        #endregion

        #region "Show Name"
        private void btnAddShowName_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the show name or use a pre existing value.", "Enter Show Name", ShowNames.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            ShowNames.AddDistinct(Value);
            UpdateComboBoxes();
            cmbShowName.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = Value;
        }

        private void btnClearShowName_Click(object sender, EventArgs e)
        {
            cmbShowName.Text = "";
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = "";
        }

        private void cmbShowName_SelectedValueChanged(object sender, EventArgs e)
        {
            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = cmbShowName.Text;
        }
        #endregion

        #region "Character"
        private void btnAddNewCharacter_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the character name or use a pre existing value.", "Enter Character Name", CharacterNames.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            CharacterNames.AddDistinct(Value);
            lstCharacters.Items.Add(Value);
            lstCharacters.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.AddDistinct(Value);
        }

        private void btnRemoveCharacter_Click(object sender, EventArgs e)
        {
            if (lstCharacters.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.Remove(lstCharacters.SelectedItem as string);
                lstCharacters.Items.Remove(lstCharacters.SelectedItem);
            }
        }

        private void btnClearCharacters_Click(object sender, EventArgs e)
        {
            lstCharacters.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.Clear();
        }
        #endregion

        #region "Tags"
        private void btnAddNewTag_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the tag or use a pre existing value.", "Enter Tag", Tags.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Tags.AddDistinct(Value);
            lstTags.Items.Add(Value);
            lstTags.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.AddDistinct(Value);
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            if (lstTags.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.Remove(lstTags.SelectedItem as string);
                lstCharacters.Items.Remove(lstTags.SelectedItem);
            }
        }

        private void btnClearTags_Click(object sender, EventArgs e)
        {
            lstTags.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.Clear();
        }
        #endregion

        private void pnlDetails_Resize(object sender, EventArgs e)
        {
            cmbCategory.Width = pnlDetails.Width - 16;
            cmbShowName.Width = pnlDetails.Width - 16;
            lstCharacters.Width = pnlDetails.Width - 16;

            btnAddCategory.Left = pnlDetails.Width - 63;
            btnClearCategory.Left = pnlDetails.Width - 33;

            btnAddShowName.Left = pnlDetails.Width - 63;
            btnClearShowName.Left = pnlDetails.Width - 33;

            btnAddNewCharacter.Left = pnlDetails.Width - 93;
            btnRemoveCharacter.Left = pnlDetails.Width - 63;
            btnClearCharacters.Left = pnlDetails.Width - 33;
        }

        private void pnlTagButtons_Resize(object sender, EventArgs e)
        {
            btnAddNewTag.Left = pnlTagButtons.Width - 84;
            btnRemoveTag.Left = pnlTagButtons.Width - 54;
            btnClearTags.Left = pnlTagButtons.Width - 24;
        }
    }
}
