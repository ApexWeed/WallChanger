﻿using System;
using System.Collections.Generic;
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
        List<Language> FallbackLanguages;
        List<Language> Languages;

        public MainForm()
        {
            InitializeComponent();
            ParseSettings();
        }

        static void AddToTree(TreeView Tree, string Path, object Tag = null, char Splitter = '.')
        {
            var levels = Path.Split(Splitter);
            for (int i = 0; i < levels.Length; i++)
            {
                var name = levels.Take(i + 1).JoinString();
                var nodes = Tree.Nodes.Find(name, true);
                if (nodes.Length == 0)
                {
                    var node = new TreeNode(levels[i])
                    {
                        Name = name
                    };

                    if (i == levels.Length - 1)
                    {
                        node.Tag = Tag;
                    }

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
                else
                {
                    if (Tag != null)
                    {
                        nodes[0].Tag = Tag;
                    }
                }
            }
        }

        void ParseSettings()
        {
            LM = new LanguageManager(true);
            Languages = new List<Language>();
            FallbackLanguages = new List<Language>();
            Languages.AddRange(LM.GetLanguages(true));
            FallbackLanguages.AddRange(LM.GetLanguages(true));
            cmbCurrentLanguage.DataSource = Languages;
            cmbFallbackLanguage.DataSource = FallbackLanguages;
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

            foreach (var entry in TranslationEntries)
            {
                AddToTree(treStrings, entry.Name, entry);
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
            if (treStrings.SelectedNode != null && treStrings.SelectedNode.Tag != null)
            {
                LoadDetails(treStrings.SelectedNode.Tag as TranslationEntry);
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
                txtFallback.Text = DisplayString((cmbFallbackLanguage.SelectedValue as Language).GetString(Entry.Name), Entry);
            }
            else
            {
                txtString.Text = DisplayString((cmbCurrentLanguage.SelectedValue as Language).GetString(Entry.Name), Entry);
                txtFallback.Text = DisplayString((cmbFallbackLanguage.SelectedValue as Language).GetString(Entry.Name), Entry);
            }

            UpdatePreview();
        }

        private void ClearDetails()
        {
            txtString.Text = "";
            txtFallback.Text = "";
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
                LoadDetails(treStrings.SelectedNode.Tag as TranslationEntry);
            }
        }

        private static string DisplayString(string String, TranslationEntry Entry)
        {
            foreach (var param in Entry.Parameters)
            {
                String = String.Replace(param.Original, param.Substitution);
            }

            return String;
        }

        private static string StorageString(string String, TranslationEntry Entry)
        {
            foreach (var param in Entry.Parameters)
            {
                String = String.Replace(param.Substitution, param.Original);
            }

            return String;
        }

        private void UpdatePreview()
        {
            if (treStrings.SelectedNode != null && treStrings.SelectedNode.Tag != null)
            {
                var entry = treStrings.SelectedNode.Tag as TranslationEntry;
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
                        text = string.Format(StorageString(txtFallback.Text, entry), paramArray);
                    }
                    catch (FormatException Ex)
                    {
                        text = StorageString(txtFallback.Text, entry);
                    }
                    txtPreview.Text = text;
                }
                else
                {
                    var text = txtPreview.Text;
                    try
                    {
                        text = string.Format(StorageString(txtString.Text, entry), paramArray);
                    }
                    catch (FormatException Ex)
                    {
                        text = StorageString(txtString.Text, entry);
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
                    var value = StorageString(txtFallback.Text, treStrings.SelectedNode.Tag as TranslationEntry);
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
                    var value = StorageString(txtString.Text, treStrings.SelectedNode.Tag as TranslationEntry);
                    var stringName = treStrings.SelectedNode.FullPath;
                    if (value == stringName)
                    {
                        return;
                    }
                    (cmbCurrentLanguage.SelectedItem as Language).AddString(stringName, value);
                    ((cmbFallbackLanguage.Items.Find(x => (x as Language).Code == (cmbCurrentLanguage.SelectedItem as Language).Code)) as Language).AddString(stringName, value);
                    (cmbCurrentLanguage.SelectedItem as Language).Save("lang");
                }
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
    }
}