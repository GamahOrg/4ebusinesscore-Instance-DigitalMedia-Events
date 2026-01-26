using Events.Application.Features.Sectors.Command.ChangeSectorState;
using Events.Application.Features.Sectors.Query.GetAll;

namespace Events.API.Controller
{
    [AllowAnonymous]
    public class SectorController : BaseController
    {
        private readonly IMediator _mediator;
        public SectorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public Task<ResponseDTO> PostSector(PostSectorDto sectorDto)
        {
            return _mediator.Send(new PostSectorCommand { SectorDto = sectorDto });
        }

        [HttpPut("{sectorId}")]
        public Task<ResponseDTO> PutSector(PutSectorDto sectorDto, Guid sectorId)
        {
            return _mediator.Send(new PutSectorCommand { SectorId = sectorId, SectorDto = sectorDto });
        }

        [HttpPut("ChangeSectorState/{sectorId}")]
        public Task<ResponseDTO> ChangeSectorState([FromRoute] Guid sectorId)
        {
            return _mediator.Send(new ChangeSectorStateCommand { SectorId = sectorId });
        }

        [HttpDelete("{sectorId}")]
        public Task<ResponseDTO> DeleteSector(Guid sectorId)
        {
            return _mediator.Send(new DeleteSectorCommand { SectorId = sectorId });
        }

        [HttpGet]
        public Task<ResponseDTO> GetAllSectors()
        {
            return _mediator.Send(new GetAllSectorsQuery());
        }

        [HttpGet("GetAllSectorsPaginatedFiltered")]
        public Task<ResponseDTO> GetAllSectorsPaginatedFiltered(string? nameAr, string? nameEn, DateTime? createdOn, int pageNumber, int pageSize)
        {
            return _mediator.Send(new GetAllSectorsPaginatedQuery
            {
                CreatedOn = createdOn,
                NameAr = nameAr,
                NameEn = nameEn,
                PageNumber = pageNumber,
                PageSize = pageSize,
            });
        }

        [HttpGet("{sectorId}")]
        public Task<ResponseDTO> GetSectorById(Guid sectorId)
        {
            return _mediator.Send(new GetSectorByIdQuery { SectorId = sectorId });
        }

    }
}
