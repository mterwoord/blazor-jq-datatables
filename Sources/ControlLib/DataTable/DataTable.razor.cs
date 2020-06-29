using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControlLib.DataTable.Columns;
using ControlLib.DataTable.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ControlLib.DataTable
{
    partial class DataTable<T>: IDisposable, IDataTable
    {
        #region Dependencies

        [Inject]
        public IJSRuntime JsRuntime
        {
            get;
            set;
        }

        #endregion

        #region Parameters

        [Parameter]
        public RenderFragment ChildContent
        {
            get;
            set;
        }

        [Parameter]
        public RenderFragment Columns
        {
            get;
            set;
        }

        [Parameter]
        public Func<GetDataCallbackArgumentsModel, CancellationToken, Task<GetDataCallbackResultModel>> GetData
        {
            get;
            set;
        }

        #endregion Parameters

        #region Properties

        #endregion Properties

        private ElementReference _tableRef;
        private ElementReference _containerRef;

        private string GetErrorMessage()
        {
            var sb = new StringBuilder();
            if (AllColumns          == null
                || AllColumns.Count == 0)
            {
                //sb.AppendLine("No Columns specified!");
            }
            if (GetData == null)
            {
                sb.AppendLine("No GetData specified!");
            }
            return sb.ToString();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

        }

        private DataTableCallback                        _callback;
        private DotNetObjectReference<DataTableCallback> _callbackReference;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);


            if (firstRender && string.IsNullOrWhiteSpace(GetErrorMessage()))
            {
                _callback          = new DataTableCallback(this);
                _callbackReference = DotNetObjectReference.Create(_callback);

                //var columnModels = AllColumns.Select(i => new ColumnDefinitionModel(i.Header, i.Expression)).ToArray();
                Console.WriteLine("Nu table initializeren");
                await JsRuntime.InvokeVoidAsync("dataTable_initializeDataTable", _containerRef, _tableRef, null, _callbackReference);
            }
        }

        public void Dispose()
        {
            CleanupControlAsync();

            _callbackReference?.Dispose();

            Console.WriteLine("Callback disposed!");

        }

        private async void CleanupControlAsync()
        {
            //await JsRuntime.InvokeVoidAsync("oldTwDataTable_cleanupTwDataTable", _containerRef, _tableRef, _callbackReference);
        }

        internal async Task<GetDataCallbackResultModel> DoGetDataAsync(GetDataCallbackArgumentsModel argumentsModel)
        {
            return await GetData(argumentsModel, CancellationToken.None);
        }

        async Task<GetDataCallbackResultModel> IDataTable.DoGetDataAsync(GetDataCallbackArgumentsModel data)
        {
            return await DoGetDataAsync(data);
        }

        internal List<TextTableColumn> AllColumns
        {
            get;
        }=new List<TextTableColumn>();

        public void AddColumn(TextTableColumn column)
        {
            if (column == null)
            {
                throw new ArgumentNullException(nameof(column));
            }
            AllColumns.Add(column);
        }

        public void RemoveColumn(TextTableColumn column)
        {
            if (column == null)
            {
                throw new ArgumentNullException(nameof(column));
            }
            AllColumns.Remove(column);
        }

        internal IDataTable AsInterface => this;
    }
}