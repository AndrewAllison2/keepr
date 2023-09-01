<template>

  <div class="container-fluid">
    <div class="row">

      <div class="col-12 col-md-6 p-0">
        <img class="img-fluid rounded keep-img" :src="keep?.img" :alt="keep?.name">
      </div>

      <div class="col-12 col-md-6 keep-info p-3 highest-div">

        <div class="d-flex justify-content-center top-div">
          <i class="mdi mdi-eye me-2" title="Views"></i>
          <h1 class="fs-5 me-4">{{ keep?.views }}</h1>
          <i class="mdi mdi-file me-2" title="Kept"></i>
          <h1 class="fs-5">{{ keep?.kept }}</h1>
        </div>

              <!-- <div v-if="keep?.creatorId == account?.id" class="text-end">
                <i class="mdi mdi-close-circle text-danger selectable fs-5" title="Remove this keep" @click="removeKeep(this.keep)"></i>
              </div> -->

        <div class="row mt-5 pt-5 text-center">
          
          <div class="col-10 m-auto mt-3 middle-div">
            <h1 class="fw-1">{{ keep?.name }}</h1>
            <p class="keep-desc">{{ keep?.description }}</p>
          </div>
        </div>

        <div class="row mt-5 pt-5">

          <!-- NOTE THIS IS FOR THE Vaults LATER -->


          <div class="col-12 d-block d-md-flex justify-content-around align-items-center bottom-div">

          
            <div v-if="vault?.creatorId == account?.id">
                            
                <button class="btn drop-down" @click="removeVaultKeep(keep)">Remove from Vault</button>
              </div>
              
            <div v-if="keep" class="d-flex align-items-center keep-creator">
              <router-link :to="{name: 'Profile', params: {profileId: keep?.creatorId}}">
                <img class="img-fluid avatar me-2" :src="keep?.creator?.picture" :alt="keep?.creator?.name" title="View Profile" data-bs-toggle="modal" data-bs-target="keepModal">
              </router-link>
              <p class="h5">{{ keep?.creator?.name }}</p>
            </div>
          </div>

        </div>

      </div>
    </div>
  </div>


</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import { Modal } from "bootstrap";
import { logger } from "../utils/Logger.js";


export default {
  setup() {
    return {
      keep: computed(() => AppState.activeKeep),
      vault: computed(() => AppState.activeVault),
      account: computed(()=> AppState.account),


      async removeVaultKeep(keep) {
        try 
        {
          if (!await Pop.confirm('Are you sure you want to remove this keep from your vault?')) {
            return
          }
          // const foundKeep = AppState.keptKeeps.find(k => k.id == keep.id)
          logger.log('Keep to remove grabbed from method', keep)
          // const vaultKeep = AppState.vaultKeeps.find(vk => vk.id == AppState.keptKeeps.vaultKeepId && vk.vaultId == AppState.activeVault.id)
          // logger.log('VK id found from the keep we grabbed', vaultKeep)
          logger.log(AppState.vaultKeeps)
          await vaultKeepsService.removeVaultKeep(keep.vaultKeepId)
          Modal.getOrCreateInstance('#vaultKeepsView').hide()
        }
        catch (error)
        {
          return Pop.error(error.message)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-img {
  height: 80vh;
  width: 70vw;
  object-fit: cover;
  object-position: center;
}

// .keep-info {

// }

.save-btn {
  background-color: #A277D940;
  color: black;
  width: 5em;
  text-shadow: 1px 1px white;
}

.avatar {
  height: 7vh;
  width: 7vh;
  border-radius: 50%;
  object-fit: cover;
}

.drop-down{
  background-color: #A277D940;
  color: black;
  text-shadow: 1px 1px white;
}

.highest-div{
  flex-direction: column;
  
  
  .top-div{
    height: 20%;
  }
  
  .middle-div{
    height: 11em;
  }
  
  .keep-info{
    height: 20%;
  }


}

.keep-desc{
  text-overflow: clip;
  word-wrap: break-word;
}

@media screen and (max-width: 769px){
    .keep-img{
    width: 100vw;
    object-fit:fill;
    object-position: center;
  }

  .avatar {
  height: 5vh;
  width: 5vh;
  border-radius: 50%;
  object-fit: cover
  ;
}

.keep-creator{
  margin-top: 1em;
  padding-left: 5.5em;
  object-fit: cover;
}

.drop-down{
  margin-left: 5.2em;
}


.highest-div{
  .top-div{
    height: auto;
  }
  
  .middle-div{
    height: auto;
  }
  
  .keep-info{
    height: auto;
  }
  
}
}
</style>