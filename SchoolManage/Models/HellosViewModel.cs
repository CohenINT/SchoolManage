using System;
namespace SchoolManage.Models
{
    public class HellosViewModel
    {
            public string French { get; set; }
            public string Hebrew { get; set; }
            public string English { get; set; }
            public string Arabic { get; set; }

        public HellosViewModel()
        {

        }

        public HellosViewModel(string fre,string heb,string eng,string ara)
        {
            French = fre;
            Hebrew = heb;
            English = eng;
            Arabic = ara;
        }



    }
}
