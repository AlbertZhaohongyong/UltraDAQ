namespace UltraDAQ_Lite.SubForm
{
    partial class Form_WaveMonitor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel_WaveTools = new System.Windows.Forms.Panel();
            this.iconButton_UpdateMemory = new FontAwesome.Sharp.IconButton();
            this.iconButton_Collect = new FontAwesome.Sharp.IconButton();
            this.panel_WaveChart = new System.Windows.Forms.Panel();
            this.panel_Chart = new System.Windows.Forms.Panel();
            this.chart_WaveDate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.iconButton_Save = new FontAwesome.Sharp.IconButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel_WaveTools.SuspendLayout();
            this.panel_WaveChart.SuspendLayout();
            this.panel_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_WaveDate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_WaveTools
            // 
            this.panel_WaveTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_WaveTools.Controls.Add(this.iconButton_Save);
            this.panel_WaveTools.Controls.Add(this.iconButton_UpdateMemory);
            this.panel_WaveTools.Controls.Add(this.iconButton_Collect);
            this.panel_WaveTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_WaveTools.Location = new System.Drawing.Point(0, 0);
            this.panel_WaveTools.Name = "panel_WaveTools";
            this.panel_WaveTools.Size = new System.Drawing.Size(966, 72);
            this.panel_WaveTools.TabIndex = 0;
            // 
            // iconButton_UpdateMemory
            // 
            this.iconButton_UpdateMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_UpdateMemory.FlatAppearance.BorderSize = 0;
            this.iconButton_UpdateMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_UpdateMemory.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_UpdateMemory.IconChar = FontAwesome.Sharp.IconChar.HandPointUp;
            this.iconButton_UpdateMemory.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.iconButton_UpdateMemory.IconSize = 31;
            this.iconButton_UpdateMemory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton_UpdateMemory.Location = new System.Drawing.Point(91, 9);
            this.iconButton_UpdateMemory.Name = "iconButton_UpdateMemory";
            this.iconButton_UpdateMemory.Rotation = 0D;
            this.iconButton_UpdateMemory.Size = new System.Drawing.Size(50, 55);
            this.iconButton_UpdateMemory.TabIndex = 22;
            this.iconButton_UpdateMemory.Text = "Update";
            this.iconButton_UpdateMemory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton_UpdateMemory.UseVisualStyleBackColor = true;
            this.iconButton_UpdateMemory.Click += new System.EventHandler(this.iconButton_Update_Click);
            // 
            // iconButton_Collect
            // 
            this.iconButton_Collect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_Collect.CausesValidation = false;
            this.iconButton_Collect.FlatAppearance.BorderSize = 0;
            this.iconButton_Collect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Collect.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Collect.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.iconButton_Collect.IconColor = System.Drawing.Color.Green;
            this.iconButton_Collect.IconSize = 31;
            this.iconButton_Collect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton_Collect.Location = new System.Drawing.Point(19, 9);
            this.iconButton_Collect.Name = "iconButton_Collect";
            this.iconButton_Collect.Rotation = 0D;
            this.iconButton_Collect.Size = new System.Drawing.Size(57, 55);
            this.iconButton_Collect.TabIndex = 24;
            this.iconButton_Collect.Text = "Collect";
            this.iconButton_Collect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton_Collect.UseVisualStyleBackColor = true;
            this.iconButton_Collect.Click += new System.EventHandler(this.iconButton_Run_Click);
            // 
            // panel_WaveChart
            // 
            this.panel_WaveChart.Controls.Add(this.panel_Chart);
            this.panel_WaveChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_WaveChart.Location = new System.Drawing.Point(0, 72);
            this.panel_WaveChart.Name = "panel_WaveChart";
            this.panel_WaveChart.Size = new System.Drawing.Size(966, 473);
            this.panel_WaveChart.TabIndex = 1;
            // 
            // panel_Chart
            // 
            this.panel_Chart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Chart.Controls.Add(this.chart_WaveDate);
            this.panel_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Chart.Location = new System.Drawing.Point(0, 0);
            this.panel_Chart.Name = "panel_Chart";
            this.panel_Chart.Size = new System.Drawing.Size(966, 473);
            this.panel_Chart.TabIndex = 1;
            // 
            // chart_WaveDate
            // 
            chartArea5.Name = "ChartArea1";
            this.chart_WaveDate.ChartAreas.Add(chartArea5);
            this.chart_WaveDate.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chart_WaveDate.Legends.Add(legend5);
            this.chart_WaveDate.Location = new System.Drawing.Point(0, 0);
            this.chart_WaveDate.Name = "chart_WaveDate";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart_WaveDate.Series.Add(series5);
            this.chart_WaveDate.Size = new System.Drawing.Size(962, 469);
            this.chart_WaveDate.TabIndex = 0;
            this.chart_WaveDate.Text = "chart1";
            // 
            // iconButton_Save
            // 
            this.iconButton_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_Save.CausesValidation = false;
            this.iconButton_Save.FlatAppearance.BorderSize = 0;
            this.iconButton_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Save.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Save.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.iconButton_Save.IconColor = System.Drawing.Color.LightSeaGreen;
            this.iconButton_Save.IconSize = 31;
            this.iconButton_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton_Save.Location = new System.Drawing.Point(157, 7);
            this.iconButton_Save.Name = "iconButton_Save";
            this.iconButton_Save.Rotation = 0D;
            this.iconButton_Save.Size = new System.Drawing.Size(50, 55);
            this.iconButton_Save.TabIndex = 25;
            this.iconButton_Save.Text = "Save";
            this.iconButton_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton_Save.UseVisualStyleBackColor = true;
            this.iconButton_Save.Click += new System.EventHandler(this.iconButton_Save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form_WaveMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 545);
            this.Controls.Add(this.panel_WaveChart);
            this.Controls.Add(this.panel_WaveTools);
            this.Name = "Form_WaveMonitor";
            this.Text = "Form_WaveMonitor";
            this.Load += new System.EventHandler(this.Form_WaveMonitor_Load);
            this.panel_WaveTools.ResumeLayout(false);
            this.panel_WaveChart.ResumeLayout(false);
            this.panel_Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_WaveDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_WaveTools;
        private System.Windows.Forms.Panel panel_WaveChart;
        private System.Windows.Forms.Panel panel_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_WaveDate;
        private FontAwesome.Sharp.IconButton iconButton_UpdateMemory;
        private FontAwesome.Sharp.IconButton iconButton_Collect;
        private FontAwesome.Sharp.IconButton iconButton_Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}