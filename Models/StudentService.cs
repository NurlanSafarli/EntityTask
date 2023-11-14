using EntityTask.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTask.Models
{
    internal class StudentService
    {
        private static AppDbContext _context = new AppDbContext();

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
          
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(int id, string name, string surname, int avgPoint)
        {
            var existingStudent = GetById(id);

            if (existingStudent != null)
            {
                existingStudent.Name = name;
                existingStudent.Surname = surname;
                existingStudent.AvgPoint = avgPoint;

                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Telebe tapilmadi");
            }
        }

        public void Delete(int id)
        {
            var studentToDelete = GetById(id);

            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Telebe tapilmadi");
            }
        }
    }
}

