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

    internal VaultKeep GetVaultKeepById(int vaultKeepId)
    {
    string sql = @"SELECT * FROM vaultKeeps WHERE id = @vaultKeepId;";

    VaultKeep vaultkeep = _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultKeepId });
    return vaultkeep;
    }

    internal void RemoveVaultKeep(int vaultKeepId)
    {
    string sql = @"DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1;";

    _db.Execute(sql, new { vaultKeepId });
    }
}
