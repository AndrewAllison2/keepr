<template>
  

    <div class="cards">
      <img class="img-fluid keep-img selectable" title="View this keep" data-bs-toggle="modal" data-bs-target="#keepsModalView" @click="setActiveKeep(this.keepProp)" :src="keepProp.img" :alt="keepProp.name">
    </div>
    
    <div class="keep-info d-flex justify-content-around align-items-center">
      <h1 class="fs-5 keep-name">{{ keepProp?.name }}</h1>
      <img class="img-fluid avatar" :src="keepProp?.creator?.picture" :alt="keepProp?.creator?.name" :title="keepProp?.creator?.name">
    </div>
  




</template>





<script>
import { computed } from "vue";
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    keepProp: {type: Keep, required: true}
  },

  setup(props){
    return {
      account: computed(()=> AppState.account),


      async setActiveKeep(keep) {
        const keepId = keep.id
        keepsService.setActiveKeep(keepId)
      },

      async removeKeep(keep) {
        try 
        {
          if (!await Pop.confirm('Are you sure you want to remove this keep?')) {
            return
          }
          const keepId = keep.id
          await keepsService.removeKeep(keepId)
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
  margin-bottom: -4em;
  text-shadow: 2px 2px black;
}

.avatar{
  // height: 2.5em;
  width: 2.5em;
  border-radius: 50%;
  object-fit: cover;
  aspect-ratio: 1;
}

.keep-name{
  overflow: hidden;
  text-overflow:ellipsis;
  white-space:nowrap;
  max-height: 4em;
  margin-left: 2px;
}

@media screen and (max-width: 769px){
  .avatar{
    display: none;
  }
  
}
</style>