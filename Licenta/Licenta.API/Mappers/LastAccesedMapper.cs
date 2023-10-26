using Licenta.Db.Data;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Mappers;

namespace Licenta.API.Mappers
{
    public class LastAccesedMapper : MapperBase<LastAccesed, LastAccesedDto>
    {
        public override LastAccesed Map(LastAccesedDto element)
        {
            throw new NotImplementedException();
        }


        public override LastAccesedDto Map(LastAccesed element)
        {
            return new LastAccesedDto()
            {
                Id = element.Id,
                Module = element.Module,
                Step = element.Step
            };
        }
    }
}
