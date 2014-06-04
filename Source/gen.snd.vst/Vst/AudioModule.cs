﻿#region User/License
// oio * 7/19/2012 * 11:33 AM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using DspAudio.Midi;
using DspAudio.Vst.Module;
using Jacobi.Vst.Core;
using Jacobi.Vst.Core.Host;
using Jacobi.Vst.Interop.Host;
using NAudio.Wave;

namespace DspAudio.Vst
{
	public class AudioModule : IDisposable
	{
		public int BlockSize;
		float rate;
		/// <summary>
		/// 0 for input, 1 for output
		/// </summary>
		public VstAudioBufferManager this[int BufferIndex] {
			get { return (BufferIndex==0) ? Inputs : Outputs ; }
		}
		public VstAudioBufferManager Inputs, Outputs;
		
		public int InputsCount { get;set; }
		public int OutputsCount { get;set; }
		
		/// <summary>
		/// assign input and output buffers to parameters
		/// </summary>
		/// <param name="ins"></param>
		/// <param name="outs"></param>
		public void SetBuffers(ref VstAudioBuffer[] ins, ref VstAudioBuffer[] outs)
		{
			ins = Inputs.ToArray();
			outs = Outputs.ToArray();
		}
		
		void InitializeBufferManagers(VstPlugin plugin, int blockSize)
		{
			this.InputsCount =  plugin.PluginInfo.AudioInputCount;
			this.OutputsCount =  plugin.PluginInfo.AudioOutputCount;
			this.BlockSize = blockSize;
			//
			this.Inputs  = new VstAudioBufferManager(InputsCount, blockSize);
			if (OutputsCount > 0) this.Outputs = new VstAudioBufferManager(OutputsCount, blockSize);
			PluginProcessPrepare(plugin,blockSize);
		}
		
		void PluginProcessPrepare(VstPlugin plugin, int blockSize)
		{
			plugin.PluginCommandStub.SetBlockSize(blockSize);
			plugin.PluginCommandStub.SetSampleRate(rate);
			plugin.PluginCommandStub.SetProcessPrecision(VstProcessPrecision.Process32);
		}
		
		public AudioModule ( VstPlugin plugin, int blockSize, float rate )
		{
			this.rate = rate;
			InitializeBufferManagers(plugin,blockSize);
		}
		
		public void Dispose()
		{
			if (Inputs != null) Inputs.Dispose();
			if (Outputs != null) Outputs.Dispose();
		}
	}
}
