namespace StudentManagementAPI.Dtos;

public class StudentDetailsDto
{
    public int Id { get; set; } // Id is needed
    public string Name { get; set; }
    public string Description { get; set; }
    public StudentAddressDto Address { get; set; }
}
