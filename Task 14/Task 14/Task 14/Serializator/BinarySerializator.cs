using System.Runtime.Serialization.Formatters.Binary;

static class BinarySerializator
{
	public static void BinarySerialize(object data, string filePath)
	{
		if (!File.Exists(filePath))
		{
			return;
		}
		BinaryFormatter bf = new();
		using (Stream fs = File.OpenWrite(filePath))
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
}
