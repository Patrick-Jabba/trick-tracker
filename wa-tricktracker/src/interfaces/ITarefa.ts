import IProjeto from "./IProjeto";

export default interface ITarefa {
  id: string,
  duracaoEmSegundos: number,
  descricao: string,
  projeto: IProjeto
}