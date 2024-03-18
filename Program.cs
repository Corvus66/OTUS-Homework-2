using OTUS_Homework_2.Entity;

namespace OTUS_Homework_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teachersList = GetAllTeachers();
            var coursessList = GetAllCourses();
            var coursesWithTeachers = GetAllCoursesTeachers(teachersList, coursessList);

            PrintCoursesAndTeachers(coursesWithTeachers);

            InsertNewCourse();

            coursessList = GetAllCourses();
            coursesWithTeachers = GetAllCoursesTeachers(teachersList, coursessList);

            PrintCoursesAndTeachers(coursesWithTeachers);

            Console.ReadKey();
        }

        private static void PrintCoursesAndTeachers(List<CoursesTeacher> coursesWithTeachers)
        {
            foreach (var row in coursesWithTeachers)
            {
                Console.WriteLine($"Название курса: {row.Course.NameCourse} \n Цена: {row.Course.Price} \n Преподаватель: {row.Teacher.NameTeacher} \n Уровень преподавателя: {row.Teacher.Grade}");
                Console.WriteLine();
            }
        }

        internal static List<Teacher> GetAllTeachers()
        {
            using (PostgresContext dbContext = new PostgresContext())
            {
                return dbContext.Teachers.ToList();
            }
        }

        internal static List<Course> GetAllCourses()
        {
            using (PostgresContext dbContext = new PostgresContext())
            {
                return dbContext.Courses.ToList();
            }
        }

        internal static List<CoursesTeacher> GetAllCoursesTeachers(List<Teacher> teachersList, List<Course> coursessList)
        {
            using (PostgresContext dbContext = new PostgresContext())
            {
                var res = dbContext.CoursesTeachers.ToList();
                res.ForEach(x => x.Course = coursessList.FirstOrDefault(y => y.CourseId == x.CourseId));
                res.ForEach(x => x.Teacher = teachersList.FirstOrDefault(y => y.TeacherId == x.TeacherId));
                return res;
            }
        }

        internal static void InsertNewCourse()
        {
            using (PostgresContext ctx = new PostgresContext())
            {
                var course = new Course()
                {
                    NameCourse = "TestCourse",
                    Price = 10000
                };

                ctx.Courses.Add(course);
                ctx.SaveChanges();

                var courseTeacher = new CoursesTeacher()
                {
                    TeacherId = 5,
                    CourseId = course.CourseId
                };

                ctx.CoursesTeachers.Add(courseTeacher);
                ctx.SaveChanges();

                Console.WriteLine("Added new rows");
                Console.WriteLine();
            }
        }
    }
}