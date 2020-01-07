using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tests.Models;
using Tests.Client;

namespace Tests.Repositories
{
    public class UsersRepositoryVk: IUsersRepository
    {

        private string accessToken =
            "c45af7baa9064860a9b0b156990cdbc02d43c18793b1632ceb6ebe21f78b6c7e9be9f3ee270b0e7a158fc";

        private string url = "https://api.vk.com/method/";
        
        public User GetUserById(string id)
        {
            string request = $"{url}users.get?user_ids={id}&access_token={accessToken}&v=5.103";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            JObject userJObject = JObject.Parse(json);
            JToken userInfo = userJObject["response"][0];
            User user = new User();
            user.Id = userInfo["id"].ToString();
            user.FirstName = userInfo["first_name"].ToString();
            user.LastName = userInfo["last_name"].ToString();
            user.IsClosed = (bool)userInfo["is_closed"];
            return user;
        }
    }
}