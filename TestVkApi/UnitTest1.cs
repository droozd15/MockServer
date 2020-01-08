using System.Collections.Generic;
using NUnit.Framework;
using Tests.MockServer;
using Tests.Models;
using Tests.Repositories;
using Tests.Services;

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
            UserService userService = new UserService(userRepository);
            
            User user = userService.GetUserById("154951306");
            
            Assert.AreEqual("Аня", user.FirstName);
            Assert.AreEqual("Зановская",user.LastName);
            
        }
        
        [Test]
        public void GetUserByIdMock()
        {
            IUsersRepository userRepository = new UsersRepositoryMock();
            UserService userService = new UserService(userRepository);
            User user = userService.GetUserById("154951306");
            
            Assert.AreEqual("Аня", user.FirstName);
            Assert.AreEqual("Зановская",user.LastName);

        }
        
        [Test]
        public void GetGroupByIdVk()
        {
            IGroupRepository groupRepository = new GroupRepositoryVk();
            GroupService groupService = new GroupService(groupRepository);
            Group group = groupService.GetById("155418187");
            
            Assert.AreEqual("Папуги :>",group.Name);
            Assert.AreEqual("papugi",group.ScreenName);
            
        }
        [Test]
        public void GetGroupByIdMock()
        {
            IGroupRepository groupRepository = new GroupRepositoryMock();
            GroupService groupService = new GroupService(groupRepository);
            Group group = groupService.GetById("155418187");
            
            Assert.AreEqual("Папуги :>",group.Name);
            Assert.AreEqual("papugi",group.ScreenName);
            
        }
        
        [Test]
        public void GetGroupByUserIdVK()
        {
            IGroupRepository groupRepository = new GroupRepositoryVk();
            GroupService groupService = new GroupService(groupRepository);
            List<Group> groups = groupService.Get("154951306","5");
            
            Assert.AreEqual(5,groups.Count);
            
            Assert.AreEqual("Папуги :>",groups[2].Name);
        }
                
        [Test]
        public void GetGroupByUserIdMock()
        {
            IGroupRepository groupRepository = new GroupRepositoryMock();
            GroupService groupService = new GroupService(groupRepository);
            List<Group> groups = groupService.Get("154951306","5");
    
            Assert.AreEqual(3,groups.Count);
    
            Assert.AreEqual("Папуги :>",groups[2].Name);
        }

      
        
     }
}