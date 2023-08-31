<template>

  <form action="" @submit.prevent="createVault()">

    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="vaultName" placeholder="Title..." v-model="editable.name">
      <label for="vaultName">Title...</label>
    </div>

    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="vaultImg" placeholder="Title..." v-model="editable.img">
      <label for="vaultImg">Image URL...</label>
    </div>

    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="vaultDescription" placeholder="Title..." v-model="editable.Description">
      <label for="vaultDescription">Description...</label>
    </div>

    <div>
      <h5>Do you want to make this Vault private?</h5>
      <p>Private Vaults can only be seen by you</p>
      <div class="form-check">
        <input class="form-check-input" type="checkbox" id="checkIsPrivate" v-model="editable.isPrivate">
        <label class="form-check-label" for="checkIsPrivate">
          Private
        </label>
      </div>
    </div>

    <div class="mb-3 text-end">
      <button type="submit" class="btn btn-secondary" data-bs-dismiss="modal">Create</button>
    </div>

  </form>

</template>


<script>
import { ref } from "vue";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";
import { accountService } from "../services/AccountService.js";

export default {
  setup() {
    const editable = ref({})

    return {
      editable,

      async createVault() {
        try 
        {
          const formData = editable.value
        if (formData.isPrivate == null) {
          formData.isPrivate = false
        }
        await vaultsService.createVault(formData)
          Pop.toast(`${formData.name} has been created!`)
          accountService.getMyVaults()
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