<template>
    <img class="img-fluid vault-img mt-4" :src="vaultProp?.img" alt="">

    
</template>


<script>
import { computed } from "vue";
import { Vault } from "../models/Vault.js";
import { AppState } from "../AppState.js";


export default {
    props: {
    vaultProp: {type: Vault, required: true}
  },
  setup(){
    return {
      vaults: computed(() => AppState.vaults),
      account: computed(()=> AppState.account),



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