using TrainingManagement.Context;
using TrainingManagement.Models;

namespace TrainingManagement.Repository
{
    public class CourseRepository:InterfaceCourse
    {
        TrainingDbContext _db;
        public CourseRepository(TrainingDbContext db)
        {
            _db = db;
        }

        public List<Course> GetCourses()
        {
            return _db.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _db.Courses.FirstOrDefault(x => x.CourseId == id);
        }


        public Course Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
        }
        public int Edit(int id, Course course)
        {
            Course obj = GetCourseById(id);
            if (obj != null)
            {
                foreach (Course temp in _db.Courses)
                {
                    if (temp.CourseId == id)
                    {
                       // temp.A = user.Address;
                        //temp.ContactNo = user.ContactNo;
                        temp.CourseName =course.CourseName;
                        temp.CourseDescription =course.CourseDescription;
                        temp.Duration = course.Duration;
                        //temp.LastName = user.LastName;
                       
                    }
                }
                _db.SaveChanges();
                return 0;
            }
            else


                return 1;
        }
        public int Delete(int id)
        {
            Course obj = GetCourseById(id);
            if (obj != null)
            {
                _db.Courses.Remove(obj);
                _db.SaveChanges();
            }
            return 1;
        }
    }
}
