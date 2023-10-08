using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataLayer.ViewModels;

namespace DataLayer.Services
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsContext db;
        public PageGroupRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroup;
        }

        public PageGroup GetGroupById(int groupId)
        {
            return db.PageGroup.Find(groupId);
        }

        public bool InsertGroup(PageGroup PageGroup)
        {
            try
            {
                db.PageGroup.Add(PageGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            var group = GetGroupById(groupId);
            DeleteGroup(group);
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

        public IEnumerable<ShowGroupViewModel> GetGroupsForView()
        {
            return db.PageGroup.Select(g => new ShowGroupViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Page.Count
            });
        }
    }
}
