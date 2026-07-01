using DVLD.Controls;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD;
using Create_DVLD.Licenses.Local_Licenses;
using Create_DVLD.Licenses.International_Licenses;
namespace Create_DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        //اسم الكلاس رخص السائق يعني بدور حول السائق
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicensesHistory = clsDriver.GetLicenses(_DriverID);

            // ليش ما ساتعملنا مباشره clsLicense.GetDriverLicenses(DriverID);
            //لكنترول أصلاً مبني حولين "السائق" (Driver-Centric)
            // مبدأ "الكبسلة والفصل" (Encapsulation & Low Coupling) \ثلل الكلاسات الي بتستدعيها

            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory;
            lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;

            }
        }

        private void _LoadInternationalLicenseInfo()
        {
            _dtDriverInternationalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);

            dgvInternationalLicensesHistory.DataSource = _dtDriverInternationalLicensesHistory;
            lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();
            // إجبار نصوص الجدول على اللون الأسود لمنع اختفائها فوق الخلفية البيضاء
            dgvLocalLicensesHistory.DefaultCellStyle.ForeColor = Color.Black;
            dgvLocalLicensesHistory.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInternationalLicensesHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 180;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 150; // تم التكبير

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 210; // تم التكبير

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 280; // تم التكبير ليتسع للوقت ص/م

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 280; // تم التكبير ليتسع للوقت ص/م

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 130;
            }
        }
        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(_DriverID);

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if (_Driver != null)
            {
                _DriverID = _Driver.DriverID; // استخدام الكائن المحمل مباشرة بدل إعادة الاستعلام

                // نشحن البيانات فقط إذا كان سائقاً حقيقياً
                _LoadLocalLicenseInfo();
                _LoadInternationalLicenseInfo();
            }
            else
            {
                // إذا لم يكن سائقاً، ننظف الشاشة تماماً ونصفر العدادات بأمان دون كراش
                _DriverID = -1;
                if (_dtDriverLocalLicensesHistory != null) _dtDriverLocalLicensesHistory.Clear();
                if (_dtDriverInternationalLicensesHistory != null) _dtDriverInternationalLicensesHistory.Clear();

                lblLocalLicensesRecords.Text = "0";
                lblInternationalLicensesRecords.Text = "0";
            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            //DriverLicense.frmShowLicenseInfo frm = new DriverLicense.frmShowLicenseInfo(LicenseID);
            //هاي النيم سبيس بدل استعمال المكتبه بس الافضل استعمال المكتبه \ لسا ماوحدت الاسامي 
            // بمجرد ماتكتب الفورم بنكتب الطريق 
            frm.ShowDialog();

        }

        public void Clear()
        {
            // فحص ذكي: إذا كان الجدول ليس فارغاً، قم بتنظيفه
            if (_dtDriverLocalLicensesHistory != null)
            {
                _dtDriverLocalLicensesHistory.Clear();
            }
            else
            {
                // إذا كان null، نقوم بحجز مساحة جديدة له في الذاكرة بدلاً من عمل كراش
                _dtDriverLocalLicensesHistory = new DataTable();
            }
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }
        

        private void dgvLocalLicensesHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvLocalLicensesHistory_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tpLocalLicenses_Click(object sender, EventArgs e)
        {

        }
    }
}
