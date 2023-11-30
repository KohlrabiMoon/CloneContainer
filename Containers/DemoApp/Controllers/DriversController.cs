using DemoApp.Data;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers;

[ApiController]
[Route("[controllers]")]

public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly ApiDbContext _context;

    public DriversController(
        ILogger<DriversController> logger,
        ApiDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet (Name = "GetAllDrivers")]
    public async Task<IActionResult> Get()
    {
        var driver = new Driver()
        {
            DriverNumber = 21,
            Name = " Sir Mrs Hao"
        };

        _context.Add(driver);
        await _context.SaveChangesAsync();

        var allDrivers = await _context.Drivers.ToListAsync();

        return Ok(allDrivers);
    }
}