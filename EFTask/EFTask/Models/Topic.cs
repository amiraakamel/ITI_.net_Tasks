﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EFTask.Models;

public partial class Topic
{
    public int Top_Id { get; set; }

    public string Top_Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}