using Microsoft.EntityFrameworkCore;
using Model.EF;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            EntitiesDbContext entities = new EntitiesDbContext();
            //entities.Database.EnsureCreated();

            //Section BiSharePoint = entities.Sections.Find(1);

            //Section CSharp = new Section() { SectionName = "C# 9.0" };
            //Section Sql = new Section() { SectionName = "Sql Server" };

            //Student student = new Student()
            //{
            //    LastName = "Test1",
            //    FirstName = "Test1",
            //    Login = "Test1",
            //    Section = BiSharePoint,
            //    BirthDate = new DateTime(1981, 03, 01),
            //    YearResult = 14
            //};

            //Student student2 = new Student()
            //{
            //    LastName = "Test2",
            //    FirstName = "Test2",
            //    Login = "Test2",
            //    Section = BiSharePoint,
            //    BirthDate = new DateTime(1981, 03, 01),
            //    YearResult = 14
            //};

            //Student student3 = new Student()
            //{
            //    LastName = "Test3",
            //    FirstName = "Test3",
            //    Login = "Test3",
            //    Section = BiSharePoint,
            //    BirthDate = new DateTime(1981, 03, 01),
            //    YearResult = 14
            //};

            //Student student4 = new Student()
            //{
            //    LastName = "Test4",
            //    FirstName = "Test4",
            //    Login = "Test4",
            //    Section = BiSharePoint,
            //    BirthDate = new DateTime(1981, 03, 01),
            //    YearResult = 14
            //};

            //entities.AddRange(Sql, CSharp);//, student, student2, student3, student4);

            //entities.SaveChanges();

            //Console.WriteLine($"{BiSharePoint.Id} : {BiSharePoint.SectionName}");

            Student student = entities.Students.Include(st => st.Section).ThenInclude(se => se.Students).SingleOrDefault(st => st.Id == 2);

            Console.WriteLine($"{student.LastName} {student.FirstName} {student.Section.SectionName}");
            foreach(Student st in student.Section.Students)
            {
                Console.WriteLine($"{st.LastName}");
            }

            Console.ReadLine();
        }
    }
}
