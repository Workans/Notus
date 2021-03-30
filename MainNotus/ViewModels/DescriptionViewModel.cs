using MainNotus.business.DTO;
using MainNotus.Infrastructure;
using System.Windows;
using System.Windows.Input;

namespace MainNotus.ViewModels
{
    class DescriptionViewModel : BaseNotifyProportyChanged
    {
        private string noteName;
        private string description;
        private NoteDTO code = new NoteDTO();
        public string NoteName
        {
            get => noteName;
            set
            {
                noteName = value;
                Notify();
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                Notify();
            }
        }

        public NoteDTO Code
        {
            get => code;
            set
            {
                code = value;
                Notify();
            }
        }
        public ICommand CloseCommand { get; set; }

        public DescriptionViewModel(NoteDTO code)
        {
            Code = code;
            NoteName = Code.NoteName;
            Description = Code.FullDescription;

            InitCommand();
        }

        private void InitCommand()
        {
            CloseCommand = new RelayCommand(x =>
              {
                  Window wnd = x as Window;
                  wnd.Close();
              });

        }
    }
}
