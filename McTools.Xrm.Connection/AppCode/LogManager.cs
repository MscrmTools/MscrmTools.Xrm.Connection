using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace McTools.Xrm.Connection.AppCode
{
    public class LogManager
    {
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        private readonly string _filePath;

        /// <summary>
        /// Initialize a new instance of class <see cref="SettingsManager"/>
        /// </summary>
        /// <param name="filename">Name of the file</param>
        public LogManager(string filename)
        {
            _filePath = Path.Combine(Paths.LogsPath, filename);
        }

        public enum Level
        {
            Verbose,
            Info,
            Warning,
            Error
        }

        public static Level LogLevel { get; set; } = Level.Warning;

        public string FilePath => _filePath;

        /// <summary>
        /// Deletes Log file
        /// </summary>
        public void DeleteLog()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        /// <summary>
        /// Writes an error message in the log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Message parameters</param>
        public void LogError(string message, params object[] args)
        {
            Log(Level.Error, args.Length == 0 ? message : string.Format(message, args));
        }

        /// <summary>
        /// Writes an information message in the log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Message parameters</param>
        public void LogInfo(string message, params object[] args)
        {
            if (LogLevel == Level.Info || LogLevel == Level.Verbose)
            {
                Log(Level.Info, args.Length == 0 ? message : string.Format(message, args));
            }
        }

        /// <summary>
        /// Writes an information message in the log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Message parameters</param>
        public void LogVerbose(string message, params object[] args)
        {
            if (LogLevel == Level.Verbose)
            {
                Log(Level.Info, args.Length == 0 ? message : string.Format(message, args));
            }
        }

        /// <summary>
        /// Writes a warning message in the log
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Message parameters</param>
        public void LogWarning(string message, params object[] args)
        {
            if (LogLevel == Level.Info || LogLevel == Level.Verbose || LogLevel == Level.Warning)
            {
                Log(Level.Warning, args.Length == 0 ? message : string.Format(message, args));
            }
        }

        /// <summary>
        /// Opens the log file
        /// </summary>
        public void OpenLog()
        {
            if (File.Exists(_filePath))
            {
                Process.Start(_filePath);
            }
        }

        /// <summary>
        /// Opens the log folder
        /// </summary>
        public void OpenLogFolder()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Process.Start(Path.GetDirectoryName(_filePath));
        }

        /// <summary>
        /// Set the new connection details
        /// </summary>
        /// <param name="connectionDetail">Details of the connection</param>
        public void SetConnection(ConnectionDetail connectionDetail)
        {
            _connection = connectionDetail;
        }

        /// <summary>
        /// Writes a message in a text file
        /// </summary>
        /// <param name="level">Level of the message</param>
        /// <param name="message">Content of the message</param>
        private void Log(Level level, string message)
        {
            var parentFolder = Path.GetDirectoryName(_filePath);
            if (parentFolder != null && !Directory.Exists(parentFolder))
            {
                Directory.CreateDirectory(parentFolder);
            }

            _readWriteLock.EnterWriteLock();

            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine("{0:yyyy-MM-dd hh:mm:ss.fff tt}\t{1}\t{2}\t{3}", DateTime.Now, level, message);
                }
            }
            catch (Exception error)
            {
                throw new Exception("Unable to write log for the following reason: " + error.Message, error);
            }
            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }
    }
}