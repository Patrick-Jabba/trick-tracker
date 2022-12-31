<template>
  <Box>
    <div class="columns">
      <div class="column is-4">
        {{ tarefa.descricao || "Tarefa sem descrição" }}
      </div>
      <div class="column is-3">
        {{ tarefa.projeto?.nome || "N/D" }}

      </div>
      <div class="column">
        <Cronometro :tempoEmSegundos="tarefa.duracaoEmSegundos" />
      </div>
      <div>
        <button
          class="button ml-2"
          @click="editarTarefaSelecionada"
          title="Editar Título"
        >
          <span class="icon is-small">
            <i class="fas fa-pencil"></i>
          </span>
        </button>
        <button
          class="button ml-2 is-danger"
          @click="excluirTarefa(tarefa.id)"
          title="Deletar Tarefa"
        >
          <span class="icon is-small">
            <i class="fas fa-trash"></i>
          </span>
        </button>
      </div>
    </div>
  </Box>
</template>

<script lang="ts">
import { defineComponent, PropType, computed } from "vue";

import Box from "./Box.vue";
import Cronometro from "./Cronometro.vue";

import ITarefa from "@/interfaces/ITarefa";

import useStore from "@/store/index";
import toast from "@/utils/toast";

import { DELETE_TAREFA } from "@/store/type-actions";
import { TipoNotification } from "@/interfaces/INotification";

export default defineComponent({
  components: { Cronometro, Box },
  props: {
    tarefa: {
      type: Object as PropType<ITarefa>,
      required: true,
    },
  },

  setup(props, {emit}){
    const store = useStore();

    const tarefas = computed(() => store.state.tarefa.tarefas);    

    function excluirTarefa(id: string){
      store.dispatch(DELETE_TAREFA, id);
      toast.notificar(TipoNotification.SUCESSO, "Sucesso!", "Projeto excluído com êxito!");
    }

    function editarTarefaSelecionada(): void{
      emit("editarTarefa", props.tarefa)
    }

    return {
      tarefas,
      excluirTarefa,
      editarTarefaSelecionada,
    }
  }
});
</script>