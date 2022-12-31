<template>
  <header>
    <h1>
      <img src="../assets/logo.png" alt="logo" />
    </h1>
    <div class="has-text-centered">
      <button class="button" @click="alterarTema">
        {{ textoBotao }}
      </button>
    </div>
    <nav class="panel mt-5">
      <ul>
        <li>
          <RouterLink to="/" class="link">
            <i class="fas fa-project-diagram"></i>
            projetos
          </RouterLink>
        </li>
        <li>
          <RouterLink to="/tarefas" class="link">
            <i class="fas fa-tasks"></i>
            tarefas
          </RouterLink>
        </li>
      </ul>
    </nav>
  </header>
</template>

<script lang="ts">
import { reactive, defineComponent, computed } from "vue";

export default defineComponent({
    setup(_, {emit}){
      const state = reactive({
        modoEscuroAtivo: false
      });

      const textoBotao = computed(() => {
        if(state.modoEscuroAtivo){
          return "Ativar light mode 🌞"
        }
        return "Ativar dark mode 🌜"
      })

      function alterarTema(){
        state.modoEscuroAtivo = !state.modoEscuroAtivo;
        emit("aoTemaAlterado", state.modoEscuroAtivo)
      }
      return {
        state,
        textoBotao,
        alterarTema
      }
    }
});
</script>

<style scoped>
h1 {
  text-align: center;
}
strong {
  color: #f95738;
}
header {
  background: #0d3b66;
  width: 100%;
  height: 100vh;
  padding: 2rem;
}
@media only screen and (max-width: 768px) {
  header {
    height: auto;
  }
}
.panel li {
  margin: 8px 0;
}
.link {
  color: #fff;
}
.link:hover {
  color: #FAF0CA;
}
.link.router-link-active {
  color: #FAF0CA;
}
</style>