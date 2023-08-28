<template>
  <nav class="navbar navbar-expand-lg px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div>
        <h1 class="fs-4">HOME</h1>
      </div>
    </router-link>
    
    <div class="dropdown">
  <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
    CREATE
  </button>
  <ul class="dropdown-menu">
    <li><a class="dropdown-item text-white top-option" data-bs-toggle="modal" data-bs-target="#createKeepModal">new keep</a></li>
    <li><a class="dropdown-item text-white" data-bs-toggle="modal" data-bs-target="#createVaultModal">new vault</a></li>
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

import Login from './Login.vue';
export default {
  setup() {
    return {}
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

.dropdown-menu{
  background-color: #877A8F;
  border: 1px solid black;
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
