using Platform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.Extensions
{
    public static class StudentExtension
    {
        public static IQueryable<Student> Search(this IQueryable<Student> students, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return students;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return students.Where(s => s.FirstName.ToLower().Contains(lowerCaseTerm));
        }
    }
}
