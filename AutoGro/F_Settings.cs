using System;
using System.Windows.Forms;


namespace AutoGro
{
    public partial class F_Settings : Form
    {
        CheckBox[] extToAssociate;

        public F_Settings()
        {
            InitializeComponent();

            extToAssociate = new CheckBox[]
            {
                CB_AE_bmf,
                CB_AE_cb,
                CB_AE_ep,
                CB_AE_gtitle,
                CB_AE_mat,
                CB_AE_mdl,
                CB_AE_mtr,
                CB_AE_rsc,
                CB_AE_wld
            };

            foreach (CheckBox extCB in extToAssociate)
            {
                try
                {
                    if (IsExtensionAssociated('.' + extCB.Text))
                        extCB.Checked = true;
                }
                catch (Exception)
                {
                    GB_AssociatedExtensions.Enabled = false;
                    MessageBox.Show("Could not access registry. File associatons unavailable.\nPlease, relaunch with administrator permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
            }
        }

        /// <summary>
        /// Associates given extension with Autogro program.
        /// </summary>
        /// <param name="extension">Extension to register.</param>
        private static void AssociateExtension(string extension)
        {
            Associations.AF_FileAssociator associator = new Associations.AF_FileAssociator(extension);
            try
            {
                associator.Create("Autogro", "Gro archivator", new Associations.ProgramIcon(Application.ExecutablePath), new Associations.ExecApplication(Application.ExecutablePath), null);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Associatons could not be applied.\n\nAdministrator permission required.", "Unauthorized access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw new Exception();
            }
        }

        /// <summary>
        /// Reverts given extension being associated with Autogro.
        /// </summary>
        /// <param name="extension">Extension to dessociate.</param>
        private static void DessociateExtension(string extension)
        {
            Associations.AF_FileAssociator associator = new Associations.AF_FileAssociator(extension);
            try
            {
                associator.Delete();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Could not dessociate extension.\n\nPlease, relaunch with administrator permissions.", "Unauthorized access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw new Exception();
            }
        }

        private static bool IsExtensionAssociated(string extension)
        {
            Associations.AF_FileAssociator associator = new Associations.AF_FileAssociator(extension);
            try
            {
                if (associator.Exists)
                    if (associator.GetProgID == "Autogro")
                        return true;
                    else
                        return false;
                else
                    return false;
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception();
            }
        }

        private void ExtensionOnClick(object sender, EventArgs e)
        {
            CheckBox extCB = (CheckBox)sender;
            string extName = '.' + extCB.Text;

            if (extCB.Checked)
            {
                AssociateExtension(extName);
            }
            else
            {
                DessociateExtension(extName);
            }
        }

        private void BT_Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Shows information about this software
        /// </summary>
        private void BT_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AutoGro 2018 " + Updater.version + 

                "\n\n3rd party libraries:\n" +
                "FileAssociations class by Aidan Follestad" +

                "\n\nMade with:" +
                "\n.NET Framework 4.6.1\n" +
                "C# Windows Forms\nVisual Studio Community 2017" +

                "\n\nAuthor: Asdolg\n" + Updater.updateDate,
                
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void BT_Help_AE_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selected file extensions will be associated with Autogro.\nWhen you double click a file, Autogro will open with this file selected as the base resource.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
