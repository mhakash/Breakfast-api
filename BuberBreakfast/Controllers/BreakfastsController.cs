using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")]
public class BreakfastsController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            StarDateTime = request.StartDateTime,
            EndDateTime = request.EndDateTime,
            LastModifiedDateTime = DateTime.UtcNow,
            Savory = request.Savory,
            Sweet = request.Sweet
        };

        _breakfastService.CreateBreakfast(breakfast);

        var breakfastResponse = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StarDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);

        return CreatedAtAction(
            nameof(GetBreakfast),
            new { id = breakfast.Id },
            breakfastResponse);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        var breakfast = _breakfastService.GetBreakfast(id);
        return Ok(breakfast);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }

}