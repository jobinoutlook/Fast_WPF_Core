using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Advanced_WPF.MyClass
{
    public class User_Adder

    {
        private string id,first_name,last_name;
        private DateTime reg_date;
        private BitmapImage user_photo;
        public User_Adder(string my_id, string my_fname, string my_lname,
                        DateTime my_reg_date , BitmapImage my_user_photo)
        {
            id=my_id;
            first_name=my_fname;
            last_name=my_lname;
            reg_date=my_reg_date;
            user_photo=my_user_photo;
        }
        //----------------------------
        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        //----------
        public String First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }
        //----------
        public String Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }
        //----------
        public DateTime Reg_date
        {
            get { return reg_date; }
            set { reg_date = value; }
        }
        //----------
        public BitmapImage User_photo
        {
            get { return user_photo; }
            set { user_photo = value; }
        }
        //----------
    }
}
