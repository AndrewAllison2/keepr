import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async getProfileVaults(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log('Gettin profile vaults', res.data)
    AppState.vaults = res.data.map(v => new Vault(v))
  }

  async createVault(formData) {
    const res = await api.post('api/vaults', formData)
    logger.log('Creating Vault', res.data)
    AppState.vaults.push(new Vault(res.data))
  }

  async removeVault(vaultId) {
    const res = await api.delete(`api/vaults/${vaultId}`)
    logger.log('Removing vault', res.data)
    const vIndex = AppState.vaults.findIndex(i => i.id == vaultId)
    AppState.vaults.splice(vIndex, 1)
  }

  setActiveVault(vaultId) {
    const vault = AppState.vaults.find(v => v.id == vaultId)
    AppState.activeVault = vault
  }

}


export const vaultsService = new VaultsService()