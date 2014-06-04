﻿/*
 * Created by SharpDevelop.
 * User: tfooo
 * Date: 11/12/2005
 * Time: 4:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using DspAudio;
using DspAudio.Vst;
using DspAudio.Vst.Module;
using DspAudio.Vst.Xml;
using Jacobi.Vst.Core;

namespace DspAudio.Vst.Xml
{
	public class VstModule : PluginBase
	{
		[XmlAttribute,DefaultValue(1.0f)] public float Amplitude {
			get { return amplitude; }
			set { amplitude = value; }
		} float amplitude;
		[XmlAttribute] public string Title {
			get { return title; }
			set { title = value; }
		} string title;
		[XmlAttribute,DefaultValue(0)] public int ProgramId {
			get { return programId; }
			set { programId = value; }
		} int programId;
		[XmlAttribute,DefaultValue(0)] public int PatchId {
			get { return patchId; }
			set { patchId = value; }
		} int patchId;
		[XmlAttribute] public string Category {
			get { return category; }
			set { category = value; }
		} string category;
		
		public VstModule()
		{
		}
		public VstModule(VstPlugin plugin)
		{
			title = plugin.Title;
			patchId = plugin.PluginCommandStub.GetProgram();
			category = plugin.PluginCommandStub.GetCategory().ToString();
	//			var result = plugin.PluginCommandStub.BeginLoadBank(
	//				new VstPatchChunkInfo(
	//					1,
	//					plugin.PluginInfo.PluginID,
	//					plugin.PluginInfo.PluginVersion,
	//					plugin.PluginInfo.ProgramCount
	//				)
	//			);
	//			if (result== VstCanDoResult.Yes) { }
			try { this.ProgramDump = plugin.PluginCommandStub.GetChunk(false); } catch { }
			try { this.PatchDump   = plugin.PluginCommandStub.GetChunk(true); } catch { }
		}
	}
}
