namespace OpenImage
{
    partial class Form1
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
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.buttonPixel = new System.Windows.Forms.Button();
            this.buttonMemory = new System.Windows.Forms.Button();
            this.buttonPointer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(12, 41);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpen.TabIndex = 0;
            this.ButtonOpen.Text = "打开图像\r\n";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(12, 89);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 1;
            this.ButtonSave.Text = "保存图像";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(12, 134);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "关闭";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // buttonPixel
            // 
            this.buttonPixel.Location = new System.Drawing.Point(12, 176);
            this.buttonPixel.Name = "buttonPixel";
            this.buttonPixel.Size = new System.Drawing.Size(75, 23);
            this.buttonPixel.TabIndex = 3;
            this.buttonPixel.Text = "提取像素法";
            this.buttonPixel.UseVisualStyleBackColor = true;
            this.buttonPixel.Click += new System.EventHandler(this.buttonPixel_Click);
            // 
            // buttonMemory
            // 
            this.buttonMemory.Location = new System.Drawing.Point(13, 221);
            this.buttonMemory.Name = "buttonMemory";
            this.buttonMemory.Size = new System.Drawing.Size(75, 23);
            this.buttonMemory.TabIndex = 4;
            this.buttonMemory.Text = "内存法";
            this.buttonMemory.UseVisualStyleBackColor = true;
            this.buttonMemory.Click += new System.EventHandler(this.buttonMemory_Click);
            // 
            // buttonPointer
            // 
            this.buttonPointer.Location = new System.Drawing.Point(13, 265);
            this.buttonPointer.Name = "buttonPointer";
            this.buttonPointer.Size = new System.Drawing.Size(75, 23);
            this.buttonPointer.TabIndex = 5;
            this.buttonPointer.Text = "指针法";
            this.buttonPointer.UseVisualStyleBackColor = true;
            this.buttonPointer.Click += new System.EventHandler(this.buttonPointer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "运行时间:";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(13, 334);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(75, 21);
            this.textBoxTime.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 614);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPointer);
            this.Controls.Add(this.buttonMemory);
            this.Controls.Add(this.buttonPixel);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button buttonPixel;
        private System.Windows.Forms.Button buttonMemory;
        private System.Windows.Forms.Button buttonPointer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTime;
    }
}

