import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async getProfileVaults(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    // logger.log('Gettin profile vaults', res.data)
    AppState.vaults = res.data.map(v => new Vault(v))
  }

  async createVault(formData) {
    const res = await api.post('api/vaults', formData)
    // logger.log('Creating Vault', res.data)
    AppState.vaults.push(new Vault(res.data))
  }

  async removeVault(vaultId) {
    const res = await api.delete(`api/vaults/${vaultId}`)
    // logger.log('Removing vault', res.data)
    const vIndex = AppState.vaults.findIndex(i => i.id == vaultId)
    AppState.vaults.splice(vIndex, 1)
  }

  async getVaultById(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    AppState.activeVault = new Vault(res.data)
  }

  async getAccountVaults() {
    const res = await api.get('account/vaults')
    // logger.log(res.data, 'got my vaults')
    AppState.accountVaults = res.data.map(v => new Vault(v))
  }

}


export const vaultsService = new VaultsService()