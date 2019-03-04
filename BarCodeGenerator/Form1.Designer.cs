namespace BarCodeGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCountBarcode = new System.Windows.Forms.Label();
            this.lblFirstNumb = new System.Windows.Forms.Label();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtCountBarCode = new System.Windows.Forms.TextBox();
            this.txtFirstNumb = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCountBarcode
            // 
            this.lblCountBarcode.AutoSize = true;
            this.lblCountBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountBarcode.Location = new System.Drawing.Point(12, 24);
            this.lblCountBarcode.Name = "lblCountBarcode";
            this.lblCountBarcode.Size = new System.Drawing.Size(266, 24);
            this.lblCountBarcode.TabIndex = 0;
            this.lblCountBarcode.Text = "Количество штрих-кодов:";
            // 
            // lblFirstNumb
            // 
            this.lblFirstNumb.AutoSize = true;
            this.lblFirstNumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFirstNumb.Location = new System.Drawing.Point(12, 73);
            this.lblFirstNumb.Name = "lblFirstNumb";
            this.lblFirstNumb.Size = new System.Drawing.Size(288, 24);
            this.lblFirstNumb.TabIndex = 1;
            this.lblFirstNumb.Text = "Номер первого штрих-кода:";
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrefix.Location = new System.Drawing.Point(12, 123);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(222, 24);
            this.lblPrefix.TabIndex = 2;
            this.lblPrefix.Text = "Префикс штрих-кода:";
            // 
            // txtCountBarCode
            // 
            this.txtCountBarCode.Location = new System.Drawing.Point(306, 26);
            this.txtCountBarCode.Name = "txtCountBarCode";
            this.txtCountBarCode.Size = new System.Drawing.Size(128, 22);
            this.txtCountBarCode.TabIndex = 3;
            this.txtCountBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyPress);
            // 
            // txtFirstNumb
            // 
            this.txtFirstNumb.Location = new System.Drawing.Point(306, 75);
            this.txtFirstNumb.Name = "txtFirstNumb";
            this.txtFirstNumb.Size = new System.Drawing.Size(128, 22);
            this.txtFirstNumb.TabIndex = 4;
            this.txtFirstNumb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyPress);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(306, 123);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(128, 22);
            this.txtPrefix.TabIndex = 5;
            this.txtPrefix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyPress);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerate.Location = new System.Drawing.Point(16, 168);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(418, 57);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Сгенерировать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 237);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.txtFirstNumb);
            this.Controls.Add(this.txtCountBarCode);
            this.Controls.Add(this.lblPrefix);
            this.Controls.Add(this.lblFirstNumb);
            this.Controls.Add(this.lblCountBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор штрих-кодов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCountBarcode;
        private System.Windows.Forms.Label lblFirstNumb;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtCountBarCode;
        private System.Windows.Forms.TextBox txtFirstNumb;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Button btnGenerate;
    }
}

