namespace Models{
    public class ContactEntity{
        public int Id{get;set;} //Deberia agregarse ID para una consulta?
        public string Name{get;set;}
        public string Lastname{get;set;}
        public string Email{get;set;}
        public int PhoneNumber{get;set;}
        public string Content{get;set;}
    }
}