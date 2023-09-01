<template>
  <div class="container-fluid">
    <div class="row highest-div">

      <div class="col-12 col-md-6 p-0">
        <img class="img-fluid rounded keep-img" :src="keep?.img" :alt="keep?.name">
      </div>

      <div class="col-12 col-md-6 p-3">

        <div class="d-flex justify-content-center top-div">
          <i class="mdi mdi-eye me-2" title="Views"></i>
          <h1 class="fs-5 me-4">{{ keep?.views }}</h1>
          <i class="mdi mdi-file me-2" title="Kept"></i>
          <h1 class="fs-5">{{ keep?.kept }}</h1>
        </div>
        <div v-if="keep?.creatorId == account?.id" class="text-end">
          <i class="mdi mdi-close-circle text-danger selectable fs-5 delete-btn" title="Remove this keep" @click="removeKeep(this.keep)"></i>
        </div>


        <div class="row mt-5 pt-5 text-center middle-div">
          <h1 class="fw-1">{{ keep?.name }}</h1>
          <p>{{ keep?.description }}</p>
          
          <div class="col-10 m-auto mt-0">
          </div>
        </div>

        <div class="row mt-5 pt-5">

          <!-- NOTE THIS IS FOR THE Vaults LATER -->


          <div class="col-12 d-block d-md-flex justify-content-around align-items-center keep-info bottom-div">
          <div v-if="account.id" class="dropdown">
            <button class="btn save-btn dropdown-toggle" :hidden="hasVaults == false" type="button" data-bs-toggle="dropdown" aria-expanded="false">
              Save to Vault
            </button>
              <ul class="dropdown-menu">
                <li v-for="vault in myVaults" :key="vault?.id" :value="vault.id" @click="createVaultKeep(vault.id)" class="dropdown-item">{{vault?.name}}</li>
            </ul>
          </div>

            <div>
              <!-- <button class="btn save-btn fs-5 me-5" @click="createVaultKeep(this.keep?.id)">save</button> -->
            </div>
            <div v-if="keep" class="d-flex align-items-center creator">
              <router-link :to="{name: 'Profile', params: {profileId: keep?.creatorId}}">
                <img class="img-fluid avatar me-2" :src="keep?.creator?.picture" :alt="keep?.creator?.name" title="View Profile" data-bs-toggle="modal" data-bs-target="#keepsModalView">
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
import { keepsService } from "../services/KeepsService.js";

export default {
  setup() {
        const selectedVault = ref({})

    
    return {
      keep: computed(() => AppState.activeKeep),
      myVaults: computed(() => AppState.myVaults),
      selectedVault,
      account: computed(()=> AppState.account),
      kept: computed(() => {
        return AppState.vaultKeeps.find(k => k.keepId == AppState.activeKeep.id)
      }),
      hasVaults: computed(() => {
        if (AppState.myVaults.length == 0) {
          return false
        }return true
      }),
      


      async createVaultKeep(vaultId) {
        try 
        {
          const formData = {}
            formData.vaultId = vaultId
          formData.keepId = AppState.activeKeep.id
          await vaultKeepsService.createVaultKeep(formData)
          selectedVault.value = ''
          Pop.toast(`${AppState.activeKeep.name} has been kept`)
          Modal.getOrCreateInstance('#keepsModalView').hide()

        }
        catch (error)
        {
          return Pop.error(error.message)
        }
      },

            async removeKeep(keep) {
        try 
        {
          if (!await Pop.confirm('Are you sure you want to remove this keep?')) {
            return
          }
          const keepId = keep.id
          await keepsService.removeKeep(keepId)
          Modal.getOrCreateInstance('#keepsModalView').hide()
          Pop.toast(`${keep.name} has been removed!`)
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

.top-div{
  height: 20%;
}

.middle-div{
  height: 47%;
}

.keep-info{
  height: 15%;
  justify-self: baseline;
}

.save-btn {
  background-color: #A277D940;
  color: black;
  width: 8.5em;
  text-shadow: 1px 1px white;
}

.avatar {
  height: 7vh;
  width: 7vh;
  border-radius: 50%;
}

.drop-down{
  background-color: #A277D940;
  color: black;
  text-shadow: 1px 1px white;
}

.delete-btn{
  position: relative;
  top: -7.5em;
}

@media screen and (max-width: 769px) {
  .keep-img{
    width: 100vw;
    object-fit:fill;
    object-position: center;
  }

  .avatar {
  height: 5vh;
  width: 5vh;
  border-radius: 50%;
}

.keep-info {
  display: block;
}

.dropdown{
  margin-left: 6.2em;
  margin-bottom: 1em;
}

.creator{
  padding-left: 4em;
}

.delete-btn{
  position: relative;
  top: -2em;
}

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


</style>