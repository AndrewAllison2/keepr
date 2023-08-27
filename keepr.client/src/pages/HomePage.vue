<template>
  <div class="container-fluid">
    <div class="row">
      <h1>Keepr</h1>
    </div>
  </div>
</template>

<script>
import Pop from "../utils/Pop.js";
import {keepsService} from '../services/KeepsService.js'
import { onMounted } from "vue";

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

    return {}
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
