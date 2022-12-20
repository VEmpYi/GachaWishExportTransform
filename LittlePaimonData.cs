using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GachaWishExportTransform
{
    internal class LittlePaimonData
    {
        
        public LittlePaimonData(string user_id, string uid, string update_time, LittlePaimonItem_list item_list)
        {
            this.user_id = user_id;
            this.uid = uid;
            this.update_time = update_time;
            this.item_list = item_list;
        }

        public string user_id { get; set; }
        public string uid { get; set; }
        public string update_time { get; set; }
        public LittlePaimonItem_list item_list { get; set; }
    }

    internal class LittlePaimonItem_list
    {
        public LittlePaimonItem_list(List<LPDetailInformation> characterEventWish, List<LPDetailInformation> weaponEventWish, List<LPDetailInformation> StandardWish, List<LPDetailInformation> noviceWish)
        {
            this.characterEventWish = characterEventWish;
            this.weaponEventWish = weaponEventWish;
            this.StandardWish = StandardWish;
            this.noviceWish = noviceWish;
        }

        public List<LPDetailInformation> characterEventWish { get; set; }
        public List<LPDetailInformation> weaponEventWish { get; set; }
        public List<LPDetailInformation> StandardWish { get; set; }
        public List<LPDetailInformation> noviceWish { get; set; }
    }


    internal class LPDetailInformation
    {
        public LPDetailInformation(string id, string name, string gacha_type, string item_type, string rank_type, string time)
        {
            this.id = id;
            this.name = name;
            this.gacha_type = gacha_type;
            this.item_type = item_type;
            this.rank_type = rank_type;
            this.time = time;
        }

        private string id { get; set; }
        private string name { get; set; }
        private string gacha_type { get; set; }
        private string item_type { get; set; }
        private string rank_type { get; set; }
        private string time { get; set; }

    }

}
