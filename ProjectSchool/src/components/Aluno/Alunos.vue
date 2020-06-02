<template>
  <div>
    <titulo :texto="titulo" />
    <div>
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()" />
      <button @click="addAluno()" class="btn btnInput">Adicionar</button>
    </div>

    <!-- table>(thread>th*3)+tbody>tr>td*3 -->

    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="aluno in alunos" :key="aluno.id">
          <td>{{aluno.id}}</td>
          <td>{{aluno.nome}} {{aluno.sobrenome}}</td>
          <td>
            <button class="btn btnDanger" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum Aluno Encontrado</tfoot>
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
      titulo: "Aluno",
      nome: "",
      alunos: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then(res => res.json())
      .then(alunos => (this.alunos = alunos));
  },
  props: {},
  methods: {
    addAluno() {
      let nome = this.nome.split(" ")[0];
      let indiceEspaco = this.nome.indexOf(" ");
      let sobrenome = indiceEspaco > -1 ? this.nome.substring(indiceEspaco).trim() : "";

      let _aluno = {
        nome: nome,
        sobrenome: sobrenome
      };

      this.$http
        .post("http://localhost:3000/alunos", _aluno)
        .then(res => res.json())
        .then(alunoRetornado => {
          this.alunos.push(alunoRetornado);
          this.nome = "";
        })

    },
    remover(_aluno) {
      this.$http
        .delete(`http://localhost:3000/alunos/${_aluno.id}`)
        .then(() => {
          let indice = this.alunos.indexOf(_aluno);
          this.alunos.splice(indice, 1);     
        })
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input {
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btnInput {
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
  display: inline;
}

.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
