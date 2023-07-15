using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace InfectedRose.Interface;

public static class JsonExtensions
{
    public static T? ToObject<T>(this JsonElement element, JsonSerializerOptions? options = null)
    {
        var bufferWriter = new ArrayBufferWriter<byte>();
        using (var writer = new Utf8JsonWriter(bufferWriter))
            element.WriteTo(writer);
        return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
    }

    public static T? ToObject<T>(this JsonDocument document, JsonSerializerOptions? options = null)
    {
        if (document == null)
            throw new ArgumentNullException(nameof(document));
        return document.RootElement.ToObject<T>(options);
    }

    public static T? ToObject<T>(this JsonValue element, JsonSerializerOptions? options = null)
    {
        var bufferWriter = new ArrayBufferWriter<byte>();
        using (var writer = new Utf8JsonWriter(bufferWriter))
            element.WriteTo(writer);
        return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
    }

    public static Dictionary<string, object> ToDictionary(this JsonValue element)
    {
        var dictionary = new Dictionary<string, object>();
        
        var str = element.ToString();
        
        var json = JsonDocument.Parse(str);
        
        var root = json.RootElement;
        
        foreach (var property in root.EnumerateObject())
        {
            var value = property.Value;
            
            if (value.ValueKind == JsonValueKind.Array)
            {
                var array = new List<object>();
                
                foreach (var item in value.EnumerateArray())
                {
                    if (item.ValueKind == JsonValueKind.Object)
                    {
                        array.Add(item.ToDictionary());
                    }
                    else
                    {
                        array.Add(item.ToString());
                    }
                }
                
                dictionary.Add(property.Name, array);
            }
            else if (value.ValueKind == JsonValueKind.Object)
            {
                dictionary.Add(property.Name, value.ToDictionary());
            }
            else if (value.ValueKind == JsonValueKind.String)
            {
                dictionary.Add(property.Name, value.ToString());
            }
            else if (value.ValueKind == JsonValueKind.Number)
            {
                dictionary.Add(property.Name, value.GetDouble());
            }
            else if (value.ValueKind == JsonValueKind.True)
            {
                dictionary.Add(property.Name, true);
            }
            else if (value.ValueKind == JsonValueKind.False)
            {
                dictionary.Add(property.Name, false);
            }
            else
            {
                dictionary.Add(property.Name, value.ToString());
            }
        }

        return dictionary;
    }
    
    public static Dictionary<string, object> ToDictionary(this JsonElement element)
    {
        var dictionary = new Dictionary<string, object>();
        
        foreach (var property in element.EnumerateObject())
        {
            var value = property.Value;
            
            if (value.ValueKind == JsonValueKind.Array)
            {
                var array = new List<object>();
                
                foreach (var item in value.EnumerateArray())
                {
                    if (item.ValueKind == JsonValueKind.Object)
                    {
                        array.Add(item.ToDictionary());
                    }
                    else
                    {
                        array.Add(item.ToString());
                    }
                }
                
                dictionary.Add(property.Name, array);
            }
            else if (value.ValueKind == JsonValueKind.Object)
            {
                dictionary.Add(property.Name, value.ToDictionary());
            }
            else if (value.ValueKind == JsonValueKind.String)
            {
                dictionary.Add(property.Name, value.ToString());
            }
            else if (value.ValueKind == JsonValueKind.Number)
            {
                dictionary.Add(property.Name, value.GetDouble());
            }
            else if (value.ValueKind == JsonValueKind.True)
            {
                dictionary.Add(property.Name, true);
            }
            else if (value.ValueKind == JsonValueKind.False)
            {
                dictionary.Add(property.Name, false);
            }
            else
            {
                dictionary.Add(property.Name, value.ToString());
            }
        }

        return dictionary;
    }

}