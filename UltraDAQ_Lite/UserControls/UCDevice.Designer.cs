namespace UltraDAQ_Lite.UserControls
{
    partial class UCDevice
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.iconPictureBox_State = new FontAwesome.Sharp.IconPictureBox();
            this.checkBox_IsChoose = new System.Windows.Forms.CheckBox();
            this.label_DevSubName = new System.Windows.Forms.Label();
            this.label_SN = new System.Windows.Forms.Label();
            this.label_IP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox_State)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox_State
            // 
            this.iconPictureBox_State.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox_State.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox_State.IconChar = FontAwesome.Sharp.IconChar.Link;
            this.iconPictureBox_State.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox_State.IconSize = 25;
            this.iconPictureBox_State.Location = new System.Drawing.Point(2, 0);
            this.iconPictureBox_State.Name = "iconPictureBox_State";
            this.iconPictureBox_State.Size = new System.Drawing.Size(25, 26);
            this.iconPictureBox_State.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox_State.TabIndex = 0;
            this.iconPictureBox_State.TabStop = false;
            // 
            // checkBox_IsChoose
            // 
            this.checkBox_IsChoose.AutoSize = true;
            this.checkBox_IsChoose.Location = new System.Drawing.Point(4, 47);
            this.checkBox_IsChoose.Name = "checkBox_IsChoose";
            this.checkBox_IsChoose.Size = new System.Drawing.Size(15, 14);
            this.checkBox_IsChoose.TabIndex = 1;
            this.checkBox_IsChoose.UseVisualStyleBackColor = true;
            this.checkBox_IsChoose.CheckedChanged += new System.EventHandler(this.checkBox_IsChoose_CheckedChanged);
            // 
            // label_DevSubName
            // 
            this.label_DevSubName.AutoSize = true;
            this.label_DevSubName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DevSubName.Location = new System.Drawing.Point(36, 3);
            this.label_DevSubName.Name = "label_DevSubName";
            this.label_DevSubName.Size = new System.Drawing.Size(88, 19);
            this.label_DevSubName.TabIndex = 2;
            this.label_DevSubName.Text = "Device_001";
            // 
            // label_SN
            // 
            this.label_SN.AutoSize = true;
            this.label_SN.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SN.Location = new System.Drawing.Point(36, 27);
            this.label_SN.Name = "label_SN";
            this.label_SN.Size = new System.Drawing.Size(129, 17);
            this.label_SN.TabIndex = 3;
            this.label_SN.Text = "序列号:DS8A8064000";
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_IP.Location = new System.Drawing.Point(36, 48);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(95, 17);
            this.label_IP.TabIndex = 4;
            this.label_IP.Text = "IP:172.18.8.199";
            // 
            // UCDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.label_SN);
            this.Controls.Add(this.label_DevSubName);
            this.Controls.Add(this.checkBox_IsChoose);
            this.Controls.Add(this.iconPictureBox_State);
            this.Name = "UCDevice";
            this.Size = new System.Drawing.Size(236, 71);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox_State)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox iconPictureBox_State;
        private System.Windows.Forms.CheckBox checkBox_IsChoose;
        private System.Windows.Forms.Label label_DevSubName;
        private System.Windows.Forms.Label label_SN;
        private System.Windows.Forms.Label label_IP;
    }
}
