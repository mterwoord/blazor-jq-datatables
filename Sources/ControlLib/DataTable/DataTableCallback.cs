using System;
using System.Threading.Tasks;
using ControlLib.DataTable.Models;
using Microsoft.JSInterop;

namespace ControlLib.DataTable
{
    public class DataTableCallback
    {
        private readonly IDataTable _jsGrid;

        public DataTableCallback(IDataTable jsGrid)
        {
            _jsGrid = jsGrid ?? throw new ArgumentNullException(nameof(jsGrid));
        }

        [JSInvokable]
        public async Task<GetDataCallbackResultModel> GetData(GetDataCallbackArgumentsModel data)
        {
            return await _jsGrid.DoGetDataAsync(data);
        }
    }
}