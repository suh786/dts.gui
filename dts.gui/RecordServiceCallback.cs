// -----------------------------------------------------------------------
// <copyright file="RecordServiceCallback.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics;
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
        public void RecordAdded(string recordId, string[] record)
        {
            Debug.WriteLine(recordId);
        }
    }
}
