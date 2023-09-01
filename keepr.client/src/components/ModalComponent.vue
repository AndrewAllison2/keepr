<template>

  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl modal-component">
    <div class="modal-content">
      
      <slot name="body"></slot>
        <!-- <KeepModalView/> -->
      
      
    </div>
  </div>
</div>

</template>


<script>
// import KeepModalView from "./KeepModalView.vue";

export default {
    setup() {
        return {};
    },
    // components: { KeepModalView }
}
</script>


<style lang="scss" scoped>
.modal-component{
  height: 80vh;
}
</style>