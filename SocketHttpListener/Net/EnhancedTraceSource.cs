using System;
using System.Diagnostics;

namespace SocketHttpListener.Net
{
   ///
   /// Extension methods to add Info/Debug/Error to TraceSource, tracking a subset of the 
   /// Patterns.Logging API for easy replacement.
   ///
   internal static class EnhancedTraceSource
   {
      static internal void Debug(this TraceSource ts, string format, params object[] args)
      {
         ts.TraceEvent(TraceEventType.Verbose, 0, format, args);
      }
      
      static internal void Info(this TraceSource ts, string format, params object[] args)
      {
         ts.TraceEvent(TraceEventType.Information, 0, format, args);
      }
      
      /// <summary>
      /// Add "TraceWarning" to the default TraceSource implementation.
      /// </summary>
      static internal void Warning(this TraceSource ts, string format, params object[] args)
      {
         ts.TraceEvent(TraceEventType.Warning, 0, format, args);
      }
      
      /// <summary>
      /// Add "TraceError" to the default TraceSource implementation.
      /// </summary>
      static internal void Error(this TraceSource ts, string format, params object[] args)
      {
         ts.TraceEvent(TraceEventType.Error, 0, format, args);
      }
      
      static internal void ErrorException(this TraceSource ts, string format, Exception ex, params object[] args)
      {
         string msg = String.Format( format, args );
         msg = String.Format( "{0}: {1}", msg, ex.ToString() ); // Let's not get fancy.
         ts.TraceEvent(TraceEventType.Error, 0, msg);
      }
   }
}
