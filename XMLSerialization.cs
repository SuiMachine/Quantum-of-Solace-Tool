using System;
using System.IO;
using System.Xml.Serialization;

namespace QuantumOfSolace
{
	public class XMLSerialization
	{
		public static T ReadFromXMLFile<T>(string filePath) where T : new()
		{
			StreamReader reader = null;
			try
			{
				if (!File.Exists(filePath))
					return new T();

				XmlSerializer serializer = new XmlSerializer(typeof(T));
				reader = new StreamReader(filePath);
				return (T)serializer.Deserialize(reader);
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}
		}

		public static void SaveObjectToXML<T>(T objectToStore, string filePath) where T : new()
		{
			if (!Directory.Exists(Directory.GetParent(filePath).FullName))
				Directory.CreateDirectory(Directory.GetParent(filePath).FullName);

			StreamWriter writter = null;

			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				writter = new StreamWriter(filePath);
				serializer.Serialize(writter, objectToStore);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (writter != null)
					writter.Close();
			}
		}
	}
}
