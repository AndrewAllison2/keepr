using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth0;

    public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth0)
    {
        _vaultKeepsService = vaultKeepsService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep data)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      data.CreatorId = userInfo.Id;
      VaultKeep vaultkeep = _vaultKeepsService.CreateVaultKeep(data);
      return Ok(vaultkeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{vaultKeepId}")]
    public async Task<ActionResult<string>> RemoveVaultKeep(int vaultKeepId)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _vaultKeepsService.RemoveVaultKeep(vaultKeepId, userInfo?.Id);
      return Ok("Keep was removed from your Vault!");

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

        [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<VaultKeep>>> GetVaultKeeps()
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      List<VaultKeep> vaultkeeps = _vaultKeepsService.GetVaultKeeps(userInfo.Id);
      return Ok(vaultkeeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
}
