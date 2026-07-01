using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Create_DVLD.People
{
    public partial class frmFindPerson : Form
    {

        public delegate void DataBackEventHadlerDelegate(object sender, int PersonID);
        public event DataBackEventHadlerDelegate DataBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {

        }
        

        //للعمليات المتتاليه 
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 1. إرسال البيانات للشاشة الأم
            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);

            // 2. إغلاق الشاشة الحالية تلقائياً
            this.Close();
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
