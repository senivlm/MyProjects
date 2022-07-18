using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

static class DataSerializator
{
	public static void BinarySerialize(object data, string filePath)
    {
        if (!File.Exists(filePath))
        {
			return;
        }
		BinaryFormatter bf = new();
		using(Stream fs = File.OpenWrite(filePath))
        {
			bf.Serialize(fs, data);
        }
    }

	public static T? BinaryDeserialize<T>(string filePath)
    {
		if (!File.Exists(filePath))
		{
			return default;
		}
		object data;
		BinaryFormatter bf = new();
		using (FileStream fs = File.OpenRead(filePath))
		{
			data = bf.Deserialize(fs);
		}
		return (T)data;
	}

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
