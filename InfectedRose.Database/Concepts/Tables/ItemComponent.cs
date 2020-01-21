namespace InfectedRose.Database.Concepts.Tables
{
    public class ItemComponentTable

    {
        public ItemComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string equipLocation
        {
            get => (string) Column["equipLocation"].Value;

            set => Column["equipLocation"].Value = value;
        }

        public int baseValue
        {
            get => (int) Column["baseValue"].Value;

            set => Column["baseValue"].Value = value;
        }

        public bool isKitPiece
        {
            get => (bool) Column["isKitPiece"].Value;

            set => Column["isKitPiece"].Value = value;
        }

        public int rarity
        {
            get => (int) Column["rarity"].Value;

            set => Column["rarity"].Value = value;
        }

        public int itemType
        {
            get => (int) Column["itemType"].Value;

            set => Column["itemType"].Value = value;
        }

        public long itemInfo
        {
            get => (long) Column["itemInfo"].Value;

            set => Column["itemInfo"].Value = value;
        }

        public bool inLootTable
        {
            get => (bool) Column["inLootTable"].Value;

            set => Column["inLootTable"].Value = value;
        }

        public bool inVendor
        {
            get => (bool) Column["inVendor"].Value;

            set => Column["inVendor"].Value = value;
        }

        public bool isUnique
        {
            get => (bool) Column["isUnique"].Value;

            set => Column["isUnique"].Value = value;
        }

        public bool isBOP
        {
            get => (bool) Column["isBOP"].Value;

            set => Column["isBOP"].Value = value;
        }

        public bool isBOE
        {
            get => (bool) Column["isBOE"].Value;

            set => Column["isBOE"].Value = value;
        }

        public int reqFlagID
        {
            get => (int) Column["reqFlagID"].Value;

            set => Column["reqFlagID"].Value = value;
        }

        public int reqSpecialtyID
        {
            get => (int) Column["reqSpecialtyID"].Value;

            set => Column["reqSpecialtyID"].Value = value;
        }

        public int reqSpecRank
        {
            get => (int) Column["reqSpecRank"].Value;

            set => Column["reqSpecRank"].Value = value;
        }

        public int reqAchievementID
        {
            get => (int) Column["reqAchievementID"].Value;

            set => Column["reqAchievementID"].Value = value;
        }

        public int stackSize
        {
            get => (int) Column["stackSize"].Value;

            set => Column["stackSize"].Value = value;
        }

        public int color1
        {
            get => (int) Column["color1"].Value;

            set => Column["color1"].Value = value;
        }

        public int decal
        {
            get => (int) Column["decal"].Value;

            set => Column["decal"].Value = value;
        }

        public int offsetGroupID
        {
            get => (int) Column["offsetGroupID"].Value;

            set => Column["offsetGroupID"].Value = value;
        }

        public int buildTypes
        {
            get => (int) Column["buildTypes"].Value;

            set => Column["buildTypes"].Value = value;
        }

        public string reqPrecondition
        {
            get => (string) Column["reqPrecondition"].Value;

            set => Column["reqPrecondition"].Value = value;
        }

        public int animationFlag
        {
            get => (int) Column["animationFlag"].Value;

            set => Column["animationFlag"].Value = value;
        }

        public int equipEffects
        {
            get => (int) Column["equipEffects"].Value;

            set => Column["equipEffects"].Value = value;
        }

        public bool readyForQA
        {
            get => (bool) Column["readyForQA"].Value;

            set => Column["readyForQA"].Value = value;
        }

        public int itemRating
        {
            get => (int) Column["itemRating"].Value;

            set => Column["itemRating"].Value = value;
        }

        public bool isTwoHanded
        {
            get => (bool) Column["isTwoHanded"].Value;

            set => Column["isTwoHanded"].Value = value;
        }

        public int minNumRequired
        {
            get => (int) Column["minNumRequired"].Value;

            set => Column["minNumRequired"].Value = value;
        }

        public int delResIndex
        {
            get => (int) Column["delResIndex"].Value;

            set => Column["delResIndex"].Value = value;
        }

        public int currencyLOT
        {
            get => (int) Column["currencyLOT"].Value;

            set => Column["currencyLOT"].Value = value;
        }

        public int altCurrencyCost
        {
            get => (int) Column["altCurrencyCost"].Value;

            set => Column["altCurrencyCost"].Value = value;
        }

        public string subItems
        {
            get => (string) Column["subItems"].Value;

            set => Column["subItems"].Value = value;
        }

        public string audioEventUse
        {
            get => (string) Column["audioEventUse"].Value;

            set => Column["audioEventUse"].Value = value;
        }

        public bool noEquipAnimation
        {
            get => (bool) Column["noEquipAnimation"].Value;

            set => Column["noEquipAnimation"].Value = value;
        }

        public int commendationLOT
        {
            get => (int) Column["commendationLOT"].Value;

            set => Column["commendationLOT"].Value = value;
        }

        public int commendationCost
        {
            get => (int) Column["commendationCost"].Value;

            set => Column["commendationCost"].Value = value;
        }

        public string audioEquipMetaEventSet
        {
            get => (string) Column["audioEquipMetaEventSet"].Value;

            set => Column["audioEquipMetaEventSet"].Value = value;
        }

        public string currencyCosts
        {
            get => (string) Column["currencyCosts"].Value;

            set => Column["currencyCosts"].Value = value;
        }

        public string ingredientInfo
        {
            get => (string) Column["ingredientInfo"].Value;

            set => Column["ingredientInfo"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public int forgeType
        {
            get => (int) Column["forgeType"].Value;

            set => Column["forgeType"].Value = value;
        }

        public float SellMultiplier
        {
            get => (float) Column["SellMultiplier"].Value;

            set => Column["SellMultiplier"].Value = value;
        }
    }
}