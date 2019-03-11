namespace TumorFinder
{
    partial class TFForm
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
            this.picbox_im = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_im)).BeginInit();
            this.SuspendLayout();
            // 
            // picbox_im
            // 
            this.picbox_im.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picbox_im.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_im.Location = new System.Drawing.Point(42, 48);
            this.picbox_im.Name = "picbox_im";
            this.picbox_im.Size = new System.Drawing.Size(188, 186);
            this.picbox_im.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_im.TabIndex = 3;
            this.picbox_im.TabStop = false;
            this.picbox_im.DragDrop += new System.Windows.Forms.DragEventHandler(this.picbox_im_DragDrop);
            this.picbox_im.DragEnter += new System.Windows.Forms.DragEventHandler(this.picbox_im_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Перетащите снимок:";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(97, 253);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 5;
            this.btn_search.Text = "Поиск";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // TFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 296);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picbox_im);
            this.Name = "TFForm";
            this.Text = "Поиск опухоли";
            ((System.ComponentModel.ISupportInitialize)(this.picbox_im)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbox_im;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_search;
    }
}

