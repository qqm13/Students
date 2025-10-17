using MyMediator.Interfaces;
using Students;
using Students.Commands;

namespace Students.Commands
{

    public class GetStudentByGroupCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public int Index { get; set; } = 0;

        public class GetStudentByGroupCommandHandler : IRequestHandler<GetStudentByGroupCommand, IEnumerable<StudentDTO>>
        {
            private readonly Db131025Context db;
            public GetStudentByGroupCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<StudentDTO>> HandleAsync(GetStudentByGroupCommand request, CancellationToken ct = default)
            {
                IEnumerable<StudentDTO> studentDTOs = db.Students.Where(s => s.IdGroup == request.Index).Select(s => new StudentDTO { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Gender = s.Gender, IdGroup = s.IdGroup, Phone = s.Phone });


                return studentDTOs;
            }
        }
    }
}
