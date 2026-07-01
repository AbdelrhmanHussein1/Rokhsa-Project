using DVLD.Classes;
using DVLD.Controls;
using Create_DVLD.People;
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
using static System.Net.Mime.MediaTypeNames;

namespace Create_DVLD.Applications.Local_Driving_License
{


    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();


            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                tpApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;


            }

        }

        private void _LoadData()
        {

            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            //return int
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);


        }//قق

        //private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        //{
        //    _ResetDefualtValues();

        //    if (_Mode == enMode.Update)
        //    {
        //        _LoadData();
        //    }

        //}
        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            // 1. إعادة ربط حدث اختيار الشخص داخل الكنترول بالفورم الحالي (حل مشكلة البحث)
            ctrlPersonCardWithFilter1.OnPersonSelected += ctrlPersonCardWithFilter1_OnPersonSelected;

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {



            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من صحة مدخلات عناصر الواجهة
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. التأكد من اختيار فئة رخصة
            if (string.IsNullOrEmpty(cbLicenseClass.Text))
            {
                MessageBox.Show("Please select a License Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

            // 3. التحقق من اختيار شخص بنجاح من الـ User Control
            if (ctrlPersonCardWithFilter1.PersonID == -1 || ctrlPersonCardWithFilter1.PersonID == 0)
            {
                MessageBox.Show("Please select or find a person first before saving the application.", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int CurrentPersonID = ctrlPersonCardWithFilter1.PersonID;

            // 🌟 خطوة جوهرية: تعبئة خصائص الكائن أولاً قبل تنفيذ الفحص بالـ BLL
            _LocalDrivingLicenseApplication.ApplicantPersonID = CurrentPersonID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1; // New Driving License Application

            if (_Mode == enMode.AddNew)
            {
                _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            }

            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            // 4. استدعاء الحفظ من طبقة البزنس وتمرير متغير استقبال رسالة الخطأ
            string ErrorMessage = "";

            if (_LocalDrivingLicenseApplication.Save(out ErrorMessage))
            {
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                // تغيير وضع الشاشة إلى التحديث
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // عرض رسالة الخطأ المخصصة والمحددة القادمة من البزنس مباشرة دون أي تكرار
                MessageBox.Show("Error: " + ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // توجيه الفوكس في حال كان الخطأ متعلق بتكرار الطلب النشط
                if (ErrorMessage.Contains("Already have an active application"))
                {
                    cbLicenseClass.Focus();
                }
            }
        }


        //}
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    // 1. التحقق من المدخلات (إذا كان هناك مشكلة مع جونا، يفضل عمل تحقق يدوي أو التأكد من أحداث الـ Validating)
        //    if (!this.ValidateChildren())
        //    {
        //        MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
        //            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // تأكد من أن الـ ComboBox يحتوي على قيمة محددة قبل البحث
        //    if (string.IsNullOrEmpty(cbLicenseClass.Text))
        //    {
        //        MessageBox.Show("Please select a License Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

        //    // توحيد استخدام الـ PersonID لضمان الدقة
        //    // 1. التحقق من أنه تم اختيار شخص بنجاح
        //    if (ctrlPersonCardWithFilter1.PersonID == -1 || ctrlPersonCardWithFilter1.PersonID == 0)
        //    {
        //        MessageBox.Show("Please select or find a person first before saving the application.", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // باقي كود الحفظ الخاص بك يستمر هنا طبيعي...
        //    int CurrentPersonID = ctrlPersonCardWithFilter1.PersonID;
        //    // 2. التحقق من وجود طلب نشط لنفس الفئة
        //    int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(CurrentPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

        //    if (ActiveApplicationID != -1)
        //    {
        //        MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID,
        //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        cbLicenseClass.Focus();
        //        return;
        //    }

        //    // 3. التحقق مما إذا كان الشخص يملك رخصة بالفعل من نفس الفئة
        //    if (clsLicense.IsLicenseExistByPersonID(CurrentPersonID, LicenseClassID))
        //    {
        //        MessageBox.Show("Person already have a license with the same applied driving class, Choose different driving class",
        //            "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // 4. تعبئة بيانات الطلب
        //    _LocalDrivingLicenseApplication.ApplicantPersonID = CurrentPersonID;
        //    _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
        //    _LocalDrivingLicenseApplication.ApplicationTypeID = 1; // New Driving License Application

        //    if (_Mode == enMode.AddNew)
        //    {
        //        _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
        //    }

        //    _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
        //    _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
        //    _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

        //    // !!! تم إلغاء التعليق هنا لأن هذا السطر جوهري ومحوري للحفظ !!!
        //    _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

        //    // 5. حفظ البيانات في الداتابيز
        //    if (_LocalDrivingLicenseApplication.Save())
        //    {
        //        lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

        //        // تغيير وضع الشاشة إلى التحديث
        //        _Mode = enMode.Update;
        //        lblTitle.Text = "Update Local Driving License Application";

        //        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;

        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void tpPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPersonInfoBack_Click(object sender, EventArgs e)
        {
            tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpPersonalInfo"];
            return;
        }
    }
}
//private void DataBackEvent(object sender, int PersonID)
//{
//    // Handle the data received
//    _SelectedPersonID = PersonID;
//    ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);


//}
//هون في ديليجيت بس مش مستعمله 
