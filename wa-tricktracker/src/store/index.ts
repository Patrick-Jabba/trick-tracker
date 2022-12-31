import { InjectionKey } from "vue";
import { createStore, Store, useStore as vuexUseStore } from "vuex";

import { NOTIFICAR } from "./tipo-mutacoes";
import INotification from "@/interfaces/INotification";

import { TaskState, tarefa } from "./modulos/tarefa";
import { ProjectState, projeto } from "./modulos/projeto";

export interface State {
  projeto: ProjectState,
  tarefa: TaskState,
  notifications: INotification[]

}

export const key: InjectionKey<Store<State>> = Symbol()

export const store = createStore<State>({
  state: {
    projeto: {
      projetos: [],
    },
    tarefa: {
      tarefas: [],
    },
    notifications: []
  },
  mutations: {
    [NOTIFICAR](state, newNotification: INotification) {
      newNotification.id = new Date().getTime();
      state.notifications.push(newNotification);
      setTimeout(() => {
        state.notifications = state.notifications.filter(not => not.id !== newNotification.id);
      }, 3000)
    }
  },

  modules: {
    projeto,
    tarefa
  }
});

export default function useStore(): Store<State> {
  return vuexUseStore(key);
}

