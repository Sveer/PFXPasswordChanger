using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.IO;

namespace PFXChangePassword
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open pfx to change password";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbFilename.Text = ofd.FileName;
            }
        }

        private void ChangePass()
        {
            X509Certificate2 cert;
            if (tbPassword.Text!=tbConfirm.Text)
            {
                MessageBox.Show("New password and confirmation not the same");
                return;
            }
            try
            {
                //Load PFX/PKCS12 container and mark secret key as exportable
                cert = new X509Certificate2(tbFilename.Text, tbOldPassword.Text, X509KeyStorageFlags.Exportable);
            }
            catch {
                MessageBox.Show("Incorrect password");
                return;
            }
            //Export PFX
            var result = cert.Export(X509ContentType.Pfx, tbPassword.Text.ToSecureString());

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save pfx with new password";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, result);
                MessageBox.Show("PFX saved with password");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangePass();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            X509Certificate2 cert;
            if (tbPassword.Text != tbConfirm.Text)
            {
                MessageBox.Show("New password and confirmation not the same");
                return;
            }
            try
            {
                //Load PFX/PKCS12 container and mark secret key as exportable
                cert = new X509Certificate2(tbFilename.Text, tbOldPassword.Text, X509KeyStorageFlags.Exportable);
            }
            catch
            {
                MessageBox.Show("Incorrect password");
                return;
            }
            X509Certificate2UI.DisplayCertificate(cert);

             //Export PFX
             //var result = cert.Export(X509ContentType.Pfx, tbPassword.Text.ToSecureString());
        }

        //COnvert string to SecureString

    }
}
