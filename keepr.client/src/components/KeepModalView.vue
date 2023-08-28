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

        <div class="row ">

          <!-- NOTE THIS IS FOR THE TAGS LATER -->
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

          <button class="btn save-btn">save</button>
        </div>

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
.keep-img {
  height: 80vh;
  width: 70vw;
  object-fit: cover;
}

.keep-info {

}

.save-btn {
  
}
</style>