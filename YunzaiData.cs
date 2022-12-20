namespace GachaWishExportTransform
{

    internal class YZDetailInformation
    {
        JObject yzDetailInformation = new JObject();



        public string uid { get; set; }
        public string gacha_type { get; set; }
        public string item_id { get; set; }
        public string count { get; set; }
        public string time { get; set; }
        public string name { get; set; }
        public string lang { get; set; }
        public string item_type { get; set; }
        public string rank_type { get; set; }
        public string id { get; set; }


        public YZDetailInformation(string uid, string gacha_type, string item_id, string count, string time, string name, string lang, string item_type, string rank_type, string id)
        {
            this.uid = uid;
            this.gacha_type = gacha_type;
            this.item_id = item_id;
            this.count = count;
            this.time = time;
            this.name = name;
            this.lang = lang;
            this.item_type = item_type;
            this.rank_type = rank_type;
            this.id = id;
        }
    }
}
