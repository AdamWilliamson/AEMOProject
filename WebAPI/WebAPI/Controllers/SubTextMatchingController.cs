using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Commands.SubTextMatchingCommand;
using WebAPI.Controllers.SubTextMatching;

namespace WebAPI.Controllers
{
    [ApiController]

    public class SubTextMatchingController : ControllerBase
    {
        public SubTextMatchingController(){}

        [HttpPost]
        [Route("[controller]/FindMatches")]
        public async Task<SubTextMatchingResponse> FindMatches([FromBody]SubTextMatchingViewModel model)
        {
            // Ideally I would use MediatR, or create my own CommandHandler, to allow IOC.
            return await new SubTextMatchingCommandHandler()
                .Handle(new SubTextMatchingCommand(model.Text, model.SubText, model.CaseSensitive));
        }
    }
}
