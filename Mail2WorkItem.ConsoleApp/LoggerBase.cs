﻿using Mail2WorkItem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail2WorkItem.ConsoleApp
{
    class LoggerBase
    {
        private LogLevel minLevel;

        protected LoggerBase(LogLevel level)
        {
            this.minLevel = level;
        }

        static ConsoleColor MapColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Critical:
                    return ConsoleColor.Red;
                case LogLevel.Error:
                    return ConsoleColor.Red;
                case LogLevel.Warning:
                    return ConsoleColor.Yellow;
                case LogLevel.Information:
                    return ConsoleColor.Gray;
                case LogLevel.Verbose:
                    return ConsoleColor.Cyan;
                case LogLevel.Diagnostic:
                    return ConsoleColor.Cyan;
                default:
                    return ConsoleColor.Gray;
            }//switch
        }

        public LogLevel Level
        {
            get { return minLevel; }
            set { minLevel = value; }
        }

        protected void Log(LogLevel level, string format, params object[] args)
        {
            if (level > this.minLevel)
                return;

            string message = args != null ? string.Format(format, args: args) : format;

            ConsoleColor save = Console.ForegroundColor;
            Console.ForegroundColor = MapColor(level);

            string levelAsString = level.ToString();
            Console.Write("[{0}]{1}", levelAsString, string.Empty.PadLeft(12 - levelAsString.Length));
            Console.WriteLine(message);

            Console.ForegroundColor = save;
        }
    }
}
