using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public DateTime BirthDate { get; set; }
        public int SectionId { get; set; }
        public int YearResult { get; set; }

        //Propriété de navigation
        public Section Section { get; set; }
    }
}
