using System.Collections.Generic;
using Tests.Models;

namespace Tests.Repositories
{
    public class GroupRepositoryMock:IGroupRepository
    {
        public Group GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}