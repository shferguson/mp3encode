using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Mp3Encode.Interop;

namespace Mp3Encode.Encoding
{
    public class EncodingProgressEventArgs : EventArgs
    {
        public EncodingProgressEventArgs(int percentComplete, TimeSpan timeLeft)
        {
            PercentComplete = percentComplete;
            TimeLeft = timeLeft;
        }

        public int PercentComplete { get; private set; }
        public TimeSpan TimeLeft { get; private set; }
    }
    public delegate void EncodingProgressEventHandler(object sender, EncodingProgressEventArgs e);

    /// <summary>
    /// Interface to lame using an external process
    /// </summary>
    public class LameInterface
    {
        #region Constants

        private static string LameExe
        {
            get
            {
                return ProcessInterop.Is64BitOS ? @"Lame\64\lame.exe" : @"Lame\32\lame.exe";
            }
        }

        public static readonly int[] ValidBitRates = new int[] { 8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320 };

        public static readonly decimal[] ValidSamplingRates = new decimal[] { 8.000m, 11.025m, 12.000m, 16.000m, 22.050m, 24.000m, 32.000m, 44.100m, 48.000m };

        #endregion

        #region Private Fields

        private volatile bool cancel = false;

        #endregion

        #region Static Methods

        /// <summary>
        /// Retrieves the list of genres supported
        /// </summary>
        /// <returns></returns>
        public static List<string> GetGenreList()
        {
            List<string> list = new List<string>();

            try
            {
                using (Process lameProc = new Process())
                {
                    lameProc.StartInfo.Arguments = "--genre-list";
                    lameProc.StartInfo.FileName = LameExe;
                    lameProc.StartInfo.CreateNoWindow = true;
                    lameProc.StartInfo.RedirectStandardOutput = true;
                    lameProc.StartInfo.RedirectStandardError = true;
                    lameProc.StartInfo.UseShellExecute = false;

                    lameProc.Start();

                    while (!lameProc.StandardError.EndOfStream)
                    {
                        string genreLine = lameProc.StandardError.ReadLine();
                        string number = genreLine.Substring(0, 4);
                        string name = genreLine.Substring(4, genreLine.Length - 4);

                        list.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retreiving genre list: " + ex.Message, ex);
            }

            return list;
        }

        #endregion

        #region Events

        /// <summary>
        /// Raised when the encodingn time left or percentage changes
        /// </summary>
        public event EncodingProgressEventHandler EncodingProgress;

        #endregion

        #region Public Properties

        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }

        public string InputFile { get; set; }
        public string OutputFile { get; set; }

        public EncodingType EncodingType { get; set; }
        public int Quality { get; set; }
        public int BitRate { get; set; }
        public int AverageBitRate { get; set; }
        public decimal? SamplingRate { get; set; }
        public bool MonoMode { get; set; }

        public string Artist { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Comment { get; set; }
        public int Year { get; set; }

        #endregion

        #region Encode

        public void Encode()
        {
            cancel = false;

            try
            {
                using (StreamWriter log = new StreamWriter("encodingLog.txt"))
                using (Process lameProc = new Process())
                {
                    lameProc.StartInfo.Arguments = BuildArguments();
                    lameProc.StartInfo.FileName = LameExe;
                    lameProc.StartInfo.CreateNoWindow = true;
                    lameProc.StartInfo.RedirectStandardOutput = true;
                    lameProc.StartInfo.RedirectStandardError = true;
                    lameProc.StartInfo.UseShellExecute = false;

                    log.WriteLine("Arguments: \n\n" + lameProc.StartInfo.Arguments);

                    lameProc.Start();

                    ProcessEncodingStatusOutput(log, lameProc);

                    lameProc.WaitForExit();

                    if (!cancel && lameProc.ExitCode != 0)
                        throw new Exception("Exit code: " + lameProc.ExitCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during encoding: " + ex.Message, ex);
            }

            if (cancel)
                throw new Exception("Encoding cancelled");
        }

        #endregion

        #region Status Reporting

        private void ProcessEncodingStatusOutput(StreamWriter log, Process lameProc)
        {
            int lastPercentComplete = -1;
            TimeSpan lastTimeLeft = TimeSpan.MinValue;
            Regex percentCompleteRegEx = new Regex(@"\(\s*(\d+)%\).*(\d+:\d+)\s*$", RegexOptions.Compiled);

            while (!lameProc.StandardError.EndOfStream)
            {
                string line = lameProc.StandardError.ReadLine();
                log.WriteLine(line);

                Match match = percentCompleteRegEx.Match(line);
                if (match.Success)
                {
                    int percentComplete = int.Parse(match.Groups[1].Value);
                    TimeSpan timeLeft = TimeSpan.Parse(match.Groups[2].Value);
                    if (percentComplete != lastPercentComplete || timeLeft != lastTimeLeft)
                    {
                        OnEncodingProcessChagned(percentComplete, timeLeft);
                        lastPercentComplete = percentComplete;
                        lastTimeLeft = timeLeft;
                    }
                }

                if (cancel)
                {
                    lameProc.Kill();
                    break;
                }
            }
        }

        #endregion

        #region Aurgument Handling

        private string BuildArguments()
        {
            ValidateArguments();

            StringBuilder args = new StringBuilder("--nohist");

            switch (EncodingType)
            {
                case EncodingType.Quality:
                    args.AppendFormat(" -V {0}", Quality);
                    break;
                case EncodingType.AverageBitRate:
                    args.AppendFormat(" --abr {0}", AverageBitRate);
                    break;
                case EncodingType.ConstantBitRate:
                    args.AppendFormat(" -b {0}", BitRate);
                    break;
            }

            if (SamplingRate > 0)
                args.AppendFormat(" --resample {0}", SamplingRate);
            if (MonoMode)
                args.AppendFormat(" -a");

            AddArgumentConditional(args, "--tt", Title);
            AddArgumentConditional(args, "--ta", Artist);
            AddArgumentConditional(args, "--tl", Album);
            AddArgumentConditional(args, "--tg", Genre);
            AddArgumentConditional(args, "--tc", Comment);
            args.AppendFormat(" --ty {0}", Year);

            args.AppendFormat(" \"{0}\"", InputFile);
            args.AppendFormat(" \"{0}\"", OutputFile);

            return args.ToString();
        }

        private static void AddArgumentConditional(StringBuilder args, string arg, string value)
        {
            if (!string.IsNullOrEmpty(value))
                args.AppendFormat(" {0} \"{1}\"", arg, value);
        }

        private void ValidateArguments()
        {
            if (string.IsNullOrEmpty(OutputFile))
                throw new ArgumentException("Input file must be specified");
            if (!File.Exists(InputFile))
                throw new ArgumentException("Input file '" + InputFile + "' does not exist");
            if (string.IsNullOrEmpty(OutputFile))
                throw new ArgumentException("Output file must be specified");
            if (!Directory.Exists(Path.GetDirectoryName(OutputFile)))
                throw new ArgumentException("Output directory " + Path.GetDirectoryName(OutputFile) + " does not exist");

            switch (EncodingType)
            {
                case EncodingType.Quality:
                    if (Quality < 0 || Quality > 9)
                        throw new ArgumentException("Quality setting invalid, quality was " + Quality + ", must be between 0 and 9");
                    break;
                case EncodingType.AverageBitRate:
                    if (!ValidBitRates.Contains(AverageBitRate))
                        throw new ArgumentException("Average bit rate invalid");
                    break;
                case EncodingType.ConstantBitRate:
                    if (!ValidBitRates.Contains(BitRate))
                        throw new ArgumentException("Bit rate invalid");
                    break;
                default:
                    throw new ArgumentException("Invalid encoding type " + EncodingType);
            }

            if (SamplingRate.HasValue && !ValidSamplingRates.Contains(SamplingRate.Value))
                throw new ArgumentException("Invalid samping rate");
        }

        #endregion

        #region Private Methods

        private void OnEncodingProcessChagned(int percentComplete, TimeSpan timeLeft)
        {
            EncodingProgressEventHandler handler = EncodingProgress;
            if (handler != null)
                handler(this, new EncodingProgressEventArgs(percentComplete, timeLeft));
        }

        #endregion
    }
}