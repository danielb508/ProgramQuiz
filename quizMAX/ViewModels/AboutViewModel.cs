using Caliburn.Micro;
using quizMAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizMAX.ViewModels
{
    public class AboutViewModel : Screen
    {
        public string About { get; set; }
        public AboutViewModel()
        {
            GUIstringsModel strings = new GUIstringsModel();
            this.About = strings.GetGUIstr("About");
        }
    }
}