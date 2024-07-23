using System.Text.Json;

namespace EagleEye.Tools
{
    public class ObjectSerializer
    {
        public static async Task SerializeObject(string path, object obj)
        {
            try
            {
                var json = JsonSerializer.Serialize(obj);
                await File.WriteAllTextAsync(path, json);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Serialize", ex.Message, "OK");
            }
        }

        public static T DeserializeObject<T>(string filePath) where T : class
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<T>(json);
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
