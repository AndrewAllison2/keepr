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
}

export const vaultKeepsService = new VaultKeepsService()