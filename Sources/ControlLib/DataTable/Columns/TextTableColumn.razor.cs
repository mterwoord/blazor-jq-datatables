using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ControlLib.DataTable.Columns
{
    partial class TextTableColumn: IDisposable
    {
        [CascadingParameter]
        private IDataTable DataTable
        {
            get;
            set;
        }

        [Parameter]
        public string Header
        {
            get;
            set;
        }

        [Parameter]
        public string Expression
        {
            get;
            set;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            DataTable.AddColumn(this);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override bool ShouldRender()
        {
            return base.ShouldRender();
        }

        public void Dispose()
        {
            DataTable?.RemoveColumn(this);
        }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
        }
    }
}