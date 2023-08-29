using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsService vaultsService, KeepsService keepsService)
    {
        _vaultKeepsRepository = vaultKeepsRepository;
        _vaultsService = vaultsService;
        _keepsService = keepsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep data)
    {
    Vault vault = _vaultsService.GetVaultById(data.VaultId);
    if (vault.CreatorId != data.CreatorId)
    {
      throw new Exception("You cannot add Keeps to other users vaults");
    }
    VaultKeep vaultkeep = _vaultKeepsRepository.CreateVaultKeep(data);
    _keepsService.IncrementKeptCount(data.KeepId, vaultkeep.Id);
    return vaultkeep;
    }

    internal VaultKeep GetVaultKeepById(int vaultKeepId)
    {
    VaultKeep vaultKeep = _vaultKeepsRepository.GetVaultKeepById(vaultKeepId);
  if(vaultKeep == null){
      throw new Exception("No Keep in a Vault with that ID");
  }
    return vaultKeep;
    }

    internal List<VaultKeep> GetVaultKeeps(string userId)
    {
    List<VaultKeep> vaultkeeps = _vaultKeepsRepository.GetVaultKeeps(userId);
        return vaultkeeps;
    }

    internal void RemoveVaultKeep(int vaultKeepId, string id)
    {
    VaultKeep vaultkeep = GetVaultKeepById(vaultKeepId);
    if (vaultkeep.CreatorId != id)
    {
      throw new Exception($"You cannot delete that because it doesn't belong to you!");
    }
    _vaultKeepsRepository.RemoveVaultKeep(vaultKeepId);
    }
}
