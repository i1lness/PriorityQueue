namespace Algorithm
{
    class PriorityQueue
    {
        List<int> _heap = new List<int>();

        public void Push(int data)
        {
            _heap.Add(data);

            int now = _heap.Count - 1;

            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now] < _heap[next])
                    break;

                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
        }

        public int Pop()
        {
            int ret = _heap[0];

            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now;

                int next = now;

                if (left <= lastIndex && _heap[next] < _heap[left])
                    next = left;

                if (right <= lastIndex && _heap[next] < _heap[right])
                    next = right;

                if (next == now)
                    break;

                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count();
        }
    }

    public class Program
    {
        static void Main(String[] args)
        {
            PriorityQueue q = new PriorityQueue();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);

            while(q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }
        }
    }
}