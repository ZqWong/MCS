using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

[Serializable]
public class SingletonClass<T> : object where T : new()
{
    private static T s_instance = default(T);
    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new T();
            }

            return s_instance;
        }
    }
}

/// <summary>
/// 保证线程安全加lock的单例模式
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
public class LockedSingletonClass<T> where T: class , new()
{
    private static T s_instance = default(T);

    private static readonly object syslock = new object();

    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                lock (syslock)
                {
                    if (s_instance == null)
                    {
                        s_instance = new T();
                    }
                }
            }
            return s_instance;
        }
    }
}


/// <summary>
/// 保证线程安全加lock的单例模式
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
public class LockedSingletonFormClass<T> : Form where T : Form
{
    private static T s_instance = default(T);

    private static readonly object syslock = new object();

    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                lock (syslock)
                {
                    if (s_instance == null)
                    {
                        s_instance = new Form() as T;
                    }
                }
            }
            return s_instance;
        }
    }
}

public class ControlledSingletonClass<T> : object where T : class
{
    private static T s_instance = null;
    public static T Instance
    {
        get
        {
            return s_instance;
        }
    }

    public static void SetInstance(T instance)
    {
        s_instance = instance;
    }
}
