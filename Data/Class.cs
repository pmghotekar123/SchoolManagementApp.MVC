using System;
using System.Collections.Generic;

namespace SchoolManagementApp.MVC.Data;

public partial class Class
{
    public int Id { get; set; }

    public int? LectureId { get; set; }

    public int? CourseId { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();

    public virtual Lecture? Lecture { get; set; }
}
