import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {


  async getKeeps() {
    const res = await api.get('api/keeps')
    // logger.log('[GETTING KEEPS', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async setActiveKeep(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    // logger.log('Active keep', res.data)
    AppState.activeKeep = new Keep(res.data)
  }

  setActiveVaultKeep(vaultKeepId) {
    const foundKeep = AppState.keptKeeps.find(k => k.vaultKeepId == vaultKeepId)
    AppState.activeKeep = new Keep(foundKeep)
  }

  async getProfileKeeps(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    // logger.log('profile keeps', res.data)
    AppState.profileKeeps = res.data.map(k => new Keep(k))
  }

  async createKeep(formData) {
    const res = await api.post('api/keeps', formData)
    // logger.log('Creating keep', res.data)
    AppState.keeps.push(new Keep(res.data))
  }

  async removeKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    // logger.log('Removing keep', res.data)
    const foundIndex = AppState.keeps.findIndex(k => k.id == keepId)
    AppState.keeps.splice(foundIndex, 1)
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('getting vault keeps', res.data)
    AppState.keptKeeps = res.data.map(v => new Keep(v))
  }

}


export const keepsService = new KeepsService()