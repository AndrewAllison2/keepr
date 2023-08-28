<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>


  <ModalComponent/>

  <FormsModal id="createKeepModal">
    <template #header>Add your Keep</template>
    <template #body><CreateKeepForm/></template>
  </FormsModal>

  <FormsModal id="createVaultModal">
    <template #header>Add your Vault</template>
    <template #body><CreateVaultForm/></template>
  </FormsModal>

</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import ModalComponent from "./components/ModalComponent.vue"
import FormsModal from "./components/FormsModal.vue"
import CreateVaultForm from "./components/CreateVaultForm.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, ModalComponent, FormsModal, CreateVaultForm }
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
