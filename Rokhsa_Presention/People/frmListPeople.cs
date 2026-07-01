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

namespace Create_DVLD.People
{
    public partial class frmListPeople : Form
    {
        
        /*بالعاده بنستعمل هاي الداله في داخل فورم التحميل ولكن استعملناها هنا لسببين الاول حجم البيانات الخاص بلاشخاص يكون كبير جدا 
         ققد يسبب بطئ مقارنه بالمستخدمين مثلا(البيانات محمله قبل مالفورم يتحمل) والسبب الثاني التخصيص عدم عرض بعض العواميد التي لا حاجه لها */

        private static DataTable _dtAllPeople = clsPerson.GetAllPerson();//تخزين كامل من الداتا بيس

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
          //تخزين جزئي من الكامل                                            "FirstName", "SecondName", "ThirdName", "LastName",
                                                      "GendorCaption", "DateOfBirth", "CountryName",
                                                      "Phone", "Email");

        private void _RefreshPeoplList()
        {
            //التكرار بسبب تعديل البيانات نسخه جديده
            _dtAllPeople = clsPerson.GetAllPerson();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeoplList();
            cbFilterBy.SelectedIndex = 0;
            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

            if (dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;


                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;


                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;


                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.
                // الرقم بالظبط
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            //اي شي مشابه يعني اول باول
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //الشاشه الام هي الي تعمل اشتراك والي تعمل اينفوك هي الابن 
        //يعني الملخص مع الديليجيت فورم الاضافه بعدل على فورم الليست 
        //بدون ديليجيت فورم الليست بعدل على حاله فقط
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();/*مع ال showdialog رح يتوقف التنفيذ عند السطر الحلي مارح يكمل قراءه 
                                             اما ال show رح يكمل فرح يتم التحديث واحنا لسنا مش ضايفين او معدلين اشخاص 
         الحل : استعمل الديليجيت حتى يكون في ملتبل فورم لان الديليجيت مايهمه ترتيب الاسطر يهمه حدوث الايفينت فقط 
                                             */
            _RefreshPeoplList();
            /*هسا الفعل الاحترافي استخدام هاي الداله 
             * السبب :
             * احنا حاليا بنرجع كل ال الاشخاص او المستخدمين بسبب استعمال ال *في استعلام  السيليكت في الداتا بيس 
             مستقبلا رح نصير نرجع فيها بس اخر عشرين او عشره يعني الكل 
            اما سبب استعمالها حاليا هو التخصيص لاني مش بحاجه لكل العواميد اما في فورم اليوزر ما استعملتها اساسا 
            السبب اني استعملت داله التحميل مباشره مع جعل ال بارميتر نل والسبب تعليمي بحث + اننا نريد جميع العواميد بدون تخصيص
            عمليا يفضل استخدام الريفريش
            (كل هذا حتى يظهر التغيير على شاشه الليست لان بدونها مارح يتغير شي)
             */




            // الربط مع الديليجيت (الاشتراك في الحدث)
            //frmAddUpdatePerson.DataBack += frm_DataBack;
            //frmAddUpdatePerson.Show();
        }
        // دالة الاستقبال التي تنتظر "جرس" الديليجيت
        private void frm_DataBack(object sender, int PersonID)
        {
            // لا نحدث القائمة إلا إذا أرسلت لنا الشاشة الـ ID الجديد فعلياً
            _RefreshPeoplList();
        }


        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void txtFilterValue_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson(/*فارغه حتى بس يفتح مايكون في بيانات راجعه*/);
            frmAddUpdatePerson.ShowDialog();
            _RefreshPeoplList();

        }


//        ذا قلت: Toyota myCar = new Toyota();

//        تستطيع تشغيل "نظام التثبيت الذكي" الخاص بتويوتا فقط. (هذا هو النوع الصريح).

//        إذا قلت: Vehicle myCar = new Toyota();

//        تستطيع "القيادة" و "التوقف" فقط، لأن هذه ميزات موجودة في كل "المركبات". لن تستطيع الوصول لميزات تويوتا الخاصة لأنك عرفتها كـ "مركبة" عامة. (هذا هو نوع الأب).
//طبعا الي فهمته بما انا رح نستعمل الشوو فهي مابتفرق لان السياره  التوييواتا كمان تشمل  الميزات العامه بس سبب الفرق بين الاثنين تعليمي انه هيك ينفع وهيك ينفع
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);//مش فارغه حتى بس يفتح يرجع بيانات نعدلها 
            frm.ShowDialog();

            _RefreshPeoplList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
        //    Form frm = new frmShowPersonInfo(PersonID);
        //    frm.ShowDialog();
        //}
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // جلب القيمة باستخدام اسم العمود الصريح لضمان الدقة
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }
        private void cmsPeople_Opening(object sender, CancelEventArgs e)
        {

        }
      
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        //AI
        private void dgvPeople_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeople.ClearSelection();
                dgvPeople.Rows[e.RowIndex].Selected = true;
                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
