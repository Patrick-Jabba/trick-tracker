<template>
  <div class="box formulario">
    <div class="columns">
      <div
        class="column is-5"
        role="form"
        aria-label="Formulário para criação de uma nova tarefa"
      >
        <input
          type="text"
          class="input"
          placeholder="Qual tarefa você deseja iniciar?"
          v-model="state.descricaoTarefa"
        />
      </div>
      <div class="column is-3">
        <div class="select">
          <select v-model="state.projetoId">
            <option value="" selected disabled hidden>Selecione um projeto:</option>
            <option
              v-for="projeto in projetos"
              :value="projeto.id"
              :key="projeto.id"
            >
              {{ projeto.nome }}
            </option>
          </select>
        </div>
      </div>
      <div class="column">
        <Temporizador @aoTemporizadorFinalizado="salvarTarefa" />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { reactive, defineComponent, computed } from "vue";

import useStore from "@/store";

import toast from "@/utils/toast";

import Temporizador from "@/components/Temporizador.vue";
import { TipoNotification } from "@/interfaces/INotification";
import { GET_PROJETOS } from "@/store/type-actions";

export default defineComponent({
  components: {
    Temporizador,
  },

  setup(_, { emit }) {
    const store = useStore();
    const state = reactive({
      descricaoTarefa: "",
      projetoId: 0,
    });
    store.dispatch(GET_PROJETOS);
    const projetos = computed(() => store.state.projeto.projetos);
    
    async function salvarTarefa(tempoDecorrido: number): Promise<void> {
      const projeto = store.state.projeto.projetos.find((proj) => proj.id === state.projetoId
      );
      if (!projeto) {
        toast.notificar(TipoNotification.FALHA, "Oops!", "Selecione um projeto para vincular sua tarefa.")
        return;
      }
      emit("aoSalvarTarefa", {
        duracaoEmSegundos: tempoDecorrido,
        descricao: state.descricaoTarefa,
        projeto: projeto,
      });
      toast.notificar(TipoNotification.SUCESSO, "Sucesso", "Tarefa criada com êxito!")
      state.descricaoTarefa = "";
    }

    return {
      state,
      projetos,
      salvarTarefa,
    };
  },
});
</script>

<style>
.formulario {
  color: var(--texto-primario);
  background-color: var(--bg-primario);
}
</style>