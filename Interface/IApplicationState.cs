using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Interface
{
    public interface IApplicationState
    {
        ApplicationState NextState();
    }
}
