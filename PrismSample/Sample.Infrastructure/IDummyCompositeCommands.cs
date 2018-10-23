using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure
{
    public interface IDummyCompositeCommands
    {
        CompositeCommand command1 { get; }
    }
}
