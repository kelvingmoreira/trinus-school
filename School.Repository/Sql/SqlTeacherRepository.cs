using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Sql
{
    public class SqlTeacherRepository : IRepository<Teacher>
    {
        private List<Teacher> teachers;

        public SqlTeacherRepository()
        {
            teachers = new List<Teacher>();
        }

        public bool DeleteAsync(int id)
        {
            Teacher teacher = teachers.SingleOrDefault(x => x.Id == id);
            if (teacher != null)
            {
                return teachers.Remove(teacher);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Teacher> GetAsync()
        {
            return teachers;
        }

        public Teacher GetAsync(Func<Teacher, bool> predicate)
        {
            return teachers.FirstOrDefault(predicate);
        }

        public IEnumerable<Teacher> GetWhereAsync(Func<Teacher, bool> predicate)
        {
            return teachers.Where(predicate);
        }

        public Teacher InsertAsync(Teacher entity)
        {
            teachers.Add(entity);
            return entity;
        }

        public Teacher UpdateAsync(Teacher entity)
        {
            Teacher teacher = teachers.SingleOrDefault(x => x.Id == entity.Id);

            if (teacher != null)
            {
                return teachers[teachers.IndexOf(teacher)] = entity;
            }
            else
            {
                throw new Exception("Professor não existe");
            }
        }
    }
}
