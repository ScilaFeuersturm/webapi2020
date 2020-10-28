using System.Collections.Generic;

namespace Models{
    public class TeacherEntity{
        public int Id{get;set;}
        public string Name{get;set;}
        public string Lastname{get;set;}
        public string User{get;set;}
        public string Password{get;set;}
        public string Headquarter{get;set;}
        public string PhoneNumber{get;set;}
        public string EmergencyContactName{get;set;}
        public string EmergencyContactNumber{get;set;}

        public List<StudentEntity> students{set; get;}


    }
}