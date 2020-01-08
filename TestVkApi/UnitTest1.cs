using System.Collections.Generic;
using NUnit.Framework;
using Tests.MockServer;
using Tests.Models;
using Tests.Repositories;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void GetUserById()
        {
            IUsersRepository userRepository = new UsersRepositoryVk();
            User user = userRepository.GetUserById("154951306");
            
            Assert.AreEqual("Аня", user.FirstName);
            Assert.AreEqual("Зановская",user.LastName);
            
        }
        
        [Test]
        public void GetUserByIdMock()
        {
           
            IUsersRepository userRepository = new UsersRepositoryMock();
            User user = userRepository.GetUserById("154951306");
            
            Assert.AreEqual("Аня", user.FirstName);
            Assert.AreEqual("Зановская",user.LastName);

        }
        
        [Test]
        public void GetGroupById()
        {
            IGroupRepository groupRepository = new GroupRepositoryVk();
            Group group = groupRepository.GetById("155418187");
            
            Assert.AreEqual("Папуги :>",group.Name);
            Assert.AreEqual("papugi",group.ScreenName);
            
        }
        
        [Test]
        public void GetGroupByUserId()
        {
            IGroupRepository groupRepository = new GroupRepositoryVk();
            List<Group> groups = groupRepository.Get("154951306","5");
            
            Assert.AreEqual(5,groups.Count);
            
            Assert.AreEqual("Папуги :>",groups[2].Name);
        }
        
        
     }
}