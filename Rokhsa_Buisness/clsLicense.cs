using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using DVLD_DataAccess;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Buisness
{
    public class clsLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        //سبب المشكله

        public clsDriver DriverInfo;
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public clsLicenseClass LicenseClassIfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public clsDetainedLicense DetainedInfo { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }

        public clsLicense()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)

        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassIfo = clsLicenseClass.Find(this.LicenseClass);
            this.DetainedInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicenseData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;
            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);//
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicenseData.DeactivateLicense(this.LicenseID));
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID; // ربط الحجز بالرخصة الحالية
            detainedLicense.DetainDate = DateTime.Now;   // وقت الحجز الحالي
            detainedLicense.FineFees = Convert.ToSingle(FineFees); // تحديد قيمة الغرامة (Calculate FineFees)
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save()) // <--- هون الربط مع الـ DAL
            {
                return -1;
            }
            return detainedLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            //بشريا بنحكي نيو بعدها كومبليتد بس برمجيا احنا ندخل بيانات وسلمنا اذا مافي نيو عطول كومبليتد
            Application.LastStatusDate = DateTime.Now;//ووقت انشاء الطلب كمان الوقت الحالي
            Application.ApplicationDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())//هسا هون بنروح لكلاس الابليكيشن والسيف بتستدعي الادد الخاص بالكلاس ومن جوا الادد هي بتستدعي طبقه الداتا اكسيس وبتحط بالبراميتر ال THIS والقيمه الراجعه بتحطها لرقم الطلب
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;

            //كائن الرخصة الحالي(this) جواته كائن فرعي اسمه DetainedInfo
            //(معلومات الحجز).هذا الكائن الفرعي هو اللي مخزن جواته الـ LicenseID والـ DetainID وكل بلاوي الحجز.

            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);
            //            ليش الكود ما عدل على جدول الـ Licenses نفسه؟
            //لأن الرخصة نفسها(كرت الرخصة) بضل زي ما هو؛ ما بنعدل على تاريخ انتهائه ولا رقمه ولا فئته.الرخصة لما انحجزت، ما تغير فيها شيء، هي بس "انقفلت" برمجياً لأن جدول الـ DetainedLicenses نزل فيه سطر إنها محجوزة والـ IsReleased = 0.
            //فـ "فك الحجز" برمجياً وقانونياً يعني تعديل حالة الحجز في جدول الحجوزات لتصبح IsReleased = 1، وليس تعديل سطر الرخصة نفسه.بمجرد ما جدول الحجز يفتح القفل، الرخصة بترجع شغالة تلقائياً بالسيستم!
            //عشان هيك الكود ما احتاج يلمس جدول الـ Licenses مباشرة بالـ UPDATE؛ هو اكتفى بفتح الطلب المالي وتعديل جدول الحجز بدلالة كائن الرخصة الذكي الممسوك بالذاكرة(this).
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())// بننشئ رخصه جديده بمعلومات القديمه حتى مايضيع تاريخ القديمه عند التغيير وكلهم مربوطات برقم السائق
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassIfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassIfo.ClassFees;//عند النجاح في 3 اختبارات او انتهاء صلاحيه الرخصه اما عند البدل او فك الحجز مابنستعملها لانها بعدها صالحه
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;



            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

    }
}
//"كم معاملة فك حجز رخصة عملنا بشهر 5 لعام 2026؟" ➔ (هون السيستم بيعرف الجواب من ApplicationDate اللي خزنّاه هسا).

//"مين السائقين اللي لسه طلباتهم معلقة وما كملت؟" ➔ (هون السيستم بفلتر بناءً على ApplicationStatus).

//"كم دخل مالي دخل على الدائرة من وراء معاملات فك الحجز؟" ➔ (هون بنعمل SUM لحقل PaidFees).
//"مين الموظف اللي وافق على معاملة فك الحجز واستلم الفلوس من عبد الرحمن؟" ➔ (هون السيستم بيعرف الجواب فوراً من حقل CreatedByUserID اللي خزنّاه من الـ ReleasedByUserID).

//"شو هي المعاملة المالية اللي تسببت في فك الحجز عن الرخصة رقم 120؟" ➔ (هون السيستم بيعمل ربط وعن طريق الـ ApplicationID اللي تولد ورجعناه بالشاشة، بنعرف الوصل المالي والطلب اللي فكها بالظبط).

//"مين هو المواطن أو الشخص اللي استفاد من معاملة فك الحجز الحالية؟" ➔ (هون السيستم بيجيب الاسم الرباعي والبيانات الشخصية بدلالة الـ ApplicantPersonID اللي ربطناه بكائن السائق).

//"متى بالظبط تم إغلاق المعاملة وتحويلها من تحت الإجراء لتصبح منتهية؟" ➔ (هون السيستم بيطول الوقت بالدقيقة والثانية من حقل LastStatusDate).يعني متى صارت كومبليتد

//"كم عدد الرخص المحجوزة التي تم الإفراج عنها مقارنة بالرخص التي تم تجديدها هذا الشهر؟" ➔ (هون السيستم بيعمل فرز وعدّ COUNT بناءً على الـ ApplicationTypeID عشان يقارن بين الخدمات).