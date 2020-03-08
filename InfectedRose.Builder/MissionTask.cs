using System.Linq;
using System.Xml.Serialization;
using InfectedRose.Database;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Database.Generic;

namespace InfectedRose.Builder
{
    [XmlRoot]
    public class MissionTask
    {
        [XmlElement] public int TaskType { get; set; }
        
        [XmlElement] public int Target { get; set; }
        
        [XmlElement] public string TargetGroup { get; set; }
        
        [XmlElement] public int TargetValue { get; set; }
        
        [XmlElement] public string Parameters { get; set; }
        
        [XmlElement] public int IconId { get; set; }
        
        [XmlElement] public string LargeIcon { get; set; }
        
        [XmlElement] public int LargeIconId { get; set; }

        internal void Build(AccessDatabase database, int missionId)
        {
            var table = database["MissionTasks"];

            var row = table.Create(missionId);

            var unique = table.Select(s => s.Value<int>("uid")).Max() + 1;

            var task = new MissionTasksTable(row);

            task.localize = true;
            task.IconID = IconId;
            task.largeTaskIcon = LargeIcon;
            task.taskType = TaskType;
            task.target = Target;
            task.targetGroup = TargetGroup;
            task.targetValue = TargetValue;
            task.taskParam1 = Parameters;
            task.locStatus = 2;
            task.uid = unique;
            task.largeTaskIconID = LargeIconId;
        }
    }
}