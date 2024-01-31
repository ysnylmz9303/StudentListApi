using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static private List<Student> studentsItem = new()
        {
            new Student { Id = 1, FirstName = "Denemeisim1", LastName = "Denemesoyisim1" },
            new Student { Id = 2, FirstName = "Denemeisim2", LastName = "Denemesoyisim2" },
            new Student { Id = 3, FirstName = "Denemeisim3", LastName = "Denemesoyisim3" },
            new Student { Id = 4, FirstName = "Denemeisim4", LastName = "Denemesoyisim4" },
            new Student { Id = 5, FirstName = "Denemeisim5", LastName = "Denemesoyisim5" },
            new Student { Id = 6, FirstName = "Denemeisim6", LastName = "Denemesoyisim6" },
            new Student { Id = 7, FirstName = "Denemeisim7", LastName = "Denemesoyisim7" },
            new Student { Id = 8, FirstName = "Denemeisim8", LastName = "Denemesoyisim8" }
        };  

        [HttpGet]

        public IEnumerable<Student> GetAllStudents()
        {
            return studentsItem;
        }

        [HttpGet("{id}")]

        public Student? GetStudent(int id)
        {
            return studentsItem.Find(a => a.Id == id);
        }

        [HttpPost]

        public void AddStudents(string firstName, string lastName)
        {
            var item = new Student
            {
                Id = studentsItem.Count + 1,
                FirstName = firstName,
                LastName = lastName
            };

            studentsItem.Add(item);
        }

        [HttpPut("{id}")]

        public void UpdateStudent (int id,string firstName,string lastName)
        {
            var index = studentsItem.FindIndex(a => a.Id == id);

            if (index == -1 )
            {
                return;
            }

            studentsItem[index] = new Student
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
        }

        [HttpDelete("(id)")]

        public void DeleteStudent(int id)
        {
            var index = studentsItem.FindIndex(a => a.Id == id);
                
            if (index == -1 )
            {
                return;
            }

            studentsItem.RemoveAt(index);
        }



    }
}
