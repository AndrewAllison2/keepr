<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-8 m-auto text-center">
        <img class="img-fluid mt-3 vault-img" :src="vault?.img" :alt="vault?.name">
        <div v-if="vault?.creatorId == account?.id" class="delete-button text-end">
          <i class="mdi mdi-close-circle fs-4 text-danger selectable" title="Delete this vault" @click="removeVault()"></i>
    </div>
        <div class="vault-info">
          <h1>{{ vault?.name }}</h1>
          <h2 class="fs-4">By {{ vault?.creator?.name }}</h2>
        </div>
      </div>

      <div class="text-center">
        <h5>{{ keptKeeps.length }} Keeps</h5>
      </div>

      <div class="row">

        <section class="masonry-with-columns mt-3">
    
      
        <div v-for="keep in keptKeeps" :key="keep.id">
          
            <KeepComponent :keepProp="keep" />
          
        </div>
</section>

      </div>
    </div>
  </div>
</template>


<script>
import { useRoute, useRouter } from "vue-router";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import { keepsService } from "../services/KeepsService.js";


export default {
  setup() {

    
    const route = useRoute()
    const router = useRouter()

    async function getKeepsByVaultId() {
      try 
      {
        const vaultId = route.params.vaultId
        await keepsService.getKeepsByVaultId(vaultId)
      }
      catch (error)
      {
        return Pop.error(error.message)
      }
    }

    function setActiveVault() {
      try 
      {
        const vaultId = route.params.vaultId
        vaultsService.setActiveVault(vaultId)
      }
      catch (error)
      {
        return Pop.error(error.message)
      }
    }

    onMounted(() => {
      setActiveVault()
      getKeepsByVaultId()
    })
    return {
      vault: computed(() => AppState.activeVault),
      keptKeeps: computed(() => AppState.keptKeeps),
      account: computed(()=> AppState.account),

      async removeVault() {
        try 
        {
          if (!await Pop.confirm('Are you sure you want to delte this vault?')) {
            return
          }
          const vaultId = route.params.vaultId
          await vaultsService.removeVault(vaultId)
          router.push({ name: 'Home' })
          Pop.toast('Your vault was deleted!')
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
.vault-img{
  height: 50vh;
}

.vault-info{
  position: relative;
  top: -9em;
  // right: -40.5em;
  color: white;
  text-shadow: 2px 2px black;
  margin-bottom: -2em;
}

.masonry-with-columns {
  columns: 4 230px;
  column-gap: 1rem;
  padding-left: 15em;
  padding-right: 15em;

    div {
        width: 150px;
        background: white;
        color: white;
        margin: 0 1rem 1rem 0;
        display: inline-block;
        width: 100%;
        text-align: center;
        border-radius: 3%;
        
      } 
} 
</style>