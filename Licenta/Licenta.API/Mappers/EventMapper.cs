using Licenta.Db.Data;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Mappers;
using System;

namespace Licenta.API.Mappers
{
    public class EventMapper : MapperBase<Event, EventDto>
    {
        public override Event Map(EventDto element)
        {
            return new Event()
            {
                Id = element.Id,
                Title = element.Title,
                DueTime = element.DueTime,
                Description = element.Description,

            };
        }
        public override EventDto Map(Event element)
        {
            return new EventDto()
            {
                Id = element.Id,
                Title = element.Title,
                DueTime = element.DueTime,
                Description = element.Description,

            };
        }
    }
}
