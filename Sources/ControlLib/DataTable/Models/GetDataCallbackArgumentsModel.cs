using System.Collections.Generic;

namespace ControlLib.DataTable.Models
{
    public class GetDataCallbackArgumentsModel
    {
        public IList<GetDataCallbackColumnModel> Columns
        {
            get;
            set;
        }

        public int Skip
        {
            get;
            set;
        }

        public int Take
        {
            get;
            set;
        }
    }
}