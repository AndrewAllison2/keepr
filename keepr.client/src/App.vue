<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>


  <ModalComponent/>

  <FormsModal id="createKeepModal">
    <template #header>Create New Keep</template>
    <template #body>Keep Form</template>
  </FormsModal>

</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import ModalComponent from "./components/ModalComponent.vue"
import FormsModal from "./components/FormsModal.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, ModalComponent, FormsModal }
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
