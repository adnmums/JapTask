namespace Platform.Common
{
    public abstract class RequestParameters
    {
        const int maxPagesize = 10;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPagesize) ? maxPagesize : value;
            }
        }
    }
}