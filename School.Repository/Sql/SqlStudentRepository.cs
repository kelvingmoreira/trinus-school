using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Sql
{
    public class SqlStudentRepository : IRepository<Student>
    {
        private List<Student> students;

        public SqlStudentRepository()
        {
            students = new List<Student>();
        }

        public bool DeleteAsync(int id)
        {
            Student student = students.SingleOrDefault(x => x.Id == id);

            if (student != null)
            {
                return students.Remove(student);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Student> GetAsync()
        {
            return students;
        }

        public Student GetAsync(Func<Student, bool> predicate)
        {
            return students.FirstOrDefault(predicate);
        }

        public IEnumerable<Student> GetWhereAsync(Func<Student, bool> predicate)
        {
            return students.Where(predicate);
        }

        public Student InsertAsync(Student entity)
        {
            students.Add(entity);
            return entity;
        }

        public Student UpdateAsync(Student entity)
        {
            Student student = students.SingleOrDefault(x => x.Id == entity.Id);

            if (student != null)
            {
                return students[students.IndexOf(student)] = entity;
            }
            else
            {
                throw new Exception("Aluno não existe");
            }
        }
    }
}
