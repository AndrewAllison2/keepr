<template>
    <img class="img-fluid vault-img mt-4" :src="vaultProp?.img" alt="">

    <div v-if="vaultProp?.creatorId == account?.id" class="delete-button">
      <i class="mdi mdi-close-circle text-danger selectable fs-5" title="Remove this vault" @click="removeVault(this.vaultProp)"></i>
    </div>
</template>


<script>
import { computed } from "vue";
import { Vault } from "../models/Vault.js";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";

export default {
    props: {
    vaultProp: {type: Vault, required: true}
  },
  setup(){
    return {
      vaults: computed(() => AppState.vaults),
      account: computed(()=> AppState.account),

      async removeVault(vault) {
        if (!await Pop.confirm('Are you sure you want to remove this Vault?')) {
          return
        }
        const vaultId = vault.id
        await vaultsService.removeVault(vaultId)
      }

    }
  }
}
</script>


<style lang="scss" scoped>

.vault-img{
  object-fit: cover;
  border-radius: 2%;
  height: 13em;
  width: 23em;
}

.delete-button{
  position: relative;
  top: -13em;
  right: -20em;
  margin-bottom: -2em;
}

</style>