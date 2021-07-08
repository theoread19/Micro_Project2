using Confluent.Kafka;
using Google.Protobuf;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UserProtoBufService;

namespace Infrastructure.Kafka.Consumer
{
    internal class UserDeserializer : IDeserializer<UserProtoReq>
    {
        private MessageParser<UserProtoReq> _parser;

        public UserDeserializer()
        {
            this._parser = new MessageParser<UserProtoReq>(() => new UserProtoReq());
        }
        public UserProtoReq Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {

            try
            {
                if (this._parser.ParseFrom(data.ToArray()) == null)
                {
                    return null;
                }
                return this._parser.ParseFrom(data.ToArray());
            }
            catch(Exception e)
            {
                throw new Exception("" + e); 
            }
           
        }
    }
}