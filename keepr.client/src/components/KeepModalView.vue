<template>
  <div class="container-fluid">
    <div class="row">

      <div class="col-12 col-md-6 p-0">
        <img class="img-fluid rounded keep-img" :src="keep?.img" :alt="keep?.name">
      </div>

      <div class="col-12 col-md-6 keep-info p-3">

        <div class="d-flex justify-content-center">
          <i class="mdi mdi-eye me-2" title="Views"></i>
          <h1 class="fs-5 me-4">{{ keep?.views }}</h1>
          <i class="mdi mdi-file me-2" title="Kept"></i>
          <h1 class="fs-5">{{ keep?.kept }}</h1>
        </div>

        <div class="row mt-5 pt-5 text-center">
          <h1 class="fw-1">{{ keep?.name }}</h1>

          <div class="col-10 m-auto mt-3">
            <p>{{ keep?.description }}</p>
          </div>
        </div>

        <div class="row mt-5 pt-5">

          <!-- NOTE THIS IS FOR THE Vaults LATER -->


          <div class="col-12 d-flex justify-content-around align-items-center">

          <div class="btn-group">
            <button type="button" :disabled='!selectedVault' class="btn save-btn" @click="createVaultKeep()">save</button>
            <button type="button" class="btn drop-down dropdown-toggle dropdown-toggle-split" data-bs-toggle="dropdown" aria-expanded="false">
              <span class="visually-hidden">Toggle Dropdown</span>
            </button>
            <ul class="dropdown-menu">
              <li v-for="vault in myVaults" :key="vault?.id" :value="vault.id" @click="selectedVault=`${vault.id}`" class="dropdown-item">{{vault?.name}}</li>
              
            </ul>
          </div>

            <div>
              <!-- <button class="btn save-btn fs-5 me-5" @click="createVaultKeep(this.keep?.id)">save</button> -->
            </div>
            <div v-if="keep" class="d-flex align-items-center">
              <router-link :to="{name: 'Profile', params: {profileId: keep?.creatorId}}">
                <img class="img-fluid avatar me-2" :src="keep?.creator?.picture" :alt="keep?.creator?.name" title="View Profile">
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
import { computed, ref, } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { vaultKeepsService } from '../services/VaultKeepsService.js'
import { Modal } from "bootstrap";

export default {
  setup() {
        const selectedVault = ref('')

    
    return {
      keep: computed(() => AppState.activeKeep),
      myVaults: computed(() => AppState.myVaults),
      selectedVault,
      kept: computed(() => {
        return AppState.vaultKeeps.find(k => k.keepId == AppState.activeKeep.id)
        
      }),
      


      async createVaultKeep() {
        try 
        {
          const formData = {}
            formData.vaultId = selectedVault.value
          formData.keepId = AppState.activeKeep.id
          await vaultKeepsService.createVaultKeep(formData)
          Pop.toast(`${AppState.activeKeep.name} has been kept`)
          Modal.getOrCreateInstance('#keepModal').hide()

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
  height: 10vh;
  width: 10vh;
  border-radius: 50%;
}

.drop-down{
  background-color: #A277D940;
  color: black;
  text-shadow: 1px 1px white;
}
</style>