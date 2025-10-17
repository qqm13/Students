 using MyMediator.Interfaces;
    
namespace Students.Commands
{
   
        public class GetGenderCountCommand : IRequest<IEnumerable<StudentDTO>>
    {
            public int Index { get; set; } = 0;

            public class GetGenderCountCommandHandler : IRequestHandler<GetGenderCountCommand, IEnumerable<StudentDTO>>
            {
                private readonly Db131025Context db;
                public GetGenderCountCommandHandler(Db131025Context db)
                {
                    this.db = db;
                }

                public async Task<IEnumerable<StudentDTO>> HandleAsync(GetGenderCountCommand request, CancellationToken ct = default)
                {
                IEnumerable<StudentDTO> countGenders = 
                db.Students.Where(s => s.IdGroup == request.Index && s.Gender == 1).Select(s => new StudentDTO { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Gender = s.Gender, IdGroup = s.IdGroup, Phone = s.Phone });
                //db.Students.Where(s => s.IdGroup == request.Index).Select
                //(s => new StudentDTO { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Gender = s.Gender, IdGroup = s.IdGroup, Phone = s.Phone });
                return countGenders;
                }
            }
        }
    }


