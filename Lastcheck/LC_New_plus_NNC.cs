using DevExpress.Export;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCB_TEGAKI;

namespace VCB_Entry.Lastcheck
{
    public partial class LC_New_plus_NNC : Form
    {
        public LC_New_plus_NNC()
        {
            InitializeComponent();
        }
        DataTable datasave = new DataTable();
        DataTable dt_all_data = new DataTable();
        DataTable table_rs = new DataTable();
        DataTable table_masterSheet1 = new DataTable();
        DataTable table_masterSheet2 = new DataTable();
        private DAEntry_Entry dAEntry = new DAEntry_Entry();
        WorkDB_LC workdb = new WorkDB_LC();
        public static int dot;
        public static int LCtong;
        public static string type_tem;
        public static bool save = false;
        public static bool db = false;
        public static bool exit = false;
        public static string batchname;
        public static int batchID;
        public static int userID;
        public static int formID;
        public static string formName;
        public static string datestring = "";
        public string[] INFperformance = new string[2];
        DateTime dtimeBefore; bool start_lc = false; DataTable dt_chitiet_img = new DataTable();
        string form_show = "";
        private const uint LOCALE_SYSTEM_DEFAULT = 0x0800;
        private const uint LCMAP_HALFWIDTH = 0x00400000;
        public static string ToHalfWidth(string fullWidth)
        {
            StringBuilder sb = new StringBuilder(6144);
            LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_HALFWIDTH, fullWidth, -1, sb, sb.Capacity);
            return sb.ToString();
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int LCMapString(uint Locale, uint dwMapFlags, string lpSrcStr, int cchSrc, StringBuilder lpDestStr, int cchDest);
        private const uint LCMAP_FULLWIDTH = 0x00800000;
        public static string ToFullWidth(string halfWidth)
        {
            StringBuilder sb = new StringBuilder(256);
            LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_FULLWIDTH, halfWidth, -1, sb, sb.Capacity);
            return sb.ToString();
        }
        //List<string> Hiragana = new List<string>() { "あ", "い", "う", "え", "お", "か", "ぬ", "ね", "の", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "て", "と", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ", "を", "ん", "が", "ぎ", "ぐ", "げ", "ご", "ざ", "じ", "ず", "ぜ", "ぞ", "だ", "じ", "ず", "で", "ど", "ば", "び", "ぶ", "べ", "ぼ", "ぱ", "ぴ", "ぷ", "ぺ", "ぽ", "きゃ", "きゅ", "きょ", "しゃ", "しゅ", "しょ", "ちゃ", "ちゅ", "ちょ", "にゃ", "にゅ", "にょ", "ひゃ", "ひゅ", "ひょ", "みゃ", "みゅ", "みょ", "りゃ", "りゅ", "りょ", "ぎゃ", "ぎゅ", "ぎょ", "じゃ", "じゅ", "じょ", "びゃ", "びゅ", "びょ", "ぴゃ", "ぴゅ", "ぴょ", "　", "（", "）" };
        //List<string> Kana = new List<string>() { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ", "リ", "ル", "レ", "ロ", "ワ", "ヲ", "ン", "ガ", "ギ", "グ", "ゲ", "ゴ", "ザ", "ジ", "ズ", "ゼ", "ゾ", "ダ", "ジ", "ズ", "デ", "ド", "バ", "ビ", "ブ", "ベ", "ボ", "パ", "ピ", "プ", "ペ", "ポ", "キャ", "キュ", "キョ", "シャ", "シュ", "ショ", "チャ", "チュ", "チョ", "ニャ", "ニュ", "ニョ", "ヒャ", "ヒュ", "ヒョ", "ミャ", "ミュ", "ミョ", "リャ", "リュ", "リョ", "ギャ", "ギュ", "ギョ", "ジャ", "ジュ", "ジョ", "ビャ", "ビュ", "ビョ", "ピャ", "ピュ", "ピョ", "　", "（", "）", "ヅ", "ヴァ", "ヴィ", "ヴェ", "ヴォ" };
        //List<string> Kana_F8 = new List<string>() { "ｱ", "ｲ", "ｳ", "ｴ", "ｵ", "ｶ", "ｷ", "ｸ", "ｹ", "ｺ", "ｻ", "ｼ", "ｽ", "ｾ", "ｿ", "ﾀ", "ﾁ", "ﾂ", "ﾃ", "ﾄ", "ﾅ", "ﾆ", "ﾇ", "ﾈ", "ﾉ", "ﾊ", "ﾋ", "ﾌ", "ﾍ", "ﾎ", "ﾏ", "ﾐ", "ﾑ", "ﾒ", "ﾓ", "ﾔ", "ﾕ", "ﾖ", "ﾗ", "ﾘ", "ﾙ", "ﾚ", "ﾛ", "ﾜ", "ｦ", "ﾝ", "ｶﾞ", "ｷﾞ", "ｸﾞ", "ｹﾞ", "ｺﾞ", "ｻﾞ", "ｼﾞ", "ｽﾞ", "ｾﾞ", "ｿﾞ", "ﾀﾞ", "ｼﾞ", "ｽﾞ", "ﾃﾞ", "ﾄﾞ", "ﾊﾞ", "ﾋﾞ", "ﾌﾞ", "ﾍﾞ", "ﾎﾞ", "ﾊﾟ", "ﾋﾟ", "ﾌﾟ", "ﾍﾟ", "ﾎﾟ", "ｷｬ", "ｷｭ", "ｷｮ", "ｼｬ", "ｼｭ", "ｼｮ", "ﾁｬ", "ﾁｭ", "ﾁｮ", "ﾆｬ", "ﾆｭ", "ﾆｮ", "ﾋｬ", "ﾋｭ", "ﾋｮ", "ﾐｬ", "ﾐｭ", "ﾐｮ", "ﾘｬ", "ﾘｭ", "ﾘｮ", "ｷﾞｬ", "ｷﾞｭ", "ｷﾞｮ", "ｼﾞｬ", "ｼﾞｭ", "ｼﾞｮ", "ﾋﾞｬ", "ﾋﾞｭ", "ﾋﾞｮ", "ﾋﾟｬ", "ﾋﾟｭ", "ﾋﾟｮ", "　", "（", "）", "ﾂﾞ", "ｳﾞｧ", "ｳﾞｨ", "ｳﾞｪ", "ｳﾞｫ "};

        //List<char>  Hiragana_1 = new List<char>() { 'あ', 'い', 'う', 'え', 'お', 'か', 'き', 'く', 'け', 'こ', 'さ', 'し', 'す', 'せ', 'そ', 'た', 'ち', 'つ', 'て', 'と', 'な', 'に', 'ぬ', 'て', 'と', 'は', 'ひ', 'ふ', 'へ', 'ほ', 'ま', 'み', 'む', 'め', 'も', 'や', 'ゆ', 'よ', 'ら', 'り', 'る', 'れ', 'ろ', 'わ', 'を', 'ん', 'が', 'ぎ', 'ぐ', 'げ', 'ご', 'ざ', 'じ', 'ず', 'ぜ', 'ぞ', 'だ', 'じ', 'ず', 'で', 'ど', 'ば', 'び', 'ぶ', 'べ', 'ぼ', 'ぱ', 'ぴ', 'ぷ', 'ぺ', 'ぽ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', 'ゃ', 'ゅ', 'ょ', '　', '（', '）', 'ぬ', 'ね', 'の' };
        //List<char> Kana_1 = new List<char>() { 'ア', 'イ', 'ウ', 'エ', 'オ', 'カ', 'キ', 'ク', 'ケ', 'コ', 'サ', 'シ', 'ス', 'セ', 'ソ', 'タ', 'チ', 'ツ', 'テ', 'ト', 'ナ', 'ニ', 'ヌ', 'ネ', 'ノ', 'ハ', 'ヒ', 'フ', 'ヘ', 'ホ', 'マ', 'ミ', 'ム', 'メ', 'モ', 'ヤ', 'ユ', 'ヨ', 'ラ', 'リ', 'ル', 'レ', 'ロ', 'ワ', 'ヲ', 'ン', 'ガ', 'ギ', 'グ', 'ゲ', 'ゴ', 'ザ', 'ジ', 'ズ', 'ゼ', 'ゾ', 'ダ', 'ジ', 'ズ', 'デ', 'ド', 'バ', 'ビ', 'ブ', 'ベ', 'ボ', 'パ', 'ピ', 'プ', 'ペ', 'ポ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', 'ャ', 'ュ', 'ョ', '　', '（', '）', 'ヅ', 'ヴ', 'ァ', 'ヴ', 'ィ', 'ヴ', 'ェ', 'ヴ', 'ォ' };
        //List<char> Kana_F8_1 = new List<char>() { 'ｱ', 'ｲ', 'ｳ', 'ｴ', 'ｵ', 'ｶ', 'ｷ', 'ｸ', 'ｹ', 'ｺ', 'ｻ', 'ｼ', 'ｽ', 'ｾ', 'ｿ', 'ﾀ', 'ﾁ', 'ﾂ', 'ﾃ', 'ﾄ', 'ﾅ', 'ﾆ', 'ﾇ', 'ﾈ', 'ﾉ', 'ﾊ', 'ﾋ', 'ﾌ', 'ﾍ', 'ﾎ', 'ﾏ', 'ﾐ', 'ﾑ', 'ﾒ', 'ﾓ', 'ﾔ', 'ﾕ', 'ﾖ', 'ﾗ', 'ﾘ', 'ﾙ', 'ﾚ', 'ﾛ', 'ﾜ', 'ｦ', 'ﾝ', 'ﾞ', 'ﾟ','ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', 'ｬ', 'ｭ', 'ｮ', '　', '（', '）' ,'ﾞ','ｳ','ﾞ','ｧ','ｳ','ﾞ','ｨ','ｳ','ﾞ','ｪ', 'ｳ', 'ﾞ', 'ｫ'};




        private static bool CheckInvalidInput(string stringToCheck, IEnumerable<char> allowedChars)
        {
            return stringToCheck.All(allowedChars.Contains);
        }
        private static string Result_array_convertF7F8(string input)
        {
            var full_hira_kana_F78 = "ぬねのあいうえおかきくっけこさしすせそたぬねのちつてとなにぬてとはひふへほまみむめもやゆよらりるれろわをんがぎぐげござじずぜぞだじずでどばびぶべぼぱぴぷぺぽきゃきゅきょしゃしゅしょちゃちゅちょにゃにゅにょひゃひゅひょみゃみゅみょりゃりゅりょぎゃぎゅぎょじゃじゅじょびゃびゅびょぴゃぴゅぴょ　（）アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンガギグゲゴザジズゼゾダジズデドバビブベボパピプペポキャキュキョシャシュショチャチュチョニャニュニョヒャヒュヒョミャミュミョリャリュリョギャギュギョジャジュジョヂャヂュヂョビャビュビョピャピュピョヅヴァヴィヴェヴォｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｶﾞｷﾞｸﾞｹﾞｺﾞｻﾞｼﾞｽﾞｾﾞｿﾞﾀﾞｼﾞｽﾞﾃﾞﾄﾞﾊﾞﾋﾞﾌﾞﾍﾞﾎﾞﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟｷｬｷｭｷｮｼｬｼｭｼｮﾁｬﾁｭﾁｮﾆｬﾆｭﾆｮﾋｬﾋｭﾋｮﾐｬﾐｭﾐｮﾘｬﾘｭﾘｮｷﾞｬｷﾞｭｷﾞｮｼﾞｬｼﾞｭｼﾞｮﾁﾞｬﾁﾞｭﾁﾞｮﾋﾞｬﾋﾞｭﾋﾞｮﾋﾟｬﾋﾟｭﾋﾟｮﾂﾞｳﾞｧｳﾞｨｳﾞｪｳﾞｫ";
            var hiragana = "ぬねのあいうえおかきくっけこさしすせそたぬねのちつてとなにぬてとはひふへほまみむめもやゆよらりるれろわをんがぎぐげござじずぜぞだじずでどばびぶべぼぱぴぷぺぽきゃきゅきょしゃしゅしょちゃちゅちょにゃにゅにょひゃひゅひょみゃみゅみょりゃりゅりょぎゃぎゅぎょじゃじゅじょびゃびゅびょぴゃぴゅぴょ　（）";
            var Kana_F7 = "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンガギグゲゴザジズゼゾダジズデドバビブベボパピプペポキャキュキョシャシュショチャチュチョニャニュニョヒャヒュヒョミャミュミョリャリュリョギャギュギョジャジュジョヂャヂュヂョビャビュビョピャピュピョヅヴァヴィヴェヴォ　（）";
            var Kana_F8 = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｶﾞｷﾞｸﾞｹﾞｺﾞｻﾞｼﾞｽﾞｾﾞｿﾞﾀﾞｼﾞｽﾞﾃﾞﾄﾞﾊﾞﾋﾞﾌﾞﾍﾞﾎﾞﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟｷｬｷｭｷｮｼｬｼｭｼｮﾁｬﾁｭﾁｮﾆｬﾆｭﾆｮﾋｬﾋｭﾋｮﾐｬﾐｭﾐｮﾘｬﾘｭﾘｮｷﾞｬｷﾞｭｷﾞｮｼﾞｬｼﾞｭｼﾞｮﾁﾞｬﾁﾞｭﾁﾞｮﾋﾞｬﾋﾞｭﾋﾞｮﾋﾟｬﾋﾟｭﾋﾟｮﾂﾞｳﾞｧｳﾞｨｳﾞｪｳﾞｫ　（）";
            string Result = "";
            string Input_string = "";
            bool checkfull_character = CheckInvalidInput(input, full_hira_kana_F78);
            List<string> character_not = new List<string>();
            if (checkfull_character == false)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (hiragana.Contains(input[i].ToString()) == false)
                    {
                        Input_string += input[i].ToString();
                        character_not.Add(input[i].ToString() + "|" + i);
                    }
                }
                Input_string = ToFullWidth(Input_string);
                for (int i = 0; i < Input_string.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(input);
                    sb[Convert.ToInt32(character_not[i].ToString().Split('|')[1])] = Input_string[i];
                    input = sb.ToString();
                }
                Result = input;
            }
            else
            {
                bool full_Hira = CheckInvalidInput(input, hiragana);
                bool full_Kana_F7 = CheckInvalidInput(input, Kana_F7);
                if (full_Hira == true)
                {
                    Result = input;
                }
                else if (full_Kana_F7 == true)
                {
                    Result = ToHalfWidth(input);
                }
                else
                {
                    Result = input;
                }
            }
            return Result;
        }
        string link_Export = "";
        string ID_LC = "";//workdb.GetStringSQL("Select Link_Export from dbo.[LinkExport] where Id = 1");
        private void LC_New_plus_nnc_Load(object sender, EventArgs e)
        {
            spl_mng.ShowWaitForm();
            table_rs = new DataTable();
            table_rs.Columns.Add("Form", typeof(String));
            table_rs.Columns.Add("発注 NO", typeof(String));
            table_rs.Columns.Add("メッセージ", typeof(String));
            table_rs.Columns.Add("品番", typeof(String));
            table_rs.Columns.Add("取引数量（バラ）", typeof(String));
            table_rs.Columns.Add("形態", typeof(String));
            table_rs.Columns.Add("備考", typeof(String));
            table_rs.Columns.Add("直送先コード", typeof(String));
            table_rs.Columns.Add("予備項目3", typeof(String));
            table_rs.Columns.Add("Date_timenow", typeof(String));
            dt_chitiet_img = table_rs.Clone();
            table_conten1 = table_rs.Clone();
            table_conten2 = table_rs.Clone();
            table_Check = table_rs.Clone();
            link_Export = workdb.GetStringSQL("Select Link_Export from dbo.[LinkExport] where Id = 1");
            dt_all_data = workdb.dtLastcheck(dot, type_tem, LCtong);
            if (LCtong == 1)
            {
                if (dt_all_data.Rows.Count != dAEntry.GetIntSQL("Select Count(Id) from db_owner.[AllImage] where TurnUp = " + dot + ""))
                {
                    MessageBox.Show("Số lượng ảnh của Ca qua LC tổng chưa đủ ???", "Thông Báo");
                    this.Close();
                    return;
                }
                btn_export.Visible = true;
                btn_checkLogic.Visible = true;
                btn_Done.Visible = false;
                if (link_Export == "")
                {
                    MessageBox.Show("Đường dẫn File Excel Export có vấn đề !!!", "Thông Báo");
                    this.Close();
                    return;
                }
            }
            dt_all_data.Columns.Add("Select_index", typeof(string));
            dt_all_data.Columns.Add("Change_data", typeof(string));
            if (dt_all_data.Rows.Count > 0)
            {
                // Phùng sửa ngày 0505 tab Trello 8.1
                DataView dv = dt_all_data.DefaultView;
                dv.Sort = "ImageName";
                dt_all_data = dv.ToTable();
                //
                grid_img.DataSource = null;
                grid_img.DataSource = dt_all_data;
                for (int i = 1; i < dt_all_data.Columns.Count; i++)
                {
                    gridV_Img.Columns[i].Visible = false;
                }
                for (int i = 0; i < dt_all_data.Rows.Count; i++)
                {
                    ID_LC += dt_all_data.Rows[i]["AllImageID"].ToString() + ",";
                }
                if (ID_LC.Length > 0)
                {
                    ID_LC = ID_LC.Substring(0, ID_LC.Length - 1);
                }
                bool check_complete = false;
                while (check_complete == false)
                {
                    check_complete = workdb.check_sql("Update db_owner.[ImageContent] set UserLC_Keep_Img = " + userID + " where AllImageID in (" + ID_LC + ")");
                    if (check_complete == false)
                    {
                        MessageBox.Show("Mất kết nối mạng --> Thực hiện lại !!!");
                    }
                }
                //workdb.ExecuteSQL("Update db_owner.[ImageContent] set UserLC_Keep_Img = " + userID + " where AllImageID in (" + ID_LC + ")");
            }
            else
            {
                MessageBox.Show("No Data LastCheck !!!  --> Exit");
                this.Close();
                return;
            }
            dtimeBefore = DateTime.Now;
            lblsoluonganh.Text = dt_all_data.Rows.Count.ToString();
            //bgwLoad.RunWorkerAsync();
            datasave = new DataTable();
            datasave.Columns.Add("DÒNG");
            datasave.Columns.Add("CỘT");
            datasave.Columns.Add("IdImage");
            datasave.Columns.Add("Data");
            datasave.Columns.Add("Index_Dong");
            ImgV.Dock = DockStyle.Fill;
            gridV_Img.BestFitColumns();
            start_lc = true;
            spl_mng.CloseWaitForm();
            read_file_excel_master();
            splitContainer2.SplitterDistance = splitContainer2.Height - 5;
        }
        void read_file_excel_master()
        {
            #region add các cột thông tin để Export dữ liệu
            table_masterSheet1 = new DataTable();
            OleDbConnection con1 = null;
            try
            {
                string path_file_master = link_Export + @"\NNC商品マスタ.xlsx";
                string Contrs1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path_file_master + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
                con1 = new OleDbConnection(Contrs1);
                OleDbCommand cmd1 = new OleDbCommand("Select * from [アピカ品商品マスタ$]", con1);
                con1.Open();
                table_masterSheet1.Load(cmd1.ExecuteReader());
                con1.Close();
            }
            catch
            {
                con1.Close();
                MessageBox.Show("Please Check Link Save File Layout Export NNC ???");
                return;
            }
            table_masterSheet2 = new DataTable();
            try
            {
                string path_file_master = link_Export + @"\NNC商品マスタ.xlsx";
                string Contrs1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path_file_master + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
                con1 = new OleDbConnection(Contrs1);
                OleDbCommand cmd1 = new OleDbCommand("Select * from [キョクトウ品商品マスタ$]", con1);
                con1.Open();
                table_masterSheet2.Load(cmd1.ExecuteReader());
                con1.Close();
            }
            catch
            {
                con1.Close();
                MessageBox.Show("Please Check Link Save File Layout Export NNC ???");
                return;
            }
            #endregion
        }
        int index_focus = 0; float dbzome; Bitmap bitmapTmp;
        private void gridV_Img_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index_focus = e.FocusedRowHandle;
            string tenanh = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "ImageName").ToString();
            dt_all_data.Rows[index_focus]["Select_index"] = "1";
            string data_result = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "Result").ToString();
            showdata(index_focus);
            if (bitmapTmp != null)
            {
                bitmapTmp.Dispose();
            }
            bitmapTmp = new Bitmap(byteArrayToImage(workdb.getImageOnServer(tenanh)));
            ImgV.Image = bitmapTmp;
            dbzome = ImgV.CurrentZoom;
            type_tem = gridV_Img.GetRowCellValue(e.FocusedRowHandle, "ResultP").ToString();
        }
        static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        DataTable table_conten1 = new DataTable();
        DataTable table_conten2 = new DataTable();
        DataTable table_Check = new DataTable();
        void showdata(int index)
        {
            BackgroundWorker worker = new BackgroundWorker();
            if (index > 0)
            {
                spl_mng.ShowWaitForm();
            }
            string data_rs = dt_all_data.Rows[index]["Result"].ToString();
            string data_conten1 = dt_all_data.Rows[index]["Content1"].ToString();
            string data_conten2 = dt_all_data.Rows[index]["Content2"].ToString();
            string data_check = dt_all_data.Rows[index]["Checkresult"].ToString();
            table_rs.Clear(); table_conten1.Clear(); table_conten2.Clear(); table_Check.Clear();
            #region // Phân tích dữ liệu Result
            for (int i = 0; i < data_rs.Split('|')[3].Split('\n').Length; i++)
            {
                string template = data_rs.Split('|')[0].ToString();
                string truong3 = data_rs.Split('|')[2].ToString();
                string datetime = data_rs.Split('|')[2].ToString();
                table_rs.Rows.Add();
                for (int t = 0; t < table_rs.Columns.Count; t++)
                {
                    if (t == 0)
                    {
                        table_rs.Rows[i][t] = template;
                        form_show = template;
                    }
                    else if (t == 2)
                    {
                        table_rs.Rows[i][t] = truong3;
                    }
                    else if (t == 9)
                    {
                        table_rs.Rows[i][t] = datetime;
                    }
                    else if (t == 7)
                    {
                        if (data_rs.Split('|')[t].ToString().Contains("\n"))
                        {
                            table_rs.Rows[i][t] = data_rs.Split('|')[t].Split('\n')[i].ToString();
                        }
                        else
                        {
                            table_rs.Rows[i][t] = data_rs.Split('|')[t].ToString();
                        }
                    }
                    else
                    {
                        try
                        {
                            string data_colum = data_rs.Split('|')[t].Split('\n')[i].ToString();
                            table_rs.Rows[i][t] = data_colum;
                        }
                        catch
                        {
                            table_rs.Rows[i][t] = "";
                        }
                    }
                }
            }
            #endregion // Phân tích dữ liệu Result

            #region// phân tích dữ liệu E1
            for (int i = 0; i < data_conten1.Split('|')[3].Split('\n').Length; i++)
            {
                string template = data_conten1.Split('|')[0].ToString();
                string truong3 = data_conten1.Split('|')[2].ToString();
                table_conten1.Rows.Add();
                for (int t = 0; t < table_conten1.Columns.Count; t++)
                {
                    if (t == 0)
                    {
                        table_conten1.Rows[i][t] = template;
                    }
                    else if (t == 2)
                    {
                        table_conten1.Rows[i][t] = truong3;
                    }
                    else if (t == 7)
                    {
                        if (data_conten1.Split('|')[t].ToString().Contains("\n"))
                        {
                            table_conten1.Rows[i][t] = data_conten1.Split('|')[t].Split('\n')[i].ToString();
                        }
                        else
                        {
                            table_conten1.Rows[i][t] = data_conten1.Split('|')[t].ToString();
                        }

                    }
                    else if (t < 9)
                    {
                        try
                        {
                            string data_colum = data_conten1.Split('|')[t].Split('\n')[i].ToString();
                            table_conten1.Rows[i][t] = data_colum;
                        }
                        catch
                        {
                            table_conten1.Rows[i][t] = "";
                        }
                    }

                }
            }
            #endregion

            #region // phân tích dữ liệu E2
            for (int i = 0; i < data_conten2.Split('|')[3].Split('\n').Length; i++)
            {
                string template = data_conten2.Split('|')[0].ToString();
                string truong3 = data_conten2.Split('|')[2].ToString();
                table_conten2.Rows.Add();
                for (int t = 0; t < table_conten2.Columns.Count; t++)
                {
                    if (t == 0)
                    {
                        table_conten2.Rows[i][t] = template;
                    }
                    else if (t == 2)
                    {
                        table_conten2.Rows[i][t] = truong3;
                    }
                    else if (t == 7)
                    {
                        if (data_conten2.Split('|')[t].ToString().Contains("\n"))
                        {
                            table_conten2.Rows[i][t] = data_conten2.Split('|')[t].Split('\n')[i].ToString();
                        }
                        else
                        {
                            table_conten2.Rows[i][t] = data_conten2.Split('|')[t].ToString();
                        }

                    }
                    else if (t < 9)
                    {
                        try
                        {
                            string data_colum = data_conten2.Split('|')[t].Split('\n')[i].ToString();
                            table_conten2.Rows[i][t] = data_colum;
                        }
                        catch
                        {
                            table_conten2.Rows[i][t] = "";
                        }
                    }

                }
            }
            #endregion

            #region // phân tích dữ liệu Check
            for (int i = 0; i < data_check.Split('|')[3].Split('\n').Length; i++)
            {
                string template = data_check.Split('|')[0].ToString();
                string truong3 = data_check.Split('|')[2].ToString();
                table_Check.Rows.Add();
                for (int t = 0; t < table_Check.Columns.Count; t++)
                {
                    if (t == 0)
                    {
                        table_Check.Rows[i][t] = template;
                    }
                    else if (t == 2)
                    {
                        table_Check.Rows[i][t] = truong3;
                    }
                    else if (t == 7)
                    {
                        if (data_check.Split('|')[t].ToString().Contains("\n"))
                        {
                            table_Check.Rows[i][t] = data_check.Split('|')[t].Split('\n')[i].ToString();
                        }
                        else
                        {
                            table_Check.Rows[i][t] = data_check.Split('|')[t].ToString();
                        }

                    }
                    else if (t < 9)
                    {
                        try
                        {
                            string data_colum = data_check.Split('|')[t].Split('\n')[i].ToString();
                            table_Check.Rows[i][t] = data_colum;
                        }
                        catch
                        {
                            table_Check.Rows[i][t] = "";
                        }
                    }

                }
            }
            #endregion
            if (index > 0)
            {
                spl_mng.CloseWaitForm();
            }

            grid_data.DataSource = null;
            grid_data.DataSource = table_rs;
            gridV_data.Columns[9].Visible = false;
            //gridV_data.Columns[6].Visible = false;
            //gridV_data.Columns[7].Visible = false;
            gridV_data.Columns[8].Visible = false;
            gridV_data.Columns[0].OptionsColumn.ReadOnly = true;
            gridV_data.Columns[0].OptionsColumn.AllowEdit = false;
            gridV_data.BestFitColumns();
            worker.WorkerReportsProgress = true;
        }
        private void gridV_Img_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
        private void gridV_Img_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            string columname = e.Column.FieldName;
            if (r > -1)
            {
                if (gridV_Img.GetRowCellValue(e.RowHandle, gridV_Img.Columns["Select_index"]).ToString() == "1")
                {
                    if (e.Column.FieldName == "ImageName")
                    {
                        e.Appearance.BackColor = Color.SteelBlue;
                    }
                }
            }
        }

        private void gridV_Img_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridV_data_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridV_data_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            string columname = e.Column.FieldName;
            if (r > -1)
            {
                if (cl < 9)
                {
                    #region bôi màu của Entry và CHeck
                    try
                    {
                        if (table_Check.Rows[r][cl].ToString() != table_conten1.Rows[r][cl].ToString() || table_Check.Rows[r][cl].ToString() != table_conten2.Rows[r][cl].ToString())
                        {
                            e.Appearance.BackColor = Color.LightPink;
                        }
                    }
                    catch
                    {
                        e.Appearance.BackColor = Color.LightPink;
                    }
                    #endregion
                    #region bôi màu của Check và LC
                    try
                    {
                        if (table_Check.Rows[r][cl].ToString() != table_rs.Rows[r][cl].ToString())
                        {
                            e.Appearance.BackColor = Color.OrangeRed;
                        }
                    }
                    catch
                    {
                        e.Appearance.BackColor = Color.OrangeRed;
                    }
                    #endregion
                }
            }
        }

        private void grid_data_EditorKeyDown(object sender, KeyEventArgs e)
        {
            ColumnView View = (ColumnView)grid_data.FocusedView;
            GridColumn column = View.Columns[gridV_data.FocusedColumn.FieldName];
            int row = gridV_data.FocusedRowHandle;
            if (e.Control && e.KeyCode == Keys.Subtract)
            {
                if (row != 0)
                {
                    DeleteSelectedRows(gridV_data);
                    View.FocusedRowHandle = row - 1;
                    View.FocusedColumn = gridV_data.VisibleColumns[1];
                    changed = true;
                    change_data_save = true;
                }
                else
                {
                    MessageBox.Show("Không thể xóa");
                    return;
                }
            }
            //else if (e.KeyCode == Keys.Enter)
            //{
            //    if (row < 0)
            //    {
            //        row = 1;
            //    }
            //    if (row == gridV_data.RowCount - 1)
            //    {
            //        View.FocusedRowHandle = row + 1;
            //        View.FocusedColumn = column;
            //        gridV_data.AddNewRow();
            //        View.FocusedRowHandle = row + 1;
            //        View.FocusedColumn = gridV_data.VisibleColumns[0];
            //        changed = true;
            //        change_data_save = true;
            //    }
            //    else
            //    {
            //        View.FocusedRowHandle = row + 1;
            //        View.FocusedColumn = column;
            //        changed = true;
            //        change_data_save = true;
            //    }
            //}
            else if (e.Control && e.KeyCode == Keys.Add)
            {
                DataRow dtr = table_rs.NewRow();
                table_rs.Rows.InsertAt(dtr, row + 1);
                //dtcopy.Rows.Add();
                //dtcopy.AcceptChanges();
                grid_data.DataSource = null;
                grid_data.DataSource = table_rs;
                grid_data.Focus();
                View.FocusedRowHandle = row + 1;
                View.FocusedColumn = column;
                changed = true;
                change_data_save = true;
                SendKeys.Send("{F2}");
                SendKeys.Send("{END}");
            }
        }

        private void DeleteSelectedRows(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            if (view == null || view.SelectedRowsCount == 0) return;
            DataRow[] rows = new DataRow[view.SelectedRowsCount];
            for (int i = 0; i < view.SelectedRowsCount; i++)
                rows[i] = view.GetDataRow(view.GetSelectedRows()[i]);
            view.BeginSort();
            try
            {
                foreach (DataRow row in rows)
                    row.Delete();
            }
            finally
            {
                view.EndSort();
            }
        }
        bool changed = false; bool change_data_save = false; bool Done_image = false;
        private void gridV_data_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (index_focus > -1)
            {
                changed = true;
                change_data_save = true;
            }
        }
        private void grid_data_Leave(object sender, EventArgs e)
        {
            spl_mng.ShowWaitForm();
            if (changed == true)
            {
                if (index_focus > -1)
                {
                    string data_rs_new = "";
                    for (int i = 0; i < table_rs.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            data_rs_new = table_rs.Rows[0][0].ToString() + "|";
                        }
                        else if (i == 2)
                        {
                            data_rs_new += table_rs.Rows[0][2].ToString() + "|";
                        }
                        else if (i == 9)
                        {
                            data_rs_new += table_rs.Rows[0][9].ToString();
                        }
                        else
                        {
                            string data_full_columns = "";
                            for (int t = 0; t < table_rs.Rows.Count; t++)
                            {
                                data_full_columns += table_rs.Rows[t][i].ToString() + "\n";
                            }
                            if (data_full_columns.Length > 0)
                            {
                                data_full_columns = data_full_columns.Substring(0, data_full_columns.Length - 1);
                            }
                            data_rs_new += data_full_columns + "|";
                        }
                    }
                    dt_all_data.Rows[index_focus]["Result"] = data_rs_new;
                    dt_all_data.Rows[index_focus]["Change_data"] = "1";
                    dt_all_data.AcceptChanges();
                    change_data_save = true;
                }
            }
            changed = false;
            spl_mng.CloseWaitForm();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (change_data_save == true)
            {
                var mess_change = MessageBox.Show("Có dữ liệu thay đổi. Thực hiện lưu dữ liệu ???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mess_change == DialogResult.Yes)
                {
                    for (int i = 0; i < dt_all_data.Rows.Count; i++)
                    {
                        if (dt_all_data.Rows[i]["Change_data"].ToString() == "1")
                        {
                            int id_img = Convert.ToInt32(dt_all_data.Rows[i]["AllImageID"].ToString());
                            workdb.Update_dataSave(id_img, dt_all_data.Rows[i]["Result"].ToString());
                        }
                    }
                    MessageBox.Show("Complete Save Data");
                }
                change_data_save = false;
            }
        }
        private void LC_New_plus_nnc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (start_lc == true)
            {
                if (change_data_save == true)
                {
                    btn_save_Click(sender, e);
                }
                TimeSpan span = DateTime.Now - dtimeBefore;
                int ms = (int)span.TotalMilliseconds;
                workdb.Save_PFM(dot, ms.ToString(), userID);
                if (Done_image == false)
                {
                    if (dt_all_data.Rows.Count > 0)
                    {
                        bool check_complete = false;
                        while (check_complete == false)
                        {
                            check_complete = workdb.check_sql("Update db_owner.[ImageContent] set UserLC_Keep_Img = 0 where AllImageID in (" + ID_LC + ")");
                            if (check_complete == false)
                            {
                                MessageBox.Show("Mất kết nối mạng --> Thực hiện lại !!!");
                            }
                        }
                        //workdb.ExecuteSQL("Update db_owner.[ImageContent] set UserLC_Keep_Img = 0 where AllImageID in (" + ID_LC + ")");
                    }
                }
            }
        }
        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (change_data_save == true)
            {
                MessageBox.Show("Thực hiện Save dữ liệu đã thay đổi nhé !!!", "Thông Báo");
                return;
            }
            if (MessageBox.Show("Thực hiện Done những ảnh đang hiển thị ???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dt_all_data.Rows.Count > 0)
                {
                    bool check_complete = false;
                    while (check_complete == false)
                    {
                        check_complete = workdb.check_sql("Update db_owner.[ImageContent] set UserLC_Done = " + userID + " where AllImageID in (" + ID_LC + ")");
                        if (check_complete == false)
                        {
                            MessageBox.Show("Mất kết nối mạng --> Thực hiện lại !!!");
                        }
                    }
                    check_complete = workdb.check_sql("Update db_owner.[ImageContent] set UserLC_Done = " + userID + " where AllImageID in (" + ID_LC + ")");
                    MessageBox.Show("Complete");
                    //workdb.ExecuteSQL("Update db_owner.[ImageContent] set UserLC_Done = " + userID + " where AllImageID in ("+ID_LC+")");
                    Done_image = true;
                    this.Close();
                }
            }
        }
        public void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            using (
                var sw = new StreamWriter(
                    new FileStream(strFilePath, FileMode.Open, FileAccess.ReadWrite),
                    Encoding.GetEncoding("shift-jis")
                )
            )
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    sw.Write(dtDataTable.Columns[i]);
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                //sw.Encoding = "shift-jis"
                foreach (DataRow dr in dtDataTable.Rows)
                {
                    for (int i = 0; i < dtDataTable.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string value = dr[i].ToString();
                            if (value.Contains(','))
                            {
                                value = String.Format("\"{0}\"", value);
                                sw.Write(value);
                            }
                            else
                            {
                                sw.Write(dr[i].ToString());
                            }
                        }
                        if (i < dtDataTable.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }
        }
        List<byte> listByteCSV = new List<byte>();
        public static bool bool_check_logic;
        private void btn_export_Click(object sender, EventArgs e)
        {
            if (gridV_Img.RowCount > 0)
            {
                #region add các cột thông tin để Export dữ liệu
                OleDbConnection con1 = null;
                DataTable table_bang_export = new DataTable();
                try
                {
                    string path_file_master = link_Export + @"\File_Master_Xuat_NNC_211013.xlsx";
                    string Contrs1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path_file_master + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
                    con1 = new OleDbConnection(Contrs1);
                    OleDbCommand cmd1 = new OleDbCommand("Select * from [Sheet1$]", con1);
                    con1.Open();
                    table_bang_export.Load(cmd1.ExecuteReader());
                    con1.Close();
                }
                catch
                {
                    con1.Close();
                    MessageBox.Show("Please Check Link Save File Layout Export NNC ???");
                    return;
                }
                #endregion
                int int_index_row_export = 0;
                DataTable dt_data_Export = new DataTable();
                dt_data_Export = workdb.dtLastcheck(dot, type_tem, LCtong);
                DataTable dt_template = new DataTable();
                dt_template = workdb.GetDatatableSQL("Select TempName,Rules,Form6,Colum1_1,Colum1_2,Colum1_3,MaCot1,MaCot2,MaCot3 from dbo.[Template]");
                DataView dv = dt_data_Export.DefaultView;
                dv.Sort = "ImageName";
                dt_data_Export = dv.ToTable();
                for (int z = 0; z < dt_data_Export.Rows.Count; z++)
                {
                    dt_chitiet_img.Clear();
                    #region // Phân tích dữ liệu Result
                    string data_rs = dt_data_Export.Rows[z]["Result"].ToString();
                    for (int i = 0; i < data_rs.Split('|')[3].Split('\n').Length; i++)
                    {
                        string template = data_rs.Split('|')[0].ToString();
                        string truong3 = data_rs.Split('|')[2].ToString();
                        string datetime = data_rs.Split('|')[2].ToString();
                        dt_chitiet_img.Rows.Add();
                        for (int t = 0; t < dt_chitiet_img.Columns.Count; t++)
                        {
                            if (t == 0)
                            {
                                dt_chitiet_img.Rows[i][t] = template;
                            }
                            else if (t == 2)
                            {
                                dt_chitiet_img.Rows[i][t] = truong3;
                            }
                            else if (t == 9)
                            {
                                dt_chitiet_img.Rows[i][t] = datetime;
                            }
                            else if (t == 7)
                            {
                                if (data_rs.Split('|')[t].ToString().Contains("\n"))
                                {
                                    dt_chitiet_img.Rows[i][t] = data_rs.Split('|')[t].Split('\n')[i].ToString();
                                }
                                else
                                {
                                    dt_chitiet_img.Rows[i][t] = data_rs.Split('|')[t].ToString();
                                }
                            }
                            else
                            {
                                try
                                {
                                    string data_colum = data_rs.Split('|')[t].Split('\n')[i].ToString();
                                    dt_chitiet_img.Rows[i][t] = data_colum;
                                }
                                catch
                                {
                                    dt_chitiet_img.Rows[i][t] = "";
                                }
                            }
                        }
                    }
                    #endregion // Phân tích dữ liệu Result
                    #region Add Dữ liệu tương đương các Form
                    string data_template = dt_data_Export.Rows[z]["ResultP"].ToString();
                    string name_img = dt_data_Export.Rows[z]["ImageName"].ToString();
                    if (name_img == "20220224-3-29 VBPO-0021.jpeg")
                    {

                    }
                    bool bol_data_null_cot2 = true;
                    for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                    {
                        if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() != "")
                        {
                            bol_data_null_cot2 = false;
                        }
                    }
                    if (data_template.Split('-')[0] == "1")
                    {
                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3 
                            //Update info thông tin cột ngày 9/11/2021
                            if (bol_data_null_cot2 == true)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                            }
                            else
                            {
                                //Update info thông tin cột ngày 18/01/2022
                                if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                }

                            }
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Substring(0, 8).ToString(); //Update yêu cầu 27/10/2021
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                        }
                    }
                    else if (data_template.Split('-')[0] == "2")
                    {
                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1]; //name_img.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3                            
                            //Update info thông tin cột ngày 9/11/2021
                            if (bol_data_null_cot2 == true)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                            }
                            else
                            {
                                //Update info thông tin cột ngày 18/01/2022
                                if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                }
                            }
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //Update 07/01/2022
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();
                        }
                    }
                    else if (data_template.Split('-')[0] == "3")
                    {
                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1]; //name_img.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3                            
                            //Update info thông tin cột ngày 9/11/2021
                            if (bol_data_null_cot2 == true)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                            }
                            else
                            {
                                //Update info thông tin cột ngày 18/01/2022
                                if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                }
                            }
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                        }
                    }
                    else if (data_template.Split('-')[0] == "11")
                    {

                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        //thêm ngày 15/08
                        string strCheck_column_2 = string.Join("", dt_chitiet_img.Rows.OfType<DataRow>().Select(r => r["発注 NO"].ToString()));
                        //
                        bool truong2_7khacnhau = false;
                        bool data_truong7_null = false;
                        if (dt_chitiet_img.Rows.Count != dt_chitiet_img.Select("[備考] = '" + dt_chitiet_img.Rows[0]["備考"] + "'").CopyToDataTable().Rows.Count)
                        {
                            truong2_7khacnhau = true;
                        }
                        else if (dt_chitiet_img.Rows.Count == 1)
                        {
                            truong2_7khacnhau = true;
                            if (dt_chitiet_img.Rows[0]["備考"].ToString() == "")
                            {
                                data_truong7_null = true;
                            }
                        }
                        else
                        {
                            if (dt_chitiet_img.Rows[0]["備考"].ToString() == "")
                            {
                                data_truong7_null = true;
                            }
                        }
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1]; //name_img.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3                            
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8

                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            if (truong2_7khacnhau == true)
                            {
                                if (dt_chitiet_img.Rows.Count == 1 && data_truong7_null == true)
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = "定番";//dữ liệu thay đổi từ 8 qua 備考
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = dt_chitiet_img.Rows[i]["備考"].ToString();//dữ liệu thay đổi từ 8 qua 備考
                                }
                                //Update info thông tin cột ngày 9/11/2021
                                if (bol_data_null_cot2 == true)
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                                }
                                else
                                {
                                    //Update info thông tin cột ngày 18/01/2022
                                    if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                    {
                                        table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                    }
                                    else
                                    {
                                        table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                    }
                                }
                            }
                            else
                            {
                                // các dòng trường 7 giống nhau hết
                                if (data_truong7_null == true) // giống nhau mà trống cmn
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = "定番";
                                    if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                    {
                                        table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString();
                                    }
                                    // thêm 05/08/2022
                                    else
                                    { table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); }
                                }
                                else // giống nhau mà có dữ liệu
                                {
                                    if (strCheck_column_2 != "")
                                    {
                                        if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() != "")
                                        {
                                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString();
                                        }
                                        else
                                        {
                                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                                        }
                                        table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = dt_chitiet_img.Rows[i]["備考"].ToString();
                                    }
                                    else
                                    {
                                        table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["備考"].ToString();
                                    }
                                }
                            }
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                        }
                    }
                    else if (data_template.Split('-')[0] == "12" || data_template.Split('-')[0] == "16")
                    {
                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1]; //name_img.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();//MaCot2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();//MaCot2 change new
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3                            
                            //Update info thông tin cột ngày 9/11/2021
                            if (bol_data_null_cot2 == true)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                            }
                            else
                            {
                                //Update info thông tin cột ngày 18/01/2022
                                if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                }
                            }
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = dt_chitiet_img.Rows[i]["備考"].ToString();
                        }
                    }
                    else if (data_template.Split('-')[0] == "13")
                    {
                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1]; //name_img.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            if (dtr_form.Rows[0]["Rules"].ToString().Contains("8") == false)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();//MaCot2
                            }
                            else
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dt_chitiet_img.Rows[i][7].ToString();//MaCot2
                            }
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();//MaCot2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3
                            //Update info thông tin cột ngày 9/11/2021
                            if (bol_data_null_cot2 == true)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                            }
                            else
                            {
                                //Update info thông tin cột ngày 18/01/2022
                                if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                }
                            }
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = dt_chitiet_img.Rows[i]["備考"].ToString();
                        }
                    }
                    else if (data_template.Split('-')[0] == "14")
                    {
                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];// name_img.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();//MaCot2
                            ///
                            //update 19/07/2022
                            ///
                            if (dtr_form.Rows[0]["Rules"].ToString().Contains("8") == false)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();//MaCot2
                            }
                            else
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dt_chitiet_img.Rows[i][7].ToString();//MaCot2
                            }
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3
                            ///
                            //update 19/07/2022
                            ///
                            //Update info thông tin cột ngày 9/11/2021
                            if (bol_data_null_cot2 == true)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                            }
                            else
                            {
                                //Update info thông tin cột ngày 18/01/2022
                                if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                }
                            }
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["備考"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                        }
                    }
                    else if (data_template.Split('-')[0] == "15")
                    {
                        DataTable dtr_form = dt_template.Select("TempName = '" + data_template + "'").CopyToDataTable();
                        string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                        for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                        {
                            string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                            string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                            int_index_row_export++;
                            table_bang_export.Rows.Add();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1][0] = int_index_row_export.ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["作成日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1]; //name_img.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["代理店コード"] = dtr_form.Rows[0]["MaCot1"].ToString();//MaCot1
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["直送先コード "] = dtr_form.Rows[0]["MaCot2"].ToString();//MaCot2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷元 倉庫"] = dtr_form.Rows[0]["MaCot3"].ToString();//MaCot3
                            //Update info thông tin cột ngày 9/11/2021
                            if (bol_data_null_cot2 == true)
                            {
                                table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột 2
                            }
                            else
                            {
                                //Update info thông tin cột ngày 18/01/2022
                                if (dt_chitiet_img.Rows[i]["発注 NO"].ToString() == "")
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dtr_form.Rows[0]["MaCot1"].ToString(); //dữ liệu cột MaCot1
                                }
                                else
                                {
                                    table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                                }
                            }
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["発注 NO"] = dt_chitiet_img.Rows[i]["発注 NO"].ToString(); //dữ liệu cột 2
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["メッセージ"] = dt_chitiet_img.Rows[i][2].ToString();//dữ liệu cột 3
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["品番"] = dt_chitiet_img.Rows[i][3].ToString();//dữ liệu cột 4
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["取引数量（バラ）"] = dt_chitiet_img.Rows[i][4].ToString();//dữ liệu cột 5
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["形態"] = dt_chitiet_img.Rows[i][5].ToString();//dữ liệu cột 6
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目1"] = dt_chitiet_img.Rows[i][6].ToString();//dữ liệu cột 7
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目2"] = dt_chitiet_img.Rows[i][7].ToString();//dữ liệu cột 8
                            //table_bang_export.Rows[table_bang_export.Rows.Count - 1]["予備項目3"] = dt_chitiet_img.Rows[i][8].ToString();//dữ liệu cột 9
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["出荷日"] = name_img.Replace("kem", "†").Replace("ket", "†").Split('†')[1];//.Substring(0, 8).ToString();
                            table_bang_export.Rows[table_bang_export.Rows.Count - 1]["JANコード"] = str_JAN_columnN;
                        }
                    }
                    #endregion
                }
                //for (int i = 0; i < table_bang_export.Rows.Count; i++)
                //{
                //    for (int j = 1; j < table_bang_export.Columns.Count; j++)
                //    {
                //        if (table_bang_export.Rows[i][j].ToString() != "")
                //        {
                //            table_bang_export.Rows[i][j] = Result_array_convertF7F8(table_bang_export.Rows[i][j].ToString());
                //        }
                //    }
                //}
                #region View Data export
                frm_table_export frm_ex = new frm_table_export();
                frm_ex.dt_export = table_bang_export;
                frm_ex.ShowDialog();
                #endregion
                #region Xuất dữ liệu
                if (bool_check_logic == true)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.RestoreDirectory = true;
                    saveDialog.Title = "Save to file xlsx";
                    saveDialog.Filter = "EXCEL | *.xlsx";
                    saveDialog.Title = "Save to file Csv";
                    saveDialog.Filter = "EXCEL | *.xlsx";
                    DateTime now = DateTime.Now;
                    string datestring2 = now.Year.ToString() + String.Format("{0:00}", int.Parse(now.Month.ToString())) + String.Format("{0:00}", int.Parse(now.Day.ToString()));
                    saveDialog.FileName = "NNC_" + datestring2 + "_" + dot + ".xlsx";
                    //saveDialog.Filter = "Excel (2007) (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        //if (!File.Exists(saveDialog.FileName))
                        //{
                        //    File.Create(saveDialog.FileName).Close();
                        //}

                        gridExport.DataSource = table_bang_export;
                        gridExport.ExportToXlsx(saveDialog.FileName, new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
                        //ToCSV(table_bang_export, saveDialog.FileName);
                        MessageBox.Show("Complete!");
                    }
                }
                else
                {
                    return;
                }
                #endregion
            }
        }
        private string check_masterNNC(string nameSheet, string name_data_role4)
        {
            string Jan_columns_N = "";
            if (nameSheet.ToString() == "アピカ")
            {
                try
                {
                    DataTable dt_master_NNC_new = table_masterSheet1.Select("[アピカ品　商品マスタ] = '" + name_data_role4 + "'").CopyToDataTable();
                    Jan_columns_N = dt_master_NNC_new.Rows[0][4].ToString();
                }
                catch { }

            }
            else if (nameSheet.ToString() == "キョクトウ") //キョクトウ
            {
                try
                {
                    DataTable dt_master_NNC_new = table_masterSheet2.Select("[キョクトウ品商品マスタ] = '" + name_data_role4 + "'").CopyToDataTable();
                    Jan_columns_N = dt_master_NNC_new.Rows[0][4].ToString();
                }
                catch { }

            }
            return Jan_columns_N;
        }
        static byte[] Getbytes(string str)
        {
            Encoding encoding = Encoding.GetEncoding("Shift_jis");
            byte[] array = encoding.GetBytes(str);
            return array;
        }
        static string Getstring(byte[] b)
        {
            Encoding encoding = Encoding.GetEncoding("Shift_jis");
            string array = encoding.GetString(b);
            return array;
        }
        private void LC_New_plus_NNC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Q)
                {
                    FrmSOP frmsop = new FrmSOP();
                    byte[] binary;
                    binary = dAEntry.Get_imgsop(type_tem);
                    if (binary != null)
                    {
                        frmsop.getimg = binary;
                        frmsop.Anchor = AnchorStyles.Right;
                        frmsop.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không có ảnh SOP ");
                        return;
                    }
                }
            }
        }
        DataTable tb_error_checkLOgic = new DataTable();
        private void btn_checkLogic_Click(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 5;
            if (change_data_save == true)
            {
                if (MessageBox.Show("Thực hiện Save ???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn_save_Click(sender, e);
                }
                else
                {
                    return;
                }
            }
            DataTable dt_template = new DataTable();
            dt_template = workdb.GetDatatableSQL("Select TempName,Rules,Form6,Colum1_1,Colum1_2,Colum1_3,MaCot1,MaCot2,MaCot3 from dbo.[Template]");
            tb_error_checkLOgic = new DataTable();
            tb_error_checkLOgic.Columns.Add("Name_Image"); tb_error_checkLOgic.Columns.Add("Data_Error"); tb_error_checkLOgic.Columns.Add("Index_Error"); tb_error_checkLOgic.Columns.Add("Index_Rows_data"); tb_error_checkLOgic.Columns.Add("Index_Columns_data"); tb_error_checkLOgic.Columns.Add("Select_index");
            for (int z = 0; z < dt_all_data.Rows.Count; z++)
            {
                string name_image = dt_all_data.Rows[z]["ImageName"].ToString();
                string str_rsP = dt_all_data.Rows[z]["ResultP"].ToString();
                string str_Result = dt_all_data.Rows[z]["Result"].ToString();//Result
                dt_chitiet_img.Clear();
                #region // Phân tích dữ liệu Result
                string data_rs = dt_all_data.Rows[z]["Result"].ToString();
                for (int i = 0; i < data_rs.Split('|')[3].Split('\n').Length; i++)
                {
                    string template = data_rs.Split('|')[0].ToString();
                    string truong3 = data_rs.Split('|')[2].ToString();
                    string datetime = data_rs.Split('|')[2].ToString();
                    dt_chitiet_img.Rows.Add();
                    for (int t = 0; t < dt_chitiet_img.Columns.Count; t++)
                    {
                        if (t == 0)
                        {
                            dt_chitiet_img.Rows[i][t] = template;
                        }
                        else if (t == 2)
                        {
                            dt_chitiet_img.Rows[i][t] = truong3;
                        }
                        else if (t == 9)
                        {
                            dt_chitiet_img.Rows[i][t] = datetime;
                        }
                        else if (t == 7)
                        {
                            if (data_rs.Split('|')[t].ToString().Contains("\n"))
                            {
                                dt_chitiet_img.Rows[i][t] = data_rs.Split('|')[t].Split('\n')[i].ToString();
                            }
                            else
                            {
                                dt_chitiet_img.Rows[i][t] = data_rs.Split('|')[t].ToString();
                            }
                        }
                        else
                        {
                            try
                            {
                                string data_colum = data_rs.Split('|')[t].Split('\n')[i].ToString();
                                dt_chitiet_img.Rows[i][t] = data_colum;
                            }
                            catch
                            {
                                dt_chitiet_img.Rows[i][t] = "";
                            }
                        }
                    }
                }
                #endregion
                DataTable dtr_form = dt_template.Select("TempName = '" + str_rsP + "'").CopyToDataTable();
                string str_master_NNC_truong6 = dtr_form.Rows[0]["Form6"].ToString();
                string str_truong6_role = "";
                //1: 冊、包‡B|2:甲、箱、ケース‡K
                if (str_master_NNC_truong6 != "")
                {
                    for (int i = 0; i < str_master_NNC_truong6.Split('|').Length; i++)
                    {
                        str_truong6_role += str_master_NNC_truong6.Split('|')[i].ToString().Split('‡')[1].ToString();
                    }
                }
                string str_master_NNC = dtr_form.Rows[0]["Colum1_2"].ToString();
                bool note_truong31 = false; bool note_truong32 = false; bool note_truong33 = false; bool note_truong34 = false; bool note_truong_space = false;
                // Thực hiện yêu cầu đầu tiên 4,5,6 không bằng nhau: Dựa vào số dòng của trường 2 (khung màu xanh ảnh minh họa). Nếu trường 4, 5, 6 có giá trị nào trống (Khung màu đỏ) thì sẽ hiện thông báo
                for (int i = 0; i < dt_chitiet_img.Rows.Count; i++)
                {

                    // chế 05/08/2022
                    //if (dt_chitiet_img.Rows[i][3].ToString() == "")
                    //{
                    //    tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 4 trống dòng: " + (i + 1) + "", z, i, 3);
                    //}
                    //if (dt_chitiet_img.Rows[i][4].ToString() == "")
                    //{
                    //    tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 5 trống dòng: " + (i + 1) + "", z, i, 4);
                    //}
                    //if (dt_chitiet_img.Rows[i][5].ToString() == "")
                    //{
                    //    tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 6 trống dòng: " + (i + 1) + "", z, i, 5);
                    //}

                    try
                    {
                        List<string> lstrole = dtr_form.Rows[0]["Rules"].ToString().Split(',').ToList();

                        for (int k = 0; k < lstrole.Count; k++)
                        {
                            if (dt_chitiet_img.Rows[i][Convert.ToInt32(lstrole[k]) - 1].ToString() == "")
                            {
                                if (lstrole[k] == "3")
                                {
                                    if (!note_truong31)
                                    { note_truong31 = true; tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường " + lstrole[k] + " trống dòng: " + (i + 1) + "", z, i, Convert.ToInt32(lstrole[k]) - 1); }
                                }
                                else { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường " + lstrole[k] + " trống dòng: " + (i + 1) + "", z, i, Convert.ToInt32(lstrole[k]) - 1); }
                            }
                            //else
                            //{
                            //    string checkspace = dt_chitiet_img.Rows[i][Convert.ToInt32(lstrole[k]) - 1].ToString();
                            //    string strclone = checkspace;
                            //    if (checkspace.Trim().Length != strclone.Length && !note_truong31)
                            //    { note_truong31 = true; tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường " + lstrole[k] + " dòng: " + (i + 1) + " có space", z, i, Convert.ToInt32(lstrole[k]) - 1); }
                            //}

                        }
                        for (int l = 1; l < 8; l++)
                        {
                            if (!dtr_form.Rows[0]["Rules"].ToString().Contains((l + 1).ToString()))
                            {
                                if (dt_chitiet_img.Rows[i][l].ToString() != "")
                                {
                                    if (l == 2)
                                    {
                                        if (!note_truong32)
                                        { note_truong32 = true; tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường " + (l + 1) + " dòng: " + (i + 1) + " có vấn đề", z, i, l); }
                                    }
                                    else { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường " + (l + 1) + " dòng: " + (i + 1) + " có vấn đề", z, i, l); }
                                }
                            }
                        }
                    }
                    catch
                    {
                        tb_error_checkLOgic.Rows.Add(name_image, "Role có ký tự đặc biệt: " + dtr_form.Rows[0]["Rules"].ToString() + "", z, i, 0);
                    }
                    //
                    //
                    ///
                    if (dt_chitiet_img.Rows[i][4].ToString() != "")
                    {
                        string checkspace = dt_chitiet_img.Rows[i][4].ToString();
                        string strclone = checkspace;
                        if (checkspace.Trim().Length != strclone.Length)
                        { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 5 dòng: " + (i + 1) + " có space", z, i, 4); }
                        int n;
                        var isNumeric = int.TryParse(dt_chitiet_img.Rows[i][4].ToString(), out n);
                        if (isNumeric == false)
                        {
                            tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 5 dòng: " + (i + 1) + " không phải là Số", z, i, 4);
                        }
                    }
                    for (int t = 0; t < dt_chitiet_img.Columns.Count - 1; t++)
                    {
                        string str_cell_info = dt_chitiet_img.Rows[i][t].ToString();
                        var cell_error = str_cell_info.IndexOfAny(",.＊*@!#".ToCharArray()) != -1;
                        if (cell_error == true)
                        {
                            if (t == 2)
                            {
                                if (!note_truong33)
                                { note_truong33 = true; tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường: " + (t + 1) + " dòng: " + (i + 1) + " kí tự không hợp lệ ", z, i, t); }
                            }
                            else
                            { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường: " + (t + 1) + " dòng: " + (i + 1) + " kí tự không hợp lệ ", z, i, t); }
                        }
                    }
                    string str_data_role4 = dt_chitiet_img.Rows[i][3].ToString();
                    if (str_data_role4 != "")
                    {
                        string checkspace = dt_chitiet_img.Rows[i][3].ToString();
                        string strclone = checkspace;
                        if (checkspace.Trim().Length != strclone.Length)
                        { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 4 dòng: " + (i + 1) + " có space", z, i, 3); }
                        string str_JAN_columnN = check_masterNNC(str_master_NNC, str_data_role4);
                        if (str_JAN_columnN == "")
                        {
                            tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 4 dòng: " + (i + 1) + " không có mã sản phẩm", z, i, 3);
                        }
                    }
                    string str_data_2 = dt_chitiet_img.Rows[i][1].ToString();
                    if (str_data_2 != "")
                    {
                        string checkspace = str_data_2;
                        string strclone = checkspace;
                        if (checkspace.Trim().Length != strclone.Length)
                        { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 2 dòng: " + (i + 1) + " có space", z, i, 1); }
                    }
                    string str_data_3 = dt_chitiet_img.Rows[0][2].ToString();
                    if (str_data_3 != "")
                    {
                        if (!note_truong_space)
                        {
                            string checkspace = str_data_3;
                            string strclone = checkspace;
                            if (checkspace.Trim().Length != strclone.Length)
                            { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 3 dòng: 1 có space", z, 0, 2); }
                            note_truong_space = true;
                        }
                    }
                    string str_data_6 = dt_chitiet_img.Rows[i][5].ToString();
                    if (str_data_6 != "")
                    {
                        string checkspace = str_data_6;
                        string strclone = checkspace;
                        if (checkspace.Trim().Length != strclone.Length)
                        { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 6 dòng: " + (i + 1) + " có space", z, i, 5); }
                    }
                    string str_data_7 = dt_chitiet_img.Rows[i][6].ToString();
                    if (str_data_7 != "")
                    {
                        string checkspace = str_data_7;
                        string strclone = checkspace;
                        if (checkspace.Trim().Length != strclone.Length)
                        { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 7 dòng: " + (i + 1) + " có space", z, i, 6); }
                    }
                    string str_data_8 = dt_chitiet_img.Rows[i][7].ToString();
                    if (str_data_8 != "")
                    {
                        string checkspace = str_data_8;
                        string strclone = checkspace;
                        if (checkspace.Trim().Length != strclone.Length)
                        { tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 8 dòng: " + (i + 1) + " có space", z, i, 7); }
                    }
                    if (str_rsP.Split('-')[0] == "2")
                    {
                        if (dt_chitiet_img.Rows[i][2].ToString() != "")
                        {
                            if (!note_truong34)
                            { note_truong34 = true; tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 3 dòng: " + (i + 1) + " kiểm tra luật xuất trường 3 và 7", z, i, 2); }
                        }
                    }

                    if (str_rsP.Split('-')[0].ToString() == "13")//("13-").ToString() == "13-" || str_rsP.ToString() == "13-2")
                    {
                        //sửa ngày 15/08 Nghĩa kêu xóa
                        //if (dtr_form.Rows[0]["Rules"].ToString().Contains("8"))
                        //{
                        //string str_data_role8 = dt_chitiet_img.Rows[i][7].ToString();
                        //if (str_data_role8 == "")
                        //{
                        //    tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 8 trống dòng: " + (i + 1) + "", z, i, 7);
                        //}
                        //}
                    }
                    if (str_rsP.ToString().Split('-')[0].ToString() == "14")
                    {
                        //sửa ngày 15/08 Nghĩa kêu xóa
                        //if (dtr_form.Rows[0]["Rules"].ToString().Contains("7"))
                        //{
                        //string str_data_role7 = dt_chitiet_img.Rows[i][6].ToString();
                        //if (str_data_role7 == "")
                        //{
                        //    tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 7 trống dòng: " + (i + 1) + "", z, i, 6);
                        //}
                        //}
                        string str_data_role2 = dt_chitiet_img.Rows[i][1].ToString(); //12012022
                        if (str_data_role2.Contains("-") == false)
                        {
                            tb_error_checkLOgic.Rows.Add(name_image, "Trường 2 dòng: " + (i + 1) + " chưa đúng xem SOP", z, i, 1);//Trường 2 dòng....chưa đúng xem SOP
                        }
                    }
                    //Update yêu cầu bổ sung CheckLogic 04112021
                    if (str_truong6_role.Contains(dt_chitiet_img.Rows[i][5].ToString()) == false)
                    {
                        tb_error_checkLOgic.Rows.Add(name_image, "Dữ liệu trường 6 dòng " + (i + 1) + " chứa kí tự không hợp lệ", z, i, 5);
                    }
                }
                //int int_sl_row4 = str_Result.Split('|')[3].ToString().Split('\n').Length;
                //int int_sl_row5 = str_Result.Split('|')[4].ToString().Split('\n').Length;
                //int int_sl_row6 = str_Result.Split('|')[5].ToString().Split('\n').Length;
                //if (int_sl_row4 != int_sl_row5 )
                //{
                //    tb_error_checkLOgic.Rows.Add(name_image, "Số lượng dòng khác nhau: 4 -- 5 ", z);
                //}
                //if (int_sl_row4 != int_sl_row6)
                //{
                //    tb_error_checkLOgic.Rows.Add(name_image, "Số lượng dòng khác nhau: 4 -- 6 ", z);
                //}
            }
            if (tb_error_checkLOgic.Rows.Count > 0)
            {
                splitContainer2.SplitterDistance = splitContainer2.Height * 3 / 4;
                grid_checkLogic.DataSource = null;
                grid_checkLogic.DataSource = tb_error_checkLOgic;
                gridV_checkLogic.Columns[0].OptionsColumn.ReadOnly = true;
                gridV_checkLogic.Columns[2].Visible = false;
                gridV_checkLogic.Columns[3].Visible = false;
                gridV_checkLogic.Columns[4].Visible = false;
                gridV_checkLogic.Columns[5].Visible = false;
                gridV_Export.BestFitColumns();
            }
            else
            {
                MessageBox.Show("CheckLogic not Error--> Continue  !!!");
            }
        }

        private void btn_checkLogic_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Function CheckLogic", btn_checkLogic);
        }
        private void btn_export_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Export Data", btn_export);
        }
        private void btn_save_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Save Changed Data", btn_save);
        }
        private void btn_Done_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Submit Form", btn_Done);
        }
        private void gridV_checkLogic_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int r = e.RowHandle;
            int cl = e.Column.ColumnHandle;
            string columname = e.Column.FieldName;
            if (r > -1)
            {
                if (gridV_checkLogic.GetRowCellValue(e.RowHandle, gridV_checkLogic.Columns["Select_index"]).ToString() == "1")
                {
                    if (e.Column.FieldName == "Name_Image")
                    {
                        e.Appearance.BackColor = Color.SteelBlue;
                    }
                }
            }
        }
        private void gridV_checkLogic_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            int r = e.FocusedRowHandle;
            if (r > -1)
            {
                string tenanh = gridV_checkLogic.GetRowCellValue(e.FocusedRowHandle, "Select_index").ToString();
                tb_error_checkLOgic.Rows[r]["Select_index"] = "1";
                string str_info_grdimg = tb_error_checkLOgic.Rows[r][2].ToString() + "|" + tb_error_checkLOgic.Rows[r][3].ToString() + "|" + tb_error_checkLOgic.Rows[r][4].ToString();
                grid_img.Focus();
                gridV_Img.FocusedRowHandle = Convert.ToInt32(tb_error_checkLOgic.Rows[r][2].ToString());
                grid_data.Focus();
                gridV_data.FocusedRowHandle = Convert.ToInt32(tb_error_checkLOgic.Rows[r][3].ToString());
                ColumnView View = (ColumnView)grid_data.FocusedView;
                GridColumn column = View.Columns[dt_chitiet_img.Columns[Convert.ToInt32(tb_error_checkLOgic.Rows[r][4].ToString())].ToString()];
                gridV_data.FocusedColumn = column;
                ColumnView View1 = (ColumnView)grid_checkLogic.FocusedView;
                GridColumn column1 = View1.Columns["Name_Image"];
                grid_checkLogic.Focus();
                gridV_checkLogic.FocusedRowHandle = r;
            }
        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
