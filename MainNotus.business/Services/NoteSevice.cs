using AutoMapper;
using MainNotus.business.DTO;
using MainNotus.data.Contexts;
using MainNotus.data.Repositories;
using System.Collections.Generic;

namespace MainNotus.business.Services
{
    public class NoteSevice : IService<NoteDTO>
    {
        IRepository<Note> noteRepo;
        private IUnitOfWork unitOfWork;
        IMapper mapper;

        public NoteSevice(IRepository<Note> noteRepo, IUnitOfWork unitOfWork)
        {
            this.noteRepo = noteRepo;
            this.unitOfWork = unitOfWork;

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Note, NoteDTO>().ReverseMap()));
        }

        public NoteDTO AddUpdate(NoteDTO entity)
        {
            var note = mapper.Map<Note>(entity);
            noteRepo.AddUpdate(note);
            unitOfWork.Save();
            return mapper.Map<NoteDTO>(note);
        }

        public NoteDTO Get(int id) => mapper.Map<NoteDTO>(noteRepo.Get(id));

        public IEnumerable<NoteDTO> GetAll() => mapper.Map<IEnumerable<NoteDTO>>(noteRepo.GetAll());

        public void Remove(NoteDTO entity)
        {
            var note = mapper.Map<Note>(entity);
            noteRepo.Remove(note);
            unitOfWork.Save();
        }
    }
}
