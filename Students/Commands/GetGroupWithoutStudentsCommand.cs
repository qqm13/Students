using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace Students.Commands
{
    //public class GetGroupWithoutStudentsCommand : IRequestHandlerIEnumerable<GroupDTO>>
    //{
    //    private readonly Db131025Context db;
    //    public GetGroupWithoutStudentsCommandHandler(Db131025Context db)
    //    {
    //        this.db = db;
    //    }

    //    public async Task<IEnumerable<GroupDTO>> HandleAsync(GetGroupWithoutStudentsCommand request, CancellationToken ct = default)
    //    {
    //        IEnumerable<GroupDTO> studentDTOs = db.Students.Where(s => s.IdGroup == request.Index).Select(s => new StudentDTO { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Gender = s.Gender, IdGroup = s.IdGroup, Phone = s.Phone });


    //        return studentDTOs;
    //    }
    //}
    public class GetGroupWithoutStudentsCommand : IRequest<IEnumerable<GroupDTO>>
    {

        public class GetGroupWithoutStudentsCommandHandler : IRequestHandler<GetGroupWithoutStudentsCommand, IEnumerable<GroupDTO>>
        {
            private readonly Db131025Context db;
            public GetGroupWithoutStudentsCommandHandler(Db131025Context db)
            {
                this.db = db;
            }


            public async Task<IEnumerable<GroupDTO>> HandleAsync(GetGroupWithoutStudentsCommand request, CancellationToken ct = default)
            {
                return await db.Groups
                                    .Where(g => g.Students.Count == 0)
                                    .Select(g => new GroupDTO
                                    {
                                        Id = g.Id,
                                        Title = g.Title
                                    }).ToArrayAsync();
            }
        }
    }

}