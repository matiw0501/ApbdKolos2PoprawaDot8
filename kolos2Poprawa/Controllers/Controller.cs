using kolos2Poprawa.Exceptions;
using kolos2Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolos2Poprawa.Controllers;

[ApiController]
public class Controller : ControllerBase
{
    private readonly IDbService _dbService;

    public Controller(IDbService dbService)
    {
        _dbService = dbService;
    }


    [HttpGet("api/nurseries/{id}/batches")]
    public async Task<IActionResult> GetNurseriesBatches([FromRoute] int id)
    {
        try
        {
            var nurseriesBatches = await _dbService.GetNurseriesBatches(id);
            return Ok(nurseriesBatches);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            
        }
        
    }
    
    [HttpPost("api/batches")]
    public async Task<IActionResult> AddBatch([FromBody] AddBatchDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _dbService.AddBatch(dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




}