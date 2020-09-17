using System.Collections.Generic;

namespace InfectedRose.LXFML.BrickTypes
{
    public class Transform
    {
        public List<float> TransformItems { get; set; } = new List<float>(); // Use transform 9, 10 and 11 for OBJ
        
        public Transform()
        {
            
        }

        public void ParseTransform(string TransformData)
        {
            string[] data = TransformData.Split(",");
            
            foreach (string item in data)
            {
                TransformItems.Add(float.Parse(item));
            }
        }
    }
}