namespace StudentManagementAPI.Models;

public class StudentAddress
{

    public int Id { get; set; }

    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }



    // Navigation props
    public int? StudentId { get; set; }// FK

    public Student? Studnet { get; set; } //Navigation props

}
