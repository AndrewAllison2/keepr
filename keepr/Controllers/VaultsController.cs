
namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth0;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth0, KeepsService keepsService)
    {
        _vaultsService = vaultsService;
        _auth0 = auth0;
        _keepsService = keepsService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.CreateVault(vaultData);
      return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpGet("{vaultId}")]
    public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
      return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{vaultId}")]
    public async Task<ActionResult<Vault>> UpdateVault([FromBody] Vault vaultData, int vaultId)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      vaultData.Id = vaultId;
      Vault vault = _vaultsService.UpdateVault(vaultData, userInfo?.Id);
      return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{vaultId}")]
    public async Task<ActionResult<string>> RemoveVault(int vaultId)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _vaultsService.RemoveVault(vaultId, userInfo.Id);
      return Ok("Your Vault has been removed!");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}/keeps")]
    public async Task<ActionResult<List<VaultedKeep>>> GetKeepsByVaultId(int vaultId)
    {
      try 
      {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      List<VaultedKeep> keeps = _keepsService.GetKeepsByVaultId(vaultId, userInfo?.Id);
      
      return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
}
