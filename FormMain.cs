using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 追加した参照
using KeyHoldTool.UserControls;
using MMFrame.Windows.GlobalHook;
using MMFrame.Windows.Simulation;

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

        #region イベント

        #region イベント フォーム
        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            SetInitialize();

            this.TopMost = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 停止
            HookStop();
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
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Text = this.Text;

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }
        #endregion イベント フォーム

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
            try
            {
                this.Enabled = false;

                // アプリ初期値を設定
                SetInitialize();
            }
            finally
            {
                this.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                // 保存前の状態へ戻す

                // テスト用
                {
                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
                    HoldStart();

                    HoldStop();
                }

            }
            finally
            {
                this.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                // 外部ファイルへ保存


                // フック情報を更新
                HookStart();
            }
            finally
            {
                this.Enabled = true;
            }
        }

        #region キー入力フック
        /// <summary>
        /// キーボードからの入力フック
        /// </summary>
        /// <param name="s"></param>
        public void hookKey(ref KeyboardHook.StateKeyboard s)
        {
            // キー押下時に処理実行
            if (s.Stroke == KeyboardHook.Stroke.KEY_DOWN)
            {
                //if (s.) (s.Key | Keys.H)
                HoldStart();
            }
        }

        /// <summary>
        /// マウスからの入力フック
        /// </summary>
        /// <param name="s"></param>
        public void hookMouse(ref MouseHook.StateMouse s)
        {
            // マウス押下時に処理実行
            if ((s.Stroke == MouseHook.Stroke.LEFT_DOWN)
             || (s.Stroke == MouseHook.Stroke.RIGHT_DOWN)
             || (s.Stroke == MouseHook.Stroke.MIDDLE_DOWN)
             || (s.Stroke == MouseHook.Stroke.WHEEL_DOWN))
            {
                HoldStart();
            }
        }
        #endregion キーフック

        #endregion イベント


        #region メソッド

        /// <summary>
        /// 初期値設定
        /// </summary>
        private void SetInitialize()
        {
            // 固定キー設定
            keySettingPanelHold.InputMode = UserControls.KeySettingPanel.InputDevice.Mouse;
            keySettingPanelHold.Key = "S";
            keySettingPanelHold.MouseButton = "Right";
            keySettingPanelHold.Shift = false;
            keySettingPanelHold.Ctrl = false;
            keySettingPanelHold.Alt = false;

            // 固定開始キー設定
            keySettingPanelStart.InputMode = UserControls.KeySettingPanel.InputDevice.Keybord;
            keySettingPanelStart.Key = "H";
            keySettingPanelStart.MouseButton = "Left";
            keySettingPanelStart.Shift = false;
            keySettingPanelStart.Ctrl = true;
            keySettingPanelStart.Alt = true;

        }

        /// <summary>
        /// キーボード、マウスの取得開始
        /// </summary>
        private void HookStart()
        {
            // キー入力フックを停止
            HookStop();

            switch (keySettingPanelStart.InputMode)
            {
                case KeySettingPanel.InputDevice.Keybord:
                    {
                        KeyboardHook.AddEvent(hookKey);
                        KeyboardHook.Start();
                    }
                    break;

                case KeySettingPanel.InputDevice.Mouse:
                    {
                        MouseHook.AddEvent(hookMouse);
                        MouseHook.Start();
                    }
                    break;
            }
        }

        /// <summary>
        /// キーボード、マウスの取得終了
        /// </summary>
        private void HookStop()
        {
            if ((MouseHook.IsHooking == true)
             || (KeyboardHook.IsHooking == true))
            {
                MouseHook.Stop();
                KeyboardHook.Stop();
            }
        }

        /// <summary>
        /// キーボード、マウスの固定開始
        /// </summary>
        private void HoldStart()
        {
            List<InputSimulator.Input> inputs = new List<InputSimulator.Input>();
            List<InputSimulator.MouseStroke> mouseFlags = new List<InputSimulator.MouseStroke>();

            mouseFlags.Add(InputSimulator.MouseStroke.LEFT_DOWN);

            InputSimulator.AddMouseInput(ref inputs, mouseFlags, 0, false, 0, 0);
            //InputSimulator.AddKeyboardInput(ref inputs, "ゆっくりしていってね！！");

            InputSimulator.SendInput(inputs);
        }

        private void HoldStop()
        {
            List<InputSimulator.Input> inputs = new List<InputSimulator.Input>();
            InputSimulator.MouseStroke[]  mouseFlags = new []
                {
                    InputSimulator.MouseStroke.LEFT_UP,
                    InputSimulator.MouseStroke.RIGHT_UP,
                    InputSimulator.MouseStroke.MIDDLE_UP
                };

            InputSimulator.AddMouseInput(ref inputs, mouseFlags, 0, false, 0, 0);
            InputSimulator.AddKeyboardInput(ref inputs, (int)InputSimulator.KeyboardStroke.KEY_UP, 0, 0, 0, 0);

            InputSimulator.SendInput(inputs);
        }

        #endregion メソッド

    }
}
