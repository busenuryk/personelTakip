
namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
        //base
        //parametreleri ifade ederken buradan devralıcaz
    {   //PAGESIZE PAGENUMBER??????
        const int MaxPageSize = 20;
        public int PageNumber { get; set; }
        private int  _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public String? OrderBy { get; set; }

    }
}
