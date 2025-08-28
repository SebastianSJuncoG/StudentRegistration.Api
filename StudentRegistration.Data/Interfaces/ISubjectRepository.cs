using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Interfaces
{
    public interface ISubjectRepository
    {
        /// <summary>
        /// Obtiene una lista de todos las materias
        /// </summary>
        /// <returns>Retorna una lista con todas las materia</returns>
        Task<IEnumerable<Subject>> GetSubjects();

        /// <summary>
        /// Obtiene una materia por su Id
        /// </summary>
        /// <param name="id">Id de la materia a consultar</param>
        /// <returns>Retorna una materia en especifico segun su Id</returns>
        Task<Subject> GetSubjectId(int id);

        /// <summary>
        /// Obtiene una lista de las materias que pueden ser validas para un estudiante
        /// </summary>
        /// <returns>Retorna una lista con las materia validas para un estudiante</returns>
        Task<IEnumerable<Subject>> GetSubjectsValids(Guid IdStudent);

        /// <summary>
        /// Registra una asignatura a un estudiente
        /// </summary>
        /// <param name="NewRegister">Objeto con el id del estudiante y de la materia</param>
        /// <returns>Retorna un booleano para identificar si el registro fue satisfactorio</returns>
        Task<Boolean> registerSubjectByStudent(SubjectStudent NewRegister);

        /// <summary>
        /// Asigna un docente a una asignatura
        /// </summary>
        /// <param name="IdStudent">Id del estudiante</param>
        /// <param name="IdSubject">Id de la materia</param>
        /// <returns>Retorna un booleano para identificar si el registro fue satisfactorio</returns>
        Task<Boolean> registerTeacherToSubject(SubjectTeacher NewRegister);

        /// <summary>
        /// Permite editar una materia para un estudiante
        /// </summary>
        /// <param name="program">Objeto de la materia a editar</param>
        /// <returns>Retorna un bool para indicar si se edito de forma correcta</returns>
        Task<bool> UpdateSubjectByStudent(SubjectStudent subjectStudent);

        /// <summary>
        /// Permite eliminar una materia para un estudiante
        /// </summary>
        /// <param name="program">Objeto de la materia a eliminar</param>
        /// <returns>Retorna un bool para indicar si se elimino de forma correcta</returns>
        Task<bool> DeleteSubjectByStudent(int id);

        /// <summary>
        /// Entrega la cantidad de creditos que ha usado un estudiante
        /// </summary>
        /// <param name="Id">Id del estudiante</param>
        /// <returns>Entrega la cantidad de creditos que ha usado un estudiante</returns>
        Task<int> CreditCouting(Guid Id);
    }
}
