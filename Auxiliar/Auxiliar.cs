using Gilbert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gilbert.Auxiliar
{
    public static class Auxiliar
    {

    }

    public static class ViewsPath
    {
        public static string CompanyPath(string view)
        {
            return "~/Views/Company/Employ/"+ view + ".cshtml";
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