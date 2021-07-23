using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using RakDotNet.IO;

namespace InfectedRose.Core
{
    public class LegoDataDictionary : IDictionary<string, object>, ISerializable
    {
        public const char InfoSeparator = '\u001F';
        private readonly Dictionary<string, (byte, object)> _map;

        public int Count => _map.Count;
        public bool IsReadOnly => false;

        public ICollection<string> Keys => _map.Keys;
        public ICollection<object> Values => _map.Values.Select(v => v.Item2).ToArray();

        public object this[string key]
        {
            get => _map[key].Item2;
            set => Add(key, value);
        }

        public object this[string key, byte type]
        {
            get => _map[key].Item2;
            set => Add(key, value, type);
        }

        public LegoDataDictionary()
        {
            _map = new Dictionary<string, (byte, object)>();
        }

        public void Add(string key, object value, byte type)
            => _map[key] = (type, value);

        public void Add(string key, object value)
        {
            var type =
                value is int ? 1 :
                value is float ? 3 :
                value is double ? 4 :
                value is uint ? 5 :
                value is bool ? 7 :
                value is long ? 8 :
                value is byte[] ? 13 : 0;

            Add(key, value, (byte) type);
        }

        public void Add(KeyValuePair<string, object> item)
            => Add(item.Key, item.Value);

        public void Clear()
            => _map.Clear();

        public bool ContainsKey(string key)
            => _map.ContainsKey(key);

        public bool Contains(KeyValuePair<string, object> item)
            => _map.ContainsKey(item.Key) && _map[item.Key].Item2 == item.Value;

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
            => _map.Remove(key);

        public bool Remove(KeyValuePair<string, object> item)
            => _map.Remove(item.Key);

        public bool TryGetValue(string key, out object value)
        {
            if (_map.TryGetValue(key, out var temp))
            {
                value = temp.Item2;

                return true;
            }

            value = null;

            return false;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _map.Select(k => new KeyValuePair<string, object>(k.Key, k.Value.Item2)).GetEnumerator();
        }

        public IEnumerable <Tuple<string, byte, object>> AsTuples()
        {
            return _map.Select(k => new Tuple<string, byte, object>(k.Key, k.Value.Item1, k.Value.Item2));
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public override string ToString()
            => ToString("\r\n");

        public void Serialize(BitWriter writer) => Serialize(writer, true);

        public void Serialize(BitWriter writer, bool bitBool)
        {
            writer.Write((uint) _map.Count);

            foreach (var (key, (type, value)) in _map)
            {
                writer.Write((byte) (key.Length * 2));
                writer.WriteLwoString(key, key.Length, true);
                writer.Write(type);

                switch (type)
                {
                    case 1:
                    case 2:
                        writer.Write((int) value);
                        break;

                    case 3:
                        writer.Write((float) value);
                        break;

                    case 4:
                        writer.Write((double) value);
                        break;

                    case 5:
                    case 6:
                        writer.Write((uint) value);
                        break;

                    case 7:
                        var boolean = (bool) value;

                        if (bitBool)
                        {
                            writer.WriteBit(boolean);
                        }
                        else
                        {
                            writer.Write((byte) (boolean ? 1 : 0));
                        }

                        break;

                    case 8:
                    case 9:
                        writer.Write((long) value);
                        break;

                    case 13:
                        var bytes = (byte[]) value;

                        writer.Write((uint) bytes.Length);
                        writer.Write(bytes);
                        break;

                    default:

                        var str = value switch
                        {
                            Vector2 vec2 => $"{vec2.X}{InfoSeparator}{vec2.Y}",
                            Vector3 vec3 => $"{vec3.X}{InfoSeparator}{vec3.Z}{InfoSeparator}{vec3.Y}",
                            Vector4 vec4 => $"{vec4.X}{InfoSeparator}{vec4.Z}{InfoSeparator}{vec4.Y}{InfoSeparator}{vec4.W}",
                            LegoDataList list => list.ToString(),
                            _ => value.ToString()
                        };

                        writer.Write((uint) str.Length);
                        writer.WriteLwoString(str, str.Length, true);
                        break;
                }
            }
        }

        public string ToString(string separator)
        {
            var str = new StringBuilder();

            foreach (var (k, (t, v)) in _map)
            {
                var val = v switch
                {
                    bool boolean => boolean ? "1" : "0",
                    Vector2 vec2 => $"{vec2.X}{InfoSeparator}{vec2.Y}",
                    Vector3 vec3 => $"{vec3.X}{InfoSeparator}{vec3.Z}{InfoSeparator}{vec3.Y}",
                    Vector4 vec4 => $"{vec4.X}{InfoSeparator}{vec4.Z}{InfoSeparator}{vec4.Y}{InfoSeparator}{vec4.W}",
                    LegoDataList list => list.ToString(),
                    _ => v.ToString()
                };

                str.Append($"{k}={t}:{val}");

                var i = _map.Keys.ToList().IndexOf(k);

                if (i + 1 < Count)
                    str.Append(separator);
            }

            return str.ToString();
        }

        public static LegoDataDictionary FromDictionary<T>(Dictionary<string, T> dict)
        {
            var ldd = new LegoDataDictionary();

            foreach (var k in dict)
            {
                ldd[k.Key] = k.Value;
            }

            return ldd;
        }

        public void Add(string key, int type, string val)
        {
            object v;

            switch (type)
            {
                case 1:
                case 2:
                    v = int.Parse(val);
                    break;

                case 3:
                    v = float.Parse(val, CultureInfo.InvariantCulture);
                    break;

                case 4:
                    v = double.Parse(val);
                    break;

                case 5:
                case 6:
                    v = uint.Parse(val);
                    break;

                case 7:
                    if (int.TryParse(val, out var i))
                    {
                        v = i == 1;
                    }
                    else if (bool.TryParse(val, out var b))
                    {
                        v = b;
                    }
                    else
                    {
                        throw new FormatException($"Failed to parse {val} as boolean.");
                    }

                    break;

                case 8:
                case 9:
                    v = long.Parse(val);
                    break;

                default:
                    if (val.Contains('+'))
                    {
                        v = LegoDataList.FromString(val);
                    }
                    else if (val.Contains(InfoSeparator))
                    {
                        var floats = val.Split(InfoSeparator).Select(s => float.Parse(s, CultureInfo.InvariantCulture))
                            .ToArray();

                        v = floats.Length switch
                        {
                            1 => floats[0],
                            2 => new Vector2(floats[0], floats[1]),
                            3 => new Vector3(floats[0], floats[1], floats[2]),
                            4 => new Vector4(floats[0], floats[1], floats[2], floats[3]),
                            _ => (object) val
                        };
                    }
                    else
                    {
                        v = val;
                    }

                    break;
            }

            this[key, (byte) type] = v;
        }

        public static LegoDataDictionary FromString(string text, char separator = '\n')
        {
            var dict = new LegoDataDictionary();

            if (string.IsNullOrWhiteSpace(text)) return dict;

            var lines = text.Replace("\r", "").Split(separator);

            foreach (var line in lines)
            {
                var firstEqual = line.IndexOf('=');
                var firstColon = line.IndexOf(':');
                var key = line.Substring(0, firstEqual);
                var type = int.Parse(line.Substring(firstEqual + 1, firstColon - firstEqual - 1));
                var val = line.Substring(firstColon + 1);

                dict.Add(key, type, val);
            }

            return dict;
        }

    }
}
