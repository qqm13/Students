using MyMediator.Interfaces;
using MyMediator.Types;

namespace Students.Commands
{
    public class AddNewGroupForSpecCommand : IRequest
    {
        public int IndexSpec { get; set; } = 0;
        public string GroupTitle { get; set; } = "";

        public class AddNewGroupForSpecCommandHandler : IRequestHandler<AddNewGroupForSpecCommand, Unit>
        {
            private readonly Db131025Context db;

            public AddNewGroupForSpecCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<Unit> HandleAsync(AddNewGroupForSpecCommand request, CancellationToken ct = default)
            {
                if(db.Specials.FirstOrDefault(s => s.Id == request.IndexSpec) == null)
                {
                    return Unit.Value;
                }


                db.Groups.Add(new Group {IdSpecial =  request.IndexSpec, Title = request.GroupTitle });
                await db.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
