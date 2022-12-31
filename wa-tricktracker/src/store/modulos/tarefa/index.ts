import ITarefa from "@/interfaces/ITarefa";
import services from "@/services";
import { State } from "@/store";
import { ADICIONA_TAREFA, ALTERA_TAREFA, EXCLUIR_TAREFA, DEFINIR_TAREFA} from "@/store/tipo-mutacoes";
import { GET_TAREFAS, POST_TAREFA, UPDATE_TAREFA, DELETE_TAREFA } from "@/store/type-actions";
import { Module } from "vuex";

export interface TaskState {
  tarefas: ITarefa[]
}

export const tarefa: Module<TaskState, State> = {
  mutations: {
    
    [ADICIONA_TAREFA](state, tarefa: ITarefa) {
      state.tarefas.push(tarefa);
    },
    [ALTERA_TAREFA](state, tarefa: ITarefa) {
      const index = state.tarefas.findIndex(t => t.id === tarefa.id);
      state.tarefas[index] = tarefa;
    },
    [EXCLUIR_TAREFA](state, id: string) {
      state.tarefas = state.tarefas.filter(t => t.id != id);
    },
    [DEFINIR_TAREFA](state, tarefas: ITarefa[]) {
      state.tarefas = tarefas;
    },
  },
  actions: {
    
    async [GET_TAREFAS]({ commit }, filtro: string) {
      try {
        let url = "tarefas"
        if(filtro){
          url += `?descricao=${filtro}`
        }
        const { data } = await services.tarefas.getTarefas(url);

        commit(DEFINIR_TAREFA, data);
      } catch (error) {
        console.log(error)
      }
    },
    async [POST_TAREFA]({commit}, tarefa: ITarefa){
      try {
        const { data } = await services.tarefas.createTarefa(tarefa);

        commit(ADICIONA_TAREFA, data)
        return data;
      } catch (error) {
        console.log(error);
      }
    },
    async [UPDATE_TAREFA]({commit}, tarefa: ITarefa){
      try {
        const {data} = await services.tarefas.updateTarefa(tarefa);

        commit(ALTERA_TAREFA, data);
        return data;
      } catch (error) {
        console.log(error);
      }
    },
    async [DELETE_TAREFA]({commit}, id: string){
      try {
        await services.tarefas.deleteTarefa(id);
        commit(EXCLUIR_TAREFA, id)
      } catch (error) {
        console.log(error);
      }
    }
  },
}