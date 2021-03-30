using MainNotus.business.DTO;
using MainNotus.business.Services;
using MainNotus.data.Contexts;
using MainNotus.data.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainNotus.business.Moduls
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<NoteDTO>>().To<NoteSevice>();
            Bind<IService<LanguageDTO>>().To<LanguageService>();

            Bind<IRepository<Note>>().To<NotesRepository>();
            Bind<IRepository<Language>>().To<LanguageRepository>();

            Bind<DbContext>().To<NotusContext>();

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
