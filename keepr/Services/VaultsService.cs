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
}
