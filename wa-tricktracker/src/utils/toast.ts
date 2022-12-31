import { store } from "@/store";
import { NOTIFICAR } from "@/store/tipo-mutacoes";
import { TipoNotification } from "@/interfaces/INotification";

const toast = {
  notificar: function (tipo: TipoNotification, titulo: string, texto: string) {
    store.commit(NOTIFICAR, {
      titulo,
      texto,
      tipo,
    });
  }
}

export default toast;