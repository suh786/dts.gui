using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dts.gui.Models
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
