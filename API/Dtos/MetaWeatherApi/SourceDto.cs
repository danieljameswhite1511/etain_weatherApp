namespace API.Dtos.MetaWeatherApi
{
    public class SourceDto
    {
        public string Title { get; set; }
        public string Slug { get; set; } 
        public string  Url { get; set; }
        public string Crawl_Rate { get; set; }
        private string _fileName = "/favicon.ico";
        private string _favIcon;
        public string faviconUrl { get{
           
           var firstForwardSlashes = Url.IndexOf("/") + 2;
           var urlSubstring = Url.Substring(firstForwardSlashes, Url.Length-firstForwardSlashes);
           var secondForwardSlash = urlSubstring.IndexOf("/") + firstForwardSlashes;


           _favIcon = Url.Substring(0, secondForwardSlash) + _fileName;

            return _favIcon;
        } }
        
    }
}