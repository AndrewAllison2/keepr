using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
    {
        _vaultKeepsRepository = vaultKeepsRepository;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep data)
    {
    VaultKeep vaultkeep = _vaultKeepsRepository.CreateVaultKeep(data);
    return vaultkeep;
    }
}
