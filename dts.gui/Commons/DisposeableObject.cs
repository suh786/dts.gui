using System;

namespace dts.gui.Commons
{
    public class DisposeableObject : IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected virtual void DisposeInternal()
        {
            
        }

        #endregion
    }
}
