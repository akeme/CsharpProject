using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDApi.Models
{
    public class Log
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public long IdEquipament { get; set; }
        public string Name { get; set; }

        public byte Status { get; set; }
        public int TypeReq { get; set; }
        public DateTime DataReq { get; set; }

    }
}
