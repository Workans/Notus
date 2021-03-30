using MainNotus.business.DTO;
using MainNotus.business.Services;
using MainNotus.Infrastructure;
using MainNotus.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MainNotus.ViewModels
{
    class MainViewModel : BaseNotifyProportyChanged
    {
        private NoteDTO code;
        private string language;
        private ObservableCollection<NoteDTO> notes;

        public NoteDTO Code
        {
            get => code;
            set
            {
                code = value;
                Notify();
            }
        }
        public string Lanaguage
        {
            get => language;
            set
            {
                language = value;
                Notify();
            }
        }

        IService<NoteDTO> serviceNote;
        IService<LanguageDTO> serviceLangauge;

        public ObservableCollection<NoteDTO> Notes
        {
            get => notes;
            set
            {
                notes = value;
                Notify();
            }
        }

        public ICommand SelectCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DescriptionCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AboutCommad { get; set; }

        public MainViewModel(IService<NoteDTO> serviceNote, IService<LanguageDTO> serviceLangauge)
        {
            this.serviceNote = serviceNote;
            this.serviceLangauge = serviceLangauge;
            Lanaguage = "NaN";
            InitNotes();
            InitCommands();
        }

        void InitNotes()
        {
            Notes = new ObservableCollection<NoteDTO>(serviceNote.GetAll());
        }

        void InitCommands()
        {
            SelectCommand = new RelayCommand(x =>
              {
                  Lanaguage = serviceLangauge.Get(Code.LanguageId).LanguageName;
              });

            CloseCommand = new RelayCommand(x =>
              {
                  Window wnd = x as Window;
                  wnd.Close();
              });

            EditCommand = new RelayCommand(x =>
              {

              });

            AddCommand = new RelayCommand(x =>
              {
                  AddView wnd = new AddView
                  {
                      DataContext = new AddViewModel(serviceNote)
                  };
                  wnd.ShowDialog();
              });

            DescriptionCommand = new RelayCommand(x =>
              {
                  try
                  {
                      DescriptionView wnd = new DescriptionView
                      {
                          DataContext = new DescriptionViewModel(Code)
                      };
                      wnd.ShowDialog();
                  }
                  catch (Exception)
                  {
                      MessageBox.Show("Please choise note");
                  }
              });

            AboutCommad = new RelayCommand(x =>
              {
                  MessageBox.Show("Notus v 0.1 by Mihail Kapinos");
              });

            DeleteCommand = new RelayCommand(x =>
              {
                  var note = serviceNote.Get(Code.NoteId);
                  serviceNote.Remove(note);
                  Notes.Remove(note);
              });
        }
    }
}
