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
                IEnumerable<GroupDTO> groups =
                    db.Groups.Select(s => new GroupDTO { Id = s.Id, idSpecial = s.IdSpecial, Title = s.Title });
                // db.Students.Where(s => s.IdGroup == request.Index && s.Gender == 0).Select(s => new GroupDTO { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Gender = s.Gender, IdGroup = s.IdGroup, Phone = s.Phone });
                var stud = db.Students/*.Where(s => s.IdGroup == request.Index)*/.Select
                (s => new StudentDTO { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Gender = s.Gender, IdGroup = s.IdGroup, Phone = s.Phone });

                int countgroup1 = 0;
                int countgroup2 = 0;
                int countgroup3 = 0;
                int countgroup4 = 0;

                IEnumerable<GroupDTO> groupsResult;

                foreach (var stude in stud)
                {
                    if (stude.Id == 1)
                    {
                        countgroup1++;
                    }
                    else if (stude.Id == 2)
                    {
                        countgroup2++;
                    }
                    else if (stude.Id == 3)
                    {
                        countgroup3++;
                    }
                    else if (stude.Id == 4)
                    {
                        countgroup4++;
                    }
                    else
                    {
                        //groupsResult 
                    }
                }

                return null;/*groupsResult;*/
            }
        }
    }

}