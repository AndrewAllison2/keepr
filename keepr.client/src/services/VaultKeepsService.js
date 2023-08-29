import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

  async createVaultKeep(formData) {
    const res = await api.post('api/vaultKeeps', formData)
    logger.log('creating VK', res.data)
  }
}

export const vaultKeepsService = new VaultKeepsService()