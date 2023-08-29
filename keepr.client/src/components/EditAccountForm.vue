<template>

  <form @submit.prevent="editAccount()">
    <div class="mb-2">
        <label for="name">Name</label>
        <input class="form-control" type="text" id="name" minlength="3" maxlength="75" v-model="editable.name">
      </div>
      
      <div class="mb-2">
        <label for="picture">Picture</label>
        <input class="form-control" type="url" id="picture" minlength="3" maxlength="200" v-model="editable.picture">
      </div>
      <button class="btn back-button mt-1" type="submit">Update</button>
  </form>

</template>


<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { accountService } from "../services/AccountService.js";
import { Modal } from "bootstrap";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,

      async editAccount() {
        try 
        {
          const formData = editable.value
          await accountService.editAccount(formData)
          Modal.getOrCreateInstance('#editAccount').hide()
          editable.value = {}
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

</style>