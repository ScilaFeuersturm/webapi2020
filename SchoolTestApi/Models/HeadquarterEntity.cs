using System.Collections.Generic;

namespace Models{
    public class HeadquarterEntity{
        public int Id{get;set;} 
        public string Name{get;set;}
        public List<TeacherEntity> teachers {set;get;}
        
    }
}