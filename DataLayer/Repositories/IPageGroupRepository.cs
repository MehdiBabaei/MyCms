using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepository : IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();
        PageGroup GetGroupById(int groupId);
        bool InsertGroup(PageGroup PageGroup);
        bool UpdateGroup(PageGroup PageGroup);
        bool DeleteGroup(PageGroup PageGroup);
        bool DeleteGroup(int groupId);
        void Save();
        IEnumerable<ShowGroupViewModel> GetGroupsForView();
    }
}
