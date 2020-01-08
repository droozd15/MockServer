using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Tests.Client;
using Tests.Models;

namespace Tests.Repositories
{
    public class GroupRepositoryVk:IGroupRepository
    {
        private string accessToken =
            "c45af7baa9064860a9b0b156990cdbc02d43c18793b1632ceb6ebe21f78b6c7e9be9f3ee270b0e7a158fc";

        private string url = "https://api.vk.com/method/";


        public Group GetById(string id)
        {
            string request = $"{url}groups.getById?group_id={id}&access_token={accessToken}&v=5.103";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }
        
        private Group Parse(string json)
        {
            JObject groupJObject = JObject.Parse(json);
            JToken groupInfo = groupJObject["response"][0];
            Group group = new Group();
            group.Id = groupInfo["id"].ToString();
            group.Name = groupInfo["name"].ToString();
            group.ScreenName = groupInfo["screen_name"].ToString();
            group.IsClosed = (bool)groupInfo["is_closed"];
            return group;
            
        }
        
    }
}