
namespace Inheritance
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.textBoxBrowse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCowMlk = new System.Windows.Forms.TextBox();
            this.textBoxGoatVac = new System.Windows.Forms.TextBox();
            this.textBoxJCowVac = new System.Windows.Forms.TextBox();
            this.textBoxCowVac = new System.Windows.Forms.TextBox();
            this.textBoxGoatMlk = new System.Windows.Forms.TextBox();
            this.textBoxProfit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(240, 182);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(130, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate Profit";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(240, 50);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(130, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse For File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // textBoxBrowse
            // 
            this.textBoxBrowse.Location = new System.Drawing.Point(240, 76);
            this.textBoxBrowse.Name = "textBoxBrowse";
            this.textBoxBrowse.Size = new System.Drawing.Size(455, 22);
            this.textBoxBrowse.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cow Milk Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Goat Milk Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cow Vaccination Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Jersey Cow Vaccination Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Goat Vaccination Price";
            // 
            // textBoxCowMlk
            // 
            this.textBoxCowMlk.Location = new System.Drawing.Point(34, 76);
            this.textBoxCowMlk.Name = "textBoxCowMlk";
            this.textBoxCowMlk.Size = new System.Drawing.Size(100, 22);
            this.textBoxCowMlk.TabIndex = 8;
            // 
            // textBoxGoatVac
            // 
            this.textBoxGoatVac.Location = new System.Drawing.Point(34, 398);
            this.textBoxGoatVac.Name = "textBoxGoatVac";
            this.textBoxGoatVac.Size = new System.Drawing.Size(100, 22);
            this.textBoxGoatVac.TabIndex = 9;
            // 
            // textBoxJCowVac
            // 
            this.textBoxJCowVac.Location = new System.Drawing.Point(34, 312);
            this.textBoxJCowVac.Name = "textBoxJCowVac";
            this.textBoxJCowVac.Size = new System.Drawing.Size(100, 22);
            this.textBoxJCowVac.TabIndex = 10;
            // 
            // textBoxCowVac
            // 
            this.textBoxCowVac.Location = new System.Drawing.Point(34, 236);
            this.textBoxCowVac.Name = "textBoxCowVac";
            this.textBoxCowVac.Size = new System.Drawing.Size(100, 22);
            this.textBoxCowVac.TabIndex = 11;
            // 
            // textBoxGoatMlk
            // 
            this.textBoxGoatMlk.Location = new System.Drawing.Point(34, 148);
            this.textBoxGoatMlk.Name = "textBoxGoatMlk";
            this.textBoxGoatMlk.Size = new System.Drawing.Size(100, 22);
            this.textBoxGoatMlk.TabIndex = 12;
            // 
            // textBoxProfit
            // 
            this.textBoxProfit.Location = new System.Drawing.Point(240, 211);
            this.textBoxProfit.Name = "textBoxProfit";
            this.textBoxProfit.Size = new System.Drawing.Size(214, 22);
            this.textBoxProfit.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 451);
            this.Controls.Add(this.textBoxProfit);
            this.Controls.Add(this.textBoxGoatMlk);
            this.Controls.Add(this.textBoxCowVac);
            this.Controls.Add(this.textBoxJCowVac);
            this.Controls.Add(this.textBoxGoatVac);
            this.Controls.Add(this.textBoxCowMlk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox textBoxBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCowMlk;
        private System.Windows.Forms.TextBox textBoxGoatVac;
        private System.Windows.Forms.TextBox textBoxJCowVac;
        private System.Windows.Forms.TextBox textBoxCowVac;
        private System.Windows.Forms.TextBox textBoxGoatMlk;
        private System.Windows.Forms.TextBox textBoxProfit;
    }
}

