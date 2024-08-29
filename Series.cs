using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patikaflix
{

    public enum SeriesType
    {
        Comedy = 1,
        Drama = 2,
        Action = 3,
        ScienceFiction = 4,
        Documentary = 5
    }

    public class Series
    {
        

        public string SeriesName { get; set; }
        public int StartDate { get; set; }
        public SeriesType SeriesType { get; set; }
        public int PublicationDate { get; set; }
        public string Director { get; set; }
        public string PublishedFirstPlatform { get; set; }

        public Series(string seriesName, int startDate, SeriesType seriesType, int publicationDate, string director, string publishedFirstPlatform)
        {
            SeriesName = seriesName;
            StartDate = startDate;
            SeriesType = seriesType;
            PublicationDate = publicationDate;
            Director = director;
            PublishedFirstPlatform = publishedFirstPlatform;
        }

        public Series(string seriesName, SeriesType seriesType, int v1, int v2, string director, string empty)
        {
            SeriesName = seriesName;
            SeriesType = seriesType;
            Director = director;
        }
    }
}

