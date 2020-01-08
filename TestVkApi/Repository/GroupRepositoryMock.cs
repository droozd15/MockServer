using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tests.Client;
using Tests.Models;

namespace Tests.Repositories
{
    public class GroupRepositoryMock:IGroupRepository
    {
       
        private string accessToken =
            "e4dd7cea02356d1d975085be3d5234a260f2f5a32e3aac8084cc742583532728668a7850edc8d0afc1495";

        private string url = "http://localhost:8080/method/";
        
        public Group GetById(string id)
        {
            string request = $"{url}groups/getById/{id}";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private Group Parse(string json)
        {
            return JsonConvert.DeserializeObject<Group>(json);
        }
        
        public List<Group> Get(string id, string count)
        {
            string request = $"{url}groups/get/{id}";
            WebClient webClient = new WebClient();
            
            string json = webClient.SendRequest(request, "GET");
            
            Group[] res = ParseList(json, count);
            List<Group> groups = new List<Group>();
            for (int i = 0; i < res.Length; i++)
                groups.Add(res[i]);
            return groups;
        }
        private Group[] ParseList(string json, string count)
        {
            return JsonConvert.DeserializeObject<Group[]>(json);
        }
    }
}