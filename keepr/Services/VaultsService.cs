using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;

    public VaultsService(VaultsRepository vaultsRepository)
    {
        _vaultsRepository = vaultsRepository;
    }

    internal Vault CreateVault(Vault vaultData)
    {
    int vaultId = _vaultsRepository.CreateVault(vaultData);

    Vault vault = GetVaultById(vaultId, vaultData.CreatorId);
    return vault;
    }

    internal Vault GetVaultById(int vaultId, string id = null)
    {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception($"No vault with the ID of {vault.Id}");
    }
    if (vault.IsPrivate == true && vault.CreatorId != id)
    {
      throw new Exception($"No vault with the ID of {vault.Id}");
    }
    return vault;
    }

    internal Vault UpdateVault(Vault vaultData, string userId)
    {
    Vault ogVault = GetVaultById(vaultData.Id, userId);
  if (ogVault.CreatorId != userId)
  {
      throw new Exception($"{ogVault.Name} is not your Vault! You cannot edit it!");
  }
    ogVault.Name = vaultData.Name ?? ogVault.Name;
    ogVault.Description = vaultData.Description ?? ogVault.Description;
    ogVault.Img = vaultData.Img ?? ogVault.Img;
    ogVault.IsPrivate = vaultData.IsPrivate ?? ogVault.IsPrivate;

    _vaultsRepository.UpdateVault(ogVault);
    return ogVault;
    }

    internal void RemoveVault(int vaultId, string id)
    {
    Vault vault = GetVaultById(vaultId, id);
    if (vault.CreatorId != id)
    {
      throw new Exception($"You are not the creator of {vault.Name}! You cannot delete it!");
    }
    _vaultsRepository.RemoveVault(vaultId);
    }

    internal List<Vault> GetMyVaults(string userId)
    {
    List<Vault> vaults = _vaultsRepository.GetMyVaults(userId);

    return vaults;
    }
}
