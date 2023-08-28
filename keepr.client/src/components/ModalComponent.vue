<template>

  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      
      
        <KeepModalView/>
      
      
    </div>
  </div>
</div>

</template>


<script>
import KeepModalView from "./KeepModalView.vue";

export default {
    setup() {
        return {};
    },
    components: { KeepModalView }
}
</script>


<style lang="scss" scoped>

</style>