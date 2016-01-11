using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LanguageEditor
{
    public partial class MainForm : Form
    {
        LanguageManager LM;
        List<TranslationEntry> TranslationEntries;
        Dictionary<string, string> LanguageVariables;
        BindingList<Language> FallbackLanguages;
        BindingSource BSFallbackLanguages;
        BindingList<Language> Languages;
        BindingSource BSLanguages;

        public MainForm()
        {
            InitializeComponent();
            ParseSettings();
        }

        /// <summary>
        /// Adds an entry to the tree, creating sub nodes based on the Splitter.
        /// </summary>
        /// <param name="Tree">The tree to add the node/s to.</param>
        /// <param name="Path">The path to add the node at, split using Splitter</param>
        /// <param name="Tag">The tag to add to the node, defaults to null.</param>
        /// <param name="Splitter">The character to split the path by, defaults to '.'.</param>
        static void AddToTree(TreeView Tree, string Path, object Tag = null, char Splitter = '.')
        {
            var levels = Path.Split(Splitter);
            for (int i = 0; i < levels.Length; i++)
            {
                // Take progressively longer slices of the path.
                var name = levels.Take(i + 1).JoinString();
                var nodes = Tree.Nodes.Find(name, true);
                // Create the node if it doesn't exist.
                if (nodes.Length == 0)
                {
                    var node = new TreeNode(levels[i])
                    {
                        Name = name
                    };

                    // Add the tag to the new node if it's the last one in the path, otherwise do a hack job that probably shouldn't be in this code.
                    if (i == levels.Length - 1)
                    {
                        node.Tag = Tag;
                    }
                    else
                    {
                        node.Tag = new NodeColour();
                    }

                    // Make sure the node is added at the right location.
                    if (i == 0)
                    {
                        Tree.Nodes.Add(node);
                    }
                    else
                    {
                        var parentName = levels.Take(i).JoinString();
                        var parents = Tree.Nodes.Find(parentName, true);
                        parents[0].Nodes.Add(node);
                    }
                }
                // Update the value of the existing node but only if it is the last in the path.
                else
                {
                    if (Tag != null && i == levels.Length - 1)
                    {
                        nodes[0].Tag = Tag;
                    }
                }
            }
        }

        /// <summary>
        /// Loads and parses settings.
        /// </summary>
        void ParseSettings()
        {
            LM = new LanguageManager(true);
            Languages = new BindingList<Language>();
            FallbackLanguages = new BindingList<Language>();
            Languages.AddRange(LM.GetLanguages(true));
            FallbackLanguages.AddRange(LM.GetLanguages(true));
            BSLanguages = new BindingSource
            {
                DataSource = Languages
            };
            BSFallbackLanguages = new BindingSource
            {
                DataSource = FallbackLanguages
            };

            cmbCurrentLanguage.DataSource = BSLanguages;
            cmbFallbackLanguage.DataSource = BSFallbackLanguages;
            TranslationEntries = new List<TranslationEntry>();
            LanguageVariables = new Dictionary<string, string>();
            treStrings.Nodes.Clear();

            using (StreamReader read = new StreamReader(@"lang\lang.cfg"))
            {
                var line = read.ReadLine();
                while (line != "")
                {
                    LanguageVariables.Add(line.Split('=')[0].Trim(), line.Split('=')[1].Trim());
                    line = read.ReadLine();
                }

                while (ParseEntry(read, TranslationEntries))
                {

                }
            }

            //var rnd = new Random();
            foreach (var entry in TranslationEntries)
            {
                var tag = new ColourableTranslationEntry(ColourableTreeView.ColourMode.Primary, entry, false);
                AddToTree(treStrings, entry.Name, tag);
            }

            UpdateTranslationStatus();

            if (LanguageVariables.ContainsKey("DefaultLanguage"))
            {
                if (LM.Languages.ContainsKey(LanguageVariables["DefaultLanguage"]))
                {
                    cmbCurrentLanguage.SelectedItem = LM.Languages[LanguageVariables["DefaultLanguage"]];
                }
            }

            if (LanguageVariables.ContainsKey("DefaultFallbackLanguage"))
            {
                if (LM.Languages.ContainsKey(LanguageVariables["DefaultFallbackLanguage"]))
                {
                    cmbFallbackLanguage.SelectedItem = LM.Languages[LanguageVariables["DefaultFallbackLanguage"]];
                }
            }

            if (LanguageVariables.ContainsKey("Product"))
            {
                this.Text = $"Language Editor - {LanguageVariables["Product"]}";
            }
        }

        int totalEntries;
        int translatedEntries;
        void UpdateTranslationStatus()
        {
            totalEntries = 0;
            translatedEntries = 0;

            foreach (TreeNode node in treStrings.Nodes)
            {
                UpdateNodeTranslationStatus(node);
            }

            treStrings.Invalidate();
            lblTranslationStatus.Text = $"Translated: {translatedEntries}/{totalEntries} ({(translatedEntries == 0 ? 0 : 100.0f * translatedEntries / totalEntries):F2}%)";
        }

        /// <summary>
        /// Updates the translation status of a single node recursively. Also sets the status of any children.
        /// </summary>
        /// <param name="Node">The node to update.</param>
        /// <returns></returns>
        bool UpdateNodeTranslationStatus(TreeNode Node)
        {
            // If the node has no children then it is either a translation entry or an empty group (which should not be possible).
            if (Node.Nodes.Count == 0)
            {
                // This is a translation entry, check the translation engine for the string.
                if (Node.Tag != null && Node.Tag is ColourableTranslationEntry)
                {
                    var translated = false;
                    var Entry = (Node.Tag as ColourableTranslationEntry).TranslationEntry;
                    if (chkEditFallback.Checked)
                    {
                        if (ToDisplayString((cmbFallbackLanguage.SelectedValue as Language).GetString(Entry.Name), Entry) != Entry.Name)
                        {
                            translated = true;
                        }
                    }
                    else
                    {
                        if (ToDisplayString((cmbCurrentLanguage.SelectedValue as Language).GetString(Entry.Name), Entry) != Entry.Name)
                        {
                            translated = true;
                        }
                    }
                    (Node.Tag as ColourableTranslationEntry).ColourMode = translated ? ColourableTreeView.ColourMode.Primary : ColourableTreeView.ColourMode.Secondary;

                    totalEntries++;
                    if (translated)
                    {
                        translatedEntries++;
                    }

                    return translated;
                }

                // An empty group, should not be possible.
                return true;
            }
            // The node has children, recurse through them.
            else
            {
                // Find how many children are translated by recursion.
                var childrenTranslated = 0;
                foreach (TreeNode child in Node.Nodes)
                {
                    if (UpdateNodeTranslationStatus(child))
                    {
                        childrenTranslated++;
                    }
                }

                // It is possible for a node to be a group and a translation entry at the same time.
                if (Node.Tag != null && Node.Tag is ColourableTranslationEntry)
                {
                    var translated = false;
                    var Entry = (Node.Tag as ColourableTranslationEntry).TranslationEntry;
                    if (chkEditFallback.Checked)
                    {
                        if (ToDisplayString((cmbFallbackLanguage.SelectedValue as Language).GetString(Entry.Name), Entry) != Entry.Name)
                        {
                            translated = true;
                        }
                    }
                    else
                    {
                        if (ToDisplayString((cmbCurrentLanguage.SelectedValue as Language).GetString(Entry.Name), Entry) != Entry.Name)
                        {
                            translated = true;
                        }
                    }
                    (Node.Tag as ColourableTranslationEntry).ColourMode = translated ? (childrenTranslated == Node.Nodes.Count) ? ColourableTreeView.ColourMode.Primary : ColourableTreeView.ColourMode.Tertiary : ColourableTreeView.ColourMode.Secondary;

                    totalEntries++;
                    if ((Node.Tag as ColourableTranslationEntry).ColourMode != ColourableTreeView.ColourMode.Secondary)
                    {
                        translatedEntries++;
                    }

                    return (Node.Tag as ColourableTranslationEntry).ColourMode == ColourableTreeView.ColourMode.Primary;
                }
                // Normally groups aren't a translation entry though.
                else
                {
                    // Green for all children translated, red otherwise.
                    (Node.Tag as NodeColour).ColourMode = (childrenTranslated == Node.Nodes.Count) ? ColourableTreeView.ColourMode.Primary : ColourableTreeView.ColourMode.Secondary;
                    return (Node.Tag as NodeColour).ColourMode == ColourableTreeView.ColourMode.Primary;
                }
            }
        }

        static bool ParseEntry(StreamReader read, List<TranslationEntry> Collection)
        {
            if (read.EndOfStream)
            {
                return false;
            }

            var line = read.ReadLine().Trim();
            if (line.StartsWith("#") || line == "")
            {
                return true;
            }
            if (line.EndsWith("="))
            {
                // Has parameters.
                var name = line.Split('=')[0].Trim();
                line = read.ReadLine().Trim();
                if (line == "{")
                {
                    var Parameters = new List<string>();
                    while (true)
                    {
                        line = read.ReadLine().Trim();
                        if (line == "}")
                        {
                            break;
                        }

                        Parameters.Add(line);
                    }

                    if (Parameters.Count % 3 != 0)
                    {
                        return false;
                    }
                    else
                    {
                        var entry = new TranslationEntry(name);
                        for (int i = 0; i < Parameters.Count / 3; i++)
                        {
                            var IDLen = Parameters[i * 3].IndexOf('.') + 1;
                            var param = new TranslationParameter(Parameters[i * 3].Substring(0, IDLen - 1));
                            for (int j = i * 3; j < i * 3 + 3; j++)
                            {
                                var parts = Parameters[j].Substring(IDLen).Split('=');
                                switch (parts[0].Trim())
                                {
                                    case "Substitution":
                                        {
                                            param.Substitution = parts[1].Trim();
                                            break;
                                        }
                                    case "Description":
                                        {
                                            param.Description = parts[1].Trim();
                                            break;
                                        }
                                    case "Sample":
                                        {
                                            param.Sample = parts[1].Trim();
                                            break;
                                        }
                                }
                            }
                            entry.Parameters.Add(param);
                        }
                        Collection.Add(entry);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // No parameters.
                var entry = new TranslationEntry(line);
                Collection.Add(entry);
                return true;
            }
        }

        private void treStrings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treStrings.SelectedNode != null && treStrings.SelectedNode.Tag != null && treStrings.SelectedNode.Tag is ColourableTranslationEntry)
            {
                LoadDetails((treStrings.SelectedNode.Tag as ColourableTranslationEntry).TranslationEntry);
            }
            else
            {
                SetTitle(treStrings.SelectedNode.FullPath);
                ClearDetails();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CC0022:Should dispose object", Justification = "Disposed elsewhere.")]
        private void LoadDetails(TranslationEntry Entry)
        {
            SetTitle(Entry.ToString());
            ClearDetails();

            var currentParam = 0;
            foreach (var param in Entry.Parameters)
            {
                var lblParam = new Label
                {
                    Text = param.Substitution,
                    Left = 5,
                    Top = currentParam * 50 + 15,
                    Height = 12
                };
                grpParameters.Controls.Add(lblParam);

                var lblSubstitution = new Label
                {
                    Text = $"Sample: {ConvertSample(param.Sample).ToString()}",
                    Top = currentParam * 50 + 15,
                    Height = 12
                };
                lblSubstitution.Width = TextRenderer.MeasureText(lblSubstitution.Text, lblSubstitution.Font).Width;
                lblSubstitution.Left = grpParameters.Width - lblSubstitution.Width - 5;
                grpParameters.Controls.Add(lblSubstitution);

                var txtDescription = new TextBox
                {
                    Enabled = false,
                    Text = param.Description,
                    Left = 5,
                    Top = currentParam * 50 + 35,
                    Width = grpParameters.Width - 10
                };
                grpParameters.Controls.Add(txtDescription);

                currentParam++;
            }

            if (chkEditFallback.Checked)
            {
                txtFallback.Text = ToDisplayString((cmbFallbackLanguage.SelectedValue as Language).GetString(Entry.Name), Entry);
            }
            else
            {
                txtString.Text = ToDisplayString((cmbCurrentLanguage.SelectedValue as Language).GetString(Entry.Name), Entry);
                txtFallback.Text = ToDisplayString((cmbFallbackLanguage.SelectedValue as Language).GetString(Entry.Name), Entry);
            }

            UpdatePreview();
        }

        private void ClearDetails()
        {
            txtString.Text = "String";
            txtFallback.Text = "Fallback";
            txtPreview.Text = "Preview";
            foreach (var control in grpParameters.Controls)
            {
                (control as Control).Dispose();
            }
            grpParameters.Controls.Clear();
        }

        private void SetTitle(string Text)
        {
            lblTitle.Text = Text;
            //lblTitle.Left = pnlEditor.Width / 2 - TextRenderer.MeasureText(Text, lblTitle.Font).Width / 2;
        }

        private void treStrings_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void chkEditFallback_CheckedChanged(object sender, System.EventArgs e)
        {
            txtString.Enabled = !chkEditFallback.Checked;
            txtFallback.Enabled = chkEditFallback.Checked;
            if (treStrings.SelectedNode != null)
            {
                LoadDetails((treStrings.SelectedNode.Tag as ColourableTranslationEntry).TranslationEntry);
            }

            UpdateTranslationStatus();
        }

        private static string ToDisplayString(string String, TranslationEntry Entry)
        {
            foreach (var param in Entry.Parameters)
            {
                String = String.Replace(param.Original, param.Substitution);
            }

            return String;
        }

        private static string ToStorageString(string String, TranslationEntry Entry)
        {
            foreach (var param in Entry.Parameters)
            {
                String = String.Replace(param.Substitution, param.Original);
            }

            return String;
        }

        private void UpdatePreview()
        {
            if (treStrings.SelectedNode != null && treStrings.SelectedNode.Tag != null && treStrings.SelectedNode.Tag is ColourableTranslationEntry)
            {
                var entry = (treStrings.SelectedNode.Tag as ColourableTranslationEntry).TranslationEntry;
                var paramArray = new object[entry.Parameters.Count];
                for (int i = 0; i < entry.Parameters.Count; i++)
                {
                    paramArray[i] = ConvertSample(entry.Parameters[i].Sample);
                }
                if (chkEditFallback.Checked)
                {
                    var text = txtPreview.Text;
                    try
                    {
                        text = string.Format(ToStorageString(txtFallback.Text, entry), paramArray);
                    }
                    catch (FormatException Ex)
                    {
                        text = ToStorageString(txtFallback.Text, entry);
                    }
                    txtPreview.Text = text;
                }
                else
                {
                    var text = txtPreview.Text;
                    try
                    {
                        text = string.Format(ToStorageString(txtString.Text, entry), paramArray);
                    }
                    catch (FormatException Ex)
                    {
                        text = ToStorageString(txtString.Text, entry);
                    }
                    txtPreview.Text = text;
                }
            }
        }

        private static object ConvertSample(string Sample)
        {
            if (Sample == "!!TIME!!")
            {
                return DateTime.Now;
            }
            else if (Sample.StartsWith("!!INT!!"))
            {
                return int.Parse(Sample.Split(' ')[1]);
            }
            else if (Sample.StartsWith("!!DOUBLE!!"))
            {
                return double.Parse(Sample.Split(' ')[1]);
            }
            else if (Sample.StartsWith("!!FLOAT!!"))
            {
                return float.Parse(Sample.Split(' ')[1]);
            }
            else
            {
                return Sample;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (treStrings.SelectedNode != null && treStrings.SelectedNode.Tag != null)
            {
                if (chkEditFallback.Checked)
                {
                    var value = ToStorageString(txtFallback.Text, (treStrings.SelectedNode.Tag as ColourableTranslationEntry).TranslationEntry);
                    var stringName = treStrings.SelectedNode.FullPath;
                    if (value == stringName)
                    {
                        return;
                    }
                    
                    (cmbFallbackLanguage.SelectedItem as Language).AddString(stringName, value);
                    ((cmbCurrentLanguage.Items.Find(x => (x as Language).Code == (cmbFallbackLanguage.SelectedItem as Language).Code)) as Language).AddString(stringName, value);
                    (cmbFallbackLanguage.SelectedItem as Language).Save("lang");
                }
                else
                {
                    var value = ToStorageString(txtString.Text, (treStrings.SelectedNode.Tag as ColourableTranslationEntry).TranslationEntry);
                    var stringName = treStrings.SelectedNode.FullPath;
                    if (value == stringName)
                    {
                        return;
                    }
                    (cmbCurrentLanguage.SelectedItem as Language).AddString(stringName, value);
                    ((cmbFallbackLanguage.Items.Find(x => (x as Language).Code == (cmbCurrentLanguage.SelectedItem as Language).Code)) as Language).AddString(stringName, value);
                    (cmbCurrentLanguage.SelectedItem as Language).Save("lang");
                }

                UpdateTranslationStatus();
            }
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void txtFallback_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void btnNewLanguage_Click(object sender, EventArgs e)
        {
            using (var newLanguagePrompt = new NewLanguagePrompt())
            {
                if (newLanguagePrompt.ShowDialog() == DialogResult.OK)
                {
                    var language = new Language(newLanguagePrompt.LanguageCode, newLanguagePrompt.LanguageName, newLanguagePrompt.Description, newLanguagePrompt.Author);
                    LM.Languages.Add(newLanguagePrompt.LanguageCode, language);
                    language.Save("lang");
                    Languages.Add(language);
                    FallbackLanguages.Add(language);

                    cmbCurrentLanguage.SelectedItem = language;
                }
            }
        }
    }
}
