using System;
using System.Collections.Generic;
using until.develop;


namespace until.utils.algorithm
{
    public class PriorityQueue<T> where T : IComparable
    {
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        private T[] _Heap = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="capacity"></param>
        public PriorityQueue(int capacity)
        {
            Capacity = capacity;
            Count = 0;
            _Heap = new T[Capacity];
        }

        /// <summary>
        /// 値の挿入
        /// </summary>
        /// <param name="element"></param>
        public void push(T element)
        {
            if (Count >= Capacity)
            {
                resize(Capacity * 2);
            }

            int index = Count++;
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (compare(_Heap[parent], element))
                {
                    break;
                }
                _Heap[index] = _Heap[parent];
                index = parent;
            }

            _Heap[index] = element;
        }

        /// <summary>
        /// 拡張
        /// </summary>
        public void resize(int capacity)
        {
            var newheap = new T[capacity];
            var num = Math.Min(Count, capacity);
            for (int index = 0; index < num; ++index)
            {
                newheap[index] = _Heap[index];
            }

            Capacity = capacity;
            Count = num;
            _Heap = newheap;
        }

        /// <summary>
        /// 値の取り出し
        /// </summary>
        /// <param name="element"></param>
        public T pop()
        {
            if (Count <= 0)
            {
                return default(T);
            }

            T result = _Heap[0];
            T element = _Heap[--Count];

            int index = 0;
            while (true)
            {
                int a = index * 2 + 1;
                if (a >= Count)
                {
                    break;
                }
                int b = a + 1;
                if (b < Count && compare(_Heap[b], _Heap[a]))
                {
                    a = b;
                }

                if (compare(element, _Heap[a]))
                {
                    break;
                }

                _Heap[index] = _Heap[a];
                index = a;
            }
            _Heap[index] = element;

            return result;
        }

        /// <summary>
        /// 比較。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>a < b であれば true</returns>
        private bool compare(T a, T b)
        {
            return a.CompareTo(b) <= 0;
        }

#if TEST
        /// <summary>
        /// デバッグ用の内容出力
        /// </summary>
        public void dump()
        {
            for (var index = 0; index < Count; ++index)
            {
                Log.info(this, $"[{index}] = {_Heap[index]}");
            }
        }
#endif
    }
}
