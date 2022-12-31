import { State } from "@/store";
import { Module } from "vuex";
import IProjeto from "@/interfaces/IProjeto";
import { ADICIONA_PROJETO, ALTERA_PROJETO, EXCLUIR_PROJETO, DEFINIR_PROJETO } from "@/store/tipo-mutacoes";
import services from "@/services";
import { GET_PROJETOS, POST_PROJETO, UPDATE_PROJETO, DELETE_PROJETO } from "@/store/type-actions";

export interface ProjectState {
  projetos: IProjeto[]
}

export const projeto: Module<ProjectState, State> = {
  mutations: {
    [ADICIONA_PROJETO](state, nomeDoProjeto: string) {
      const projeto = {
        nome: nomeDoProjeto,
      } as IProjeto
      state.projetos.push(projeto);
    },
    [ALTERA_PROJETO](state, projeto: IProjeto) {
      const index = state.projetos.findIndex(proj => proj.id === projeto.id);
      state.projetos[index] = projeto;
    },
    [EXCLUIR_PROJETO](state, id: string) {
      state.projetos = state.projetos.filter(proj => proj.id != id);
    },
    [DEFINIR_PROJETO](state, projetos: IProjeto[]) {
      state.projetos = projetos;
    },
  },
  actions: {
    async [GET_PROJETOS]({ commit }) {
      try {
        const { data } = await services.projetos.getProjetos();

        commit(DEFINIR_PROJETO, data);
      } catch (error) {
        console.log(error)
      }
    },
    async [POST_PROJETO]({ commit }, nomeDoProjeto: string) {
      try {
        const { data } = await services.projetos.createProject(nomeDoProjeto);

        commit(ADICIONA_PROJETO, data)
        return data;
      } catch (error) {
        console.log(error)
      }
    },
    async [UPDATE_PROJETO]({commit}, projeto: IProjeto) {
      try {
        const { data } = await services.projetos.updateProject(projeto);
        
        commit(ALTERA_PROJETO, data);
        return data;
      } catch (error) {
        console.log(error);
      }
    },
    async [DELETE_PROJETO]({ commit }, id: string) {
      try {
        await services.projetos.deleteProject(id);
        commit(EXCLUIR_PROJETO, id);
      } catch (error) {
        console.log(error);
      }
    },
  }
}