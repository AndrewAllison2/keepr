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

}


export const keepsService = new KeepsService()