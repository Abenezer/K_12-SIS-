using K_12.Entity;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace K_12.WEB.Utilities
{
    public static class DictionaryExtensions
    {


        public static ICollection<DropDownListItem> ToDropDownList(this IDictionary<string, string> source)
    
        {
            ICollection<DropDownListItem> list = new HashSet<DropDownListItem>();

      
            foreach (KeyValuePair<string, string> item in source)
            {
                DropDownListItem listItem = new DropDownListItem();

                listItem.GetType().GetProperty("Text").SetValue(listItem, item.Key, null);
                listItem.GetType().GetProperty("Value").SetValue(listItem, item.Value, null);
                list.Add(listItem);
            }

            return list;
        }

    }
}