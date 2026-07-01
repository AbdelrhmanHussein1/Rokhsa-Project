using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD.Controls;
using Create_DVLD.People;


namespace DVLD.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            cbFilterBy.SelectedIndex = 1;
        }

        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {  handler(PersonID); }
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        private int _PersonID = -1;

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }//clsPerson يرجع المختار_Person  مخصص للدوال الاخارجيه 
        }

        //public void LoadPersonInfo(int PersonID)
        //{

        //    cbFilterBy.SelectedIndex = 1;
        //    txtFilterValue.Text = PersonID.ToString();
        //    FindNow();

        //}
        public void LoadPersonInfo(int PersonID)
        {
            // 1. تثبيت مؤشر الفلتر على Person ID وعرض الرقم في خانة النص
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();

            // 2. استدعاء كرت الشخص الداخلي مباشرة لتحميل المعلومات بدون تشغيل دالة البحث العام FindNow()
            ctrlPersonCard1.LoadPersonInfo(PersonID);

            // 3. إطلاق الديليجيت لتأكيد ربط المعرف الصحيح مع الفورم الأب بعد اكتمال التحميل الناجح
            if (OnPersonSelected != null && ctrlPersonCard1.PersonID != -1)
            {
                OnPersonSelected(ctrlPersonCard1.PersonID);
            }
        }
        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;
                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            // 1. التحقق من أن الحقول داخل الـ User Control صالحة ولا تسبب أخطاء
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. التحقق الإضافي للتأكد من أن النص ليس فارغاً قبل استدعاء قاعدة البيانات
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                errorProvider1.SetError(txtFilterValue, "This field is required!");
                txtFilterValue.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }

            // 3. إذا كل شيء تمام، نفذ البحث
            FindNow();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
                errorProvider1.SetError(txtFilterValue, null);
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm1 = new frmAddUpdatePerson();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();

        }
        //ديليجيت
        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        //لم تشتغل ما اعرف السبب
        // حتى مع الربط
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            // سنستخدم FindForm لنتأكد من الوصول للفورم الأب
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true; // لمنع صوت الـ "طن" المزعج
                //MessageBox.Show("Enter key detected inside User Control!");
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        //قق بديل
        private void txtFilterValue_KeyDown(object sender, KeyEventArgs e)
        {
            // فحص ضغط زر Enter عبر KeyDown
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // السطر السحري لمنع صوت الـ "طن" المزعج نهائياً واحتواء الحدث

                // استدعاء زر البحث فوراً
                btnFind.PerformClick();
            }
        }
        private void gbFilters_Enter(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
                
        }
       
        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
