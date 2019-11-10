using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGro
{
    public partial class ExtensionsTuner : Form
    {
        public List<string> extensions;

        public ExtensionsTuner(List<string> curExtensions)
        {
            InitializeComponent();
            extensions = curExtensions;
            UpdateView();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BT_Default_Click(object sender, EventArgs e)
        { 
            extensions = new List<string>() { "tga", "fbx", "obj", "mp3", "png", "amf", "zpr" };
            UpdateView();
        }

        private void BT_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BT_Remove_Click(object sender, EventArgs e)
        {
            if (listExtensions.SelectedIndex >= 0)
                extensions.Remove(listExtensions.SelectedItem as string);
            UpdateView();
        }

        private void BT_Add_Click(object sender, EventArgs e)
        {
            if (listExtensions.Items.Contains(TB_NewExtension.Text))
                MessageBox.Show("Desired extension is already in the list.");
            else if (TB_NewExtension.Text.Length == 0)
            {
                TB_NewExtension.BackColor = Color.Red;
                MessageBox.Show("Extension should have at least one symbol.");
            }
            else
            {
                extensions.Add(TB_NewExtension.Text);
                TB_NewExtension.Text = string.Empty;
            }
            UpdateView();
        }

        private void UpdateView()
        {
            listExtensions.Items.Clear();
            foreach (string ext in extensions)
                listExtensions.Items.Add(ext);
        }

        private void TB_NewExtension_TextChanged(object sender, EventArgs e)
        {
            TB_NewExtension.BackColor = Color.White;
        }
    }
}
