import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {


  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log('[GETTING KEEPS', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  setActiveKeep(keep) {
    AppState.activeKeep = keep
  }

  async getProfileKeeps(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log('profile keeps', res.data)
    AppState.profileKeeps = res.data.map(k => new Keep(k))
  }

  async createKeep(formData) {
    const res = await api.post('api/keeps', formData)
    logger.log('Creating keep', res.data)
  }

}


export const keepsService = new KeepsService()