﻿using Newtonsoft.Json;
using PushR.Models;
using PushR.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PushR.Services
{
    public class Services
    {
        public static async Task<string> Register(UserModel model)
        {
            HandleApiCall apiCall = new HandleApiCall();
            var json = JsonConvert.SerializeObject(model);
            var result = await apiCall.DoCall("Register", json);
            return result;
        }

        public static async Task<string> Login(UserModel model)
        {
            HandleApiCall apiCall = new HandleApiCall();
            var json = JsonConvert.SerializeObject(model);
            var result = await apiCall.DoCall("Login", json);
            return result;
        }

        public static async Task<List<UserModel>> AllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            HandleApiCall apiCall = new HandleApiCall();

            var result = await apiCall.DoCall("AllUsers", await SecureStorage.GetAsync("UserId"));
            users = JsonConvert.DeserializeObject<List<UserModel>>(result);

            return users;
        }

        public static async Task<List<UserChatModel>> UserChat(UserChatModel model)
        {
            List<UserChatModel> users = new List<UserChatModel>();

            HandleApiCall apiCall = new HandleApiCall();

            var json = JsonConvert.SerializeObject(model);
            var result = await apiCall.DoCall("UserChat", json);
            users = JsonConvert.DeserializeObject<List<UserChatModel>>(result);

            return users;
        }
    }
}