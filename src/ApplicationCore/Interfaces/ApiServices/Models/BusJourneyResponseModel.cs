using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models
{
    public class BusJourneyResponseModel : BaseModel<IEnumerable<BusJourneyResponseModel.Item>>
    {
        public class Item
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("partner-id")]
            public int PartnerId { get; set; }

            [JsonPropertyName("partner-name")]
            public string PartnerName { get; set; }

            [JsonPropertyName("route-id")]
            public long RouteId { get; set; }

            [JsonPropertyName("bus-type")]
            public string BusType { get; set; }

            [JsonPropertyName("bus-type-name")]
            public string BusTypeName { get; set; }

            [JsonPropertyName("total-seats")]
            public int TotalSeats { get; set; }

            [JsonPropertyName("available-seats")]
            public int AvailableSeats { get; set; }

            [JsonPropertyName("journey")]
            public JourneyItem Journey { get; set; }

            [JsonPropertyName("features")]
            public Feature[] Features { get; set; }

            [JsonPropertyName("origin-location")]
            public string OriginLocation { get; set; }

            [JsonPropertyName("destination-location")]
            public string DestinationLocation { get; set; }

            [JsonPropertyName("is-active")]
            public bool IsActive { get; set; }

            [JsonPropertyName("origin-location-id")]
            public int OriginLocationId { get; set; }

            [JsonPropertyName("destination-location-id")]
            public int DestinationLocationId { get; set; }

            [JsonPropertyName("is-promoted")]
            public bool IsPromoted { get; set; }

            [JsonPropertyName("cancellation-offset")]
            public long CancellationOffset { get; set; }

            [JsonPropertyName("has-bus-shuttle")]
            public bool HasBusShuttle { get; set; }

            [JsonPropertyName("disable-sales-without-gov-id")]
            public bool DisableSalesWithoutGovId { get; set; }

            [JsonPropertyName("display-offset")]
            public string DisplayOffset { get; set; }

            [JsonPropertyName("partner-rating")]
            public double? PartnerRating { get; set; }

            [JsonPropertyName("has-dynamic-pricing")]
            public bool HasDynamicPricing { get; set; }

            [JsonPropertyName("disable-sales-without-hes-code")]
            public bool DisableSalesWithoutHesCode { get; set; }

            [JsonPropertyName("disable-single-seat-selection")]
            public bool DisableSingleSeatSelection { get; set; }

            [JsonPropertyName("change-offset")]
            public int ChangeOffset { get; set; }

            [JsonPropertyName("rank")]
            public long? Rank { get; set; }

            [JsonPropertyName("display-coupon-code-input")]
            public bool DisplayCouponCodeInput { get; set; }

            [JsonPropertyName("disable-sales-without-date-of-birth")]
            public bool DisableSalesWithoutDateOfBirth { get; set; }


            public partial class Feature
            {
                [JsonPropertyName("id")]
                public long Id { get; set; }

                [JsonPropertyName("priority")]
                public int? Priority { get; set; }

                [JsonPropertyName("name")]
                public string Name { get; set; }

                [JsonPropertyName("description")]
                public string Description { get; set; }

                [JsonPropertyName("is-promoted")]
                public bool IsPromoted { get; set; }

                [JsonPropertyName("back-color")]
                public string BackColor { get; set; }

                [JsonPropertyName("fore-color")]
                public string ForeColor { get; set; }
            }

            public partial class JourneyItem
            {
                [JsonPropertyName("kind")]
                public string Kind { get; set; }

                [JsonPropertyName("code")]
                public string Code { get; set; }

                [JsonPropertyName("stops")]
                public Stop[] Stops { get; set; }

                [JsonPropertyName("origin")]
                public string Origin { get; set; }

                [JsonPropertyName("destination")]
                public string Destination { get; set; }

                [JsonPropertyName("departure")]
                public DateTime Departure { get; set; }

                [JsonPropertyName("arrival")]
                public DateTime Arrival { get; set; }

                [JsonPropertyName("currency")]
                public string Currency { get; set; }

                [JsonPropertyName("duration")]
                public string Duration { get; set; }

                [JsonPropertyName("original-price")]
                public double OriginalPrice { get; set; }

                [JsonPropertyName("internet-price")]
                public double InternetPrice { get; set; }

                [JsonPropertyName("provider-internet-price")]
                public double? ProviderInternetPrice { get; set; }

                [JsonPropertyName("booking")]
                public string Booking { get; set; }

                [JsonPropertyName("bus-name")]
                public string BusName { get; set; }

                [JsonPropertyName("policy")]
                public Policy Policy { get; set; }

                [JsonPropertyName("features")]
                public string[] Features { get; set; }

                [JsonPropertyName("description")]
                public string Description { get; set; }

                [JsonPropertyName("available")]
                public string Available { get; set; }
            }

            public partial class Policy
            {
                [JsonPropertyName("max-seats")]
                public int? MaxSeats { get; set; }

                [JsonPropertyName("max-single")]
                public int? MaxSingle { get; set; }

                [JsonPropertyName("max-single-males")]
                public long? MaxSingleMales { get; set; }

                [JsonPropertyName("max-single-females")]
                public long? MaxSingleFemales { get; set; }

                [JsonPropertyName("mixed-genders")]
                public bool MixedGenders { get; set; }

                [JsonPropertyName("gov-id")]
                public bool GovId { get; set; }

                [JsonPropertyName("lht")]
                public bool Lht { get; set; }
            }

            public partial class Stop
            {
                [JsonPropertyName("name")]
                public string Name { get; set; }

                [JsonPropertyName("station")]
                public long? Station { get; set; }

                [JsonPropertyName("time")]
                public DateTime? Time { get; set; }

                [JsonPropertyName("is-origin")]
                public bool IsOrigin { get; set; }

                [JsonPropertyName("is-destination")]
                public bool IsDestination { get; set; }
            }
        }
    }
}