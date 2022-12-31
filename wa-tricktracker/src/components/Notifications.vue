<template>
  <div class="notifications">
    <article class="message" :class="state.contexto[notification.tipo]" v-for="notification in notifications" :key="notification.id">
      <div class="message-header">
        {{ notification.titulo }}
      </div>
      <div class="message-body">
        {{ notification.texto }}
      </div>
    </article>
  </div>
</template>

<script lang="ts">
import { reactive, defineComponent, computed } from 'vue'

import useStore from "@/store";
import { TipoNotification } from '@/interfaces/INotification';

export default defineComponent({
  setup() {
    const store = useStore();
    const state = reactive({
      contexto: {
        [TipoNotification.SUCESSO]: 'is-success',
        [TipoNotification.ATENCAO]: 'is-warning',
        [TipoNotification.FALHA]: 'is-danger',
      }
    });

    const notifications = computed(() => store.state.notifications)

    return {
      state,
      notifications
    }
  },
})
</script>

<style scoped>
  .notifications {
    position: absolute;
    right: 0;
    width: 300px;
    padding: 8px;
    z-index: 105;
  }
</style>