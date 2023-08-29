import { AppState } from "../AppState.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

  async createVaultKeep(formData) {
    const res = await api.post('api/vaultKeeps', formData)
    logger.log('creating VK', res.data)
    AppState.vaultKeeps.push(new VaultKeep(res.data))
  }

  async getVaultKeeps() {
    const res = await api.get('api/vaultkeeps')
    logger.log(res.data)
    AppState.vaultKeeps = res.data.map(v => new VaultKeep(v))

  }

  async removeVaultKeep(vaultKeepId) {
    const res = await api.delete(`api/vaultKeeps/${vaultKeepId}`)
    logger.log('removing vk', res.data)
    const index = AppState.keptKeeps.findIndex(i => i.id == vaultKeepId)
    AppState.vaultKeeps.splice(index, 1)
  }

  // async getVaultKeeps(userId) {
  //   const res = await api.get('api/vaultKeeps')
  //   logger.log('vault keeps', res.data)
  // }
}

export const vaultKeepsService = new VaultKeepsService()