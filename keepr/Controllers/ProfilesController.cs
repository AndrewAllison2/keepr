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

    public ProfilesController(ProfilesService profilesService)
    {
        _profilesService = profilesService;
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

    // [HttpGet("{profileId}/keeps")]
    // public ActionResult<List<Keep>> GetUserKeepsByProfileId(string profileId)
    // {
    //   try 
    //   {
    //   List<Keep> keeps = _profilesService.GetUserKeepsByProfileId(profileId);
    //   return Ok(keeps);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
}
