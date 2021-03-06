﻿using Project.Handler;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class UserController
    {
        public static bool doRegister(string name, string email, string password, string gender, string conf, out string errorMsg)
        {
            User usr = RegisterHandler.SearchByEmail(email);
            errorMsg = "";
            if(usr != null)
            {
                errorMsg = "Email already exists!";
                return false;
            }
            else if(password.Length <= 5)
            {
                errorMsg = "Must be longer than 5 characters";
                return false;
            }
            else if (!conf.Equals(password))
            {
                errorMsg = "Password must be same!";
                return false;
            }
            else if (name.Equals("") || email.Equals("") || password.Equals("") || conf.Equals("") || gender.Equals(""))
            {
                errorMsg = "Data must be filled!";
                return false;
            }
            else if (!email.Contains("@"))
            {
                errorMsg = "Please include an @ in the email address.";
                return false;
            }
            else if (!email.EndsWith(".com") || !email.EndsWith(".net"))
            {
                errorMsg = "Email must ends with .com or .net";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void addUser(string name, string email, string password, string gender)
        {
            RegisterHandler.addUser(name, email, password, gender);
        }

        public static List<User> getAllUser()
        {
            return UserHandler.getAllUser();
        }
    }
}