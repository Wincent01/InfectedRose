namespace InfectedRose.Interface.Templates
{
    [ModType("sql")]
    public class SqlMod : ModType
    {
        public override void Apply(Mod mod)
        {
            switch (mod.Action)
            {
                case "run-server":
                    ModContext.ServerSql.Add(ModContext.ParseValue(mod.GetValue<string>("sql")));
                    break;
            }
        }
    }
}