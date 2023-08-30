import { AppState } from "../AppState.js"
import { Profile } from "../models/Profile.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProfilesService {

  async getProfileById(profileId) {
    const res = await api.get(`api/profiles/${profileId}`)
    // logger.log('Got Profile', res.data)
    AppState.activeProfile = new Profile(res.data)
    // logger.log(AppState.activeProfile)
  }

}


export const profilesService = new ProfilesService()