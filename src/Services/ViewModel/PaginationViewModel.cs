using System.Collections.Generic;

namespace TryLog.Services.ViewModel
{
    public class PaginationViewModel<T> where T : class
    {
        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
    }
}
