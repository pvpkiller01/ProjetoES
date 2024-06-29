using ESProjeto.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESProjeto.Shared.Patterns
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
    }
}
