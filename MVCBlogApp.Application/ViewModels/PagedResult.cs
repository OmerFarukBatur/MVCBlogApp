namespace MVCBlogApp.Application.ViewModels
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int PreviousPage
        {
            get
            {
                if (CurrentPage == 1)
                    return CurrentPage;
                else
                    return CurrentPage - 1;
            }
        }

        public int NextPage
        {
            get
            {
                if (CurrentPage == PageCount)
                    return PageCount;
                else
                    return CurrentPage + 1;
            }
        }

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }
        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public class PagedResult<T> : PagedResultBase 
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
