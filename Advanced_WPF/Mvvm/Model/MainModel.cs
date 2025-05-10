using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Advanced_WPF.Mvvm.Model
{

    public class MainModel
    {
        private BitmapImage photo;
        private Int32 id;
        private string fname, lname, gender;
        //---------------constructor-----------------
        public MainModel(BitmapImage user_photo, Int32 user_id, string user_fname,
                         string user_lname, string user_gender)
        {
            photo = user_photo;
            id = user_id;
            fname = user_fname;
            lname = user_lname;
            gender = user_gender;
        }
        //-------------------Properties----------------------
        public BitmapImage Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName
        {
            get { return fname; }
            set { fname = value; }
        }
        public string LastName
        {
            get { return lname; }
            set { lname = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}