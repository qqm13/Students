using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using Students.Commands;

namespace Students.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly Mediator mediator;
        public StudentController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }



        [HttpGet("GetStudentsByGroup")]
        public async Task<IEnumerable<StudentDTO>> StudentsByGroup(int index)
        {
            var command = new GetStudentByGroupCommand { Index = index };

            var result = await mediator.SendAsync(command);


            return result;
        }

        [HttpGet("GenderCount")]
        public async Task<CountGenders> GetGenderCount(int index)
        {
            IEnumerable<StudentDTO> result1;
            IEnumerable<StudentDTO> result2;

            CountGenders finish = new CountGenders();

            var command = new GetGenderCountCommand { Index = index };

            result1 = await mediator.SendAsync(command);

            foreach (StudentDTO r in result1)
            {
                finish.CountMale++;
            }

            var command1 = new GetGenderCountCommand1 { Index = index };

            result2 = await mediator.SendAsync(command1);

            foreach (StudentDTO r in result2)
            {
                finish.CountFemale++;
            }

            return finish;
        }
        [HttpGet("GetStudentsByGroupnull")]
        public async Task<IEnumerable<StudentDTO>> StudentsByGroupnull()
        {
            var command = new GetStudentByGroupCommandnull();

            var result = await mediator.SendAsync(command);


            return result;
        }

        [HttpGet("GetGroupWithoutStudentsCommand")]
        public async Task<IEnumerable<GroupDTO>> GroupWithoutStudentsCommand()
        {
            var command = new GetGroupWithoutStudentsCommand();
            var result = await mediator.SendAsync(command);
            return result;
        }

        [HttpGet("GetStatistic")]
        public async Task<IEnumerable<GroupStatDTO>> GetStatisticCommand()
        {
            var command = new GetStatisticCommand();
            var result = await mediator.SendAsync(command);
            return result;
        }

        [HttpGet("GetStatBySpecId")]
        public async Task<IEnumerable<GroupStatDTO>> GetStatBySpecIdCommand(int index)
        {
            var command = new GetStatBySpecIdCommand { Index = index};
            var result = await mediator.SendAsync(command);
            return result;
        }

        [HttpPost("AddNewGroupForSpec")]
        public async Task<ActionResult> AddNewGroupForSpec(int index, string groupName)
        {
            var command = new AddNewGroupForSpecCommand { IndexSpec = index , GroupTitle = groupName};
            await mediator.SendAsync(command);
            return Ok();
        }



    }

}

