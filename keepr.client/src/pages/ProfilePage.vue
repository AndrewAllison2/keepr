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

        <h5 class="text-center">{{vaultCount}} Vaults | {{keepCount}} Keeps</h5>
      </div>
    </div>

    <!-- SECTION VAULTS -->
    <div class="row">
      <h4>VAULTS</h4>
      <div v-for="v in vaults" :key="v.id" class="col-12 col-md-3">
        <VaultCard :vaultProp="v"/>
      </div>
    </div>

    <div class="row mt-5">
      <h4>KEEPS</h4>
    </div>
  </div>

  <section class="masonry-with-columns mt-3">
    
      
        <div v-for="keep in keeps" :key="keep.id">
          
            <KeepComponent :keepProp="keep" />
          
        </div>
</section>

</template>


<script>
import { useRoute } from "vue-router";
import Pop from "../utils/Pop.js";
import { profilesService } from '../services/ProfilesService.js'
import { vaultsService } from '../services/VaultsService.js'
import { computed, onMounted, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import KeepComponent from "../components/KeepComponent.vue";
import { keepsService } from "../services/KeepsService.js";



export default {
    setup() {
        const route = useRoute();
        async function getProfileById() {
            try {
                const profileId = route.params.profileId;
                await profilesService.getProfileById(profileId);
            }
            catch (error) {
                return Pop.error(error.message);
            }
        }
        async function getProfileVaults() {
            try {
                const profileId = route.params.profileId;
                await vaultsService.getProfileVaults(profileId);
            }
            catch (error) {
                return Pop.error(error.message);
            }
    }

    async function getProfileKeeps() {
      const profileId = route.params.profileId;
      await keepsService.getProfileKeeps(profileId)
    }


    
        onMounted(() => {
            getProfileById();
          getProfileVaults();
            getProfileKeeps()
        });


        return {
            profile: computed(() => AppState.activeProfile),
          vaults: computed(() => AppState.vaults),
          keeps: computed(() => AppState.profileKeeps),
          keepCount: computed(() => AppState.profileKeeps.length),
            vaultCount: computed(()=> AppState.vaults.length)
        };
    },
    components: { KeepComponent }
}
</script>


<style lang="scss" scoped>
.avatar{
  border-radius: 100%;
  height: 10em;
  width: 10em;
}

.masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;

    div {
        width: 150px;
        background: white;
        color: white;
        margin: 0 1rem 1rem 0;
        display: inline-block;
        width: 100%;
        text-align: center;
        border-radius: 3%;
      } 
}
</style>