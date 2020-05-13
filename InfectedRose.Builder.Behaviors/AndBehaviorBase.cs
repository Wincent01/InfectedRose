using InfectedRose.Builder.Behaviors.External;
using InfectedRose.Database;

namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.And)]
    public class AndBehaviorBase : BehaviorBase
    {
        protected override void Load(AccessDatabase database)
        {
            foreach (var key in GetParameterKeys(database))
            {
                if (key.StartsWith("behavior"))
                {
                    Branch(database, key);
                }
            }
        }

        protected override void ApplyChanges(AccessDatabase database)
        {
            for (var index = 0; index < Branches.Count; index++)
            {
                var branch = Branches[index];

                SetParameter(database, $"behavior {index + 1}", branch.Id);
            }
        }

        public override void Export(BehaviorXml details)
        {
            for (var index = 0; index < Branches.Count; index++)
            {
                var branch = Branches[index];

                details.SetParameter($"behavior {index + 1}", branch);
            }
        }
    }
}