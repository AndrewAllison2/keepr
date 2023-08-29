<template>
  <div class="cards">
    <img class="img-fluid vault-img mt-4" :src="vaultProp?.img" :alt="vaultProp?.name">

    <div class="vault-info d-flex justify-content-between px-4">
      <h4>{{ vaultProp?.name }}</h4>
      <i v-if="vaultProp?.isPrivate == true" class="mdi mdi-lock" title="Private Vault"></i>
    </div>

  </div>

    
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

.vault-info{
  position: relative;
  top: -3em;
  text-shadow: 1px 1px black;
  color: white;
}

</style>