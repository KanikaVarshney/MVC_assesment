using TrainingManagement.Models;

namespace TrainingManagement
{
    public interface InterfaceCourse
    {
        List<Course> GetCourses();

        Course Create(Course course);
        Course GetCourseById(int id);
        int Edit(int id, Course course);
        int Delete(int id);
    }
}
