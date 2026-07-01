using DVLD.Classes;
using DVLD_Buisness;
using System;
using System.Windows.Forms;
using DVLD;

namespace Create_DVLD.Login
{
    public partial class frmLoginDVLD : Form
    {
        // ── Drag support (no border) ─────────────────
        private bool _drag = false;
        private System.Drawing.Point _dragOrigin;

        public frmLoginDVLD()
        {
            InitializeComponent();

          
        }

        private void frmLoginDVLD_Load(object sender, EventArgs e)
        {
            string userName = "", password = "";
            if (clsGlobal.GetStoredCredential(ref userName, ref password))
            {
                txtUserName.Text = userName;
                txtPassword.Text = password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string HashedPassword = clsUser.ComputeSHA256Hash(txtPassword.Text.Trim());

            // نرسل الهاش النظيف للبزنس
            //clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), HashedPassword);
            clsUser user = clsUser.FindByUsernameAndPassword(
                txtUserName.Text.Trim(),
                txtPassword.Text.Trim());

            if (user != null)
            {
                if (chkRememberMe.Checked)
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                else
                    clsGlobal.RememberUsernameAndPassword("", "");

                if (!user.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.",
                        "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.",
                    "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.BorderColor = System.Drawing.Color.FromArgb(43, 127, 212);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtUserName.BorderColor = System.Drawing.Color.FromArgb(197, 216, 238);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BorderColor = System.Drawing.Color.FromArgb(43, 127, 212);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.BorderColor = System.Drawing.Color.FromArgb(197, 216, 238);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(null, null);
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { _drag = true; _dragOrigin = e.Location; }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_drag) this.Location = System.Drawing.Point.Add(this.Location,
                new System.Drawing.Size(System.Drawing.Point.Subtract(e.Location,
                new System.Drawing.Size(_dragOrigin))));
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            _drag = false;
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblLoginDesc_Click(object sender, EventArgs e)
        {

        }
    }
}