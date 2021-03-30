using AutoMapper;
using MainNotus.business.DTO;
using MainNotus.data.Contexts;
using MainNotus.data.Repositories;
using System.Collections.Generic;

namespace MainNotus.business.Services
{
    public class LanguageService : IService<LanguageDTO>
    {
        IRepository<Language> langRepo;
        private IUnitOfWork unitOfWork;
        IMapper mapper;

        public LanguageService(IRepository<Language> langRepo, IUnitOfWork unitOfWork)
        {
            this.langRepo = langRepo;
            this.unitOfWork = unitOfWork;

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Language, LanguageDTO>().ReverseMap()));
        }

        public LanguageDTO AddUpdate(LanguageDTO entity)
        {
            var lang = mapper.Map<Language>(entity);
            langRepo.AddUpdate(lang);
            unitOfWork.Save();
            return mapper.Map<LanguageDTO>(lang);
        }

        public LanguageDTO Get(int id) => mapper.Map<LanguageDTO>(langRepo.Get(id));

        public IEnumerable<LanguageDTO> GetAll() => mapper.Map<IEnumerable<LanguageDTO>>(langRepo.GetAll());

        public void Remove(LanguageDTO entity)
        {
            var lang = mapper.Map<Language>(entity);
            langRepo.Remove(lang);
            unitOfWork.Save();
        }
    }
}
