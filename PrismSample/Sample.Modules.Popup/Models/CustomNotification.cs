using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.Popup.Models
{
    public class CustomNotification : Confirmation, ICustomNotification
    {
        public IList<string> Items { get; private set; }
        public string SelectedItem { get; set; }

        public CustomNotification()
        {
            this.Items = new List<string>();
            this.SelectedItem = null;
            CreateItems();
        }

        private void CreateItems()
        {
            Items.Add("Items1");
            Items.Add("Items2");
            Items.Add("Items3");
            Items.Add("Items4");
            Items.Add("Items5");
        }
    }
}
