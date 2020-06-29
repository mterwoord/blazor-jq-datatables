using System.Threading.Tasks;
using ControlLib.DataTable.Columns;
using ControlLib.DataTable.Models;

namespace ControlLib.DataTable
{
    public interface IDataTable
    {
        Task<GetDataCallbackResultModel> DoGetDataAsync(GetDataCallbackArgumentsModel data);

        void AddColumn(TextTableColumn    column);
        void RemoveColumn(TextTableColumn column);
    }
}