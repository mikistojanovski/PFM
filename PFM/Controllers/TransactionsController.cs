using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using PFM.Commands;
using PFM.Models;
using PFM.Services;

namespace PFM.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{


    private readonly ILogger<TransactionController> _logger;
    
    private readonly ITransactionService _transactionService;

    public TransactionController(ILogger<TransactionController> logger, ITransactionService transaction)
    {
        _logger =logger;
        _transactionService = transaction;
    }

    //Post 
    [HttpPost]
    public async Task<IActionResult> CreateTransaction(IFormFile file, [FromServices] IWebHostEnvironment hostingEnvironment)
    {

        //CSV
        string filename = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
        using (FileStream fs = System.IO.File.Create(filename))
        {
            file.CopyTo(fs);
            fs.Flush();
        }
        var commands = this.GetCommands(filename);
        



        var result = await _transactionService.CreateTransaction(commands);

        if (result.Count == 0)
        {
            return BadRequest("No transactions created");
        }
        else
        {
            return Ok();
        }




    }

    private List<CreateTransactionCommand> GetCommands(string filename)
    {
        var commands = new List<CreateTransactionCommand>();

        //CSV
        var path = $"{filename}";
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {

            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var com = csv.GetRecord<CreateTransactionCommand>();
                commands.Add(com);
            }
        }

        return commands;
    }

    //POST
    [HttpPost("transactionid")]
    public async Task<IActionResult> CategorizeTransaction([FromQuery] int transactionid, [FromQuery] string namecategory)
    {
        var result = await _transactionService.CategorizeTransaction(transactionid, namecategory);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok();
    }

    //GET with pages
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder)
    {
        page = page ?? 1;
        pageSize = pageSize ?? 10;
        _logger.LogInformation("Returning {page}. page of products", page);
        var result = await _transactionService.GetTransactions(page.Value, pageSize.Value, sortBy, sortOrder);
        return Ok(result);
    }

    //B6
    [HttpPost("{id}/split")]
    public async Task<IActionResult> Split([FromRoute] int id)
    {
        var result = await _transactionService.SplitTransactions(id);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok();
    }



}
