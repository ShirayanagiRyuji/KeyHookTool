using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 追加した参照
using System.Windows.Forms;

namespace KeyHoldTool.UserControls
{
    public class KeyInputTextBox :TextBox
    {
        #region インスタンスフィールド
        /// <summary>
        /// キー名称変換辞書
        /// </summary>
        private static Dictionary<Keys, string> f_KeyName = new Dictionary<Keys, string>();

        #endregion インスタンスフィールド


        #region プロパティ
        /// <summary>
        /// 入力キー値
        /// </summary>
        public int KeyData { get; protected set; }

        #endregion プロパティ


        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public KeyInputTextBox()
        {
            KeyData = 0;

            // 初期値の設定
            this.ImeMode = ImeMode.Off;

            // イベント設定
            this.KeyDown += this_KeyDown;
            this.KeyPress += (s, e) => { e.Handled = true; };                   // キー入力をキャンセル（テキストエリアへ反映しない）
            this.ImeModeChanged += (s, e) => { this.ImeMode = ImeMode.Off; };   // IMEモード変更をキャンセル（Off固定にする）
        }
        #endregion コンストラクタ


        #region イベント
        /// <summary>
        /// キー押下時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            // 全リセット
            KeyData = 0;

            // 入力エリアへ表示するテキスト
            StringBuilder viewText = new StringBuilder();

            switch  (e.KeyValue)
            {
                case (int)Keys.None:    // なし
                case (int)Keys.Alt:
                case (int)Keys.ControlKey:
                case (int)Keys.LControlKey:
                case (int)Keys.RControlKey:
                case (int)Keys.ShiftKey:
                case (int)Keys.LShiftKey:
                case (int)Keys.RShiftKey:
                    // 何もしない
                    break;

                default:
		            if (f_KeyName.ContainsKey(e.KeyCode) == true)
		            {
		                viewText.Append(f_KeyName[e.KeyCode]);
		            }
		            else
		            {
		                KeysConverter kc = new KeysConverter();
		                viewText.Append(kc.ConvertToString(e.KeyCode));
		            }
		            KeyData = (int)e.KeyData;
                break;
            }

            // Textへの設定は1回だけにしないと、毎回ChnageTextイベントが走る
            this.Text = viewText.ToString();

            e.Handled = true;
        }
        #endregion イベント


        #region メソッド

        #region メソッド public static
        /// <summary>
        /// キー名称変換辞書登録
        /// </summary>
        /// <param name="keyNameMap">
        /// キー名称とキーコードのリスト
        /// TKey : キー名称 System.Windows.Forms.Keys.ToString() と等しくないと正常に登録できない
        /// TValue : 表示するキー名称 任意の文字列
        /// </param>
        public static void SetKeyNameDictionary(IDictionary<string, string> keyNameMap)
        {
            // 表示用キー名称の設定
            foreach (var keyName in keyNameMap)
            {
                if (typeof(Keys).GetEnumNames().Where(w => w == keyName.Key).Count() > 0)
                {
                    Keys keyCode = (Keys)Enum.Parse(typeof(Keys), keyName.Key, true);   // 列挙型へ変換
                    f_KeyName.Add(keyCode, keyName.Value);
                }
            }
        }
        #endregion メソッド public static


        /// <summary>
        /// キー情報登録
        /// </summary>
        /// <param name="keyData"></param>
        public void SetKeyData(int keyData)
        {
            this_KeyDown(this, new KeyEventArgs((Keys)keyData));
        }
        #endregion メソッド
    }
}
