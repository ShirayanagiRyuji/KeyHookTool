using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyHoldTool
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームサイズ変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// https://www.itlab51.com/?p=2482
        /// </remarks>
        private void FormMain_ClientSizeChanged(object sender, EventArgs e)
        {
            notifyIcon1.Icon = new Icon(@"C:\Windows\Installer\{FF6BA80C-E7E4-3BA8-945D-BC6EC31E41C4}\Icon_msi.ico");

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }

        /// <summary>
        /// タスクトレイ上のアイコンダブルクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// https://www.itlab51.com/?p=2482
        /// </remarks>
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            notifyIcon1.Icon = null;
        }

        /// <summary>
        /// Initializeボタンクリク時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInitialize_Click(object sender, EventArgs e)
        {
            // アプリ初期値を設定
            SetInitialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初期値設定
        /// </summary>
        private void SetInitialize()
        {
            keySettingPanelHold.Input = UserControls.KeySettingPanel.InputDevice.Mouse;
            keySettingPanelHold.Key = "S";
            keySettingPanelHold.MouseButton = "Right";
            keySettingPanelHold.Shift = true;
            keySettingPanelHold.Ctrl = true;
            keySettingPanelHold.Alt = true;

            keySettingPanelStart.Input = UserControls.KeySettingPanel.InputDevice.Keybord;
            keySettingPanelStart.Key = "H";
            keySettingPanelStart.MouseButton = "Left";
            keySettingPanelStart.Shift = false;
            keySettingPanelStart.Ctrl = false;
            keySettingPanelStart.Alt = false;

        }

    }
}
