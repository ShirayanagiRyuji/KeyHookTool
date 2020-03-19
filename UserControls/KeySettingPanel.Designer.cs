namespace KeyHoldTool.UserControls
{
    partial class KeySettingPanel
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.comboBoxButton = new System.Windows.Forms.ComboBox();
            this.radioButtonMouse = new System.Windows.Forms.RadioButton();
            this.radioButtonKeybord = new System.Windows.Forms.RadioButton();
            this.checkBoxAlt = new System.Windows.Forms.CheckBox();
            this.checkBoxCtrl = new System.Windows.Forms.CheckBox();
            this.checkBoxShift = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.textBoxKey);
            this.groupBoxSettings.Controls.Add(this.comboBoxButton);
            this.groupBoxSettings.Controls.Add(this.radioButtonMouse);
            this.groupBoxSettings.Controls.Add(this.radioButtonKeybord);
            this.groupBoxSettings.Controls.Add(this.checkBoxAlt);
            this.groupBoxSettings.Controls.Add(this.checkBoxCtrl);
            this.groupBoxSettings.Controls.Add(this.checkBoxShift);
            this.groupBoxSettings.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxSettings.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(260, 137);
            this.groupBoxSettings.TabIndex = 4;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "StartKey";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(130, 21);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(100, 23);
            this.textBoxKey.TabIndex = 7;
            // 
            // comboBoxButton
            // 
            this.comboBoxButton.FormattingEnabled = true;
            this.comboBoxButton.Items.AddRange(new object[] {
            "Left",
            "Light",
            "Middle",
            "Wheel"});
            this.comboBoxButton.Location = new System.Drawing.Point(130, 47);
            this.comboBoxButton.Name = "comboBoxButton";
            this.comboBoxButton.Size = new System.Drawing.Size(121, 24);
            this.comboBoxButton.TabIndex = 6;
            // 
            // radioButtonMouse
            // 
            this.radioButtonMouse.AutoSize = true;
            this.radioButtonMouse.Location = new System.Drawing.Point(16, 48);
            this.radioButtonMouse.Name = "radioButtonMouse";
            this.radioButtonMouse.Size = new System.Drawing.Size(69, 20);
            this.radioButtonMouse.TabIndex = 4;
            this.radioButtonMouse.TabStop = true;
            this.radioButtonMouse.Text = "Mouse";
            this.radioButtonMouse.UseVisualStyleBackColor = true;
            this.radioButtonMouse.CheckedChanged += new System.EventHandler(this.radioButtonMouse_CheckedChanged);
            // 
            // radioButtonKeybord
            // 
            this.radioButtonKeybord.AutoSize = true;
            this.radioButtonKeybord.Checked = true;
            this.radioButtonKeybord.Location = new System.Drawing.Point(16, 22);
            this.radioButtonKeybord.Name = "radioButtonKeybord";
            this.radioButtonKeybord.Size = new System.Drawing.Size(82, 20);
            this.radioButtonKeybord.TabIndex = 3;
            this.radioButtonKeybord.TabStop = true;
            this.radioButtonKeybord.Text = "Keybord";
            this.radioButtonKeybord.UseVisualStyleBackColor = true;
            this.radioButtonKeybord.CheckedChanged += new System.EventHandler(this.radioButtonKeybord_CheckedChanged);
            // 
            // checkBoxAlt
            // 
            this.checkBoxAlt.AutoSize = true;
            this.checkBoxAlt.Location = new System.Drawing.Point(16, 105);
            this.checkBoxAlt.Name = "checkBoxAlt";
            this.checkBoxAlt.Size = new System.Drawing.Size(46, 20);
            this.checkBoxAlt.TabIndex = 2;
            this.checkBoxAlt.Text = "Alt";
            this.checkBoxAlt.UseVisualStyleBackColor = true;
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(130, 79);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(53, 20);
            this.checkBoxCtrl.TabIndex = 1;
            this.checkBoxCtrl.Text = "Ctrl";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            // 
            // checkBoxShift
            // 
            this.checkBoxShift.AutoSize = true;
            this.checkBoxShift.Location = new System.Drawing.Point(16, 79);
            this.checkBoxShift.Name = "checkBoxShift";
            this.checkBoxShift.Size = new System.Drawing.Size(59, 20);
            this.checkBoxShift.TabIndex = 0;
            this.checkBoxShift.Text = "Shift";
            this.checkBoxShift.UseVisualStyleBackColor = true;
            // 
            // KeySettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxSettings);
            this.Name = "KeySettingPanel";
            this.Size = new System.Drawing.Size(262, 139);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.RadioButton radioButtonMouse;
        private System.Windows.Forms.RadioButton radioButtonKeybord;
        private System.Windows.Forms.CheckBox checkBoxAlt;
        private System.Windows.Forms.CheckBox checkBoxCtrl;
        private System.Windows.Forms.CheckBox checkBoxShift;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.ComboBox comboBoxButton;
    }
}
