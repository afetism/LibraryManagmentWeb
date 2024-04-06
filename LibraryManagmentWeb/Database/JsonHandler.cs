using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryManagmentWeb.Database
{
	public class JsonHandler<T>
	{

		public string FilePath { get; set; }
		public List <T> Values{ get; set; }

		public JsonHandler(string path)
		{
            

			if ( path is not null )
            {
				FilePath=path;
				if ( File.Exists( FilePath ) )
				{
					string data = File.ReadAllText( FilePath );
					Values  = JsonSerializer.Deserialize<List<T>>(data) ?? new();
				}
				else
				{
					Values = new();
				}
			}
        }

		public void SaveData()
		{
			string jsonString = JsonSerializer.Serialize(Values);
			File.WriteAllText(FilePath, jsonString);
		}


    }
}
