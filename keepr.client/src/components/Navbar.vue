<template>
  <nav class="navbar navbar-expand-lg px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div>
        <h1 class="fs-4">HOME</h1>
      </div>
    </router-link>
    
    <div class="dropdown">
  <button v-if="$route.path == '/' || $route.path =='/:profileId'" role="button" class="btn btn-secondary dropdown-toggle" :hidden="!account.id" type="button" data-bs-toggle="dropdown" aria-expanded="false">
    CREATE
  </button>
  <ul class="dropdown-menu">
    <li><a class="dropdown-item top-option" data-bs-toggle="modal" data-bs-target="#createKeepModal">new keep</a></li>
    <li><a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#createVaultModal">new vault</a></li>
  </ul>
</div>

    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>

        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>

import { computed } from "vue";
import { AppState } from "../AppState.js";
import Login from './Login.vue';
export default {
  setup() {


    return {
      account: computed(() => AppState.account),

    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.navbar{
  border-bottom: 2px solid black;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.dropdown-toggle{
    background-color: #A277D940;
  color: black;
  text-shadow: 1px 1px white;
  
}
.dropdown-menu{
  background-color: #877A8F;
  border: 1px solid black;
  color: black;
  
}

.dropdown-item{
  background-color: #A277D940;
  color: black;
  text-shadow: 1px 1px white;
  
}

.top-option{
  border-bottom: 1px solid black;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
