<template>
  <section class="masonry-with-columns mt-3">
    
      
        <div v-for="keep in keeps" :key="keep.id">
          
            <KeepComponent :keepProp="keep" />
          
        </div>
</section>
    
  
</template>

<script>
import Pop from "../utils/Pop.js";
import {keepsService} from '../services/KeepsService.js'
import { computed, onMounted,  watchEffect } from "vue";
import { AppState } from "../AppState.js";
import KeepComponent from "../components/KeepComponent.vue";
import { accountService } from "../services/AccountService.js";


export default {
    setup() {
        async function getKeeps() {
            try {
                await keepsService.getKeeps();
            }
            catch (error) {
                return Pop.error(error.message);
            }
        }

        async function getMyVaults() {
            try 
            {
                await accountService.getMyVaults()
            }
            catch (error)
            {
            return Pop.error(error.message)
            }
        }


        onMounted(() => {
            getKeeps();
        });

        watchEffect(() => {
            if (AppState.account.id) {
                getMyVaults()
            }
        });
        
        return {
            keeps: computed(() => AppState.keeps),

        };
    },
    components: { KeepComponent }
}
</script>

<style scoped lang="scss">


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
