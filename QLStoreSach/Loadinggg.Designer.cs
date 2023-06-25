namespace QLStoreSach
{
    partial class Loadinggg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loadinggg));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prograssbar1 = new CircularProgressBar.CircularProgressBar();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            this.label2.Location = new System.Drawing.Point(88, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loading...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "iBook Store";
            // 
            // prograssbar1
            // 
            this.prograssbar1.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("prograssbar1.AnimationFunction")));
            this.prograssbar1.AnimationSpeed = 500;
            this.prograssbar1.BackColor = System.Drawing.Color.White;
            this.prograssbar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prograssbar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            this.prograssbar1.InnerColor = System.Drawing.Color.White;
            this.prograssbar1.InnerMargin = 2;
            this.prograssbar1.InnerWidth = -1;
            this.prograssbar1.Location = new System.Drawing.Point(52, 117);
            this.prograssbar1.MarqueeAnimationSpeed = 2000;
            this.prograssbar1.Name = "prograssbar1";
            this.prograssbar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.prograssbar1.OuterMargin = -25;
            this.prograssbar1.OuterWidth = 26;
            this.prograssbar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            this.prograssbar1.ProgressWidth = 6;
            this.prograssbar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.prograssbar1.Size = new System.Drawing.Size(150, 150);
            this.prograssbar1.StartAngle = 270;
            this.prograssbar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prograssbar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.prograssbar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.prograssbar1.SubscriptText = "";
            this.prograssbar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.prograssbar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.prograssbar1.SuperscriptText = "";
            this.prograssbar1.TabIndex = 2;
            this.prograssbar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.prograssbar1.Value = 68;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Loadinggg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(255, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prograssbar1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loadinggg";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CircularProgressBar.CircularProgressBar prograssbar1;
        private System.Windows.Forms.Timer Timer;
    }
}

