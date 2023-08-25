using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep data)
    {
    string sql = @"
    INSERT INTO vaultKeeps (creatorId, vaultId, keepId)
    VALUES(@CreatorId, @VaultId, @KeepId);
    SELECT LAST_INSERT_ID()
    ;";

    int vaultKeepId = _db.ExecuteScalar<int>(sql, data);
    data.Id = vaultKeepId;
    return data;
    }
}
