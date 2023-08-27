<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div v-for="k in keeps" :key="k.id">
          <h4>{{ k.name }}</h4>
        </div>
      </div>
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
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
