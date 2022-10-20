using MediatR;
using System;
using System.Collections.Generic; 

namespace OBilet.CaseStudy.ApplicationCore.Queries
{
    public class GetJourneyQuery : IRequest<JourneyResult>
    {
        public int OriginId { get; set; }

        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }

        public GetJourneyQuery(int originId, int destinationId, DateTime departureDate)
        {
            OriginId = originId;
            DestinationId = destinationId;
            DepartureDate = departureDate;
        }
    }

    public class JourneyResult
    {
        public JourneyResult(IList<Item> items)
        {
            Items = items;
        }

        public IList<Item> Items { get; set; }

        public class Item
        {
            public long Id { get; set; }

            /// <summary>
            /// İlk Durak
            /// </summary>
            public string Origin { get; set; }

            /// <summary>
            /// Son Durak
            /// </summary>
            public string Destination { get; set; }

            /// <summary>
            /// Kalkış zamanı
            /// </summary>
            public DateTime Departure { get; set; }

            /// <summary>
            /// Varış zamanı
            /// </summary>
            public DateTime Arrival { get; set; }

            /// <summary>
            /// Başlangıç Lokasyonu
            /// </summary>
            public string OriginLocation { get; set; }

            /// <summary>
            /// Bitiş Lokasyonu
            /// </summary>
            public string DestinationLocation { get; set; }

            /// <summary>
            /// Başlangış Lokasyon Id
            /// </summary>
            public int OriginLocationId { get; set; }

            /// <summary>
            /// Bitiş Lokasyonu Id
            /// </summary>
            public int DestinationLocationId { get; set; }

            /// <summary>
            /// İnternet liste fiyatı
            /// </summary>
            public double InternetPrice { get; set; }

            /// <summary>
            /// Para Birimi
            /// </summary>
            public string Currency { get; set; }
        }
    }
}