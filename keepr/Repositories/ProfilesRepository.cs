using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Repositories;

public class ProfilesRepository
{
  private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Profile GetProfileById(string profileId)
    {
    string sql = @"
    SELECT * FROM accounts WHERE id = @profileId
    ;";

    Profile profile = _db.QueryFirstOrDefault<Profile>(sql, new { profileId });
    return profile;
    }

    internal List<Keep> GetUserKeepsByProfileId(string profileId)
    {
    string sql = @"
    SELECT
    k.*,
    acc.*
    FROM keeps k
    JOIN accounts acc ON acc.id = k.creatorId
    WHERE creatorId = @profileId;";

    List<Keep> keeps = _db.Query<Keep, Account, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { profileId }
      ).ToList();
    return keeps;
    }

    internal List<Vault> GetUserVaultsByProfileId(string profileId)
    {
    string sql = @"SELECT * FROM vaults WHERE creatorId = @ProfileId;";

    List<Vault> vaults = _db.Query<Vault>(sql, new { profileId }).ToList();
    return vaults;
    }
}
