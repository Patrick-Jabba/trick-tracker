<template>
  <section >
    <strong class="display">{{ tempoDecorrido }}</strong>
  </section>
</template>

<script lang="ts">
import { defineComponent, computed } from "vue";

export default defineComponent({
    props: {
      tempoEmSegundos: {
        type: Number,
        default: 0
      }
    },

  setup(props) {
    const tempoDecorrido = computed((): string => {
      return new Date(props.tempoEmSegundos * 1000).toISOString().substr(11, 8);
    });
    return {
      tempoDecorrido
    };
  },
});
</script>

<style scoped>
  .display {
    color: var(--texto-primario);
  }
</style>