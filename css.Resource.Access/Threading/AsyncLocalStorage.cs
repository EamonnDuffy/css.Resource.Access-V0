using System;
using System.Threading;

namespace css.Resource.Access.Threading
{
    public class AsyncLocalStorage
    {
        // Static/MetaClass Attributes.
        private static readonly AsyncLocal<AsyncLocalStorage> AsyncLocal = new AsyncLocal<AsyncLocalStorage>();

        // Instance Attributes.
        private DateTime BeginRequestDateTimeUtc { get; set; }

        // Static/MetaClass Methods.
        public static void BeginRequest()
        {
#if DEBUG
            var threadId = Thread.CurrentThread.ManagedThreadId;
#endif

            // TODO: REVIEW: The following approach.
            if (AsyncLocal.Value == null)
                AsyncLocal.Value = new AsyncLocalStorage();

            AsyncLocal.Value.BeginRequestDateTimeUtc = DateTime.UtcNow;
        }

        public static long EndRequest()
        {
            var nowUtc = DateTime.UtcNow;

            var timeSpan = nowUtc - AsyncLocal.Value.BeginRequestDateTimeUtc;

            return (long)timeSpan.TotalMilliseconds;
        }
    }
}
