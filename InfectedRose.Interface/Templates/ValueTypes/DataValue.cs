using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes;

public class DataValue
{
    [JsonPropertyName("value")]
    public JsonValue Value { get; set; }
        
    [JsonPropertyName("type")]
    public string? TypeInternal { get; set; }
        
    [JsonIgnore]
    public FieldType Type
    {
        get
        {
            if (TypeInternal == null)
            {
                var str = Value.ToString();
                    
                if (int.TryParse(str, out var i))
                {
                    return FieldType.Integer;
                }
                    
                if (float.TryParse(str, out var f))
                {
                    return FieldType.Float;
                }
                    
                // Count instances of \u001f
                var instances = str.Split("\u001f").Length;
                    
                if (instances == 3)
                {
                    return FieldType.Position;
                }
                    
                if (instances == 4)
                {
                    return FieldType.Rotation;
                }

                return FieldType.String;
            }
                
            if (Enum.TryParse<FieldType>(TypeInternal, out var fieldType)) return fieldType;
                
            fieldType = ParseFieldType(TypeInternal);
                
            TypeInternal = fieldType.ToString();

            return fieldType;
        }
        set => TypeInternal = value.ToString();
    }

    public static string ParseFieldType(FieldType type)
    {
        return type switch
        {
            FieldType.Id => "id",
            FieldType.Object => "id",
            FieldType.WorldObject => "id",
            FieldType.Integer => "int",
            FieldType.UnsignedInteger => "uint",
            FieldType.String => "string",
            FieldType.Buffer => "blob",
            FieldType.Skill => "id",
            FieldType.Flag => "id",
            FieldType.Mission => "id",
            FieldType.Float => "float",
            FieldType.Double => "double",
            FieldType.Boolean => "bool",
            FieldType.Model => "id",
            FieldType.Physics => "id",
            FieldType.Icon => "id",
            FieldType.None => "string",
            FieldType.Position => "string",
            FieldType.Rotation => "string",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
        
    public static FieldType ParseFieldType(string type)
    {
        return type switch
        {
            "id" => FieldType.Object,
            "int" => FieldType.Integer,
            "uint" => FieldType.UnsignedInteger,
            "string" => FieldType.String,
            "blob" => FieldType.Buffer,
            "float" => FieldType.Float,
            "double" => FieldType.Double,
            "bool" => FieldType.Boolean,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, $"Unknown type: {type}")
        };
    }

    public static string ParseType(int type)
    {
        return type switch
        {
            1 => "int",
            3 => "float",
            4 => "double",
            5 => "uint",
            7 => "bool",
            8 => "long",
            13 => "blob",
            0 => "string",
            100 => "id",
            _ => "string"
        };
    }
        
    public static int ParseType(string type)
    {
        return type switch
        {
            "int" => 1,
            "float" => 3,
            "double" => 4,
            "uint" => 5,
            "bool" => 7,
            "long" => 8,
            "blob" => 13,
            "string" => 0,
            "id" => 0,
            _ => 0
        };
    }

    [JsonIgnore]
    public int TypeId
    {
        set => ParseFieldType(ParseType(value));
        get => ParseType(ParseFieldType(Type));
    }

    [JsonIgnore]
    public object? ObjectValue
    {
        get
        {
            switch (Type)
            {
                case FieldType.None:
                    return null;
                case FieldType.Id:
                case FieldType.Object:
                case FieldType.WorldObject:
                case FieldType.String:
                case FieldType.Buffer:
                case FieldType.Rotation:
                case FieldType.Position:
                case FieldType.Skill:
                case FieldType.Flag:
                case FieldType.Mission:
                case FieldType.Model:
                case FieldType.Physics:
                case FieldType.Icon:
                    return Value.ToString();
                case FieldType.Integer:
                    return Value.GetValue<int>();
                case FieldType.UnsignedInteger:
                    return Value.GetValue<uint>();
                case FieldType.Float:
                    return Value.GetValue<float>();
                case FieldType.Double:
                    return Value.GetValue<double>();
                case FieldType.Boolean:
                    return Value.GetValue<bool>();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
        
    public override string ToString()
    {
        return $"{TypeId}:{Value}";
    }
}