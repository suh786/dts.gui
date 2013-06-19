
using System;
using System.Windows;
using System.Windows.Controls;

namespace dts.gui.View
{
    public interface IView : IDisposable
    {
        void Init();
        object DataContext { get; set; }
    }

    public class ViewBase : UserControl, IView
    {
        protected ViewBase()
        {
            this.Loaded += HandleLoaded;
        }

        private void HandleLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Init();
        }

        public virtual void Init()
        {
            
        }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    Loaded -= HandleLoaded;

                    DisposeInternal();
                }

                IsDisposed = true;
            }
        }
        
        protected virtual void DisposeInternal()
        {
        } 
    }
}
