import { TipoNotification } from "@/interfaces/INotification"
import { store } from "@/store";
import { NOTIFICAR } from "@/store/tipo-mutacoes";

type Toaster = {
  toast: (tipo: TipoNotification, titulo: string, texto: string) => void
}

export default () : Toaster => {

  const toast = (tipo: TipoNotification, titulo: string, texto: string): void => {
    store.commit(NOTIFICAR, {
      titulo,
      texto,
      tipo,
    });
  }

  return {
    toast
  }
}