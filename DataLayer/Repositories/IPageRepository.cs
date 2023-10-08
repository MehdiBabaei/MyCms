using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(int PageId);
        bool InsertPage(Page Page);
        bool UpdatePage(Page Page);
        bool DeletePage(Page Page);
        bool DeletePage(int PageId);
        void Save();
        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> ShowPageByGroupId(int groupId);
        IEnumerable<Page> SearchPage(string search);
    }
}
