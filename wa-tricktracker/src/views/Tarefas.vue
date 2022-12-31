<template>
  <Formulario @aoSalvarTarefa="salvarTarefa" />
  <div v-if="tarefas.length === 0" class="lista">
    <Box>Você ainda não possui tarefas criadas :( </Box>
  </div>
  <div v-else class="lista">
    <div class="field">
      <p class="control has-icons-left">
        <input 
          class="input" 
          type="text" 
          placeholder="Ache uma tarefa..."
          v-model="state.filtro"
        />
        <span class="icon is-small is-left">
          <i class="fas fa-search"></i>
        </span>
      </p>
    </div>
    <Tarefa
      v-for="(tarefa, index) in tarefas"
      :key="index"
      :tarefa="tarefa"
      @editarTarefa="selecionarTarefa"
    />
    <Modal :mostrarModal="state.tarefaSelecionada !== null">
      <template v-slot:cabecalho>
        <p class="modal-card-title">Editar Tarefa</p>
        <button @click="fecharModal" class="delete" aria-label="close"></button>
      </template>
      <template v-slot:corpo>
        <div class="field">
          <label for="descricaoDaTarefa" class="label">
            Digite a descrição da tarefa
          </label>
          <input
            type="text"
            class="input"
            v-model="state.tarefaSelecionada.descricao"
            id="descricaoDaTarefa"
          />
        </div>
      </template>
      <template v-slot:rodape>
        <button @click="confirmarUpdateTarefa" class="button is-success">
          Salvar Alterações
        </button>
        <button @click="fecharModal" class="button">Cancelar</button>
      </template>
    </Modal>  
  </div>
</template>

<script lang="ts">
import { defineComponent, computed, reactive, watchEffect } from "vue";

import useStore from "@/store";
import ITarefa from "@/interfaces/ITarefa";

import Box from "@/components/Box.vue";
import Tarefa from "@/components/Tarefa.vue";
import Modal from "@/components/Modal.vue";
import Formulario from "@/components/Formulario.vue";

import {
  GET_PROJETOS,
  GET_TAREFAS,
  POST_TAREFA,
  UPDATE_TAREFA,
} from "@/store/type-actions";

export default defineComponent({
  components: {
    Box,
    Tarefa,
    Modal,
    Formulario,
  },
  setup() {
    const store = useStore();
    const state = reactive({
      tarefaSelecionada: null as ITarefa | null,
      filtro: ""
    });
    store.dispatch(GET_TAREFAS);
    store.dispatch(GET_PROJETOS);

    const tarefas = computed(() => store.state.tarefa.tarefas);
   
    watchEffect(() => {
      store.dispatch(GET_TAREFAS, state.filtro)
    })

    function salvarTarefa(tarefa: ITarefa) {
      store.dispatch(GET_PROJETOS);
      store.dispatch(POST_TAREFA, tarefa);
    }

    function selecionarTarefa(tarefa: ITarefa) {
      state.tarefaSelecionada = tarefa;
    }

    function fecharModal() {
      state.tarefaSelecionada = null;
      location.reload();
    }

    function confirmarUpdateTarefa() {
      store.dispatch(UPDATE_TAREFA, state.tarefaSelecionada);
      fecharModal();
    }

    return {
      state,
      tarefas,
      salvarTarefa,
      selecionarTarefa,
      fecharModal,
      confirmarUpdateTarefa,
    };
  },
});
</script>

<style >
.lista {
  padding: 1.25rem;
}
</style>
