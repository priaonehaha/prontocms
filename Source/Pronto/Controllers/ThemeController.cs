﻿using System;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Pronto.Controllers
{
    public class ThemeController : Controller
    {
        public ThemeController(IWebsiteConfiguration websiteConfiguration)
        {
            this.websiteConfiguration = websiteConfiguration;
        }

        IWebsiteConfiguration websiteConfiguration;

        public ActionResult FileAction(string path)
        {
            if (string.IsNullOrEmpty(path) || path.Contains(".."))
            {
                Response.StatusCode = 404;
                return new EmptyResult();
            }

            var filename = Path.Combine(Server.MapPath("~/themes/" + websiteConfiguration.ThemeName), path);
            if (System.IO.File.Exists(filename))
            {
                var realPath = Url.Content("~/themes/" + websiteConfiguration.ThemeName + "/" + path);
                Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
                var url = Request.Url.GetLeftPart(UriPartial.Authority) + realPath;
                Response.AddHeader("Location", url);
                return new EmptyResult();
                //return FileIfModified(filename);
            }
            else
            {
                Response.StatusCode = 404;
                return new EmptyResult();
            }
        }

        ActionResult FileIfModified(string filename)
        {
            var modified = System.IO.File.GetLastWriteTimeUtc(filename);
            if (HasFileChanged(modified))
            {
                Response.AppendHeader("Last-Modified", modified.ToString("r"));
                var contentType = GetContentType(filename);
                return File(filename, contentType);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.NotModified;
                return new EmptyResult();
            }
        }

        bool HasFileChanged(DateTime modified)
        {
            DateTime ifModifiedSinceHeader;
            if (!DateTime.TryParse(Request.Headers["If-Modified-Since"], out ifModifiedSinceHeader))
            {
                return true;
            }
            return modified > ifModifiedSinceHeader.ToUniversalTime();
        }

        string GetContentType(string filename)
        {
            switch (Path.GetExtension(filename).ToLowerInvariant())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".css":
                    return "text/css";
                case ".js":
                    return "text/javascript";
                default: throw new Exception("Cannot determine content type for file: " + filename);
            }
        }

        // For future use maybe, when we want a theme switching admin screen...

        //[AuthorizeAdmin]
        //public void Change(string theme)
        //{
        //    var config = WebConfigurationManager.OpenWebConfiguration(null);
        //    config.AppSettings.Settings["theme"].Value = theme;
        //    config.Save();
        //}

        //[AuthorizeAdmin]
        //public ActionResult List()
        //{
        //    return Json(Directory.GetDirectories(Server.MapPath("~/themes")).Select(d => Path.GetDirectoryName(d)));
        //}
    }
}
