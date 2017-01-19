using System.Collections.Generic;

namespace WebSample.Data.Query
{
    public class SearchResult<T>
    {
        public IList<T> Records { get; set; }
        public int TotalRecords { get; set; }        

        public SearchResult(IList<T> records, int totalRecords)
        {
            Records = records;
            TotalRecords = totalRecords;            
        }
    }
}
