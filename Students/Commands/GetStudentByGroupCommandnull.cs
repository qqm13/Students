using MyMediator.Interfaces;

namespace Students.Commands
{
    public class GetStudentByGroupCommandnull: IRequest<IEnumerable<StudentDTO>>
    {
        

            public class GetStudentByGroupCommandnullHandler : IRequestHandler<GetStudentByGroupCommandnull, IEnumerable<StudentDTO>>
            {
                private readonly Db131025Context db;
                public GetStudentByGroupCommandnullHandler(Db131025Context db)
                {
                    this.db = db;
                }

                public async Task<IEnumerable<StudentDTO>> HandleAsync(GetStudentByGroupCommandnull request, CancellationToken ct = default)
                {
                    IEnumerable<StudentDTO> studentDTOs = db.Students.Where(s => s.IdGroup == null).Select(s => new StudentDTO { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Gender = s.Gender, IdGroup = s.IdGroup, Phone = s.Phone });


                    return studentDTOs;
                }
            }
        }
    }

