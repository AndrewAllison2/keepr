<template>
  
  <div class="cards">
    <img class="img-fluid keep-img selectable" data-bs-toggle="modal" data-bs-target="#keepModal" @click="setActiveKeep(this.keepProp)" :src="keepProp.img" :alt="keepProp.name">
    
  </div>
  
  <div class="keep-info d-flex justify-content-around align-items-center">
    <h5>{{ keepProp?.name }}</h5>
    <img class="img-fluid avatar" :src="keepProp?.creator?.picture" :alt="keepProp?.creator?.name">
  </div>




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

div{
  max-height:min-content;
}

.keep-info{
  position: relative;
  top: -3.2em;
  left: -0em;
  margin-bottom: -3em;
  text-shadow: 2px 2px black;
}

.avatar{
  height: 3em;
  width: 3em;
  border-radius: 50%;
}
</style>