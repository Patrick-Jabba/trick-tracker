<template>
  <section>
    <form @submit.prevent="salvarProjeto">
      <div class="field">
        <label for="nomeDoProjeto" class="label"> Nome do projeto </label>
        <input
          placeholder="Digite o nome do projeto"
          type="text"
          class="input"
          v-model="state.nomeDoProjeto"
          id="nomeDoProjeto"
        />
      </div>
      <div class="field">
        <button type="submit" class="button">Salvar</button>
      </div>
    </form>
  </section>
</template>

<script lang="ts">
import { reactive, defineComponent, onMounted } from "vue";
import router from "@/router";

import delay from "@/utils/delay";
import toast from "@/utils/toast";

import useStore from "@/store";
import { TipoNotification } from "@/interfaces/INotification";
import { GET_PROJETOS, POST_PROJETO, UPDATE_PROJETO } from "@/store/type-actions";

export default defineComponent({
  props: {
    id: {
      type: Number,
    },
  },

  setup(props) {
    const store = useStore();
    const state = reactive({
      nomeDoProjeto: "",
      dataCriacao: "",
    });

    onMounted(() => {
      if (props.id) {
        const projeto = store.state.projeto.projetos.find(proj => proj.id == props.id);
        state.nomeDoProjeto = projeto?.nome || "";
      }
    });

    async function salvarProjeto() {
      try {
        if (props.id) {
        if (!state.nomeDoProjeto) {
          toast.notificar(TipoNotification.FALHA, "Oops!", "Seu projeto precisa de um nome.");
          return;
        }
        store.dispatch(UPDATE_PROJETO, {
          id: props.id,
          nome: state.nomeDoProjeto,
        });
        toast.notificar(TipoNotification.SUCESSO, "Sucesso!", "Prontinho ;) Seu projeto foi alterado com sucesso.");
        await delay(500);
          store.dispatch(GET_PROJETOS);
          router.push({ name: "projetos" });
      } else {
        if (!state.nomeDoProjeto) {
          toast.notificar(TipoNotification.FALHA, "Oops!", "Seu projeto precisa de um nome.");
          return;
        }
        store.dispatch(POST_PROJETO, state.nomeDoProjeto);
        toast.notificar(TipoNotification.SUCESSO, "Sucesso!", "Prontinho ;) Seu projeto foi criado.");
        await delay(500);
          store.dispatch(GET_PROJETOS);
          router.push({ name: "projetos" });
      }
      state.nomeDoProjeto = "";      
      } catch (error) {
        console.log(error);
      }
    }

    return {
      state,
      salvarProjeto,
    };
  },
});
</script>

<style scoped>
label {
  color: var(--texto-primario);
}
</style>