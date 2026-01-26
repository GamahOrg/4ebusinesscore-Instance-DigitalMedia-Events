using Events.Application.Featur.LK_EntityMember.Command.DeleteLK_EntityMember;
using Events.Application.Feature.LK_EntityMember.Command.PostLK_EntityMember;
using Events.Application.Feature.LK_EntityMember.Command.PutLkLK_EntityMember;
using Events.Application.Feature.LK_EntityMember.Query.EntityMember;

namespace Events.API.Controller
{
    public class LK_EventsStatusController : BaseController
    {
        private readonly IMediator _mediator;

        public LK_EventsStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Post

        [HttpPost]
        public async Task<ResponseDTO> Post([FromForm] PosLK_EventsStatusCommand PostPositionCommand)
        {
            return await _mediator.Send(PostPositionCommand);
        }
        #endregion

        #region Put

        [HttpPut]
        public async Task<ResponseDTO> Put([FromForm] PuLK_EventsStatusCommand PutPositionComand)
        {
            return await _mediator.Send(PutPositionComand);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{Id}")]
        public async Task<ResponseDTO> Delete(int Id)
        {
            return await _mediator.Send(new DeleteLK_EventsStatusCommand { Id = Id });
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            return await _mediator.Send(new GetAllLK_EntityMemberQuery { });

        }
        #endregion
    }
}
