import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {


  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log('[GETTING KEEPS', res.data)
  }

}


export const keepsService = new KeepsService()