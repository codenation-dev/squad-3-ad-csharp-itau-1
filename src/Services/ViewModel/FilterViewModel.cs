using System.Collections.Generic;

namespace TryLog.Services.ViewModel
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            Order = 1;
            SearchText = string.Empty;
            idsEnv = new List<int>(3);
        }
        public int Order { get; set; }
        public string SearchText { get; set; }
        public List<int> idsEnv;        
    } 
}
