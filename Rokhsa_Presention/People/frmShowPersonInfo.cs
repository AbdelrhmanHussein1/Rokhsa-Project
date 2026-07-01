//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using DVLD.Controls;
//using DVLD_Buisness;

//namespace Create_DVLD.People
//{
//    public partial class frmShowPersonInfo : Form
//    {
//        private int _PersonID = -1;

//        public frmShowPersonInfo(int PersonID)
//        {
//            InitializeComponent();
//            _PersonID = PersonID; // تأكد من وجود هذا السطر ليحفظ الرقم بدلاً من -1
//        }

//        public frmShowPersonInfo(string NationalNo)
//        {
//            InitializeComponent();
//            ctrlPersonCard1.LoadPersonInfo(NationalNo);
//        }

//        private void ctrlPersonCard1_Load(object sender, EventArgs e)
//        {

//        }

//        private void frmShowPersonInfo_Load(object sender, EventArgs e)
//        {
//            ctrlPersonCard1.LoadPersonInfo(_PersonID);

//        }

//        private void btnClose_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void ctrlPersonCard2_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Controls;
using DVLD_Buisness;

namespace Create_DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        // تعريف المتغيرات على مستوى الكلاس لحفظ القيم القادمة من الخارج
        private int _PersonID = -1;
        private string _NationalNo = "";

        // المنهج الأول: عند فتح الشاشة بواسطة الـ ID
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        // المنهج الثاني: عند فتح الشاشة بواسطة الرقم الوطني
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            // الآن حدث الـ Load أصبح ذكياً ويفحص طريقة الفتح قبل الاستدعاء
            if (_PersonID != -1)
            {
                // إذا كان هناك ID حقيقي ممرر، نادِ دالة الأرقام
                ctrlPersonCard1.LoadPersonInfo(_PersonID);
            }
            else if (_NationalNo != "")
            {
                // إذا كان الممرر هو الرقم الوطني، نادِ دالة النصوص
                ctrlPersonCard1.LoadPersonInfo(_NationalNo);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {
            // اتركها فارغة أو احذفها من شاشة الـ Events
        }

        private void ctrlPersonCard2_Load(object sender, EventArgs e)
        {
            // اتركها فارغة أو احذفها من شاشة الـ Events
        }
    }
}