using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;

    public ProfilesService(ProfilesRepository profilesRepository)
    {
        _profilesRepository = profilesRepository;
    }

    internal Profile GetProfileById(string profileId)
    {
    Profile profile = _profilesRepository.GetProfileById(profileId);
    if (profile == null)
    {
      throw new Exception($"No profile by that ID: {profileId}");
    }
    return profile;
    }

    internal List<Keep> GetUserKeepsByProfileId(string profileId)
    {
    List<Keep> keeps = _profilesRepository.GetUserKeepsByProfileId(profileId);
    return keeps;
    }

    internal List<Vault> GetUserVaultsByProfileId(string profileId, string userId)
    {
    List<Vault> vaults = _profilesRepository.GetUserVaultsByProfileId(profileId);
    vaults = vaults.FindAll(v => v.IsPrivate == false || v.CreatorId == userId);
    return vaults;
    }
}
