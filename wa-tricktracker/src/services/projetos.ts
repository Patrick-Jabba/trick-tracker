import IProjeto from "@/interfaces/IProjeto";
import { AxiosInstance } from "axios";

export default (httpClient: AxiosInstance) => ({
  getProjetos: async () => {
    const response = await httpClient.get("/Projeto");

    return {
      data: response.data
    }
  },
  createProject: async (nome: string) => {
    const response = await httpClient.post("/Projeto", {
      nome,
    });

    return {
      data: response.data
    }
  },
  updateProject: async (projeto: IProjeto) => {
    const response = await httpClient.put(`/Projeto/${projeto.id}`, projeto);

    return {
      data: response.data
    }
  },
  deleteProject: async (id: string) => {
    await httpClient.delete(`/Projeto/${id}`)
  }
})