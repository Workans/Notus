using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MainNotus.Infrastructure
{
    public abstract class BaseNotifyProportyChanged : INotifyPropertyChanged
    {
        protected void Notify([CallerMemberName] string proportyChange = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proportyChange));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
