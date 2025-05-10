using Advanced_WPF.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_WPF.Mvvm.ViewModel
{
    public class MainViewModel
    {
        private List<Advanced_WPF.Mvvm.Model.MainModel> main_model_list = new List<Model.MainModel>();
        //---------constructor--------------
        public MainViewModel()
        {
            string fn;
            fn = Environment.CurrentDirectory + "\\Data\\Pics\\user\\";
            main_model_list.Add(new Model.MainModel(
                                 new System.Windows.Media.Imaging.BitmapImage(new Uri(fn + "face1.jpg")),
                                 12, "Alex", "Parker", "Male"));
            //-----------------
            main_model_list.Add(new Model.MainModel(
                                 new System.Windows.Media.Imaging.BitmapImage(new Uri(fn + "face2.jpg")),
                                 15, "Mike", "Jackson", "Male"));
            //-----------------
            main_model_list.Add(new Model.MainModel(
                                 new System.Windows.Media.Imaging.BitmapImage(new Uri(fn + "face3.jpg")),
                                 18, "Sara", "Madeson", "Female"));
        }
        //---------properties---------------
        public List<Model.MainModel> MainModelList
        {
            get { return main_model_list; }
            set { main_model_list = value; }
        }
    }
}
