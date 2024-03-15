using Newtonsoft.Json;

namespace HttpCallExample;
public class Serializer<T>
{
    //using Newtonsoft.Json;
    public JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
    {
        MissingMemberHandling = MissingMemberHandling.Ignore
    };

    /// <summary>
    /// Deserializes the JSON to the specified .NET type.
    /// </summary>
    /// <param name="json">The object to deserialize.</param>
    /// <returns>The deserialized object from the JSON string.</returns>
    public T FromJson(string json)
    {
        return JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
    }

    /// <summary>
    /// Serializes the specified object to a JSON string.
    /// </summary>
    /// <param name="data">The object to serialize.</param>
    /// <returns>A JSON string representation of the object.</returns>
    public string ToJson(object data)
    {
        return JsonConvert.SerializeObject(data, JsonSerializerSettings);
    }
}