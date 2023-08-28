<template>
  <div class="container-fluid">
    <div class="row">

      <div class="col-12 col-md-6">
        <img class="img-fluid" :src="keep?.img" :alt="keep?.name">
      </div>

      <div class="col-12 col-md-6">

      </div>
    </div>
  </div>

</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {

    
    return {
      keep: computed(()=> AppState.activeKeep)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>