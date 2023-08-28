<template>

  
        <img class="img-fluid keep-img selectable" data-bs-toggle="modal" data-bs-target="#keepModal" @click="setActiveKeep(this.keepProp)" :src="keepProp.img" :alt="keepProp.name">




</template>


<script>
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";

export default {
  props: {
    keepProp: {type: Keep, required: true}
  },

  setup(props){
    return {


      setActiveKeep() {
        keepsService.setActiveKeep(props.keepProp)
      }


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