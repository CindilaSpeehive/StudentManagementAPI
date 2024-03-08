namespace StudentManagementAPI.Dtos;

public class CreateUpdateStudentDto
{
    // Id property is not needed.
    // When we create Student we wont pass Id
    //? means nullable prop(its ok to pass null value)
    public string? Name { get; set; }
    public string? Description { get; set; }
    public StudentAddressDto?  StudentAddress{ get; set; }
}
