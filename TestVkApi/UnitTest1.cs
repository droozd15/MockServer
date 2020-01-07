using NUnit.Framework;
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
    }
}