using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public int? DelegateId { get; set; }

        public List<Student> Students { get; set; }
    }
}
