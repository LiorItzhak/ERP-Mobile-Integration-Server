//using PostSharp.Aspects;
//using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Configuration;
using NLog;
//using PostSharp.Patterns.Diagnostics;
//using PostSharp.Patterns.Diagnostics.Backends.NLog;
using LogLevel = NLog.LogLevel;
//using static PostSharp.Patterns.Diagnostics.FormattedMessageBuilder;

namespace CrossLayersUtils.Aspects
{
    [AttributeUsage (AttributeTargets.Method, AllowMultiple = true,Inherited =true)]

    //[PSerializable]
    public class LogMethodAttribute :Attribute// : OnMethodBoundaryAspect
    {
        public string Before { get; set; }
        public string After { get; set; }
        public string Succeed { get; set; }
        public string Exception { get; set; }

        static LogMethodAttribute()
        {
            
            // Configure NLog.
//            var config = new NLog.Config.LoggingConfiguration();
//
//            var logfile = new NLog.Targets.FileTarget("logsFile.txt") { FileName = "logsFile.txt" };
//            var logconsole = new NLog.Targets.ConsoleTarget("console");
//            var debugger = new NLog.Targets.DebuggerTarget("debugger");
//            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
//            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
//            config.AddRule(LogLevel.Trace, LogLevel.Fatal, debugger);
//
//            logconsole.DetectConsoleAvailable = true;
//           LogManager.Configuration = config;
//           LogManager.EnableLogging();

            // Configure PostSharp Logging to use NLog.
            //LoggingServices.DefaultBackend = new NLogLoggingBackend(new LogFactory(config));
          //  LoggingServices.DefaultBackend.DefaultVerbosity.SetMinimalLevel(PostSharp.Patterns.Diagnostics.LogLevel.Trace);
          //  logSource = LogSource.Get() ;

        }
      //  private static readonly LogSource logSource;


     //   DateTime startTime;
//        public override void OnEntry(MethodExecutionArgs args)
//        {
//            if(!String.IsNullOrEmpty(Before))
//            logSource.Debug.Write(Formatted(Before));
//
//            startTime = DateTime.Now;
//            logSource.Debug.Write(Formatted($"{args.Method.DeclaringType.FullName} enter method :'{args.Method.Name}' ,with args :{string.Join(",", args.Arguments.ToArray())}"));
//        }
//
//        public override void OnException(MethodExecutionArgs args)
//        {
//            if (!String.IsNullOrEmpty(Exception))
//                logSource.Debug.Write(Formatted(Exception));
//            logSource.Warning.Write(Formatted($"throws exception :{args.Exception.Message} "));
//        }
//
//        public override void OnExit(MethodExecutionArgs args)
//        {
//            if (!String.IsNullOrEmpty(After))
//                logSource.Debug.Write(Formatted(After));
//            logSource.Debug.Write(Formatted($"{args.Method.DeclaringType.FullName} exit method :'{args.Method.Name}'  duration : {(DateTime.Now - startTime).TotalSeconds}s"));
//        }
//
//        public override void OnSuccess(MethodExecutionArgs args)
//        {
//            if (!String.IsNullOrEmpty(Succeed))
//                logSource.Debug.Write(Formatted(Succeed));
//        }
    }
}
