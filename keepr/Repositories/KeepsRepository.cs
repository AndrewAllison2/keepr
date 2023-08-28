using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateKeep(Keep keepData)
    {
    string sql = @"
    INSERT INTO keeps(name, description, img, creatorId)
    VALUES(@Name, @Description, @Img, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";

    int keepId = _db.ExecuteScalar<int>(sql, keepData);
    return keepId;
    }

        internal List<Keep> GetKeeps()
    {
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    acc.*
    FROM keeps k
    LEFT JOIN vaultKeeps vk ON vk.keepId = k.id
    JOIN accounts acc ON acc.id = k.creatorId
    GROUP BY k.id
    ORDER BY k.createdAt ASC
    ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }
    ).ToList();

    return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
    string sql = @"
    SELECT
    k.*,
    acc.*
    FROM keeps k
    JOIN accounts acc ON acc.id = k.creatorId
    WHERE k.id = @keepId
    ;";

    Keep keep = _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { keepId }
    ).FirstOrDefault();

    return keep;
    }

    internal void UpdateKeep(Keep originalKeep)
    {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    description = @Description,
    img = @Img,
    views = @Views
    WHERE id = @Id
    LIMIT 1;
    SELECT * FROM keeps WHERE id = @Id
    ;";

    _db.Execute(sql, originalKeep);
    }

    internal void RemoveKeep(int keepId)
    {
    string sql = @"DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

    _db.Execute(sql, new { keepId });
    }

    internal List<VaultedKeep> GetKeepsByVaultId(int vaultId)
    {
    string sql = @"
    SELECT
    vk.*,
    k.*,
    acc.*
    FROM vaultKeeps vk
    JOIN keeps k ON k.id = vk.keepId
    JOIN accounts acc ON acc.id = k.creatorId
    WHERE vk.vaultId = @VaultId
    
    ;";

    List<VaultedKeep> keeps = _db.Query<VaultKeep, VaultedKeep, Account, VaultedKeep>(
      sql,
      (vaultkeep, keep, profile) => {
        keep.vaultKeepId = vaultkeep.VaultId;
        keep.Creator = profile;
        return keep;
      },
      new {vaultId}).ToList();

    return keeps;
    }
}
