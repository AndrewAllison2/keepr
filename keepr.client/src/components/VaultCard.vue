<template>
    <img class="img-fluid vault-img mt-4" :src="vaultProp.img" alt="">
</template>


<script>
import { Vault } from "../models/Vault.js";

export default {
    props: {
    vaultProp: {type: Vault, required: true}
  },
  setup(){
    return {}
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

</style>