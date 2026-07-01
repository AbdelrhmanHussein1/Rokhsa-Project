//using DVLD.Applications;
//using DVLD.Applications.Detain_License;
//using DVLD.Applications.International_License;
//using DVLD.Applications.ReplaceLostOrDamagedLicense;
//using DVLD.Applications.Rlease_Detained_License;
//using DVLD.Classes;
//using DVLD.Drivers;
//using DVLD.Licenses;
//using DVLD.Licenses.International_License;
//using DVLD.Login;
//using DVLD.People;
//using DVLD.Tests;
//using DVLD.User;
using System;
using System.Drawing;
using System.Windows.Forms;
using Create_DVLD.Login;
using Create_DVLD.People;
using Create_DVLD.Users;
using DVLD.Classes;
using Create_DVLD;
using Create_DVLD.Applications.Application_Types;
using Create_DVLD.Applications.Local_Driving_License;
using Create_DVLD.Applications.Tests.Test_Types;
using Create_DVLD.Applications.International_License;
using Create_DVLD.Applications.Renew_Local_License;
using DVLD.Applications.Rlease_Detained_License;
using Create_DVLD.Drivers;
using Create_DVLD.Applications.ReplaceLostOrDamagedLicense;
using Create_DVLD.Applications.Release_Detained_License;
using Create_DVLD.Licenses.Detain_License;



namespace Create_DVLD
{

    public partial class frmMain : Form
    {
        //frmLogin _frmLogin;
        frmLoginDVLD _frmLoginDVLD;

        public frmMain(frmLoginDVLD frm)
        {
            InitializeComponent();
            _frmLoginDVLD = frm;

        }
        //public frmMain(frmLogin frm)
        //{
        //    InitializeComponent();
        //    _frmLogin = frm;

        //}

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListPeople(); 
            frm.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            lblLoggedInUser.Text = "LoggedIn User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginDVLD.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();
            frm.ShowDialog();

        }



        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();
        }


        private void vehiclesLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();

        }



        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications frm = new frmListInternationalLicesnseApplications();
            frm.ShowDialog();

        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();

        }

        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();

        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();

        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

       

       

       
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void msMainMenue_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       

        private void oNewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // هذا السطر ينهي العملية بالكامل من الذاكرة ويغلق شاشة اللوجن المخفية
            _frmLoginDVLD.Close();
        }
    }
}
