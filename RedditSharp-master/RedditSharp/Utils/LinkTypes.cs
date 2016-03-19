using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RedditSharp.Utils
{
    public static class LinkTypes
    {
        private static readonly List<Regex> KarmaDecayRegs = new List<Regex>
        {
            new Regex(@"imgur\.com"),
            new Regex(@"gyfcat\.com"),
            new Regex(@"youtube\.com"),
            new Regex(@"(.j(e)?pg)$"),
            new Regex(@"(\.jiff)$"),
            new Regex(@"(.png)$"),
            new Regex(@"(.gif(v)?)$"),
            new Regex(@"(\.tif(f)?)$"),
            new Regex(@"(\.bmp)$")
        };
        private static readonly List<Regex> VideoRegs = new List<Regex>
        {
            new Regex(@"(.mp4)$"),
            new Regex(@"(.m4v)$"),
            new Regex(@"(.webm)$"),
            new Regex(@"(.ogv)$"),
            new Regex(@"(.wmv)$"),
            new Regex(@"(.flv)$")
        };
        private static readonly Regex UrlReg = new Regex(@"^https?:\/\/.*");

        public static bool IsKarmaDecayLink(string s)
        {
            return KarmaDecayRegs.Any(x => x.IsMatch(s));
        }

        public static bool IsKarmaDecayLink(Uri uri)
        {
            return IsKarmaDecayLink(uri.ToString());
        }

        public static bool IsVideoLink(string s)
        {
            return VideoRegs.Any(x => x.IsMatch(s));
        }
        public static bool IsVideoLink(Uri uri)
        {
            return IsVideoLink(uri.ToString());
        }

        public static bool IsLink(string s)
        {
            return !KarmaDecayRegs.Any(x => x.IsMatch(s)) && UrlReg.IsMatch(s);
                //VideoRegs.Any(x => x.IsMatch(s));// || 
        }

        public static bool IsLink(Uri uri)
        {
            return IsLink(uri.ToString());
        }

        public static string EncodeUrl(string url)
        {
            return Uri.EscapeDataString(url);
        }

        public static string EncodeUrl(Uri uri)
        {
            return Uri.EscapeDataString(uri.ToString());
        }
    }
}