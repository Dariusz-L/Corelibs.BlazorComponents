using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corelibs.BlazorViews.Layouts
{
    public interface IView<TVM>
    {
        TVM Model { get; set; }
        Task RefreshView();
        Task RefreshViewModel();
    }
}
