using AutoMapper;
using BuberBreakfast.Models;
using BuberBreakfast.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : Controller
{
    private static readonly List<Driver> _drivers = new List<Driver>();
    private readonly IMapper _mapper;

    public DriversController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDrivers()
    {
        var allDrivers = _drivers.Where(x => x.Status == 1).ToList();
        return Ok(allDrivers);
    }

    [HttpPost]
    public IActionResult CreateDriver(DriverCreateRequestDto data)
    {
        if (!ModelState.IsValid) return new JsonResult("Something went wrong") { StatusCode = 500 };
        
        var newDriver = _mapper.Map<Driver>(data);
        
        _drivers.Add(newDriver);
        return CreatedAtAction("GetDriver", new { newDriver.Id }, newDriver);
    }

    [HttpGet("{id}")]
    public IActionResult GetDriver(Guid id)
    {
        var item = _drivers.FirstOrDefault(x => x.Id == id);
        if (item == null) return NotFound();

        return Ok(item);
    }
}