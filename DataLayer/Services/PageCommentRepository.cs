using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private MyCmsContext db;
        public PageCommentRepository(MyCmsContext context)
        {
            db = context;
        }
        public IEnumerable<PageComment> GetCommenyByNewsId(int pageId)
        {
            return db.PageComment.Where(p => p.PageID == pageId);
        }
        public bool AddComment(PageComment comment)
        {
            try
            {
                db.PageComment.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
