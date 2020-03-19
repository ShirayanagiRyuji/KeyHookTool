using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyHoldTool.UserControls
{
    public partial class KeySettingPanel : UserControl
    {
        /// <summary>
        /// 入力機器選択
        /// </summary>
        public enum InputDevice
        {
            /// <summary>
            /// キーボード
            /// </summary>
            Keybord,

            /// <summary>
            /// マウス
            /// </summary>
            Mouse
        }

        /// <summary>
        /// 項目の見出し
        /// </summary>
        public string Title
        {
            get
            {
                return groupBoxSettings.Text;
            }
            set
            {
                groupBoxSettings.Text = value;
            }
        }

        /// <summary>
        /// Shiftキー状態
        /// </summary>
        public bool Shift
        {
            get
            {
                return checkBoxShift.Checked;
            }
            set
            {
                checkBoxShift.Checked = value;
            }
        }

        /// <summary>
        /// Ctrlキー状態
        /// </summary>
        public bool Ctrl
        {
            get
            {
                return checkBoxCtrl.Checked;
            }
            set
            {
                checkBoxCtrl.Checked = value;
            }
        }

        /// <summary>
        /// Altキー状態
        /// </summary>
        public bool Alt
        {
            get
            {
                return checkBoxAlt.Checked;
            }
            set
            {
                checkBoxAlt.Checked = value;
            }
        }

        /// <summary>
        /// キーボードのキー
        /// </summary>
        public string Key
        {
            get
            {
                return textBoxKey.Text;
            }
            set
            {
                textBoxKey.Text = value;
            }
        }

        /// <summary>
        /// マウスボタン
        /// </summary>
        public string MouseButton
        {
            get
            {
                return comboBoxButton.Text;
            }
            set
            {
                comboBoxButton.Text = value;
            }
        }

        /// <summary>
        /// 入力機器
        /// </summary>
        public InputDevice Input
        {
            get
            {
                return (radioButtonKeybord.Checked == true ? InputDevice.Keybord : InputDevice.Mouse);
            }
            set
            {
                switch (value)
                {
                    case InputDevice.Keybord:
                        radioButtonKeybord.Checked = true;
                        break;

                    case InputDevice.Mouse:
                        radioButtonMouse.Checked = false;
                        break;
                }
            }

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public KeySettingPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonKeybord_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKey.Enabled = radioButtonKeybord.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonMouse_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxButton.Enabled = radioButtonKeybord.Checked;
        }
    }
}
