using System;

public abstract class Singleton<T> where T : class, new()
{
    private static readonly object syslock = new object();
    private static T _instance = default(T);
    public static T GetSingleton()
    {
        if (_instance == null)
        {
            lock (syslock)
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
            }
        }

        return _instance;
    }

    public virtual void Init(Action callback = null)
    {
        if (callback != null)
        {
            callback();
        }
    }
    public virtual void Dispose()
    {
    }
}
