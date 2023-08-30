import { AppState } from "../AppState.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

  async createVaultKeep(formData) {
    const res = await api.post('api/vaultKeeps', formData)
    // logger.log('creating VK', res.data)
    AppState.vaultKeeps.push(new VaultKeep(res.data))
  }

  async getVaultKeeps() {
    const res = await api.get('api/vaultkeeps')
    // logger.log(res.data)
    AppState.vaultKeeps = res.data.map(v => new VaultKeep(v))

  }

  async removeVaultKeep(vaultKeepId) {
    const res = await api.delete(`api/vaultKeeps/${vaultKeepId}`)
    logger.log('removing vk', res.data)
    // const index = AppState.vaultKeeps.findIndex(i => i.id == vaultKeepId)
    // AppState.vaultKeeps.splice(index, 1)
    logger.log('kept appstate', AppState.keptKeeps)
    const kindex = AppState.keptKeeps.findIndex(i => i.vaultKeepId == vaultKeepId)
    logger.log('Index of keep we are taking out of appstate', kindex)
    AppState.keptKeeps.splice(kindex, 1)
  }
}

export const vaultKeepsService = new VaultKeepsService()