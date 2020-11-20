﻿using Refit;  
using System.Collections.Generic;  
using System.Threading.Tasks;

namespace AwesomeApp
{
    public class SimpleServerResponse
    {
        public string result { get; set; }
    }
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserAccess
    {
        public string accesskey { get; set; }
        public string result { get; set; }
    }

    public class ChatMessageSend
    {
        public string accesskey { get; set; }
        public string message { get; set; }
    }

    public class ChatMessageReceive
    {
        public string nick { get; set; }
        public string message { get; set; }
    }

    public class ChatMessages
    {
        public List<ChatMessageReceive> chatmessages { get; set; }
        public string result { get; set; }
    }

    public interface IAuthAPI
    {
        [Post("/login")]
        Task<UserAccess> Login([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> data);

        [Post("/register")]
        Task<SimpleServerResponse> Register([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> data);

        [Post("/sendmessage")]
        Task<SimpleServerResponse> SendMessage([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> data);

        [Post("/getmessages")]
        Task<ChatMessages> GetMessages([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> data);
    }
}
