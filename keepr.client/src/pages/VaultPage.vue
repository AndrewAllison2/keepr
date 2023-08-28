<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-8 m-auto text-center">
        <img class="img-fluid mt-3 vault-img" :src="vault?.img" :alt="vault?.name">
        <div class="vault-info">
          <h1>{{ vault?.name }}</h1>
          <h2 class="fs-4">By {{ vault?.creator?.name }}</h2>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { useRoute } from "vue-router";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {
    const route = useRoute()

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
    })
    return {
      vault: computed(()=> AppState.activeVault)
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
  top: -7em;
  // right: -40.5em;
  color: white;
  text-shadow: 2px 2px black;
}
</style>