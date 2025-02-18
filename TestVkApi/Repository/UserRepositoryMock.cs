﻿using Newtonsoft.Json;
using Tests.Client;
using Tests.Models;

namespace Tests.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        private string accessToken =
            "e4dd7cea02356d1d975085be3d5234a260f2f5a32e3aac8084cc742583532728668a7850edc8d0afc1495";

        private string url = "http://localhost:8080/method/";
        
        public User GetUserById(string id)
        {
            string request = $"{url}users/get/{id}";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}