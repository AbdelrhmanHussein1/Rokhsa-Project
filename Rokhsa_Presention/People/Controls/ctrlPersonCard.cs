using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Create_DVLD.Properties;
using DVLD_Buisness;
using System.IO;
using DVLD.Controls;
using Create_DVLD.People;


namespace DVLD.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }


        private clsPerson _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo//مش فاهم لبش
        {
            get { return _Person; }//فهمت هاي بتمرر معلومات الشخص المختار لدوار خارجيه عشان الحفاظ على مبدا الابستراكشن وسريه البيرسون برايفت
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {
            // تم تغيير pbPersonImage إلى guna2CirclePictureBox1
            if (_Person.Gendor == 0)
                guna2CirclePictureBox1.Image = Resources.Male_512;
            else
                guna2CirclePictureBox1.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    guna2CirclePictureBox1.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _FillPersonInfo()
        {
            // تعديل أسماء الـ Labels والروابط لتطابق أسماء ملف الديزاينر الجديد
            llblEditPerson.Enabled = true;
            _PersonID = _Person.PersonID;

            lblPersonIDValue.Text = _Person.PersonID.ToString();
            lblNationalNoValue.Text = _Person.NationalNo;
            lblNameValue.Text = _Person.FullName; // لاحظ هنا تم ربطه بـ lblNameValue
            lblGenderValue.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblEmailValue.Text = _Person.Email;
            lblPhoneValue.Text = _Person.Phone;
            lblDateOfBirthValue.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountryValue.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblAddressValue.Text = _Person.Address;

            _LoadPersonImage();
        }






        //public void ResetPersonInfo()
        //{
        //    _PersonID = -1;
        //    lblPersonID.Text = "[????]";
        //    lblNationalNo.Text = "[????]";
        //    lblFullName.Text = "[????]";
        //    pbGendor.Image = Resources.Man_32;
        //    lblGendor.Text = "[????]";
        //    lblEmail.Text = "[????]";
        //    lblPhone.Text = "[????]";
        //    lblDateOfBirth.Text = "[????]";
        //    lblCountry.Text = "[????]";
        //    lblAddress.Text = "[????]";
        //    pbPersonImage.Image = Resources.Male_512;

        //}
        public void ResetPersonInfo()
        {
            _PersonID = -1;

            // ربط الأسماء الجديدة بناءً على ملف الديزاينر
            lblPersonIDValue.Text = "[????]";
            lblNationalNoValue.Text = "[????]";
            lblNameValue.Text = "[????]";       // الاسم الكامل
            lblGenderValue.Text = "[????]";      // الجنس
            lblEmailValue.Text = "[????]";
            lblPhoneValue.Text = "[????]";
            lblDateOfBirthValue.Text = "[????]";
            lblCountryValue.Text = "[????]";
            lblAddressValue.Text = "[????]";

            // pbGendor.Image = Resources.Man_32; // سطر قديم لو مش موجودة الأداة احذفه أو اتركه كومنت

            // الصورة الشخصية الدائرية الجديدة (Guna2CirclePictureBox)
            guna2CirclePictureBox1.Image = Resources.Male_512;
        }
        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void pbPersonImage_Click(object sender, EventArgs e)
        {

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }

        private void gbPersonInformation_Click(object sender, EventArgs e)
        {

        }

        private void gbPersonInformation_Click_1(object sender, EventArgs e)
        {

        }

        private void lblNameValue_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblCountryValue_Click(object sender, EventArgs e)
        {

        }
    }
}
