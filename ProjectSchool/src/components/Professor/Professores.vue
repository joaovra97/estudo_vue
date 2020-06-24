<template>
  <div>
    <titulo texto="Professores" />
    <table>
      <thead>
        <th>Cód.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="professor in professores" :key="professor.id">
          <td class="colPequeno">{{professor.id}}</td>
          <router-link
            :to="`/alunos/${professor.id}`"
            tag="td"
            style="cursor:pointer"
          >{{professor.nome}} {{professor.sobrenome}}</router-link>
          <td class="colPequeno">{{professor.qtdAlunos}}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>
              Nenhum Professor Encontrado
            </h5>
          </td>
        </tr>
        </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      professores: [],
      alunos: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:5000/api/alunos")
      .then(res => res.json())
      .then(alunos => {
        this.alunos = alunos;
        this.carregarProfessores();
      });
  },
  props: {},
  methods: {
    pegarQtdAlunosPorProfessor() {
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdAlunos: this.alunos.filter(
            aluno => aluno.professor.id == professor.id
          ).length
        };
        this.professores[index] = professor;
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:5000/api/professores")
        .then(res => res.json())
        .then(professores => {
          this.professores = professores;
          this.pegarQtdAlunosPorProfessor();
        });
    }
  }
};
</script>

<style scoped>

.colPequeno{
  text-align: center; 
  width: 20%
}

</style>