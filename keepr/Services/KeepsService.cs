using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Services;

public class KeepsService
{
  private readonly VaultsService _vaultsService;
  private readonly KeepsRepository _keepsRepository;

    public KeepsService(KeepsRepository keepsRepository, VaultsService vaultsService)
    {
        _keepsRepository = keepsRepository;
        _vaultsService = vaultsService;
    }

    internal Keep CreateKeep(Keep keepData)
    {
    int keepId = _keepsRepository.CreateKeep(keepData);

    Keep keep = GetKeepById(keepId);
    return keep;
    }

        internal List<Keep> GetKeeps()
    {
    List<Keep> keeps = _keepsRepository.GetKeeps();
    return keeps;
    }

    internal Keep GetKeepById(int keepId, string userId = null)
    {
    Keep keep = _keepsRepository.GetKeepById(keepId);

    if (keep == null)
    {
      throw new Exception($"No Keep by the ID of {keepId}");
    }
    return keep;
    }

  internal Keep GetKeepByIdAndUpdateVisits(int keepId, string userId = null)
  {
    Keep keep = GetKeepById(keepId, userId);
    keep.Views++;
    _keepsRepository.UpdateKeep(keep);
    return keep;
  }

    internal Keep UpdateKeep(int keepId, Keep keepData)
    {
    Keep originalKeep = GetKeepById(keepId);

    originalKeep.Name = keepData.Name ?? originalKeep.Name;
    originalKeep.Description = keepData.Description ?? originalKeep.Description;
    originalKeep.Img = keepData.Img ?? originalKeep.Img;

    _keepsRepository.UpdateKeep(originalKeep);
    return originalKeep;
    }

    internal void RemoveKeep(int keepId, string id)
    {
    Keep keep = GetKeepById(keepId);

    if (keep.CreatorId != id)
    {
      throw new Exception($"You are not the creator of {keep.Name}! You cannot delete it!");
    }
    _keepsRepository.RemoveKeep(keepId);
    }

    internal List<VaultedKeep> GetKeepsByVaultId(int vaultId, string userId)
    {
    _vaultsService.GetVaultById(vaultId, userId);
        List<VaultedKeep> keeps = _keepsRepository.GetKeepsByVaultId(vaultId);
    return keeps;
    }
}
