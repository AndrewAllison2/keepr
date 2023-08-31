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

      <div class="mb-2">
        <label for="coverImg">Cover Image</label>
        <input class="form-control" type="url" id="coverImg" minlength="3" maxlength="200" v-model="editable.coverImg">
      </div>

      <div class="mt-3 d-flex justify-content-around">
        <button class="btn save-btn" data-bs-toggle="modal" data-bs-target="#editAccount">Back</button>
        <button class="btn save-btn" type="submit">Update</button>
      </div>
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
.save-btn {
  background-color: #A277D940;
  color: black;
  width: 8em;
  text-shadow: 1px 1px white;
  border: 1px solid black;
}
</style>