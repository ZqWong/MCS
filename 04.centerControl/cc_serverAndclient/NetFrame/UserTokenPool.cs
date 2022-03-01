using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerFrame
{
    /// <summary>
    /// 客户端连接对象池
    /// </summary>
    public class UserTokenPool
    {
        // 表示同一任意类型的实例的大小可变的后进先出(LIFO)集合
        private Stack<UserToken> _Pool;

        public UserTokenPool(int maxClientConnectionNum)
        {
            _Pool = new Stack<UserToken>(maxClientConnectionNum);
        }

        /// <summary>
        /// 取出一个连接对象（创建连接时，从客户端对象池内取出客户端对象）
        /// </summary>
        /// <returns>客户端连接对象</returns>
        public UserToken pop()
        {
            return _Pool.Pop();
        }

        /// <summary>
        /// 插入一个连接对象（释放连接时，将客户端对象放回客户端对象池内）
        /// </summary>
        public void push(UserToken token)
        {
            if (token != null)
            {
                _Pool.Push(token);
            }
        }

        /// <summary>
        /// 池大小
        /// </summary>
        public int Size
        {
            get { return _Pool.Count; }
        }

        /* 问题1：为什么取出是创建连接，插入是释放连接？
         * 答：【取出一个连接对象--创建连接】，【插入一个连接对象--释放连接】
         * 因为客户端连接对象是在服务器初始化的时候就创建了的，当时创建一个就往连接池里放一个，所以当之后有客户端
         * 发来连接请求的时候，就不用新建客户端连接对象了，直接到池里去取之前创建好的连接就OK了，这就是所谓的【取出一个连接对象--创建连接】，
         * 即我要创建连接，就到池里面取一个连接对象就好了。
         * 分析：这样做有利有弊。
         * 缺点：再预设最大客户端连接数目很大的时候，在服务器初始化的时候会短时间大量的创建客户端连接对象。当【实际客户端连接数】少于【最大客户端连接数】的时候，会有闲置的【客户端连接对象】空占内存的情况。
         * 优点：就是后期但凡有客户端连接都不需要创建客户端连接对象了。应该能加快客户端连接的速度。
         */
    }
}
