using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes
{
    public class DataValue
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("value")]
        public object Value { get; set; }
        
        public static int ParseTypeString(string type)
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
                            "id" => 100,
                            _ => 0
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


        [JsonIgnore]
        public int TypeId
        {
            get => ParseTypeString(Type);
            set => Type = ParseType(value);
        }

        public override string ToString()
        {
            var type = TypeId;
            var value = Value;
            
            if (value is false) value = 0;
            else if (value is true) value = 1;
            else if (type == 0 || type == 13) value = value.ToString();

            if (type == 100)
            {
                value = ModContext.AssertId((string)value!);
                type = 1;
            }

            if (value != null)
            {
                value = value.ToString();
                
                if (value == "True") value = "1";
                else if (value == "False") value = "0";
            }
            
            return $"{type}:{value}";
        }
    }
}