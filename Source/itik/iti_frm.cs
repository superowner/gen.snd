using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using DspAudio.Formats;

namespace itik
{
	public class iti_frm : System.Windows.Forms.Form
	{
		public void lvcols(ref ListView lv, string[] columns)
		{
			lv.Columns.Clear();
			foreach (string str in columns) { lv.Columns.Add(str);  }
		}
		
		public void lvsize(ref ListView lv, ColumnHeaderAutoResizeStyle style)
		{
			foreach (ColumnHeader ch in lv.Columns) ch.AutoResize(style);
		}

		private bool midf;
		private int newint = 0, oldint = 0, vh = 64, numnum = 0;
		private ITI mo;
		
		[Flags]
		private enum rarg : byte
		{
			file = 1,
			old = 2
		}
		
		
		public iti_frm()
		{
			InitializeComponent();
		}
		
		public ITI loadITI()
		{
			OpenFileDialog OFD = new OpenFileDialog();
			OFD.Filter = "ITI|*.iti";
			OFD.ShowDialog();
			string bon = OFD.FileName;
			OFD.Dispose();
			return new ITI(bon);
		}
		
		public void OpenToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			mo = loadITI();
			theBigTrick();
		}
		public void theBigTrick()
		{
			
			//mo.ITI_INST.impVolEnvelop
			
			ts_nsmp.Text = mo.ITI_INST.impNumberOfSamples.ToString("00#smp");
			ts_nsmp.ToolTipText = "number of samples";
			ts_nna.Text = mo.ITI_INST.impNewNoteAction.ToString();
			ts_nsmp.ToolTipText = "new note action";
			this.lsmp.Items.Clear();
			lvcols(ref lsmp,new string[]{"dosn","instn","srate","flags","cvt","pointer?","loopA","loopB","susA","susB"});
			foreach(ITI.impx smpd in mo.ITI_SMPH)
			{
				ListViewItem sam = this.lsmp.Items.Add(
					smpd.impsSampleName
				);
				sam.SubItems.AddRange(new string[]{
				                      	smpd.impsDosFileName,
				                      	smpd.impsC5Speed.ToString("##,###,###,##0"),
				                      	(smpd.impsFlag.ToString()),
				                      	(smpd.impsCvt.ToString()),
				                      	(smpd.impsSamplePointer.ToString("X")),
				                      	(smpd.impsLoopBegin.ToString("##,###,###,##0")),
				                      	(smpd.impsLoopEnd.ToString("##,###,###,##0")),
				                      	(smpd.impsSusLoopBein.ToString("##,###,###,##0")),
				                      	(smpd.impsSusLoopEnd.ToString("##,###,###,##0"))
				                      });
			}
			lins.Items.Clear();
			lvcols(ref lins,new string[]{"n","nn","smp","smp"});
			//	lvcols(ref lins,new string[]{"dosn","instn","nna","dca","fade","PPS","PPC","GbV","Pan","amp:var","p:var"});
			int x=0; foreach(ITI.keyMap kmp in mo.ITI_INST.impNoteMap)
			{
				string mx;
				if ( kmp.epVal==0xFF ) mx = null;
				else if(kmp.epVal==0xFE) mx = "[FLAG!]";
				else mx = mo.NN[kmp.epVal];
				if (kmp.epPos-1 < mo.ITI_SMPH.Length && kmp.epPos > 0)
				{
					ListViewItem mam = this.lins.Items.Add
						(
							x.ToString("00#")
						);
					mam.SubItems.AddRange(new string[]
					                      {
					                      	mo.NN[(x++)],
					                      	mo.ITI_SMPH[kmp.epPos-1].impsSampleName,
					                      	mx
					                      });
				}
				else if (kmp.epPos == 0)
				{
					ListViewItem mam = this.lins.Items.Add(
						x.ToString("00#")
					);
					mam.SubItems.AddRange(new string[]{
					                      	mo.NN[(x++)],
					                      	"[empty]",
					                      	mx
					                      });
				}
				else
				{
					MessageBox.Show(kmp.epPos.ToString());
				}
			}
			lvsize(ref lsmp, ColumnHeaderAutoResizeStyle.ColumnContent);
			lvsize(ref lins, ColumnHeaderAutoResizeStyle.ColumnContent);
			ts_nsmp.Text = mo.ITI_INST.impVolEnvelop.envFlag.ToString();
			this.ts_nna.Text = mo.ITI_INST.impInstrumentName;
		}

		void eExit(object sender, System.EventArgs e) { Dispose(); }
		void eMmv(object sender, System.EventArgs e) { mmv(); }
		void eMouse(object sender, MouseEventArgs e) {
			newint = e.X;
			switch (e.Button)
			{
//				case MouseButtons.None:
//					Text = e.Button.ToString()+" "+(e.X/ppx).ToString()+" "+(((int)e.Y*(64f/pik.ClientSize.Height))).ToString("##,###,##0.00");
//					break;
				case MouseButtons.Middle:
					break;
//					Text = e.Button.ToString()+" "+(e.X/ppx).ToString()+" "+(((int)e.Y*(64f/pik.ClientSize.Height))).ToString("##,###,##0.00");
//					break;
					default: midf = false;
					newint = e.X;
					numnum = (int)(vh-(e.Y*((float)vh/(float)pik.ClientSize.Height)));
					if (numnum <=vh & numnum >=0)
						Text = string.Format( "{0}{1}{2:##,###,##0.00}", e.Button, e.X/ppx, numnum );
					oldint = newint;
					break;
			}
			oldint = newint;
			mmv();
		}

		Graphics gx;

		int ppx=6;
		void mmv() {
			try
			{
				Bitmap bmp = new Bitmap(4,4,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				Graphics g = Graphics.FromImage(bmp);
				g.Clear(Color.White);
				if (((int)mo.ITI_INST.impVolEnvelop.envFlag & ((int)ITI.evl.on))>=0)
				{
					gx = pik.CreateGraphics();
					gx.Clear(Color.Black);
					Pen penn = new Pen(Color.BlanchedAlmond);
					ITI.enveloPoint pt = new ITI.enveloPoint();
					List<Point> jake = new List<Point>();
					gx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
					// volume envelope
					int c = 0; float tempx = pik.ClientSize.Height/64; // 
					ppx = 6;  // six pixels per tick
					Bitmap crx = new Bitmap("cross.png");
					Text = crx.Width.ToString();
					foreach (ITI.enveloPoint ep in mo.ITI_INST.impVolEnvelop.envPoints)
					{
						if (c<mo.ITI_INST.impVolEnvelop.envNodeCount)
							jake.Add(new Point((int)(ep.epPos*ppx),(int)(ep.epVal*tempx)));
						c++;
					}
					gx.DrawCurve(new Pen(Color.White,2),jake.ToArray());
					//	comboBox1.Items.AddRange(jake.ToArray());
				}
			} catch {}
		}

		#region Design
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lsmp = new System.Windows.Forms.ListView();
			this.lins = new System.Windows.Forms.ListView();
			this.pik = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ts_menu_file = new System.Windows.Forms.ToolStripDropDownButton();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveITIInstrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ts_nsmp = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ts_nna = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.listSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listForeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listBgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.markusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showtreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xphidetreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
			this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(560, 443);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(560, 443);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.toolStripContainer1.TopToolStripPanelVisible = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lsmp);
			this.splitContainer1.Panel1.Controls.Add(this.lins);
			this.splitContainer1.Panel1.Controls.Add(this.pik);
			this.splitContainer1.Panel2Collapsed = true;
			this.splitContainer1.Size = new System.Drawing.Size(560, 443);
			this.splitContainer1.SplitterDistance = 367;
			this.splitContainer1.TabIndex = 0;
			// 
			// lsmp
			// 
			this.lsmp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lsmp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsmp.FullRowSelect = true;
			this.lsmp.Location = new System.Drawing.Point(0, 0);
			this.lsmp.Margin = new System.Windows.Forms.Padding(0);
			this.lsmp.Name = "lsmp";
			this.lsmp.Size = new System.Drawing.Size(292, 338);
			this.lsmp.TabIndex = 4;
			this.lsmp.UseCompatibleStateImageBehavior = false;
			this.lsmp.View = System.Windows.Forms.View.Details;
			// 
			// lins
			// 
			this.lins.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lins.Dock = System.Windows.Forms.DockStyle.Right;
			this.lins.FullRowSelect = true;
			this.lins.HideSelection = false;
			this.lins.LabelWrap = false;
			this.lins.Location = new System.Drawing.Point(292, 0);
			this.lins.Margin = new System.Windows.Forms.Padding(0);
			this.lins.Name = "lins";
			this.lins.ShowGroups = false;
			this.lins.Size = new System.Drawing.Size(268, 338);
			this.lins.TabIndex = 2;
			this.lins.UseCompatibleStateImageBehavior = false;
			this.lins.View = System.Windows.Forms.View.Details;
			// 
			// pik
			// 
			this.pik.AutoScroll = true;
			this.pik.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pik.Location = new System.Drawing.Point(0, 338);
			this.pik.Name = "pik";
			this.pik.Size = new System.Drawing.Size(560, 105);
			this.pik.TabIndex = 3;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ts_menu_file,
									this.toolStripStatusLabel3,
									this.ts_nsmp,
									this.toolStripStatusLabel1,
									this.ts_nna,
									this.toolStripStatusLabel5,
									this.toolStripStatusLabel2,
									this.toolStripDropDownButton1,
									this.toolStripStatusLabel4});
			this.statusStrip1.Location = new System.Drawing.Point(0, 443);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.statusStrip1.Size = new System.Drawing.Size(560, 22);
			this.statusStrip1.TabIndex = 2;
			// 
			// ts_menu_file
			// 
			this.ts_menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem,
									this.saveITIInstrumentToolStripMenuItem,
									this.toolStripMenuItem1,
									this.exitToolStripMenuItem});
			this.ts_menu_file.Name = "ts_menu_file";
			this.ts_menu_file.ShowDropDownArrow = false;
			this.ts_menu_file.Size = new System.Drawing.Size(27, 20);
			this.ts_menu_file.Text = "[&file]";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.openToolStripMenuItem.Text = "&Open ITI Instrument";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// saveITIInstrumentToolStripMenuItem
			// 
			this.saveITIInstrumentToolStripMenuItem.Name = "saveITIInstrumentToolStripMenuItem";
			this.saveITIInstrumentToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.saveITIInstrumentToolStripMenuItem.Text = "Save ITI Instrument";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(7, 17);
			this.toolStripStatusLabel3.Text = "|";
			// 
			// ts_nsmp
			// 
			this.ts_nsmp.Name = "ts_nsmp";
			this.ts_nsmp.Size = new System.Drawing.Size(38, 17);
			this.ts_nsmp.Text = "###smp";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(7, 17);
			this.toolStripStatusLabel1.Text = "|";
			// 
			// ts_nna
			// 
			this.ts_nna.Name = "ts_nna";
			this.ts_nna.Size = new System.Drawing.Size(26, 17);
			this.ts_nna.Text = "NNA";
			// 
			// toolStripStatusLabel5
			// 
			this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			this.toolStripStatusLabel5.Size = new System.Drawing.Size(7, 17);
			this.toolStripStatusLabel5.Text = "|";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.AutoSize = false;
			this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.toolStripStatusLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(530, 17);
			this.toolStripStatusLabel2.Spring = true;
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.listSettingsToolStripMenuItem,
									this.toolsToolStripMenuItem});
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
			this.toolStripDropDownButton1.ShowDropDownArrow = false;
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(28, 16);
			this.toolStripDropDownButton1.Text = "[opt]";
			// 
			// listSettingsToolStripMenuItem
			// 
			this.listSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.listForeToolStripMenuItem,
									this.listBgToolStripMenuItem,
									this.fontsToolStripMenuItem});
			this.listSettingsToolStripMenuItem.Name = "listSettingsToolStripMenuItem";
			this.listSettingsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.listSettingsToolStripMenuItem.Text = "[gui-color]";
			// 
			// listForeToolStripMenuItem
			// 
			this.listForeToolStripMenuItem.Name = "listForeToolStripMenuItem";
			this.listForeToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
			this.listForeToolStripMenuItem.Text = "[lists]";
			// 
			// listBgToolStripMenuItem
			// 
			this.listBgToolStripMenuItem.Name = "listBgToolStripMenuItem";
			this.listBgToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
			this.listBgToolStripMenuItem.Text = "[xp]";
			// 
			// fontsToolStripMenuItem
			// 
			this.fontsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.listsToolStripMenuItem});
			this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
			this.fontsToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
			this.fontsToolStripMenuItem.Text = "[fonts]";
			// 
			// listsToolStripMenuItem
			// 
			this.listsToolStripMenuItem.Name = "listsToolStripMenuItem";
			this.listsToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.listsToolStripMenuItem.Text = "[lists]";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.markusToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.toolsToolStripMenuItem.Text = "[tools]";
			// 
			// markusToolStripMenuItem
			// 
			this.markusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.showtreeToolStripMenuItem,
									this.xphidetreeToolStripMenuItem});
			this.markusToolStripMenuItem.Name = "markusToolStripMenuItem";
			this.markusToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
			this.markusToolStripMenuItem.Text = "[toggle]";
			// 
			// showtreeToolStripMenuItem
			// 
			this.showtreeToolStripMenuItem.Name = "showtreeToolStripMenuItem";
			this.showtreeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
			this.showtreeToolStripMenuItem.Text = "xp";
			// 
			// xphidetreeToolStripMenuItem
			// 
			this.xphidetreeToolStripMenuItem.Name = "xphidetreeToolStripMenuItem";
			this.xphidetreeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
			this.xphidetreeToolStripMenuItem.Text = "xp->tree";
			// 
			// toolStripStatusLabel4
			// 
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new System.Drawing.Size(7, 12);
			this.toolStripStatusLabel4.Text = "|";
			// 
			// iti_frm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(560, 465);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MinimumSize = new System.Drawing.Size(400, 240);
			this.Name = "iti_frm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ITI Instrument Kit";
			this.SizeChanged += new System.EventHandler(this.eMmv);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Panel pik;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fontsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showtreeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xphidetreeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem markusToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
		private System.Windows.Forms.ToolStripMenuItem listSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem listBgToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listForeToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ListView lins;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem saveITIInstrumentToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel ts_nsmp;
		private System.Windows.Forms.ToolStripDropDownButton ts_menu_file;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ListView lsmp;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStripStatusLabel ts_nna;
		private System.Windows.Forms.StatusStrip statusStrip1;
		#endregion
		
		
	}
}
