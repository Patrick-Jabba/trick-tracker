<template>
  <main
    class="columns is-gapless is-multiline"
    :class="state.modoEscuroAtivo? 'modo-escuro': ''"
      >
    <div class="column is-one-quarter">
      <BarraLateral @aoTemaAlterado="trocarTema" />
    </div>
    <div class="column is-three-quarter conteudo">
      <Notifications />
      <RouterView />
    </div>
  </main>
</template>

<script lang="ts">
import { reactive, defineComponent } from "vue";

import BarraLateral from "@/components/BarraLateral.vue";
import Notifications from "@/components/Notifications.vue";

export default defineComponent({
  components: {
    BarraLateral,
    Notifications
  },
  setup() {
    const state = reactive({
      modoEscuroAtivo: false,
    });
    
    function trocarTema(modoEscuroAtivo: boolean) {
      state.modoEscuroAtivo = modoEscuroAtivo;
    }

    return {
      state,
      trocarTema,
    };
  },
});
</script>

<style>
main {
  --bg-primario: #f8f8f2;
  --texto-primario: #000;
}

main.modo-escuro {
  --bg-primario: #2b2d42;
  --texto-primario: #aaa;
}

.conteudo {
  background-color: var(--bg-primario);
  color: var(--texto-primario);
}
</style>
