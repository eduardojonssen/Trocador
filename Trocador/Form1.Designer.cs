namespace Trocador {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UxTxtProductAmount = new System.Windows.Forms.TextBox();
            this.UxTxtAmountPaid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UxTxtChange = new System.Windows.Forms.TextBox();
            this.UxBtnCalculate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UxTxtProductAmount
            // 
            this.UxTxtProductAmount.AccessibleDescription = "";
            this.UxTxtProductAmount.AccessibleName = "Valor do produto";
            this.UxTxtProductAmount.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.UxTxtProductAmount.Location = new System.Drawing.Point(164, 21);
            this.UxTxtProductAmount.Name = "UxTxtProductAmount";
            this.UxTxtProductAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtProductAmount.TabIndex = 0;
            this.UxTxtProductAmount.Text = "125";
            this.UxTxtProductAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UxTxtAmountPaid
            // 
            this.UxTxtAmountPaid.AccessibleName = "Valor pago";
            this.UxTxtAmountPaid.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.UxTxtAmountPaid.Location = new System.Drawing.Point(164, 73);
            this.UxTxtAmountPaid.Name = "UxTxtAmountPaid";
            this.UxTxtAmountPaid.Size = new System.Drawing.Size(100, 26);
            this.UxTxtAmountPaid.TabIndex = 1;
            this.UxTxtAmountPaid.Text = "500";
            this.UxTxtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor do Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor pago";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.UxTxtChange);
            this.groupBox1.Location = new System.Drawing.Point(21, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 263);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Troco a Receber:";
            // 
            // UxTxtChange
            // 
            this.UxTxtChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UxTxtChange.Location = new System.Drawing.Point(7, 25);
            this.UxTxtChange.Multiline = true;
            this.UxTxtChange.Name = "UxTxtChange";
            this.UxTxtChange.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UxTxtChange.Size = new System.Drawing.Size(708, 232);
            this.UxTxtChange.TabIndex = 0;
            // 
            // UxBtnCalculate
            // 
            this.UxBtnCalculate.Location = new System.Drawing.Point(335, 75);
            this.UxBtnCalculate.Name = "UxBtnCalculate";
            this.UxBtnCalculate.Size = new System.Drawing.Size(129, 32);
            this.UxBtnCalculate.TabIndex = 2;
            this.UxBtnCalculate.Text = "calcular";
            this.UxBtnCalculate.UseVisualStyleBackColor = true;
            this.UxBtnCalculate.Click += new System.EventHandler(this.UxBtnCalculate_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.UxBtnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 426);
            this.Controls.Add(this.UxBtnCalculate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UxTxtAmountPaid);
            this.Controls.Add(this.UxTxtProductAmount);
            this.Name = "Form1";
            this.Text = "Trocador";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UxTxtProductAmount;
        private System.Windows.Forms.TextBox UxTxtAmountPaid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UxBtnCalculate;
        private System.Windows.Forms.TextBox UxTxtChange;
    }
}

