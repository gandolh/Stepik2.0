using Licenta.API.Mappers;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class QuizVariantService
    {
        private readonly QuizVariantsRepository _repository;
        private readonly QuizVariantMapper _mapper;

        public QuizVariantService(QuizVariantsRepository repository)
        {
            _repository = repository;
            _mapper = new QuizVariantMapper();
        }

        internal async Task<IEnumerable<QuizVariantDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }
    }
}
