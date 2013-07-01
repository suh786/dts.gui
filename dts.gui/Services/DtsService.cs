using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using dts.gui.Commons;
using dts.gui.Person;

namespace dts.gui.Services
{
    public interface IDtsService : IDisposable
    {
        ISubscriptionManager<IPersonRecord> PersonSubscriptionManager { get; }
    }

    [Export(typeof(IDtsService))]
    public class DtsService : DisposeableObject, IDtsService
    {
        public DtsService()
        {
            PersonSubscriptionManager = new PersonSubscriptionManager();
        }

        public ISubscriptionManager<IPersonRecord> PersonSubscriptionManager { get; private set; }

        protected override void DisposeInternal()
        {
            PersonSubscriptionManager.Dispose();

            base.DisposeInternal();
        }
    }
}
