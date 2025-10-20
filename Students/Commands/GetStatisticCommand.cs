using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace Students.Commands
{
    public class GetStatisticCommand : IRequest<IEnumerable<GroupStatDTO>>
    {
        public class GetStatisticCommandHandler : IRequestHandler<GetStatisticCommand, IEnumerable<GroupStatDTO>>
        {
            private readonly Db131025Context db;
            public GetStatisticCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<GroupStatDTO>> HandleAsync(GetStatisticCommand request, CancellationToken ct = default)
            {
                IEnumerable<GroupStatDTO> data1 = db.Groups.Select(g => new GroupStatDTO {Id = g.Id, IdSpecial = g.IdSpecial, StudentCount = g.Students.Count, Title = g.Title });

                return data1;
            }
        }
    }
}
