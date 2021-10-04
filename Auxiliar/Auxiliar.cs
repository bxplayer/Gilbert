﻿using Gilbert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Gilbert.Auxiliar
{
    public static class Auxiliar
    {
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();            
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");            
            str = Regex.Replace(str, @"\s+", " ").Trim();            
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-");
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }

    public static class ViewsPath
    {
        public static string CompanyPath(string view)
        {
            return "~/Views/Company/Employ/"+ view + ".cshtml";
        }

        public static string JobPath(string view)
        {
            return "~/Views/Job/" + view + ".cshtml";
        }

    }

    public static class MDsa
    {
        private static GilbertEntities db = new GilbertEntities();

        public static IEnumerable<MD_Position> getPosition()
        {
            return db.MD_Position.Where(x => x.IDStatus == 1);
        }

    }
    
}