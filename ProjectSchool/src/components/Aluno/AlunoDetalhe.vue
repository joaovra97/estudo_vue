<template>
  <div>
    <Titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="visualizando">
      <button v-show="visualizando" class="btn btnEditar" @click="editar()">Editar</button>
    </Titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{aluno.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{aluno.nome}}</label>
            <input v-else v-model="alunoEdicao.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{aluno.sobrenome}}</label>
            <input v-else v-model="alunoEdicao.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data de Nascimento:</td>
          <td>
            <label v-if="visualizando">{{aluno.dataNasc}}</label>
            <input v-else v-model="alunoEdicao.dataNasc" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizando">{{aluno.professor.nome}}</label>
            <select v-else v-model="alunoEdicao.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                :value="professor.id"
              >{{professor.nome}}</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar()">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>

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
      aluno: { professor: { nome: "", id: 0 } },
      alunoEdicao: {},
      visualizando: true
    };
  },
  beforeCreate() {
    this.$http
      .get(`http://localhost:5000/api/alunos/${this.$route.params.id}`)
      .then(res => res.json())
      .then(aluno => {
        this.aluno = aluno;
        this.preparaAlunoEdicao();
      });

    this.$http
      .get("http://localhost:5000/api/professores")
      .then(res => res.json())
      .then(professores => (this.professores = professores));
  },
  methods: {
    editar() {
      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
      this.preparaAlunoEdicao();
    },
    salvar() {
      this.visualizando = !this.visualizando;
      this.alunoEdicao.professor = this.professores.find(p => p.id == this.alunoEdicao.professor.id);
      this.alunoEdicao.professorId = this.alunoEdicao.professor.id;
      this.$http
        .put(`http://localhost:5000/api/alunos/${this.aluno.id}`, this.alunoEdicao)
        .then(res => res.json())
        .then(aluno => {          
          this.aluno = aluno;
          this.aluno.professor = this.professores.find(p => p.id == this.alunoEdicao.professor.id);
          this.preparaAlunoEdicao();
        });
    },
    preparaAlunoEdicao() {
      this.alunoEdicao = {
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNasc: this.aluno.dataNasc,
        id: this.aluno.id,
        professor: (this.aluno.professor == null ? this.professores.find(p => p.id == this.alunoEdicao.professor.id) : this.aluno.professor),
        professorId: this.aluno.professorId
      };

      console.log(this.alunoEdicao);
    }
  }
};
</script>

<style scoped>
.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  width: 95%;
  background-color: (245, 245, 245);
}

select {
  height: 38px;
  width: 100%;
}

.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}

.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}
</style>