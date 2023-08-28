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

}


export const vaultsService = new VaultsService()