namespace UltraDAQ_Lite
{
    partial class Form_Main
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            this.panel_FunctionItem = new System.Windows.Forms.Panel();
            this.iconButton_WaveView = new FontAwesome.Sharp.IconButton();
            this.iconButton_ConfgDev = new FontAwesome.Sharp.IconButton();
            this.iconButton_DockLeft = new FontAwesome.Sharp.IconButton();
            this.iconButton_DockRight = new FontAwesome.Sharp.IconButton();
            this.panel_Module = new System.Windows.Forms.Panel();
            this.menuStrip_Main.SuspendLayout();
            this.panel_FunctionItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Help});
            this.menuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Main.Name = "menuStrip_Main";
            this.menuStrip_Main.Size = new System.Drawing.Size(1134, 25);
            this.menuStrip_Main.TabIndex = 1;
            this.menuStrip_Main.Text = "菜单栏";
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem2,
            this.iconMenuItem3});
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(47, 21);
            this.ToolStripMenuItem_Help.Text = "Help";
            // 
            // iconMenuItem2
            // 
            this.iconMenuItem2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.HSquare;
            this.iconMenuItem2.IconColor = System.Drawing.Color.Teal;
            this.iconMenuItem2.IconSize = 16;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Rotation = 0D;
            this.iconMenuItem2.Size = new System.Drawing.Size(188, 30);
            this.iconMenuItem2.Text = "User Manual";
            // 
            // iconMenuItem3
            // 
            this.iconMenuItem3.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.RProject;
            this.iconMenuItem3.IconColor = System.Drawing.Color.Orange;
            this.iconMenuItem3.IconSize = 16;
            this.iconMenuItem3.Name = "iconMenuItem3";
            this.iconMenuItem3.Rotation = 0D;
            this.iconMenuItem3.Size = new System.Drawing.Size(188, 30);
            this.iconMenuItem3.Text = "About";
            // 
            // panel_FunctionItem
            // 
            this.panel_FunctionItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel_FunctionItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_FunctionItem.Controls.Add(this.iconButton_WaveView);
            this.panel_FunctionItem.Controls.Add(this.iconButton_ConfgDev);
            this.panel_FunctionItem.Controls.Add(this.iconButton_DockLeft);
            this.panel_FunctionItem.Controls.Add(this.iconButton_DockRight);
            this.panel_FunctionItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_FunctionItem.Location = new System.Drawing.Point(0, 25);
            this.panel_FunctionItem.Name = "panel_FunctionItem";
            this.panel_FunctionItem.Size = new System.Drawing.Size(121, 610);
            this.panel_FunctionItem.TabIndex = 4;
            // 
            // iconButton_WaveView
            // 
            this.iconButton_WaveView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_WaveView.FlatAppearance.BorderSize = 0;
            this.iconButton_WaveView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_WaveView.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_WaveView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton_WaveView.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.iconButton_WaveView.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(101)))), ((int)(((byte)(176)))));
            this.iconButton_WaveView.IconSize = 27;
            this.iconButton_WaveView.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton_WaveView.Location = new System.Drawing.Point(2, 98);
            this.iconButton_WaveView.Name = "iconButton_WaveView";
            this.iconButton_WaveView.Rotation = 0D;
            this.iconButton_WaveView.Size = new System.Drawing.Size(117, 42);
            this.iconButton_WaveView.TabIndex = 16;
            this.iconButton_WaveView.Text = "Wav Disp";
            this.iconButton_WaveView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_WaveView.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.iconButton_WaveView.UseVisualStyleBackColor = true;
            this.iconButton_WaveView.Click += new System.EventHandler(this.iconButton_WaveView_Click);
            // 
            // iconButton_ConfgDev
            // 
            this.iconButton_ConfgDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_ConfgDev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.iconButton_ConfgDev.FlatAppearance.BorderSize = 0;
            this.iconButton_ConfgDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_ConfgDev.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_ConfgDev.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton_ConfgDev.ForeColor = System.Drawing.Color.Black;
            this.iconButton_ConfgDev.IconChar = FontAwesome.Sharp.IconChar.Retweet;
            this.iconButton_ConfgDev.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(101)))), ((int)(((byte)(176)))));
            this.iconButton_ConfgDev.IconSize = 27;
            this.iconButton_ConfgDev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton_ConfgDev.Location = new System.Drawing.Point(2, 40);
            this.iconButton_ConfgDev.Name = "iconButton_ConfgDev";
            this.iconButton_ConfgDev.Rotation = 0D;
            this.iconButton_ConfgDev.Size = new System.Drawing.Size(117, 36);
            this.iconButton_ConfgDev.TabIndex = 13;
            this.iconButton_ConfgDev.Text = "Inst Config";
            this.iconButton_ConfgDev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_ConfgDev.UseVisualStyleBackColor = false;
            this.iconButton_ConfgDev.Click += new System.EventHandler(this.iconButton_ConfgDev_Click);
            // 
            // iconButton_DockLeft
            // 
            this.iconButton_DockLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_DockLeft.FlatAppearance.BorderSize = 0;
            this.iconButton_DockLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_DockLeft.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_DockLeft.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.iconButton_DockLeft.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.iconButton_DockLeft.IconSize = 20;
            this.iconButton_DockLeft.Location = new System.Drawing.Point(96, 6);
            this.iconButton_DockLeft.Name = "iconButton_DockLeft";
            this.iconButton_DockLeft.Rotation = 0D;
            this.iconButton_DockLeft.Size = new System.Drawing.Size(20, 20);
            this.iconButton_DockLeft.TabIndex = 12;
            this.iconButton_DockLeft.UseVisualStyleBackColor = true;
            this.iconButton_DockLeft.Click += new System.EventHandler(this.iconButton_DockLeft_Click);
            // 
            // iconButton_DockRight
            // 
            this.iconButton_DockRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_DockRight.FlatAppearance.BorderSize = 0;
            this.iconButton_DockRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_DockRight.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_DockRight.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.iconButton_DockRight.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.iconButton_DockRight.IconSize = 20;
            this.iconButton_DockRight.Location = new System.Drawing.Point(1, 6);
            this.iconButton_DockRight.Name = "iconButton_DockRight";
            this.iconButton_DockRight.Rotation = 0D;
            this.iconButton_DockRight.Size = new System.Drawing.Size(20, 20);
            this.iconButton_DockRight.TabIndex = 11;
            this.iconButton_DockRight.UseVisualStyleBackColor = true;
            this.iconButton_DockRight.Click += new System.EventHandler(this.iconButton_DockRight_Click);
            // 
            // panel_Module
            // 
            this.panel_Module.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Module.Location = new System.Drawing.Point(121, 25);
            this.panel_Module.Name = "panel_Module";
            this.panel_Module.Size = new System.Drawing.Size(1013, 610);
            this.panel_Module.TabIndex = 5;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 635);
            this.Controls.Add(this.panel_Module);
            this.Controls.Add(this.panel_FunctionItem);
            this.Controls.Add(this.menuStrip_Main);
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.panel_FunctionItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private System.Windows.Forms.Panel panel_FunctionItem;
        private FontAwesome.Sharp.IconButton iconButton_ConfgDev;
        private FontAwesome.Sharp.IconButton iconButton_DockLeft;
        private FontAwesome.Sharp.IconButton iconButton_DockRight;
        private System.Windows.Forms.Panel panel_Module;
        private FontAwesome.Sharp.IconButton iconButton_WaveView;
    }
}

