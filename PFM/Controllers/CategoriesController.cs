using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using PFM.Commands;
using PFM.Models;
using PFM.Services;


namespace PFM.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{


    private readonly ILogger<CategoriesController> _logger;
    
    private readonly ICategoryService _categoryService;

    public CategoriesController(ILogger<CategoriesController> logger, ICategoryService PFM)
    {
        _logger = logger;
        _categoryService = PFM;
    }
    //Create Post
    [HttpPost]
    public async Task<IActionResult> CreateCategories(IFormFile file, [FromServices] IWebHostEnvironment hostingEnvironment)
    {
        if (file == null)
        {
            return BadRequest("No file");
        }
        //CSV
        string filename = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
        using (FileStream fs = System.IO.File.Create(filename))
        {
            file.CopyTo(fs);
            fs.Flush();
        }
        var commands = this.GetCommands(filename);
       


        var result = await _categoryService.Create(commands);

        if (result.Count == 0)
        {
            return BadRequest("No categories created");
        }
        else
        {
            return Ok();
        }

    }
    //List Get
    private List<CreateCategoryCommand> GetCommands(string filename)
    {
        var commands = new List<CreateCategoryCommand>();

        //CSV
        var path = $"{filename}";
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {

            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var com = csv.GetRecord<CreateCategoryCommand>();
                commands.Add(com);
            }
        }
        
        return commands;
    }
    //Get Analytical
    [HttpGet("Analytical-View")]
    public async Task<IActionResult> GetAnalysis(string catcode, string sd, string ed, string direction)
    {


        var result = await _categoryService.GetAnalysis(catcode, sd, ed, direction);
        return Ok(result);
    }


}