using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using dts.gui.Models;

namespace dts.gui
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
