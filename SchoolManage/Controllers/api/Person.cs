namespace SchoolManage.Controllers
{

  
    public class Person
    {
        public int id;
        public string lang;
        public string hello;
        public string name;

        public Person()
        {
            this.id = 0;
            this.lang = "";
            this.hello = "";
        }

        public Person(int _id,string _lang, string _hello,string _name)
        {
            setPerson(_id, _lang, _hello,_name);
        }

        public void setPerson(int _id,string _lang,string _hello,string _name)
        {
            this.hello = _hello;
            this.lang = _lang;
            this.name = _name;
            this.id = _id;
        }
    }

    


}