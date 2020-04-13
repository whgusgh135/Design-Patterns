using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    // No Thread Safe Singleton

    /* 
    Two different threads could both have evaluated the test (if instance == null) and found it to be true, 
    then both create instances, which violates the singleton pattern.

    Note that in fact the instance may already have been created before the expression is evaluated, 
    but the memory model doesn't guarantee that the new value of instance will be seen by other threads 
    unless suitable memory barriers have been passed.
    public sealed class BadSingleton
    */

    public sealed class BadSingleton
    {
        //Private Constructor.  
        private BadSingleton()
        {
        }
        private static BadSingleton instance = null;
        public static BadSingleton Instance
        {
            get
            {
                if (BadSingleton == null)
                {
                    instance = new BadSingleton();
                }
                return instance;
            }
        }
    }


    // Thread Safe Singleton

    /*
    In the following code, the thread is locked on a shared object and checks whether an instance has been created or not.

    This takes care of the memory barrier issue and ensures that only one thread will create an instance.

    For example: Since only one thread can be in that part of the code at a time, by the time the second thread enters it, 
    the first thread will have created the instance, so the expression will evaluate to false.

    The biggest problem with this is performance; performance suffers since a lock is required every time an instance is requested.
     */

    public sealed class BetterSingleton
    {
        BetterSingleton()
        {
        }
        private static readonly object padlock = new object();
        private static BetterSingleton instance = null;
        public static BetterSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BetterSingleton();
                    }
                    return instance;
                }
            }
        }
    }

    // Fully lazy instantiation

    public sealed class LSingleton
    {
        private LSingleton()
        {
        }

        public static LSingleton Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly LSingleton instance = new LSingleton();
        }
    }


    // Using Lazy<T> Type

    public sealed class LazySingleton
    {
        private LazySingleton()
        {
        }
        private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());
        public static LazySingleton Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
