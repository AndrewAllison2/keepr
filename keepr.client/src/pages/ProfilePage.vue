<template>

  <div class="container-fluid">
    <div class="row">
      <div class="col-8 m-auto mt-4">
        <div class="text-center">
          <img class="img-fluid cover-img" :src="profile?.coverImg" :alt="profile?.name">
        </div>

        <div class="text-center mt-4">
          <img class="img-fluid avatar" :src="profile?.picture" :alt="profile?.name">
        </div>
        
        <h2 class="text-center mt-3">{{ profile?.name }}</h2>

        <h3 class="text-center fs-5 vk-info">{{vaultCount}} Vaults | {{keepCount}} Keeps</h3>
      </div>
    </div>

    <!-- SECTION VAULTS -->
    <div class="row mt-2">
      <h4>VAULTS</h4>
      <div v-for="v in vaults" :key="v.id" class="col-12 col-md-3">
        <router-link :to="{name: 'Vault', params:{vaultId: v?.id}}">
          <VaultCard :vaultProp="v"/>
        </router-link>
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
import { useRoute} from "vue-router";
import Pop from "../utils/Pop.js";
import { profilesService } from '../services/ProfilesService.js'
import { vaultsService } from '../services/VaultsService.js'
import { computed, onMounted } from "vue";
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
              Pop.error(error.message);

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
  // height: 10em;
  aspect-ratio: 1;
  object-fit: cover;
  width: 10em;
}

.cover-img{
  max-height: 40vh;
  max-width: 60vw;
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

.vk-info{
  background-color: #A277D940;
  color: black;
  // width: 8.5em;
  padding: 8px;
  border-radius: 5px;
  text-shadow: 1px 1px white;
}

@media screen and (max-width: 769px){
        .masonry-with-columns {
    columns: 2 100px;
    column-gap: 1rem;
    }
}
</style>