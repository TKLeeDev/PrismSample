using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.Models
{
    public interface ICustomNotification : IConfirmation
    {
        string SelectedItem { get; set; }
    }
}
