﻿using System.Text;
using System.Xml.Serialization;

namespace Benja.Service
{
    public class XmlService : IXmlService
    {
        public byte[] Write<T>(IList<T> registers)
        {
            var serializer = new XmlSerializer(typeof(List<T>));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, registers);

                return memoryStream.ToArray();
            }
        }
    }
}
