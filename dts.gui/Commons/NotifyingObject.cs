using System.ComponentModel;

namespace dts.gui.Commons
{
    public class NotifyingObject : DisposeableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyyName));
            }
        }
    }
}
