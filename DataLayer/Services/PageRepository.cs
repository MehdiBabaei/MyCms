using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Services
{
    public class PageRepository : IPageRepository
    {
        private MyCmsContext db;
        public PageRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<Page> GetAllPage()
        {
            return db.Page;
        }

        public Page GetPageById(int PageId)
        {
            return db.Page.Find(PageId);
        }

        public bool InsertPage(Page Page)
        {
            try
            {
                db.Page.Add(Page);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePage(Page Page)
        {
            try
            {
                db.Entry(Page).State = EntityState.Modified;
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePage(Page Page)
        {
            try
            {
                db.Entry(Page).State = EntityState.Deleted;
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(int PageId)
        {
            var page = GetPageById(PageId);
            DeletePage(page);
            return true;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Page.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Page.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Page.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroupId(int groupId)
        {
            return db.Page.Where(p => p.GroupID == groupId);
        }

        public IEnumerable<Page> SearchPage(string search)
        {
            return db.Page.Where(p => p.Title.Contains(search)
            || p.ShortDescription.Contains(search)
            || p.Tags.Contains(search)
            || p.Text.Contains(search)).Distinct();
        }
    }
}
