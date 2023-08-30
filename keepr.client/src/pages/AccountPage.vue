<template>
  

    <div class="container-fluid">
      <div class="row">
        <div class="col-8 m-auto mt-4">
        <div class="text-center">
          <img class="img-fluid cover-img" :src="account?.coverImg" :alt="account?.name">
        </div>
        </div>
      </div>

      <div class="row">
        <div class="col-8 m-auto text-center mt-3">
          <h1 class="mt-3"> {{ account.name }}</h1>
          <img class="mt-3 avatar" :src="account.picture" alt="" />
          <!-- <p class="mt-4">{{ account.email }}</p> -->
        </div>

        <h5 class="text-center mt-4"> {{vaultCount}} Vaults |  Keeps</h5>
      </div>
    
      <div class="text-center mt-2">
        <button class="btn save-btn" data-bs-toggle="modal" data-bs-target="#editAccount">Edit Account</button>
      </div>

      <div class="row">
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
    
      
        <div v-for="keep in myKeeps" :key="keep.id">
          
            <KeepComponent :keepProp="keep" />
          
        </div>
      </section>
  
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";
import { keepsService } from "../services/KeepsService.js";
import KeepComponent from "../components/KeepComponent.vue";
export default {
  setup() {
      
        async function getAccountVaults() {
            try {
                await vaultsService.getAccountVaults();
            }
            catch (error) {
                return Pop.error(error.message);
            }
        }

    async function getAccountKeeps() {
          
        }

        onMounted(() => {
            getAccountVaults();
            
        });
        return {
            account: computed(() => AppState.account),
            // keepCount: computed(() => AppState.profileKeeps.length),
            vaultCount: computed(() => AppState.accountVaults.length),
            vaults: computed(() => AppState.accountVaults),
            myKeeps: computed(() => {
                return AppState.keeps.filter(k => k.creatorId == AppState.account.id);
            }),
        };
    },
    components: { KeepComponent }
}
</script>

<style scoped>


.save-btn {
  background-color: #A277D940;
  color: black;
  width: 8em;
  text-shadow: 1px 1px white;
}

.hero-img{
  background-image: url(https://images.unsplash.com/photo-1533035353720-f1c6a75cd8ab?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bWluaW1hbCUyMGFydCUyMGJhY2tncm91bmR8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60);
  background-repeat: no-repeat;
  background-size: cover;
  height: 90vh;
  margin-top: 1em;
  border-radius: 5px;

}

.cover-img{
  width:fit-content;
  max-height: 15em;
}

body{
  padding: 0%;
}

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
