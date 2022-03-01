using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DW_CC_NET.tools
{


    public class OneThreadSynchronizationContext : Singleton<OneThreadSynchronizationContext>
    {
        // 线程同步队列,发送接收socket回调都放到该队列,由poll线程统一执行
        private readonly ConcurrentQueue<Action> _queue = new ConcurrentQueue<Action>();

        private SynchronizationContext _syncContext;

        public OneThreadSynchronizationContext()
        {
            //_syncContext = new SynchronizationContext();
        }

        private void Add(Action action)
        {
            this._queue.Enqueue(action);
        }

        public void Update()
        {
            while (true)
            {
                Action a;
                if (this._queue.TryDequeue(out a))
                {
                    a();
                }
                else
                {
                    break;
                }

            }
        }

        public void Post(SendOrPostCallback callback, object state)
        {
            this.Add(() => { callback(state); });
        }
    }

}
