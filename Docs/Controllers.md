# Controllers

Controllers in this project handle the HTTP requests for various endpoints. Below is a brief overview of the main controllers:

- **StudentController**: Manages CRUD operations for students.

### Example: StudentController

```csharp
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    // Additional actions (Create, Update, Delete) go here
}
