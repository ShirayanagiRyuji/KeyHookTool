namespace KeyHoldTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonInitialize = new System.Windows.Forms.Button();
            this.keySettingPanelStart = new KeyHoldTool.UserControls.KeySettingPanel();
            this.keySettingPanelHold = new KeyHoldTool.UserControls.KeySettingPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(201, 316);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(71, 34);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(114, 316);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(71, 34);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonInitialize
            // 
            this.buttonInitialize.Location = new System.Drawing.Point(12, 316);
            this.buttonInitialize.Name = "buttonInitialize";
            this.buttonInitialize.Size = new System.Drawing.Size(71, 34);
            this.buttonInitialize.TabIndex = 4;
            this.buttonInitialize.Text = "Initialize";
            this.buttonInitialize.UseVisualStyleBackColor = true;
            this.buttonInitialize.Click += new System.EventHandler(this.buttonInitialize_Click);
            // 
            // keySettingPanelStart
            // 
            this.keySettingPanelStart.Alt = false;
            this.keySettingPanelStart.Ctrl = false;
            this.keySettingPanelStart.Key = "";
            this.keySettingPanelStart.Location = new System.Drawing.Point(10, 157);
            this.keySettingPanelStart.MouseButton = "";
            this.keySettingPanelStart.Name = "keySettingPanelStart";
            this.keySettingPanelStart.Shift = false;
            this.keySettingPanelStart.Size = new System.Drawing.Size(262, 139);
            this.keySettingPanelStart.TabIndex = 1;
            this.keySettingPanelStart.Title = "StartKey";
            // 
            // keySettingPanelHold
            // 
            this.keySettingPanelHold.Alt = false;
            this.keySettingPanelHold.Ctrl = false;
            this.keySettingPanelHold.Key = "";
            this.keySettingPanelHold.Location = new System.Drawing.Point(10, 12);
            this.keySettingPanelHold.MouseButton = "";
            this.keySettingPanelHold.Name = "keySettingPanelHold";
            this.keySettingPanelHold.Shift = false;
            this.keySettingPanelHold.Size = new System.Drawing.Size(262, 139);
            this.keySettingPanelHold.TabIndex = 0;
            this.keySettingPanelHold.Title = "HoldKey";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.buttonInitialize);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.keySettingPanelStart);
            this.Controls.Add(this.keySettingPanelHold);
            this.Name = "FormMain";
            this.Text = "KeyHoldTool";
            this.ClientSizeChanged += new System.EventHandler(this.FormMain_ClientSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.KeySettingPanel keySettingPanelHold;
        private UserControls.KeySettingPanel keySettingPanelStart;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonInitialize;
        private System.Windows.Forms.NotifyIcon notifyIcon1;

    }
}

