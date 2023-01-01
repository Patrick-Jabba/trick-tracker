import ITarefa from "@/interfaces/ITarefa";
import { AxiosInstance } from "axios";

export default (httpClient: AxiosInstance) => ({
  getTarefas: async (url: string) => {
    const response = await httpClient.get(url);

    return {
      data: response.data
    }
  },
  createTarefa: async (tarefa: ITarefa) => {
    const response = await httpClient.post("/Tarefa", tarefa);

    return {
      data: response.data
    }
  },
  updateTarefa: async (tarefa: ITarefa) => {
    const response = await httpClient.put(`/Tarefa/${tarefa.id}`, tarefa);

    return { 
      data: response.data
    }
  },
  deleteTarefa: async (id: number) => {
    await httpClient.delete(`Tarefa/${id}`);
  }
})