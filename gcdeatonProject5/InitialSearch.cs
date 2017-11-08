using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace gcdeatonProject5
{
    public class InitialSearch
    {
        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        [DataMember(Name = "imdbID")]
        public string imdbID { get; set; }

        [DataMember(Name = "Type")]
        public string Type { get; set; }

        [DataMember(Name = "Poster")]
        public string Poster { get; set; }
    }


    public class SearchList
    {
        [DataMember(Name = "Search")]
        public IList<InitialSearch> Search { get; set; }

        [DataMember(Name = "totalResults")]
        public string totalResults { get; set; }

        [DataMember(Name = "Response")]
        public string Response { get; set; }
    }
}