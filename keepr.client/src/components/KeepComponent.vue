<template>

  
        <img class="img-fluid keep-img selectable" data-bs-toggle="modal" data-bs-target="#exampleModal" :src="keepProp.img" :alt="keepProp.name">




</template>


<script>
import { Keep } from "../models/Keep.js";

export default {
  props: {
    keepProp: {type: Keep, required: true}
  },

  setup(){
    return {
      
    }
  }
}
</script>


<style lang="scss" scoped>

.keep-img{
border-radius: 3%;
object-fit: contain;
}
</style>