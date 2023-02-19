using Common.Basic.Blocks;
using Corelibs.BlazorShared;
using Mediator;
using Microsoft.AspNetCore.Components;
using Corelibs.Basic.Reflection;

namespace Corelibs.BlazorViews.Layouts
{
    public abstract class BaseComponent<TQuery, TQueryOut, TVM> : ComponentBase
        where TQuery : IQuery<Result<TQueryOut>>
        where TVM : new()
    {
        [Inject] protected ICommandExecutor _commands { get; set; }
        [Inject] protected IQueryExecutor _queries { get; set; }

        protected TVM _vm { get; private set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await RefreshViewModel();
        }

        public async Task RefreshView()
        {
            await RefreshViewModel();
            await InvokeAsync(StateHasChanged);
        }

        public async Task RefreshViewModel()
        {
            var result = await _queries.Execute<TQuery, TQueryOut>(QueryParameter);
            _vm = result.GetPropertyValue<TVM>() ?? _vm;
        }

        protected abstract string QueryParameter { get; }
    }
}
