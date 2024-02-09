using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly ApiDbContext _context;

    public DriversController(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<List<Driver>>> GetDrivers()
    {
        var drivers = await _context.Drivers.ToListAsync();
        return Ok(drivers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriverDetails(int id)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(item => item.Id == id);

        if (driver is null)
            return NotFound();

        return Ok(driver);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDriverDetails), driver, driver.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver(Driver driver, int id)
    {
        var driverExist = await _context.Drivers.FirstOrDefaultAsync(item => item.Id == id);

        if (driverExist is null)
            return NotFound();

        driverExist.Name = driver.Name;
        driverExist.RacingNb = driver.RacingNb;
        driverExist.Team = driver.Team;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driverExist = await _context.Drivers.FirstOrDefaultAsync(item => item.Id == id);

        if (driverExist is null)
            return NotFound();
        
        _context.Drivers.Remove(driverExist);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}