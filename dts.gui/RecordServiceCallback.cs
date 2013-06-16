// -----------------------------------------------------------------------
// <copyright file="RecordServiceCallback.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics;
using System.Threading.Tasks;
using dts.gui.RegistrationService;

namespace dts.gui
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RegistrationServiceCallback : IRegistrationServiceCallback
    {
        public void RecordAdded(Person person)
        {
            if(person == null) return;

            Task.Factory.StartNew(() => Debug.WriteLine(person.ToDisplayString()));
        }
    }
}
