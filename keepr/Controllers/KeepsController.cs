using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
      private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth0;

    public KeepsController(KeepsService keepsService, Auth0Provider auth0)
    {
        _keepsService = keepsService;
        _auth0 = auth0;
    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepsService.CreateKeep(keepData);
      return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Keep>> GetKeeps()
    {
      try 
      {
      List<Keep> keeps = _keepsService.GetKeeps();
      return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{keepId}")]
    public ActionResult<Keep> GetKeepById(int keepId)
    {
      try 
      {
      // Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.GetKeepByIdAndUpdateVisits(keepId);
      return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{keepId}")]
    public async Task<ActionResult<Keep>> UpdateKeep(int keepId,[FromBody] Keep keepData)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepsService.UpdateKeep(keepId, keepData);
      return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{keepId}")]
    public async Task<ActionResult<string>> RemoveKeep(int keepId)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _keepsService.RemoveKeep(keepId, userInfo?.Id);
      return Ok("Your Keep has been removed!");

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
}
