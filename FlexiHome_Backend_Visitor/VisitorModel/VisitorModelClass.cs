using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace FlexiHome_Backend_Visitor.VisitorModel
{
    public class VisitorModelClass
    {

        [BsonElement("PinCode")]
        public string PinCode { get; set; }

        [BsonElement("fullName")]
        public string FullName { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber {  get; set; }

        [BsonElement("purposeOfMeet")]
        public string PurposeOfMeet { get; set; }

        [BsonElement("vehicleType")]
        public string VehicleType { get; set; }
        [BsonElement("vehicleNumber")]
        public string VehicleNumber { get; set; }

        [BsonElement("blockNumber")]
        public string BlockNumber { get; set; }

        [BsonElement("flatNumber")]
        public string FlatNumber { get; set; }

        [BsonElement("meetingWith")]
        public string MeetingWith { get; set; }

        [BsonElement("entryBy")]
        public string EntryBy { get; set; }

        [BsonElement("inTime")]
        public DateTime InTime { get; set; }

        [BsonElement("exitBy")]
        public string ExitBy { get; set; }

        [BsonElement("outTime")]
        public DateTime? OutTime { get; set; }
    }
}
