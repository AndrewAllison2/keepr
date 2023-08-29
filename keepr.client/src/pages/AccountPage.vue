<template>
  <div class="hero-img">

    <div class="container-fluid">
      <div class="row">
        <div class="col-8 m-auto text-center mt-3">
          <h1 class="mt-3">Welcome {{ account.name }}</h1>
          <img class="rounded mt-3" :src="account.picture" alt="" />
          <!-- <p class="mt-4">{{ account.email }}</p> -->
        </div>
      </div>
    
      <div class="text-center mt-5">
        <button class="btn save-btn" data-bs-toggle="modal" data-bs-target="#editAccount">Edit Account</button>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.save-btn {
  background-color: #A277D940;
  color: black;
  width: 8em;
  text-shadow: 1px 1px white;
}

.hero-img{
  background-image: url(https://images.unsplash.com/photo-1533035353720-f1c6a75cd8ab?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bWluaW1hbCUyMGFydCUyMGJhY2tncm91bmR8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60);
  background-repeat: no-repeat;
  background-size: cover;
  height: 90vh;
  margin-top: 1em;
  border-radius: 5px;

}

body{
  padding: 0%;
}
</style>
