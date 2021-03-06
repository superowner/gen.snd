﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18213
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AvUtil {
	using System;
	
	
	/// <summary>
	///   A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	// This class was auto-generated by the StronglyTypedResourceBuilder
	// class via a tool like ResGen or Visual Studio.
	// To add or remove a member, edit your .ResX file then rerun ResGen
	// with the /str option, or rebuild your VS project.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	public class Strings {
		
		private static global::System.Resources.ResourceManager resourceMan;
		
		private static global::System.Globalization.CultureInfo resourceCulture;
		
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Strings() {
		}
		
		/// <summary>
		///   Returns the cached ResourceManager instance used by this class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Resources.ResourceManager ResourceManager {
			get {
				if (object.ReferenceEquals(resourceMan, null)) {
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AvUtil.Strings", typeof(Strings).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}
		
		/// <summary>
		///   Overrides the current thread's CurrentUICulture property for all
		///   resource lookups using this strongly typed resource class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Globalization.CultureInfo Culture {
			get {
				return resourceCulture;
			}
			set {
				resourceCulture = value;
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -c:a libfaac
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -q:a (vbr example): -q:a 100
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///@ffmpeg.exe -i &quot;%~1&quot; -vn -c:a %~2 -ar 44100 -b:a %~3 &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_2m4a_codec_rate {
			get {
				return ResourceManager.GetString("cmd 2m4a codec rate", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @echo off
		///@set path=%~dp0..\bin;%~dp0;%path%
		///call ffmpeg-capture-vars %1
		///
		///echo FPS
		///set v.fps=30
		///
		///echo Video Bit-Rate
		///set v.kbps=1200k
		///set v.kbps=500k
		///set v.kbps=900000
		///set v.ext=mp4
		///set v.codec=libx264
		///
		///::	-f %v.box% ^
		///::	-y -q 150 ^
		///rem -g 100
		///ffmpeg -i &quot;%f%&quot; ^
		///	-r %v.fps% ^
		///	-strict -2 ^
		///	-vb %v.kbps% ^
		///	-vcodec %v.codec% ^
		///	-acodec %a.codec% ^
		///	-ab %a.kbps% ^
		///	-ar %a.rate% ^
		///	&quot;%~dpn1.%v.ext%&quot;
		///pause
		///.
		/// </summary>
		public static string cmd_avc_mp4_900k {
			get {
				return ResourceManager.GetString("cmd avc mp4 900k", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to :: File
		///set f=%~1
		///set f.short=%~1
		///set f.path=%~p1
		///set f.name=%~n1
		///set f.ext=%~x1
		///set f.drive=%~d1
		///set f.out=img%%00d.png
		///:: Video (default)
		///set v.fps=25
		///set v.codec=flv
		///set v.box=flv
		///set v.fps=1
		///set v.kbps=800
		///:: test vars
		///set v.start=00:00:05
		///set v.duration=00:00:01
		///:: Audio Info
		///set a.codec=aac
		///set a.kbps=96k
		///set a.rate=44100
		///.
		/// </summary>
		public static string cmd_ffmpeg_capture_vars {
			get {
				return ResourceManager.GetString("cmd ffmpeg capture vars", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///title %~n1
		///:: -c:a libfaac
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -q:a (vbr example): -q:a 100
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///:: -vn (no vid)
		///set starter=F:\Horde\artifacts\Media\
		///set join1=2013-01-27A_BEB_JayP_AndrewBartzis_OliviaValencia_Topic_Pyramids-18kbps.m4a
		///set join2=2012-01-27_EB_Guests_AndrewBartzis_OliviaValencia_Topic_Pyramids_Continued.m4a
		///cmd /k /e:on /v:on
		///.
		/// </summary>
		public static string cmd_ffmpeg_shell {
			get {
				return ResourceManager.GetString("cmd ffmpeg shell", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///@ffmpeg -i &quot;%~1&quot; -vn -acodec copy &quot;%~dpn1.ogg&quot;
		///pause
		///.
		/// </summary>
		public static string cmd_ffmpeg_webm_getogg {
			get {
				return ResourceManager.GetString("cmd ffmpeg webm getogg", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///title %~n1
		///:: -c:a libfaac
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -q:a (vbr example): -q:a 100
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///:: -vn (no vid)
		///@ffmpeg.exe -i &quot;%~1&quot; -vn -c:a libaacplus -ar 44100 -b:a 18000 &quot;%~dpn1-18kbps.m4a&quot;
		///del %1
		///.
		/// </summary>
		public static string cmd_m4a_2_m4a_18k_aacplus {
			get {
				return ResourceManager.GetString("cmd m4a 2 m4a 18k aacplus", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///@title %~n1
		///del out.m4a
		///:: -c:a libfaac
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -q:a (vbr example): -q:a 100
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///:: -vn (no vid)
		///@set starter=F:\Horde\artifacts\Media\
		///@set join1=2013-01-27A_BEB_JayP_AndrewBartzis_OliviaValencia_Topic_Pyramids-18kbps.m4a
		///@set join2=2012-01-27_EB_Guests_AndrewBartzis_OliviaValencia_Topic_Pyramids_Continued.m4a
		///
		///ffmpeg -f concat -i files.list -c copy out.m4a
		///pause
		///.
		/// </summary>
		public static string cmd_m4a_2_m4a_18k_aacplus_join_demo {
			get {
				return ResourceManager.GetString("cmd m4a 2 m4a 18k aacplus join demo", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin-mp4box;%path%
		///@MP4Box -add &quot;%~nx1&quot;:mpeg4 &quot;%~n1.m4a&quot;
		///pause
		///.
		/// </summary>
		public static string cmd_m4b_to_m4a {
			get {
				return ResourceManager.GetString("cmd m4b to m4a", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -c:a libfaac
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -q:a (vbr example): -q:a 100
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///:: -vn (no vid)
		///@ffmpeg.exe -i &quot;%~1&quot; -vn -c:a libaacplus -ar 44100 -b:a 18000 &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_18k_aacplus {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 18k aacplus", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -c:a libfaac
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -q:a (vbr example): -q:a 100
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///@ffmpeg.exe -i &quot;%~1&quot; -vn -c:a libaacplus -ac 1 -ar 44100 -b:a 18000 &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_18k_aacplus_mono {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 18k aacplus mono", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///@ffmpeg.exe -i %1 -vn -acodec libvo_aacenc -ab 24k &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_24k {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 24k", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -c:a libfaac
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -q:a (vbr example): -q:a 100
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///@ffmpeg.exe -i &quot;%~1&quot; -vn -c:a libaacplus -ac 1 -ar 44100 -b:a 24000 &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_24k_aacplus {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 24k aacplus", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -ac (audio channels)
		///:: -ab (audio bitrate)
		///@ffmpeg.exe -i %1 -vn -acodec libfaac -ab 24k -ac 1 &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_24k_faac {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 24k faac", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///@ffmpeg.exe -i %1 -vn -acodec libvo_aacenc -ab 32k &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_32k {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 32k", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///@ffmpeg.exe -i &quot;%~1&quot; -vn -acodec libaacplus -b:a 32000 -ar 44100 &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_32k_aacplus {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 32k aacplus", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -ac (audio channels)
		///:: -ab (audio bitrate)
		///@ffmpeg.exe -i %1 -vn -acodec libfaac -ab 32k &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_32k_faac {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 32k faac", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to @set path=%~dp0..\bin;%path%
		///:: -ac (audio channels)
		///:: -aq (audio quality VBR)
		///:: -ab (audio bitrate)
		///:: -b:a (audio bitrate)
		///@ffmpeg.exe -i &quot;%~1&quot; -vn -acodec libaacplus -b:a 64000 -ar 44100 &quot;%~dpn1.m4a&quot;
		///@pause
		///.
		/// </summary>
		public static string cmd_mp3_2_m4a_48k_aacplus_ar96k {
			get {
				return ResourceManager.GetString("cmd mp3 2 m4a 48k aacplus ar96k", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to These commands are just here to help as a placeholder for commands that have been useful in the past..
		/// </summary>
		public static string cmd_note {
			get {
				return ResourceManager.GetString("cmd note", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to mp4box.exe.
		/// </summary>
		public static string Command_EXE_MP4BOX {
			get {
				return ResourceManager.GetString("Command EXE MP4BOX", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to -i &quot;{0}&quot; -acodec copy -t {1} -ss {2} &quot;{3}&quot;.
		/// </summary>
		public static string Command_FFMPEG_Command {
			get {
				return ResourceManager.GetString("Command FFMPEG Command", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to bin\.
		/// </summary>
		public static string Command_Path_mp4box {
			get {
				return ResourceManager.GetString("Command Path mp4box", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to bin\mp4box.exe.
		/// </summary>
		public static string Command_Resource_MP4BOX {
			get {
				return ResourceManager.GetString("Command Resource MP4BOX", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to bin\ffmpeg.exe.
		/// </summary>
		public static string ffmpeg_app {
			get {
				return ResourceManager.GetString("ffmpeg app", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to -i &quot;$(input)&quot; -acodec copy -t $(time-len) -ss $(time-begin) &quot;$(output)&quot;.
		/// </summary>
		public static string ffmpeg_params {
			get {
				return ResourceManager.GetString("ffmpeg params", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to MPEG AAC-HC|*.aac;.
		/// </summary>
		public static string Filter_AAC {
			get {
				return ResourceManager.GetString("Filter AAC", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to All Media (Tag) Formats|*.m4a;*.mp4;*.mpeg;*.mp3;*.aac;*.flac;*.ogg|Mpeg 4 Audio|*.m4a;*.aac;*.mp4|MP3 Audio|*.mp3;|FLAC|*.flac|OGG (Vorbis)|*.ogg.
		/// </summary>
		public static string Filter_All_Media_Formats {
			get {
				return ResourceManager.GetString("Filter All Media Formats", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to Flac|*.flac.
		/// </summary>
		public static string Filter_FLAC {
			get {
				return ResourceManager.GetString("Filter FLAC", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to MPEG Layer 4 Audio AAC|*.m4a;.
		/// </summary>
		public static string Filter_M4A {
			get {
				return ResourceManager.GetString("Filter M4A", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to MPEG Layer 3 Audio|*.mpeg;*.mpg;.
		/// </summary>
		public static string Filter_MP3 {
			get {
				return ResourceManager.GetString("Filter MP3", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to Vorbis Ogg|*.ogg.
		/// </summary>
		public static string Filter_VORBIS__OGG_ {
			get {
				return ResourceManager.GetString("Filter VORBIS (OGG)", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to {0:##,###,#00}:{1:##,###,#00}:{2:00}.{3:000}.
		/// </summary>
		public static string Format_Time_String {
			get {
				return ResourceManager.GetString("Format Time String", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized resource of type System.Drawing.Bitmap.
		/// </summary>
		public static System.Drawing.Bitmap image_title_area {
			get {
				object obj = ResourceManager.GetObject("image title area", resourceCulture);
				return ((System.Drawing.Bitmap)(obj));
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to (?&lt;ss&gt;[0-9]*)\.?(?&lt;ttt&gt;[0-9]*).
		/// </summary>
		public static string Regex_Time_Expression_1 {
			get {
				return ResourceManager.GetString("Regex Time Expression 1", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to (?&lt;hh&gt;[0-9]*):?(?&lt;mm&gt;[0-9]*):?(?&lt;ss&gt;[0-9]*)\.?(?&lt;ttt&gt;[0-9]*).
		/// </summary>
		public static string Regex_Time_Expression_3 {
			get {
				return ResourceManager.GetString("Regex Time Expression 3", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to (?&lt;dd&gt;[0-9]*):?(?&lt;hh&gt;[0-9]*):?(?&lt;mm&gt;[0-9]*):?(?&lt;ss&gt;[0-9]*)\.?(?&lt;ttt&gt;[0-9]*).
		/// </summary>
		public static string Regex_Time_Expression_4 {
			get {
				return ResourceManager.GetString("Regex Time Expression 4", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to (?&lt;mm&gt;[0-9]*):?(?&lt;ss&gt;[0-9]*)\.?(?&lt;ttt&gt;[0-9]*).
		/// </summary>
		public static string Regex_Time_Expressoin_2 {
			get {
				return ResourceManager.GetString("Regex Time Expressoin 2", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to Time #1 (start)
		///	{time1}
		///
		///Time #2 (end)
		///	{time2}
		///
		///Length
		///	{difference}.
		/// </summary>
		public static string Time_Calculation_String {
			get {
				return ResourceManager.GetString("Time Calculation String", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to {0:mm\:ss}.
		/// </summary>
		public static string TimeOutputFormat_00_MS {
			get {
				return ResourceManager.GetString("TimeOutputFormat 00 MS", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to {0:dd\:HH\:mm\:ss}.
		/// </summary>
		public static string TimeOutputFormat_01_DHMS {
			get {
				return ResourceManager.GetString("TimeOutputFormat 01 DHMS", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to {0:HH\:mm\:ss}.
		/// </summary>
		public static string TimeOutputFormat_02_HMS {
			get {
				return ResourceManager.GetString("TimeOutputFormat 02 HMS", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to {0:HH\:mm\:ss.fff}.
		/// </summary>
		public static string TimeOutputFormat_03_HMSF {
			get {
				return ResourceManager.GetString("TimeOutputFormat 03 HMSF", resourceCulture);
			}
		}
	}
}
