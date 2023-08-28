using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _auth0;

    public ProfilesController(ProfilesService profilesService, Auth0Provider auth0)
    {
        _profilesService = profilesService;
        _auth0 = auth0;
    }


    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetProfileById(string profileId)
    {
      try 
      {
      Profile profile = _profilesService.GetProfileById(profileId);
      return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetUserKeepsByProfileId(string profileId)
    {
      try 
      {
      List<Keep> keeps = _profilesService.GetUserKeepsByProfileId(profileId);
      return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetUserVaultsByProfileId(string profileId)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _profilesService.GetUserVaultsByProfileId(profileId, userInfo?.Id);
      return Ok(vaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
}
