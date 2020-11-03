namespace UltraDAQ_Lite.SubForm
{
    partial class Form_Progressbar
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
            this.label_ProcessStatus = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label_ProcessStatus
            // 
            this.label_ProcessStatus.AutoSize = true;
            this.label_ProcessStatus.Location = new System.Drawing.Point(20, 21);
            this.label_ProcessStatus.Name = "label_ProcessStatus";
            this.label_ProcessStatus.Size = new System.Drawing.Size(0, 12);
            this.label_ProcessStatus.TabIndex = 6;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 44);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 19);
            this.progressBar1.TabIndex = 5;
            // 
            // Form_Progressbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(385, 82);
            this.Controls.Add(this.label_ProcessStatus);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Progressbar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form_Progressbar";
            this.Load += new System.EventHandler(this.Form_Progressbar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProcessStatus;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}