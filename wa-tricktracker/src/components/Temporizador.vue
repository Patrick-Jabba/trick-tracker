<template>
  <div class="is-flex is-align-items-center is-justify-content-space-between">
    <Cronometro :tempoEmSegundos="state.tempoEmSegundos" />
    <Button
      @click="iniciarContagem"
      :isDisabled="state.cronometroRodando"
      text="play"
      icon="fas fa-play"
    />

    <Button
      @click="finalizarContagem"
      :isDisabled="!state.cronometroRodando"
      text="stop"
      icon="fas fa-stop"
    />
  </div>
</template>

<script lang="ts">
import { reactive, defineComponent } from "vue";

import Cronometro from "@/components/Cronometro.vue";
import Button from "@/components/Button.vue";

export default defineComponent({
  components: {
    Cronometro,
    Button,
  },

  setup(_, { emit }) {
    const state = reactive({
      tempoEmSegundos: 0,
      cronometro: 0,
      cronometroRodando: false,
    });

    function iniciarContagem() {
      state.cronometroRodando = true;
      state.cronometro = setInterval(() => {
        state.tempoEmSegundos += 1;
      }, 1000);
    }
    function finalizarContagem() {
      state.cronometroRodando = false;
      clearInterval(state.cronometro);
      emit("aoTemporizadorFinalizado", state.tempoEmSegundos);
      state.tempoEmSegundos = 0;
    }
    return {
      state,
      iniciarContagem,
      finalizarContagem,
    };
  },
});
</script>