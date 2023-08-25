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
    acc.*
    FROM keeps k
    JOIN accounts acc ON acc.id = k.creatorId
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


}
