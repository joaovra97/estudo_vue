using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
        //geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //aluno
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false);
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor = false);
        Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeProfessor = false);

        //professor
        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno = false);        
        Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno = false);
    }
}