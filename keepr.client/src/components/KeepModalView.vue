<template>
  <div class="container-fluid">
    <div class="row">

      <div class="col-12 col-md-6 p-0">
        <img class="img-fluid rounded keep-img" :src="keep?.img" :alt="keep?.name">
      </div>

      <div class="col-12 col-md-6 keep-info p-3">

        <div class="d-flex justify-content-center">
          <i class="mdi mdi-eye me-2" title="Views"></i>
          <h1 class="fs-5 me-4">{{ keep?.views }}</h1>
          <i class="mdi mdi-file me-2" title="Kept"></i>
          <h1 class="fs-5">{{ keep?.kept }}</h1>
        </div>

        <div class="row mt-5 pt-5 text-center">
          <h1 class="fw-1">{{ keep?.name }}</h1>

          <div class="col-10 m-auto mt-3">
            <p>{{ keep?.description }}</p>
          </div>
        </div>

        <div class="row justify-content-center mt-5 pt-5">

          <!-- NOTE THIS IS FOR THE Vaults LATER -->
          <!-- <div>
            <div class="dropdown">
              <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">{{ keep. }}</button>
              <ul class="dropdown-menu">
                <li><a class="dropdown-item" href="#">Action</a></li>
                <li><a class="dropdown-item" href="#">Another action</a></li>
                <li><a class="dropdown-item" href="#">Something else here</a></li>
              </ul>
            </div>
          </div> -->

          <button class="btn save-btn fs-5" @click="createVaultKeep()">save</button>
        </div>

      </div>
    </div>
  </div>

</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";

export default {
  setup() {

    
    return {
      keep: computed(() => AppState.activeKeep),


      async createVaultKeep() {
        try 
        {
          logger.log('You gotta write the function bud.....')
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
.keep-img {
  height: 80vh;
  width: 70vw;
  object-fit: cover;
  object-position: center;
}

// .keep-info {

// }

.save-btn {
  background-color: #A277D940;
  color: black;
  width: 5em;
  text-shadow: 1px 1px white;
}
</style>