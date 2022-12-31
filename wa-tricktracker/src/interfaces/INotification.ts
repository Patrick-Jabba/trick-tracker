export enum TipoNotification {
  SUCESSO,
  FALHA,
  ATENCAO
}

export default interface INotification {
  titulo: string,
  texto: string,
  tipo: TipoNotification,
  id: number
}