using Events.Application.Features.EventComments.Command.Delete;
using Events.Application.Features.EventComments.Command.Post;
using Events.Application.Features.EventComments.Command.Put;

namespace Events.API.Controller
{
    //[AllowAnonymous]
    [RequestSizeLimit(1048576000)] // 1000 MB
    [RequestFormLimits(MultipartBodyLengthLimit = 1048576000)] // 1000 MB
    public class EventsController : BaseController
    {
        private readonly IMediator _mediator;
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<ResponseDTO> PostEvents([FromForm] PostEventsDto eventsDto)
        {
            return _mediator.Send(new PostEventsCommand { EventsDto = eventsDto });
        }

        [HttpPut("{EventsId}")]
        public Task<ResponseDTO> PutEvents([FromForm] PutEventsDto EventsDto, Guid eventsId)
        {
            return _mediator.Send(new PutEventsCommand { EventsId = eventsId, EventsDto = EventsDto });
        }

        [HttpPost, Route("PostEventsRating")]
        public async Task<ResponseDTO> PostEventsRating([FromBody] PostEventsRatingCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost, Route("PostEventsComment")]
        public async Task<ResponseDTO> PostEventsComment([FromBody] PostEventsCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut, Route("PutEventsComment")]
        public Task<ResponseDTO> PutComment(PutEventsCommentCommand command)
        {
            return _mediator.Send(command);
        }


        [HttpDelete("{CommentId}")]
        public Task<ResponseDTO> DeleteComment(Guid commentId)
        {
            return _mediator.Send(new DeleteCommentCommand { CommentId = commentId });
        }


        [HttpGet]
        public Task<ResponseDTO> GetAllEvents(int pageNumber, int pageSize, string? title, OrderStatus? orderStatus)
        {
            return _mediator.Send(new GetAllEventsQuery(pageNumber, pageSize, title, orderStatus));
        }

        [HttpGet("GetAllEventsPaginatedFiltered")]
        public Task<ResponseDTO> GetAllEventsPaginatedFiltered(string? title, DateTime? startDate, int pageNumber, int pageSize)
        {
            return _mediator.Send(new GetAllEventsPaginatedQuery
            {
                StartDate = startDate,
                Title = title,
                PageNumber = pageNumber,
                PageSize = pageSize,
            });
        }

        [HttpGet("{EventsId}")]
        public Task<ResponseDTO> GetEventsById(Guid EventsId)
        {
            return _mediator.Send(new GetEventsByIdQuery { EventsId = EventsId });
        }


        [HttpPut("PutPublishEvents/{EventsId}")]
        public Task<ResponseDTO> PutPublishEvents(Guid EventsId)
        {
            return _mediator.Send(new PutPublishEventsCommand { EventsId = EventsId });
        }


        [HttpDelete("DeleteEvents/{EventsId}")]
        public Task<ResponseDTO> DeleteEvents(Guid EventsId)
        {
            return _mediator.Send(new DeleteEventsCommand { EventsId = EventsId });
        }

        [HttpGet]
        [Route("GetAllLatestEventsPaginated")]
        public async Task<ResponseDTO> GetAllLatestEventsPaginated(int pageNumber, int pageSize) => await _mediator.Send(new GetAllLeatestPaginatedQuery(pageNumber, pageSize));

        [HttpGet]
        [Route("GetAllLeatestEvents")]
        public async Task<ResponseDTO> GetAllLeatestEvents(int pageNumber, int pageSize) => await _mediator.Send(new GetAllLeatestQuery(pageNumber, pageSize));

        //[HttpPut("ChangeEventsState/{EventsId}")]
        //      public Task<ResponseDTO> ChangeEventsState([FromRoute] Guid EventsId)
        //      {
        //          return _mediator.Send(new ChangeEventsStateCommand { EventsId = EventsId });
        //      }

        //[HttpGet]
        //[Route("GetAllImportantEvents")]
        //public async Task<ResponseDTO> GetAllImportantEvents(int pageNumber, int pageSize) => await _mediator.Send(new GetImportantEventsQuery(pageNumber, pageSize));

        //[HttpGet]
        //[Route("GetAllMainEvents")]
        //public async Task<ResponseDTO> GetAllMainEvents(int pageNumber, int pageSize) => await _mediator.Send(new GetMainEventsQuery(pageNumber, pageSize));
        //[HttpGet]
        //[Route("GetAllMainHomeEvents")]
        //public async Task<ResponseDTO> GetAllMainHomeEvents(int pageNumber, int pageSize) => await _mediator.Send(new GetMainHomeEventsQuery(pageNumber, pageSize));

        //[HttpGet]
        //[Route("GetAllSimilarEventsPaginated/{EventsId}")]
        //public async Task<ResponseDTO> GetAllSimilarEventsPaginated(Guid EventsId, int pageNumber, int pageSize) => await _mediator.Send(new GetSimilarEventsQuery(EventsId, pageNumber, pageSize));

        [HttpGet, Route("GetEventsDetails/{id}")]
        public async Task<ResponseDTO> GetEventsDetails(Guid id) => await _mediator.Send(new GetEventsDetailsQuery(id));

    }
}
