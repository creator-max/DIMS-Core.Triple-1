namespace DIMS_Core.DataAccessLayer.Filters
{
    public abstract class FilterBase
    {
        public int Page { get; set; } = 0;

        public int PageSize { get; set; } = 20;

        public string SortExpression { get; set; }
    }
}