using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

static class XmlSerializator
{
	public static void XmlSerialize<T>(object data, string filePath)
    {
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
		}
		DataContractSerializer xmlSerializer = new(typeof(T));
		using (XmlWriter writer = XmlWriter.Create(filePath))
		{
			xmlSerializer.WriteObject(writer, data);
		}
    }

	public static T? XmlDeserialize<T>(string filePath)
    {
		if (!File.Exists(filePath))
		{
			return default;
		}
		object? data;
		DataContractSerializer serializer = new(typeof(T));
		using(XmlReader reader = XmlReader.Create(filePath))
        {
			data = serializer.ReadObject(reader);
        }
		return (T)data;
	}
}
