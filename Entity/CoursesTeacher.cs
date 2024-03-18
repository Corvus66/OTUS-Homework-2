using System;
using System.Collections.Generic;

namespace OTUS_Homework_2.Entity;

public partial class CoursesTeacher
{
    public int CoursesTeachersId { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
