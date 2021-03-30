using MainNotus.business.DTO;
using MainNotus.business.Services;
using MainNotus.Infrastructure;
using System;
using System.Windows;
using System.Windows.Input;

namespace MainNotus.ViewModels
{
    class AddViewModel : BaseNotifyProportyChanged
    {
        private string noteName;
        private string shortDescription;
        private string fullDescription;
        private string language;

        public string NoteName
        {
            get => noteName;
            set
            {
                noteName = value;
                Notify();
            }
        }
        public string ShortDescription
        {
            get => shortDescription;
            set
            {
                shortDescription = value;
                Notify();
            }
        }
        public string FullDescription
        {
            get => fullDescription;
            set
            {
                fullDescription = value;
                Notify();
            }
        }
        public string Language
        {
            get => language;
            set
            {
                language = value;
                Notify();
            }
        }

        IService<NoteDTO> service;
        public ICommand AddCommand { get; set; }

        public AddViewModel(IService<NoteDTO> service)
        {
            this.service = service;
            InitCommand();
        }

        private void InitCommand()
        {
            AddCommand = new RelayCommand(x =>
              {
                  var note = new NoteDTO
                  {
                      NoteName = this.NoteName,
                      FullDescription = this.FullDescription,
                      ShortDescription = this.ShortDescription,
                      LanguageId = Convert.ToInt32(this.Language)
                  };
                  service.AddUpdate(note);
                  Window wnd = x as Window;
                  wnd.Close();
              });
        }
    }
}
