namespace ControlLib.DataTable.Models
{
    public class GetDataCallbackResultModel
    {
        public int RecordsTotal
        {
            get;
            set;
        }

        public int RecordsFiltered
        {
            get;
            set;
        }

        public object[] Data
        {
            get;
            set;
        }
    }
}