<template>

  <div class="container-fluid">
    <div class="row">
      <div class="col-8 m-auto">
        <div class="text-center">
          <img :src="profile?.coverImg" :alt="profile?.name">
        </div>

        <div class="text-center">
          <img class="img-fluid avatar" :src="profile?.picture" :alt="profile?.name">
        </div>
        
        <h2 class="text-center mt-3">{{ profile?.name }}</h2>

        <h5 class="text-center"># Vaults | # Keeps</h5>
      </div>
    </div>

    <div class="row">
      <div class="col-12 col-md-3">

      </div>
    </div>
  </div>
</template>


<script>
import { useRoute } from "vue-router";
import Pop from "../utils/Pop.js";
import { profilesService } from '../services/ProfilesService.js'
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";



export default {
  setup() {
    const route = useRoute()

    async function getProfileById() {
      try 
      {
        const profileId = route.params.profileId
        await profilesService.getProfileById(profileId)
      }
      catch (error)
      {
        return Pop.error(error.message)
      }
    }



    onMounted(() => {
      getProfileById()
    })
    
    return {
      profile: computed(()=> AppState.activeProfile)
    }
  }
}
</script>


<style lang="scss" scoped>
.avatar{
  border-radius: 100%;
  height: 10em;
  width: 10em;
}
</style>