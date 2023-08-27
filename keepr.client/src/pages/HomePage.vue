<template>
  <div class="masonry-with-columns mt-3">
    
      
        <div v-for="k in keeps" :key="k.id">
          <img class="img-fluid keep-img " :src="k.img" :alt="k.name">
        </div>
      </div>
    
  
</template>

<script>
import Pop from "../utils/Pop.js";
import {keepsService} from '../services/KeepsService.js'
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {

    async function getKeeps() {
      try 
      {
        await keepsService.getKeeps()
      }
      catch (error)
      {
        return Pop.error(error.message)
      }
    }

    onMounted(() => {
      getKeeps()
    })

    return {

      keeps: computed(()=> AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">


.masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;

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

.keep-img{
border-radius: 3%;
object-fit: contain;
}

</style>
