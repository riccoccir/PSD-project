﻿using Project.Handler;
using Project.Model;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class InsertProductController
    {
        public static List<ProductType> getAllProductType()
        {
            return InsertProductHandler.getAllProductType();
        }

        public static void doInsert(int id, string name, int price, int stock)
        {
            InsertProductHandler.InsertProduct(id, name, price, stock);
        }

        public static ProductType SearchByName(string type)
        {
            return InsertProductHandler.SearchByName(type);
        }

        public static bool Insert(string name, int stock, int price, string type, out string errorMsg)
        {
            errorMsg = "";
            if (name.Equals(""))
            {
                errorMsg = "Data Invalid!";
                return false;
            }
            else if(stock <= 1)
            {
                errorMsg = "Input must be 1 or more";
                return false;
            }
            else
            {

                if (stock >= 1 && price > 1000 && price % 1000 == 0)
                {
                    errorMsg = "Success!";
                    return true;
                }
                else
                {
                    errorMsg = "Data Invalid!";
                    return false;
                }
            }
        }
    }
}