namespace ControlLib.DataTable.Models
{
    public class ColumnDefinitionModel
    {
        public ColumnDefinitionModel(string header, string expression)
        {
            Header = header;
            Expression = expression;
        }

        public string Header
        {
            get;
            set;
        }

        public string Expression
        {
            get;
            set;
        }
    }
}