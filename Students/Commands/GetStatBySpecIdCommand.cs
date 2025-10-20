using MyMediator.Interfaces;

namespace Students.Commands
{
    public class GetStatBySpecIdCommand : IRequest<IEnumerable<GroupStatDTO>>
    {
        public int Index { get; set; } = 0;
        public class GetStatBySpecIdCommandHandler : IRequestHandler<GetStatBySpecIdCommand, IEnumerable<GroupStatDTO>>
        {
            private readonly Db131025Context db;
            public GetStatBySpecIdCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            

            public async Task<IEnumerable<GroupStatDTO>> HandleAsync(GetStatBySpecIdCommand request, CancellationToken ct = default)
            {
                IEnumerable<GroupStatDTO> data1 = db.Groups.Where(g => request.Index == g.IdSpecial ).Select(g => new GroupStatDTO { Id = g.Id, IdSpecial = g.IdSpecial, StudentCount = g.Students.Count, Title = g.Title });

                return data1;
            }
        }
    }
}
