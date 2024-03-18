using System;
using System.Collections.Generic;

namespace OTUS_Homework_2.Entity;

public partial class Course
{
    public int CourseId { get; set; }

    public string NameCourse { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<CoursesTeacher> CoursesTeachers { get; set; } = new List<CoursesTeacher>();
}
