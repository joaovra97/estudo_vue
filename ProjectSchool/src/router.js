import Vue from "vue";
import Router from "vue-router";
import Alunos from "./components/Aluno/Alunos";
import AlunoDetalhe from "./components/Aluno/AlunoDetalhe";
import Professor from "./components/Professor/Professores";
import Sobre from "./components/Sobre/Sobre";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/professores",
      name: "Professores",
      component: Professor,
    },
    {
      path: "/todosalunos",
      name: "Alunos",
      component: Alunos,
    },
    {
      path: "/alunodetalhe/:id",
      name: "AlunoDetalhes",
      component: AlunoDetalhe,
    },
    {
      path: "/alunos/:prof_id",
      name: "Aluno",
      component: Alunos,
    },
    {
      path: "/sobre",
      name: "Sobre",
      component: Sobre,
    },
  ],
});
