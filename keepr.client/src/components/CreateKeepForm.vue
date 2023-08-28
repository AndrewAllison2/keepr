<template>

  <form action="" @submit.prevent="createKeep()">

    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="keepName" placeholder="Title..." v-model="editable.name">
      <label for="keepName">Title...</label>
    </div>

    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="keepImg" placeholder="Title..." v-model="editable.img">
      <label for="keepImg">Image URL...</label>
    </div>

    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="keepDescription" placeholder="Title..." v-model="editable.Description">
      <label for="keepDescription">Description...</label>
    </div>

    <div class="mb-3 text-end">
      <button type="submit" class="btn btn-secondary" data-bs-dismiss="modal">Create</button>
    </div>

  </form>

</template>


<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { keepsService } from "../services/KeepsService.js";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,

      async createKeep() {
        try 
        {
          const formData = editable.value
          await keepsService.createKeep(formData)
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