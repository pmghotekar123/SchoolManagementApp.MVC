using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.MVC.Data;

public class LectureMetadata
{
    [Display(Name="First Name")]
    public string FirstName { get; set; } = null!;

    [Display(Name="Last Name")]
    public string LastName { get; set; } = null!;
}

[ModelMetadataType(typeof(LectureMetadata))]
public partial class Lecture{}