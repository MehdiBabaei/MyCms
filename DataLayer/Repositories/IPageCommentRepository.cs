using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetCommenyByNewsId(int pageId);
        bool AddComment(PageComment comment);
    }
}
