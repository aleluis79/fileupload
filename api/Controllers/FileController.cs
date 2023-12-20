using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;

    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    [HttpGet("ping")]
    public ActionResult<string> Ping()
    {
        return Ok("pong");
    }

    [HttpPost("upload")]
    public ActionResult<string> Upload([FromForm] RequestUpload request)
    {
        // guardar archivo en disco
        if (request.File != null && request.File.Length > 0)
        {
            string filePath = "./assets/" + request.File.FileName;
            request.File.CopyToAsync(new FileStream(filePath, FileMode.Create)).GetAwaiter().GetResult();
            return Ok($"File con id {request.Id} saved successfully");
        }
        else
        {
            return BadRequest("No file uploaded");
        }

    }


}

public class RequestUpload {
    public IFormFile? File { get; set; }
    public string? Id { get; set; }
}
