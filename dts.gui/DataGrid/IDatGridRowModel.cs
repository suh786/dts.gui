using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using dts.gui.Models;

namespace dts.gui.DataGrid
{
    public interface IDataGridRowModel : IIdentifiable, INotifyPropertyChanged
    {
        
    }

    public abstract class DataGridRowModelBase : NotifyingObject, IDataGridRowModel
    {
        protected DataGridRowModelBase(IIdentifiable record)
        {
            Id = record.Id;
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            private set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }
    }
}
