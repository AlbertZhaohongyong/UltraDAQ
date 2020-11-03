namespace UltraDAQ_Lite.SubForm
{
    partial class Form_Register
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Registor = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_DevInfo = new System.Windows.Forms.TextBox();
            this.textBox_DevSubName = new System.Windows.Forms.TextBox();
            this.label_DevInfo = new System.Windows.Forms.Label();
            this.label2_DevSubName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton_USB = new System.Windows.Forms.RadioButton();
            this.radioButton_LAN = new System.Windows.Forms.RadioButton();
            this.label_DeviceReg = new System.Windows.Forms.Label();
            this.iconButton_Refresh = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label_VisaInterface = new System.Windows.Forms.Label();
            this.combox_DevVisa = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.SystemColors.Control;
            this.button_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Cancel.Location = new System.Drawing.Point(304, 250);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 24;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Registor
            // 
            this.button_Registor.BackColor = System.Drawing.SystemColors.Control;
            this.button_Registor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Registor.Location = new System.Drawing.Point(380, 39);
            this.button_Registor.Name = "button_Registor";
            this.button_Registor.Size = new System.Drawing.Size(75, 23);
            this.button_Registor.TabIndex = 22;
            this.button_Registor.Text = "Connect";
            this.button_Registor.UseVisualStyleBackColor = false;
            this.button_Registor.Click += new System.EventHandler(this.button_RegistorView_Click);
            // 
            // button_OK
            // 
            this.button_OK.BackColor = System.Drawing.SystemColors.Control;
            this.button_OK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_OK.Location = new System.Drawing.Point(82, 251);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 23;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_DevInfo
            // 
            this.textBox_DevInfo.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_DevInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_DevInfo.Location = new System.Drawing.Point(84, 114);
            this.textBox_DevInfo.Multiline = true;
            this.textBox_DevInfo.Name = "textBox_DevInfo";
            this.textBox_DevInfo.ReadOnly = true;
            this.textBox_DevInfo.Size = new System.Drawing.Size(295, 126);
            this.textBox_DevInfo.TabIndex = 3;
            // 
            // textBox_DevSubName
            // 
            this.textBox_DevSubName.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_DevSubName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_DevSubName.Location = new System.Drawing.Point(84, 75);
            this.textBox_DevSubName.Name = "textBox_DevSubName";
            this.textBox_DevSubName.Size = new System.Drawing.Size(294, 21);
            this.textBox_DevSubName.TabIndex = 2;
            // 
            // label_DevInfo
            // 
            this.label_DevInfo.AutoSize = true;
            this.label_DevInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DevInfo.ForeColor = System.Drawing.Color.Black;
            this.label_DevInfo.Location = new System.Drawing.Point(7, 109);
            this.label_DevInfo.Name = "label_DevInfo";
            this.label_DevInfo.Size = new System.Drawing.Size(60, 17);
            this.label_DevInfo.TabIndex = 25;
            this.label_DevInfo.Text = "DevInfo:";
            // 
            // label2_DevSubName
            // 
            this.label2_DevSubName.AutoSize = true;
            this.label2_DevSubName.BackColor = System.Drawing.SystemColors.Control;
            this.label2_DevSubName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2_DevSubName.ForeColor = System.Drawing.Color.Black;
            this.label2_DevSubName.Location = new System.Drawing.Point(7, 75);
            this.label2_DevSubName.Name = "label2_DevSubName";
            this.label2_DevSubName.Size = new System.Drawing.Size(70, 17);
            this.label2_DevSubName.TabIndex = 29;
            this.label2_DevSubName.Text = "SubName:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.combox_DevVisa);
            this.panel3.Controls.Add(this.radioButton_USB);
            this.panel3.Controls.Add(this.radioButton_LAN);
            this.panel3.Controls.Add(this.label_DeviceReg);
            this.panel3.Controls.Add(this.iconButton_Refresh);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox_DevInfo);
            this.panel3.Controls.Add(this.label_DevInfo);
            this.panel3.Controls.Add(this.textBox_DevSubName);
            this.panel3.Controls.Add(this.button_Cancel);
            this.panel3.Controls.Add(this.button_OK);
            this.panel3.Controls.Add(this.label2_DevSubName);
            this.panel3.Controls.Add(this.label_VisaInterface);
            this.panel3.Controls.Add(this.button_Registor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(459, 280);
            this.panel3.TabIndex = 35;
            // 
            // radioButton_USB
            // 
            this.radioButton_USB.AutoSize = true;
            this.radioButton_USB.Location = new System.Drawing.Point(133, 7);
            this.radioButton_USB.Name = "radioButton_USB";
            this.radioButton_USB.Size = new System.Drawing.Size(41, 16);
            this.radioButton_USB.TabIndex = 36;
            this.radioButton_USB.TabStop = true;
            this.radioButton_USB.Text = "USB";
            this.radioButton_USB.UseVisualStyleBackColor = true;
            this.radioButton_USB.CheckedChanged += new System.EventHandler(this.radioButton_USB_CheckedChanged);
            // 
            // radioButton_LAN
            // 
            this.radioButton_LAN.AutoSize = true;
            this.radioButton_LAN.Location = new System.Drawing.Point(86, 7);
            this.radioButton_LAN.Name = "radioButton_LAN";
            this.radioButton_LAN.Size = new System.Drawing.Size(41, 16);
            this.radioButton_LAN.TabIndex = 36;
            this.radioButton_LAN.TabStop = true;
            this.radioButton_LAN.Text = "LAN";
            this.radioButton_LAN.UseVisualStyleBackColor = true;
            this.radioButton_LAN.CheckedChanged += new System.EventHandler(this.radioButton_LAN_CheckedChanged);
            // 
            // label_DeviceReg
            // 
            this.label_DeviceReg.BackColor = System.Drawing.Color.Black;
            this.label_DeviceReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_DeviceReg.Location = new System.Drawing.Point(0, 0);
            this.label_DeviceReg.Name = "label_DeviceReg";
            this.label_DeviceReg.Size = new System.Drawing.Size(460, 2);
            this.label_DeviceReg.TabIndex = 35;
            // 
            // iconButton_Refresh
            // 
            this.iconButton_Refresh.FlatAppearance.BorderSize = 0;
            this.iconButton_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Refresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Refresh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton_Refresh.IconChar = FontAwesome.Sharp.IconChar.RedoAlt;
            this.iconButton_Refresh.IconColor = System.Drawing.Color.LightSeaGreen;
            this.iconButton_Refresh.IconSize = 20;
            this.iconButton_Refresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton_Refresh.Location = new System.Drawing.Point(180, 2);
            this.iconButton_Refresh.Name = "iconButton_Refresh";
            this.iconButton_Refresh.Rotation = 0D;
            this.iconButton_Refresh.Size = new System.Drawing.Size(28, 23);
            this.iconButton_Refresh.TabIndex = 34;
            this.iconButton_Refresh.UseVisualStyleBackColor = true;
            this.iconButton_Refresh.Click += new System.EventHandler(this.iconButton_Refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Type:";
            // 
            // label_VisaInterface
            // 
            this.label_VisaInterface.AutoSize = true;
            this.label_VisaInterface.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_VisaInterface.ForeColor = System.Drawing.Color.Black;
            this.label_VisaInterface.Location = new System.Drawing.Point(7, 40);
            this.label_VisaInterface.Name = "label_VisaInterface";
            this.label_VisaInterface.Size = new System.Drawing.Size(71, 17);
            this.label_VisaInterface.TabIndex = 26;
            this.label_VisaInterface.Text = "Visa Addr:";
            // 
            // combox_DevVisa
            // 
            this.combox_DevVisa.FormattingEnabled = true;
            this.combox_DevVisa.Location = new System.Drawing.Point(84, 40);
            this.combox_DevVisa.Name = "combox_DevVisa";
            this.combox_DevVisa.Size = new System.Drawing.Size(293, 20);
            this.combox_DevVisa.TabIndex = 37;
            // 
            // Form_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 280);
            this.Controls.Add(this.panel3);
            this.Name = "Form_Register";
            this.Text = "Form_Register";
            this.Load += new System.EventHandler(this.Form_Register_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Registor;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_DevInfo;
        private System.Windows.Forms.TextBox textBox_DevSubName;
        private System.Windows.Forms.Label label_DevInfo;
        private System.Windows.Forms.Label label2_DevSubName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_VisaInterface;
        private FontAwesome.Sharp.IconButton iconButton_Refresh;
        private System.Windows.Forms.Label label_DeviceReg;
        private System.Windows.Forms.RadioButton radioButton_USB;
        private System.Windows.Forms.RadioButton radioButton_LAN;
        private System.Windows.Forms.ComboBox combox_DevVisa;
    }
}