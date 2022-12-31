import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";

const Tarefas = () => import("@/views/Tarefas.vue");
const Projetos = () => import("@/views/Projetos.vue");
const Lista = () => import("@/views/Projetos/Lista.vue");
const Formulario = () => import("@/views/Projetos/Formulario.vue");


const routes: RouteRecordRaw[] = [
  {
    path: "/",
    component: Projetos,
    children: [
      {
        path: "",
        name: "projetos",
        component: Lista
      },
      {
        path: "novo",
        name: "novo projeto",
        component: Formulario
      },
      {
        path: ":id",
        name: "editar projeto",
        component: Formulario,
        props: true
      },
    ]
  },
  {
    path: "/tarefas",
    name: "tarefas",
    component: Tarefas
  },
  
]

const router = createRouter({
  history: createWebHashHistory(),
  routes: routes
})

export default router; 