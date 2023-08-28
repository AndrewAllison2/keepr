using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateVault(Vault vaultData)
    {
    string sql = @"
    INSERT INTO vaults(name, description, creatorId, img, isPrivate)
    VALUES(@Name, @Description, @CreatorId, @Img, @IsPrivate);
    SELECT LAST_INSERT_ID()
    ;";

    int vaultId = _db.ExecuteScalar<int>(sql, vaultData);
    return vaultId;
    }

    internal Vault GetVaultById(int vaultId)
    {
    string sql = @"
    SELECT
    vau.*,
    acc.*
    FROM vaults vau
    JOIN accounts acc ON acc.id = vau.creatorId
    WHERE vau.id = @vaultId
    ;";

    Vault vault = _db.Query<Vault, Profile, Vault>(
      sql,
      (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { vaultId }
    ).FirstOrDefault();
    return vault;
    }

    internal void UpdateVault(Vault ogVault)
    {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name,
    description = @Description,
    img = @Img,
    isPrivate = @IsPrivate
    WHERE id = @Id
    ;";

    _db.Execute(sql, ogVault);
    }

    
    internal void RemoveVault(int vaultId)
    {
    string sql = @"DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";

    _db.Execute(sql, new { vaultId });
    }

    internal List<Vault> GetMyVaults(string userId)
    {
    string sql = @"SELECT * FROM vaults WHERE creatorId = @UserId;";

    List<Vault> vaults = _db.Query<Vault>(sql, new { userId }).ToList();
    return vaults;
    }
}
