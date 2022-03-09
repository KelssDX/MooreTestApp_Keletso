namespace MooreTestApp_Keletso
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txt_FIleName = new System.Windows.Forms.TextBox();
            this.combo_SortColumn = new System.Windows.Forms.ComboBox();
            this.combo_SortBy = new System.Windows.Forms.ComboBox();
            this.lbl_Sort = new System.Windows.Forms.Label();
            this.lbl_SortBy = new System.Windows.Forms.Label();
            this.btn_StandarDevation = new System.Windows.Forms.Button();
            this.btn_RMS = new System.Windows.Forms.Button();
            this.btn_ROC = new System.Windows.Forms.Button();
            this.combo_StandarDeviation = new System.Windows.Forms.ComboBox();
            this.combo_RMS = new System.Windows.Forms.ComboBox();
            this.combo_ROC = new System.Windows.Forms.ComboBox();
            this.txt_StandarDevation = new System.Windows.Forms.TextBox();
            this.txt_RMS = new System.Windows.Forms.TextBox();
            this.txt_ROC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SaveToDB = new System.Windows.Forms.Button();
            this.btn_SaveCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1033, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(581, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_OpenCSVFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txt_FIleName
            // 
            this.txt_FIleName.Location = new System.Drawing.Point(709, 378);
            this.txt_FIleName.Name = "txt_FIleName";
            this.txt_FIleName.Size = new System.Drawing.Size(349, 20);
            this.txt_FIleName.TabIndex = 2;
            // 
            // combo_SortColumn
            // 
            this.combo_SortColumn.FormattingEnabled = true;
            this.combo_SortColumn.Location = new System.Drawing.Point(369, 12);
            this.combo_SortColumn.Name = "combo_SortColumn";
            this.combo_SortColumn.Size = new System.Drawing.Size(121, 21);
            this.combo_SortColumn.TabIndex = 3;
            this.combo_SortColumn.SelectedIndexChanged += new System.EventHandler(this.combo_SortColumn_SelectedIndexChanged);
            // 
            // combo_SortBy
            // 
            this.combo_SortBy.FormattingEnabled = true;
            this.combo_SortBy.Location = new System.Drawing.Point(581, 12);
            this.combo_SortBy.Name = "combo_SortBy";
            this.combo_SortBy.Size = new System.Drawing.Size(121, 21);
            this.combo_SortBy.TabIndex = 4;
            this.combo_SortBy.SelectedIndexChanged += new System.EventHandler(this.combo_SortBy_SelectedIndexChanged);
            // 
            // lbl_Sort
            // 
            this.lbl_Sort.AutoSize = true;
            this.lbl_Sort.Location = new System.Drawing.Point(284, 19);
            this.lbl_Sort.Name = "lbl_Sort";
            this.lbl_Sort.Size = new System.Drawing.Size(67, 13);
            this.lbl_Sort.TabIndex = 5;
            this.lbl_Sort.Text = "Column Sort:";
            // 
            // lbl_SortBy
            // 
            this.lbl_SortBy.AutoSize = true;
            this.lbl_SortBy.Location = new System.Drawing.Point(531, 20);
            this.lbl_SortBy.Name = "lbl_SortBy";
            this.lbl_SortBy.Size = new System.Drawing.Size(44, 13);
            this.lbl_SortBy.TabIndex = 6;
            this.lbl_SortBy.Text = "Sort By:";
            // 
            // btn_StandarDevation
            // 
            this.btn_StandarDevation.Location = new System.Drawing.Point(44, 418);
            this.btn_StandarDevation.Name = "btn_StandarDevation";
            this.btn_StandarDevation.Size = new System.Drawing.Size(102, 23);
            this.btn_StandarDevation.TabIndex = 7;
            this.btn_StandarDevation.Text = "Standar Deviation";
            this.btn_StandarDevation.UseVisualStyleBackColor = true;
            this.btn_StandarDevation.Click += new System.EventHandler(this.btn_StandarDeviation_Click);
            // 
            // btn_RMS
            // 
            this.btn_RMS.Location = new System.Drawing.Point(44, 457);
            this.btn_RMS.Name = "btn_RMS";
            this.btn_RMS.Size = new System.Drawing.Size(102, 23);
            this.btn_RMS.TabIndex = 8;
            this.btn_RMS.Text = "RMS";
            this.btn_RMS.UseVisualStyleBackColor = true;
            this.btn_RMS.Click += new System.EventHandler(this.btn_RMS_Click);
            // 
            // btn_ROC
            // 
            this.btn_ROC.Location = new System.Drawing.Point(44, 495);
            this.btn_ROC.Name = "btn_ROC";
            this.btn_ROC.Size = new System.Drawing.Size(102, 21);
            this.btn_ROC.TabIndex = 9;
            this.btn_ROC.Text = "Rate of Change";
            this.btn_ROC.UseVisualStyleBackColor = true;
            this.btn_ROC.Click += new System.EventHandler(this.btn_ROC_Click);
            // 
            // combo_StandarDeviation
            // 
            this.combo_StandarDeviation.FormattingEnabled = true;
            this.combo_StandarDeviation.Location = new System.Drawing.Point(165, 420);
            this.combo_StandarDeviation.Name = "combo_StandarDeviation";
            this.combo_StandarDeviation.Size = new System.Drawing.Size(121, 21);
            this.combo_StandarDeviation.TabIndex = 10;
            // 
            // combo_RMS
            // 
            this.combo_RMS.FormattingEnabled = true;
            this.combo_RMS.Location = new System.Drawing.Point(165, 459);
            this.combo_RMS.Name = "combo_RMS";
            this.combo_RMS.Size = new System.Drawing.Size(121, 21);
            this.combo_RMS.TabIndex = 11;
            // 
            // combo_ROC
            // 
            this.combo_ROC.FormattingEnabled = true;
            this.combo_ROC.Location = new System.Drawing.Point(165, 496);
            this.combo_ROC.Name = "combo_ROC";
            this.combo_ROC.Size = new System.Drawing.Size(121, 21);
            this.combo_ROC.TabIndex = 12;
            // 
            // txt_StandarDevation
            // 
            this.txt_StandarDevation.Location = new System.Drawing.Point(306, 421);
            this.txt_StandarDevation.Name = "txt_StandarDevation";
            this.txt_StandarDevation.Size = new System.Drawing.Size(211, 20);
            this.txt_StandarDevation.TabIndex = 13;
            // 
            // txt_RMS
            // 
            this.txt_RMS.Location = new System.Drawing.Point(306, 460);
            this.txt_RMS.Name = "txt_RMS";
            this.txt_RMS.Size = new System.Drawing.Size(211, 20);
            this.txt_RMS.TabIndex = 14;
            // 
            // txt_ROC
            // 
            this.txt_ROC.Location = new System.Drawing.Point(306, 497);
            this.txt_ROC.Name = "txt_ROC";
            this.txt_ROC.Size = new System.Drawing.Size(211, 20);
            this.txt_ROC.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Calculation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Select Column:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Output:";
            // 
            // btn_SaveToDB
            // 
            this.btn_SaveToDB.Location = new System.Drawing.Point(581, 488);
            this.btn_SaveToDB.Name = "btn_SaveToDB";
            this.btn_SaveToDB.Size = new System.Drawing.Size(208, 35);
            this.btn_SaveToDB.TabIndex = 19;
            this.btn_SaveToDB.Text = "Save Calculations To DB";
            this.btn_SaveToDB.UseVisualStyleBackColor = true;
            this.btn_SaveToDB.Click += new System.EventHandler(this.btn_SaveToDB_Click);
            // 
            // btn_SaveCSV
            // 
            this.btn_SaveCSV.Location = new System.Drawing.Point(815, 488);
            this.btn_SaveCSV.Name = "btn_SaveCSV";
            this.btn_SaveCSV.Size = new System.Drawing.Size(205, 35);
            this.btn_SaveCSV.TabIndex = 20;
            this.btn_SaveCSV.Text = "Save Calculations CSV";
            this.btn_SaveCSV.UseVisualStyleBackColor = true;
            this.btn_SaveCSV.Click += new System.EventHandler(this.btn_SaveCSV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 540);
            this.Controls.Add(this.btn_SaveCSV);
            this.Controls.Add(this.btn_SaveToDB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ROC);
            this.Controls.Add(this.txt_RMS);
            this.Controls.Add(this.txt_StandarDevation);
            this.Controls.Add(this.combo_ROC);
            this.Controls.Add(this.combo_RMS);
            this.Controls.Add(this.combo_StandarDeviation);
            this.Controls.Add(this.btn_ROC);
            this.Controls.Add(this.btn_RMS);
            this.Controls.Add(this.btn_StandarDevation);
            this.Controls.Add(this.lbl_SortBy);
            this.Controls.Add(this.lbl_Sort);
            this.Controls.Add(this.combo_SortBy);
            this.Controls.Add(this.combo_SortColumn);
            this.Controls.Add(this.txt_FIleName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txt_FIleName;
        private System.Windows.Forms.ComboBox combo_SortColumn;
        private System.Windows.Forms.ComboBox combo_SortBy;
        private System.Windows.Forms.Label lbl_Sort;
        private System.Windows.Forms.Label lbl_SortBy;
        private System.Windows.Forms.Button btn_StandarDevation;
        private System.Windows.Forms.Button btn_RMS;
        private System.Windows.Forms.Button btn_ROC;
        private System.Windows.Forms.ComboBox combo_StandarDeviation;
        private System.Windows.Forms.ComboBox combo_RMS;
        private System.Windows.Forms.ComboBox combo_ROC;
        private System.Windows.Forms.TextBox txt_StandarDevation;
        private System.Windows.Forms.TextBox txt_RMS;
        private System.Windows.Forms.TextBox txt_ROC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_SaveToDB;
        private System.Windows.Forms.Button btn_SaveCSV;
    }
}

