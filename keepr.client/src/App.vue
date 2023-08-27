<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>


  <ModalComponent/>

</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import ModalComponent from "./components/ModalComponent.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, ModalComponent }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


body {
  margin: 0;
  padding: 1rem;
}
</style>
