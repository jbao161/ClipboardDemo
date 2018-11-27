using System;
using System.Runtime.InteropServices; //required for dll import
using System.Windows.Forms;

namespace ClipboardDemo
{
    
    partial class Form_mainwindow
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MYACTION_HOTKEY_ID = 1; // hotkey unassigned

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

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                // My hotkey has been typed
                Clipboard.SetText(DateTime.Now.ToString("yyyy_MM_dd_HHmmssfff ")); // generate a timestamp
                SendKeys.Send("^V");
                // Do what you want here
                // ...
            }
            base.WndProc(ref m);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void tray_open_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void tray_close_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_mainwindow));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextmenu_tray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tray_open = new System.Windows.Forms.ToolStripMenuItem();
            this.tray_close = new System.Windows.Forms.ToolStripMenuItem();
            this.contextmenu_tray.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextmenu_tray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TrayDemo";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextmenu_tray
            // 
            this.contextmenu_tray.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextmenu_tray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tray_open,
            this.tray_close});
            this.contextmenu_tray.Name = "contextmenu_tray";
            this.contextmenu_tray.Size = new System.Drawing.Size(115, 52);
            // 
            // tray_open
            // 
            this.tray_open.Name = "tray_open";
            this.tray_open.Size = new System.Drawing.Size(114, 24);
            this.tray_open.Text = "Open";
            this.tray_open.Click += new System.EventHandler(this.tray_open_Click);
            // 
            // tray_close
            // 
            this.tray_close.Name = "tray_close";
            this.tray_close.Size = new System.Drawing.Size(114, 24);
            this.tray_close.Text = "Close";
            this.tray_close.Click += new System.EventHandler(this.tray_close_Click);
            // 
            // Form_mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form_mainwindow";
            this.Text = "TrayDemo";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextmenu_tray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextmenu_tray;
        private System.Windows.Forms.ToolStripMenuItem tray_open;
        private System.Windows.Forms.ToolStripMenuItem tray_close;
        
    }
}

