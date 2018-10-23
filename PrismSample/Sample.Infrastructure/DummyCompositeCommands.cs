using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure
{


    public class DummyCompositeCommands : IDummyCompositeCommands
    {
        private CompositeCommand _command1 = new CompositeCommand();
        public CompositeCommand command1
        {
            get { return _command1; }
        }
    }
}
