namespace UltraDAQ_Lite.SubForm
{
    partial class Form_DeviceConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel_DeviceManager = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_AddDevice = new System.Windows.Forms.Panel();
            this.iconButton_DelDev = new FontAwesome.Sharp.IconButton();
            this.iconButton_Add = new FontAwesome.Sharp.IconButton();
            this.panel_Channel = new System.Windows.Forms.Panel();
            this.panel_channelDateGridView = new System.Windows.Forms.Panel();
            this.dataGridView_ChanSet = new System.Windows.Forms.DataGridView();
            this.panel_ChannelCommon = new System.Windows.Forms.Panel();
            this.iconButton_Config = new FontAwesome.Sharp.IconButton();
            this.comboBox_HoriOffsetUnit = new System.Windows.Forms.ComboBox();
            this.textBox_HoriOffset = new System.Windows.Forms.TextBox();
            this.label_Offset = new System.Windows.Forms.Label();
            this.comboBox_StorgeDepth = new System.Windows.Forms.ComboBox();
            this.label_MemDepth = new System.Windows.Forms.Label();
            this.comboBox_HorTimeUnit = new System.Windows.Forms.ComboBox();
            this.textBox_HorTime = new System.Windows.Forms.TextBox();
            this.label_TrigTime = new System.Windows.Forms.Label();
            this.comboBox_TrigHoldUnit = new System.Windows.Forms.ComboBox();
            this.textBox_TrigHold = new System.Windows.Forms.TextBox();
            this.label_TrigHoldOff = new System.Windows.Forms.Label();
            this.comboBox_TriggerLevelUnit = new System.Windows.Forms.ComboBox();
            this.textBox_TriggerLevel = new System.Windows.Forms.TextBox();
            this.label_TrigLevel = new System.Windows.Forms.Label();
            this.comboBox_TrigStyle = new System.Windows.Forms.ComboBox();
            this.label_TrigMode = new System.Windows.Forms.Label();
            this.comboBox_TriggeSource = new System.Windows.Forms.ComboBox();
            this.label_TrigSource = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Collect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impedance = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Coupling = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProbeRatio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Open = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel_AddDevice.SuspendLayout();
            this.panel_Channel.SuspendLayout();
            this.panel_channelDateGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChanSet)).BeginInit();
            this.panel_ChannelCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel_DeviceManager);
            this.panel1.Controls.Add(this.panel_AddDevice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 588);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel_DeviceManager
            // 
            this.flowLayoutPanel_DeviceManager.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel_DeviceManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_DeviceManager.Location = new System.Drawing.Point(0, 65);
            this.flowLayoutPanel_DeviceManager.Name = "flowLayoutPanel_DeviceManager";
            this.flowLayoutPanel_DeviceManager.Size = new System.Drawing.Size(245, 523);
            this.flowLayoutPanel_DeviceManager.TabIndex = 1;
            // 
            // panel_AddDevice
            // 
            this.panel_AddDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_AddDevice.Controls.Add(this.iconButton_DelDev);
            this.panel_AddDevice.Controls.Add(this.iconButton_Add);
            this.panel_AddDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_AddDevice.Location = new System.Drawing.Point(0, 0);
            this.panel_AddDevice.Name = "panel_AddDevice";
            this.panel_AddDevice.Size = new System.Drawing.Size(245, 65);
            this.panel_AddDevice.TabIndex = 0;
            // 
            // iconButton_DelDev
            // 
            this.iconButton_DelDev.FlatAppearance.BorderSize = 0;
            this.iconButton_DelDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_DelDev.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_DelDev.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton_DelDev.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.iconButton_DelDev.IconColor = System.Drawing.Color.Green;
            this.iconButton_DelDev.IconSize = 35;
            this.iconButton_DelDev.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton_DelDev.Location = new System.Drawing.Point(141, 4);
            this.iconButton_DelDev.Name = "iconButton_DelDev";
            this.iconButton_DelDev.Rotation = 0D;
            this.iconButton_DelDev.Size = new System.Drawing.Size(68, 55);
            this.iconButton_DelDev.TabIndex = 22;
            this.iconButton_DelDev.Text = "Delete";
            this.iconButton_DelDev.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton_DelDev.UseVisualStyleBackColor = true;
            this.iconButton_DelDev.Click += new System.EventHandler(this.iconButton_DelDev_Click);
            // 
            // iconButton_Add
            // 
            this.iconButton_Add.FlatAppearance.BorderSize = 0;
            this.iconButton_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Add.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton_Add.IconChar = FontAwesome.Sharp.IconChar.XingSquare;
            this.iconButton_Add.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.iconButton_Add.IconSize = 35;
            this.iconButton_Add.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton_Add.Location = new System.Drawing.Point(31, 4);
            this.iconButton_Add.Name = "iconButton_Add";
            this.iconButton_Add.Rotation = 0D;
            this.iconButton_Add.Size = new System.Drawing.Size(68, 55);
            this.iconButton_Add.TabIndex = 20;
            this.iconButton_Add.Text = "Reg Dev";
            this.iconButton_Add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton_Add.UseVisualStyleBackColor = true;
            this.iconButton_Add.Click += new System.EventHandler(this.iconButton_Add_Click);
            // 
            // panel_Channel
            // 
            this.panel_Channel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Channel.Controls.Add(this.panel_channelDateGridView);
            this.panel_Channel.Controls.Add(this.panel_ChannelCommon);
            this.panel_Channel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Channel.Location = new System.Drawing.Point(245, 0);
            this.panel_Channel.Name = "panel_Channel";
            this.panel_Channel.Size = new System.Drawing.Size(805, 588);
            this.panel_Channel.TabIndex = 1;
            // 
            // panel_channelDateGridView
            // 
            this.panel_channelDateGridView.Controls.Add(this.dataGridView_ChanSet);
            this.panel_channelDateGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_channelDateGridView.Location = new System.Drawing.Point(0, 127);
            this.panel_channelDateGridView.Name = "panel_channelDateGridView";
            this.panel_channelDateGridView.Size = new System.Drawing.Size(801, 457);
            this.panel_channelDateGridView.TabIndex = 1;
            // 
            // dataGridView_ChanSet
            // 
            this.dataGridView_ChanSet.AllowUserToAddRows = false;
            this.dataGridView_ChanSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ChanSet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ChanSet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_ChanSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ChanSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Collect,
            this.DeviceName,
            this.ChannelID,
            this.Tag,
            this.TagDesc,
            this.Scale,
            this.Offset,
            this.Impedance,
            this.Coupling,
            this.ProbeRatio,
            this.SN,
            this.Open});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ChanSet.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_ChanSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ChanSet.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_ChanSet.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ChanSet.Name = "dataGridView_ChanSet";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ChanSet.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_ChanSet.RowHeadersWidth = 25;
            this.dataGridView_ChanSet.RowTemplate.Height = 23;
            this.dataGridView_ChanSet.Size = new System.Drawing.Size(801, 457);
            this.dataGridView_ChanSet.TabIndex = 4;
            // 
            // panel_ChannelCommon
            // 
            this.panel_ChannelCommon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel_ChannelCommon.Controls.Add(this.iconButton_Config);
            this.panel_ChannelCommon.Controls.Add(this.comboBox_HoriOffsetUnit);
            this.panel_ChannelCommon.Controls.Add(this.textBox_HoriOffset);
            this.panel_ChannelCommon.Controls.Add(this.label_Offset);
            this.panel_ChannelCommon.Controls.Add(this.comboBox_StorgeDepth);
            this.panel_ChannelCommon.Controls.Add(this.label_MemDepth);
            this.panel_ChannelCommon.Controls.Add(this.comboBox_HorTimeUnit);
            this.panel_ChannelCommon.Controls.Add(this.textBox_HorTime);
            this.panel_ChannelCommon.Controls.Add(this.label_TrigTime);
            this.panel_ChannelCommon.Controls.Add(this.comboBox_TrigHoldUnit);
            this.panel_ChannelCommon.Controls.Add(this.textBox_TrigHold);
            this.panel_ChannelCommon.Controls.Add(this.label_TrigHoldOff);
            this.panel_ChannelCommon.Controls.Add(this.comboBox_TriggerLevelUnit);
            this.panel_ChannelCommon.Controls.Add(this.textBox_TriggerLevel);
            this.panel_ChannelCommon.Controls.Add(this.label_TrigLevel);
            this.panel_ChannelCommon.Controls.Add(this.comboBox_TrigStyle);
            this.panel_ChannelCommon.Controls.Add(this.label_TrigMode);
            this.panel_ChannelCommon.Controls.Add(this.comboBox_TriggeSource);
            this.panel_ChannelCommon.Controls.Add(this.label_TrigSource);
            this.panel_ChannelCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ChannelCommon.Location = new System.Drawing.Point(0, 0);
            this.panel_ChannelCommon.Name = "panel_ChannelCommon";
            this.panel_ChannelCommon.Size = new System.Drawing.Size(801, 127);
            this.panel_ChannelCommon.TabIndex = 0;
            // 
            // iconButton_Config
            // 
            this.iconButton_Config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_Config.FlatAppearance.BorderSize = 0;
            this.iconButton_Config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Config.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Config.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton_Config.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.iconButton_Config.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.iconButton_Config.IconSize = 35;
            this.iconButton_Config.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton_Config.Location = new System.Drawing.Point(725, 10);
            this.iconButton_Config.Name = "iconButton_Config";
            this.iconButton_Config.Rotation = 0D;
            this.iconButton_Config.Size = new System.Drawing.Size(68, 55);
            this.iconButton_Config.TabIndex = 22;
            this.iconButton_Config.Text = "Apply";
            this.iconButton_Config.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton_Config.UseVisualStyleBackColor = true;
            this.iconButton_Config.Click += new System.EventHandler(this.iconButton_Config_Click);
            // 
            // comboBox_HoriOffsetUnit
            // 
            this.comboBox_HoriOffsetUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_HoriOffsetUnit.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_HoriOffsetUnit.FormattingEnabled = true;
            this.comboBox_HoriOffsetUnit.Items.AddRange(new object[] {
            "s",
            "ms",
            "us",
            "ns",
            "ps"});
            this.comboBox_HoriOffsetUnit.Location = new System.Drawing.Point(642, 11);
            this.comboBox_HoriOffsetUnit.Name = "comboBox_HoriOffsetUnit";
            this.comboBox_HoriOffsetUnit.Size = new System.Drawing.Size(44, 24);
            this.comboBox_HoriOffsetUnit.TabIndex = 20;
            // 
            // textBox_HoriOffset
            // 
            this.textBox_HoriOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_HoriOffset.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_HoriOffset.Location = new System.Drawing.Point(565, 11);
            this.textBox_HoriOffset.Multiline = true;
            this.textBox_HoriOffset.Name = "textBox_HoriOffset";
            this.textBox_HoriOffset.Size = new System.Drawing.Size(68, 24);
            this.textBox_HoriOffset.TabIndex = 19;
            // 
            // label_Offset
            // 
            this.label_Offset.AutoSize = true;
            this.label_Offset.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Offset.Location = new System.Drawing.Point(478, 13);
            this.label_Offset.Name = "label_Offset";
            this.label_Offset.Size = new System.Drawing.Size(72, 19);
            this.label_Offset.TabIndex = 18;
            this.label_Offset.Text = "HorzPos:";
            // 
            // comboBox_StorgeDepth
            // 
            this.comboBox_StorgeDepth.AutoCompleteCustomSource.AddRange(new string[] {
            "External Trig",
            "CH1",
            "CH2",
            "CH3",
            "CH4"});
            this.comboBox_StorgeDepth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_StorgeDepth.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_StorgeDepth.FormattingEnabled = true;
            this.comboBox_StorgeDepth.Items.AddRange(new object[] {
            "1K",
            "10K",
            "100K",
            "1M"});
            this.comboBox_StorgeDepth.Location = new System.Drawing.Point(101, 91);
            this.comboBox_StorgeDepth.Name = "comboBox_StorgeDepth";
            this.comboBox_StorgeDepth.Size = new System.Drawing.Size(69, 22);
            this.comboBox_StorgeDepth.TabIndex = 17;
            // 
            // label_MemDepth
            // 
            this.label_MemDepth.AutoSize = true;
            this.label_MemDepth.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MemDepth.Location = new System.Drawing.Point(5, 93);
            this.label_MemDepth.Name = "label_MemDepth";
            this.label_MemDepth.Size = new System.Drawing.Size(92, 19);
            this.label_MemDepth.TabIndex = 16;
            this.label_MemDepth.Text = "MemDepth:";
            // 
            // comboBox_HorTimeUnit
            // 
            this.comboBox_HorTimeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_HorTimeUnit.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_HorTimeUnit.FormattingEnabled = true;
            this.comboBox_HorTimeUnit.Items.AddRange(new object[] {
            "s",
            "ms",
            "us",
            "ns",
            "ps"});
            this.comboBox_HorTimeUnit.Location = new System.Drawing.Point(393, 91);
            this.comboBox_HorTimeUnit.Name = "comboBox_HorTimeUnit";
            this.comboBox_HorTimeUnit.Size = new System.Drawing.Size(45, 24);
            this.comboBox_HorTimeUnit.TabIndex = 15;
            // 
            // textBox_HorTime
            // 
            this.textBox_HorTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_HorTime.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_HorTime.Location = new System.Drawing.Point(318, 91);
            this.textBox_HorTime.Multiline = true;
            this.textBox_HorTime.Name = "textBox_HorTime";
            this.textBox_HorTime.Size = new System.Drawing.Size(69, 24);
            this.textBox_HorTime.TabIndex = 14;
            // 
            // label_TrigTime
            // 
            this.label_TrigTime.AutoSize = true;
            this.label_TrigTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TrigTime.Location = new System.Drawing.Point(235, 93);
            this.label_TrigTime.Name = "label_TrigTime";
            this.label_TrigTime.Size = new System.Drawing.Size(82, 19);
            this.label_TrigTime.TabIndex = 13;
            this.label_TrigTime.Text = "HorzScale:";
            // 
            // comboBox_TrigHoldUnit
            // 
            this.comboBox_TrigHoldUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_TrigHoldUnit.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_TrigHoldUnit.FormattingEnabled = true;
            this.comboBox_TrigHoldUnit.Items.AddRange(new object[] {
            "s",
            "ms",
            "us",
            "ns"});
            this.comboBox_TrigHoldUnit.Location = new System.Drawing.Point(393, 52);
            this.comboBox_TrigHoldUnit.Name = "comboBox_TrigHoldUnit";
            this.comboBox_TrigHoldUnit.Size = new System.Drawing.Size(44, 24);
            this.comboBox_TrigHoldUnit.TabIndex = 12;
            // 
            // textBox_TrigHold
            // 
            this.textBox_TrigHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TrigHold.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TrigHold.Location = new System.Drawing.Point(318, 52);
            this.textBox_TrigHold.Multiline = true;
            this.textBox_TrigHold.Name = "textBox_TrigHold";
            this.textBox_TrigHold.Size = new System.Drawing.Size(69, 24);
            this.textBox_TrigHold.TabIndex = 11;
            // 
            // label_TrigHoldOff
            // 
            this.label_TrigHoldOff.AutoSize = true;
            this.label_TrigHoldOff.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TrigHoldOff.Location = new System.Drawing.Point(235, 52);
            this.label_TrigHoldOff.Name = "label_TrigHoldOff";
            this.label_TrigHoldOff.Size = new System.Drawing.Size(68, 19);
            this.label_TrigHoldOff.TabIndex = 10;
            this.label_TrigHoldOff.Text = "Holdoff:";
            // 
            // comboBox_TriggerLevelUnit
            // 
            this.comboBox_TriggerLevelUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_TriggerLevelUnit.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_TriggerLevelUnit.FormattingEnabled = true;
            this.comboBox_TriggerLevelUnit.Items.AddRange(new object[] {
            "V",
            "mV",
            "uV"});
            this.comboBox_TriggerLevelUnit.Location = new System.Drawing.Point(394, 9);
            this.comboBox_TriggerLevelUnit.Name = "comboBox_TriggerLevelUnit";
            this.comboBox_TriggerLevelUnit.Size = new System.Drawing.Size(42, 24);
            this.comboBox_TriggerLevelUnit.TabIndex = 9;
            // 
            // textBox_TriggerLevel
            // 
            this.textBox_TriggerLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TriggerLevel.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TriggerLevel.Location = new System.Drawing.Point(318, 8);
            this.textBox_TriggerLevel.Multiline = true;
            this.textBox_TriggerLevel.Name = "textBox_TriggerLevel";
            this.textBox_TriggerLevel.Size = new System.Drawing.Size(69, 25);
            this.textBox_TriggerLevel.TabIndex = 8;
            // 
            // label_TrigLevel
            // 
            this.label_TrigLevel.AutoSize = true;
            this.label_TrigLevel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TrigLevel.Location = new System.Drawing.Point(235, 12);
            this.label_TrigLevel.Name = "label_TrigLevel";
            this.label_TrigLevel.Size = new System.Drawing.Size(77, 19);
            this.label_TrigLevel.TabIndex = 7;
            this.label_TrigLevel.Text = "TrigLevel:";
            // 
            // comboBox_TrigStyle
            // 
            this.comboBox_TrigStyle.AutoCompleteCustomSource.AddRange(new string[] {
            "External Trig",
            "CH1",
            "CH2",
            "CH3",
            "CH4"});
            this.comboBox_TrigStyle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_TrigStyle.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_TrigStyle.FormattingEnabled = true;
            this.comboBox_TrigStyle.Items.AddRange(new object[] {
            "SINGLE",
            "NORMAL",
            "AUTO"});
            this.comboBox_TrigStyle.Location = new System.Drawing.Point(101, 50);
            this.comboBox_TrigStyle.Name = "comboBox_TrigStyle";
            this.comboBox_TrigStyle.Size = new System.Drawing.Size(68, 22);
            this.comboBox_TrigStyle.TabIndex = 6;
            // 
            // label_TrigMode
            // 
            this.label_TrigMode.AutoSize = true;
            this.label_TrigMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TrigMode.Location = new System.Drawing.Point(5, 51);
            this.label_TrigMode.Name = "label_TrigMode";
            this.label_TrigMode.Size = new System.Drawing.Size(91, 19);
            this.label_TrigMode.TabIndex = 5;
            this.label_TrigMode.Text = "TrigMode：";
            // 
            // comboBox_TriggeSource
            // 
            this.comboBox_TriggeSource.AutoCompleteCustomSource.AddRange(new string[] {
            "External Trig",
            "CH1",
            "CH2",
            "CH3",
            "CH4"});
            this.comboBox_TriggeSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_TriggeSource.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_TriggeSource.FormattingEnabled = true;
            this.comboBox_TriggeSource.Items.AddRange(new object[] {
            "EXT",
            "CHAN1",
            "CHAN2",
            "CHAN3",
            "CHAN4"});
            this.comboBox_TriggeSource.Location = new System.Drawing.Point(100, 10);
            this.comboBox_TriggeSource.Name = "comboBox_TriggeSource";
            this.comboBox_TriggeSource.Size = new System.Drawing.Size(68, 22);
            this.comboBox_TriggeSource.TabIndex = 4;
            // 
            // label_TrigSource
            // 
            this.label_TrigSource.AutoSize = true;
            this.label_TrigSource.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TrigSource.Location = new System.Drawing.Point(5, 10);
            this.label_TrigSource.Name = "label_TrigSource";
            this.label_TrigSource.Size = new System.Drawing.Size(88, 19);
            this.label_TrigSource.TabIndex = 3;
            this.label_TrigSource.Text = "TrigSource:";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Collect
            // 
            this.Collect.DataPropertyName = "Collect";
            this.Collect.HeaderText = "Collect";
            this.Collect.Name = "Collect";
            this.Collect.ReadOnly = true;
            // 
            // DeviceName
            // 
            this.DeviceName.DataPropertyName = "DeviceName";
            this.DeviceName.HeaderText = "Device";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ChannelID
            // 
            this.ChannelID.DataPropertyName = "ChannelID";
            this.ChannelID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChannelID.HeaderText = "Channel";
            this.ChannelID.Items.AddRange(new object[] {
            "CH1",
            "CH2",
            "CH3",
            "CH4"});
            this.ChannelID.Name = "ChannelID";
            this.ChannelID.ReadOnly = true;
            this.ChannelID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Tag
            // 
            this.Tag.DataPropertyName = "Tag";
            this.Tag.HeaderText = "ChannelTag";
            this.Tag.MaxInputLength = 7;
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            this.Tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TagDesc
            // 
            this.TagDesc.DataPropertyName = "TagDesc";
            this.TagDesc.HeaderText = "Mark";
            this.TagDesc.MaxInputLength = 13;
            this.TagDesc.Name = "TagDesc";
            this.TagDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Scale
            // 
            this.Scale.DataPropertyName = "Scale";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "\"0\"";
            this.Scale.DefaultCellStyle = dataGridViewCellStyle7;
            this.Scale.HeaderText = "Scale(V)";
            this.Scale.Name = "Scale";
            this.Scale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Offset
            // 
            this.Offset.DataPropertyName = "Offset";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "\"0\"";
            this.Offset.DefaultCellStyle = dataGridViewCellStyle8;
            this.Offset.HeaderText = "Offset（V）";
            this.Offset.Name = "Offset";
            this.Offset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Impedance
            // 
            this.Impedance.DataPropertyName = "Impedance";
            this.Impedance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Impedance.HeaderText = "Impedence(Ω）";
            this.Impedance.Items.AddRange(new object[] {
            "50",
            "1M"});
            this.Impedance.Name = "Impedance";
            // 
            // Coupling
            // 
            this.Coupling.DataPropertyName = "Coupling";
            this.Coupling.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Coupling.HeaderText = "Coupling";
            this.Coupling.Items.AddRange(new object[] {
            "DC",
            "AC",
            "GND"});
            this.Coupling.Name = "Coupling";
            this.Coupling.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ProbeRatio
            // 
            this.ProbeRatio.DataPropertyName = "ProbeRatio";
            this.ProbeRatio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProbeRatio.HeaderText = "Attenuation";
            this.ProbeRatio.Items.AddRange(new object[] {
            "*1",
            "*10"});
            this.ProbeRatio.Name = "ProbeRatio";
            this.ProbeRatio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SN
            // 
            this.SN.DataPropertyName = "SN";
            this.SN.HeaderText = "SN";
            this.SN.Name = "SN";
            this.SN.ReadOnly = true;
            this.SN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SN.Visible = false;
            // 
            // Open
            // 
            this.Open.DataPropertyName = "Open";
            this.Open.HeaderText = "Open";
            this.Open.Name = "Open";
            this.Open.ReadOnly = true;
            this.Open.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Open.Visible = false;
            // 
            // Form_DeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 588);
            this.Controls.Add(this.panel_Channel);
            this.Controls.Add(this.panel1);
            this.Name = "Form_DeviceConfig";
            this.Text = "Form_DeviceConfig";
            this.Load += new System.EventHandler(this.Form_DeviceConfig_Load);
            this.panel1.ResumeLayout(false);
            this.panel_AddDevice.ResumeLayout(false);
            this.panel_Channel.ResumeLayout(false);
            this.panel_channelDateGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChanSet)).EndInit();
            this.panel_ChannelCommon.ResumeLayout(false);
            this.panel_ChannelCommon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_DeviceManager;
        private System.Windows.Forms.Panel panel_AddDevice;
        private System.Windows.Forms.Panel panel_Channel;
        private FontAwesome.Sharp.IconButton iconButton_DelDev;
        private FontAwesome.Sharp.IconButton iconButton_Add;
        private System.Windows.Forms.Panel panel_channelDateGridView;
        private System.Windows.Forms.DataGridView dataGridView_ChanSet;
        private System.Windows.Forms.Panel panel_ChannelCommon;
        private FontAwesome.Sharp.IconButton iconButton_Config;
        private System.Windows.Forms.ComboBox comboBox_HoriOffsetUnit;
        private System.Windows.Forms.TextBox textBox_HoriOffset;
        private System.Windows.Forms.Label label_Offset;
        private System.Windows.Forms.ComboBox comboBox_StorgeDepth;
        private System.Windows.Forms.Label label_MemDepth;
        private System.Windows.Forms.ComboBox comboBox_HorTimeUnit;
        private System.Windows.Forms.TextBox textBox_HorTime;
        private System.Windows.Forms.Label label_TrigTime;
        private System.Windows.Forms.ComboBox comboBox_TrigHoldUnit;
        private System.Windows.Forms.TextBox textBox_TrigHold;
        private System.Windows.Forms.Label label_TrigHoldOff;
        private System.Windows.Forms.ComboBox comboBox_TriggerLevelUnit;
        private System.Windows.Forms.TextBox textBox_TriggerLevel;
        private System.Windows.Forms.Label label_TrigLevel;
        private System.Windows.Forms.ComboBox comboBox_TrigStyle;
        private System.Windows.Forms.Label label_TrigMode;
        private System.Windows.Forms.ComboBox comboBox_TriggeSource;
        private System.Windows.Forms.Label label_TrigSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Collect;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offset;
        private System.Windows.Forms.DataGridViewComboBoxColumn Impedance;
        private System.Windows.Forms.DataGridViewComboBoxColumn Coupling;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProbeRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Open;
    }
}