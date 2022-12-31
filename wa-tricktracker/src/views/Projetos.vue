<template>
  <div class="projetos">
    <h1 class="title">Projetos</h1>
    <RouterView />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({

})
</script>

<style scoped>
.projetos {
  padding: 1.25rem;
}

.title{ 
  color: var(--texto-primario);
}
</style>