using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SoundProdHelper.DAL.Read.Configurations
{
    public class BsonAdapter<T>
    {
        [BsonId]
        public Guid Uid { get; set; }

        public T Entity { get; set; }
    }
}