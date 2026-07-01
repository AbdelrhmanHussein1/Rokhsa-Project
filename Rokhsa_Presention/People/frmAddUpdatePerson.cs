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
using DVLD.Classes;
using DVLD_Buisness;
using DVLD.Controls;
using Microsoft.Win32;
using System.IO;


namespace Create_DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _PersonID = -1;
        clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _ResetDefualtValues()//add
        {
            //this will initialize the reset the defaule values
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            //set default image for the person.
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
            //عع
            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";


        }


        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _LoadData()//update
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //this.Close(); Error 
                this.FindForm()?.Close();//هذه لليوزر كنترول لان لايزجد فيه close فيذهب للاب لفورم الاب وال ؟ امان اكثر لتفادي اي اخطاء 
                //هسسا مالها داعي
                return;
            }

            //the following code will not be executed if the person was not found
            //lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);


            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;

            }

            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (_Person.ImagePath != "");

        }

        public void LoadPersonData(int PersonID)
        {

            // more abstraction + مرونه اكبر بدل ما اضل اعطي قيمه الداله بتوخذ المخزن في المتغير البرايفت ووحده للتواصل ووحده كالمطبخ
            _PersonID = PersonID;
            _LoadData(); // هذه هي الدالة الخاصة التي تحتوي على Find والرسالة
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.

            //MessageBox.Show("تم الدخول إلى دالة معالجة الصور بنجاح!");
            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;

        }
        //private bool _HandlePersonImage()
        //{
        //    MessageBox.Show("تم الدخول للدالة\n" +
        //                    "مسار الصورة في القاعدة: " + _Person.ImagePath + "\n" +
        //                    "مسار الصورة في الأداة على الشاشة: " + pbPersonImage.ImageLocation);

        //    if (_Person.ImagePath != pbPersonImage.ImageLocation)
        //    {
        //        MessageBox.Show("البرنامج نجح في عبور الشرط الأول (المساران مختلفان)!");

        //        if (pbPersonImage.ImageLocation != null)
        //        {
        //            MessageBox.Show("البرنامج نجح في عبور الشرط الثاني وجاري استدعاء دالة النسخ الآن...");

        //            string SourceImageFile = pbPersonImage.ImageLocation.ToString();

        //            if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
        //            {
        //                pbPersonImage.ImageLocation = SourceImageFile;
        //                MessageBox.Show("تمت عملية النسخ وتحديث المسار بنجاح تام!");
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("فشلت دالة النسخ الخارجية!");
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("البرنامج خرج لأن pbPersonImage.ImageLocation قيمتها فارغة (Null)!");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("البرنامج خرج لأن مسار الصورة القديمة يساوي تماماً مسار الصورة الحالية (لم تتغير الصورة)!");
        //    }
        //    return true;
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_HandlePersonImage())
                return;
        

        int NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gendor = (short)enGendor.Male;
            else
                _Person.Gendor = (short)enGendor.Female;

            _Person.NationalityCountryID = NationalityCountryID;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                //lblPersonID.Text = _Person.PersonID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            Control Temp = ((Control)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidatoin.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            //Make sure the national number is not used by another person
            //الشرط الاول للتعديل اذا كان نفسه المكتوب رقم الشخص بشيل الايرور
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.isPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pbPersonImage.ImageLocation = null;



            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = false;
        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;

                // 🟢 التعديل السحري: قم بتعيين المسار النصي للأداة مباشرة
                pbPersonImage.ImageLocation = selectedFilePath;

                // (اختياري) يمكنك إبقاء الـ Load أو الاستغناء عنها لأن تعيين ImageLocation يقوم بالتحميل تلقائياً
                // pbPersonImage.Load(selectedFilePath); 

                llRemoveImage.Visible = true;
            }
        }
        //private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
        //    openFileDialog1.FilterIndex = 1;
        //    openFileDialog1.RestoreDirectory = true;

        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        // Process the selected file
        //        string selectedFilePath = openFileDialog1.FileName;
        //        pbPersonImage.Load(selectedFilePath);
        //        llRemoveImage.Visible = true;
        //        // ...
        //    }
        //}

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked && pbPersonImage.ImageLocation == null)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked && pbPersonImage.ImageLocation == null)
            {
                pbPersonImage.Image = Resources.Female_512;
            }
        }
        private void txtNameFields_LettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. منع صوت الـ "طن" المزعج وتفعيل زر الإدخال إذا لزم الأمر
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;
                return;
            }

            // 2. السماح فقط بالحروف (العربية والإنجليزية)، ومفاتيح التحكم (مثل Backspace)، والمسافات
            // أي شيء غير ذلك (أرقام أو رموز مثل @, #, $, إلخ) سيتم حظره وتجاهله
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true; // احظر الضغطة
            }
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNationalNo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // إذا كان الحرف المدخل ليس رقماً وليس مفتاح "Backspace" (للإلغاء)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // يتم تجاهل الضغطة ومنع ظهور الحرف
            }
        }
    }
}
