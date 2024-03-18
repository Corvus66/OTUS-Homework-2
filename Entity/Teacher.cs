using System;
using System.Collections.Generic;

namespace OTUS_Homework_2.Entity;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string NameTeacher { get; set; } = null!;

    public int Grade { get; set; }

    public virtual ICollection<CoursesTeacher> CoursesTeachers { get; set; } = new List<CoursesTeacher>();
}
