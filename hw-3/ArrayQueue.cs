using System;

internal class ArrayQueue
{
    private readonly int[] _queue = new int[16];
    private int _head;
    private int _tail;

    public ArrayQueue()
    {
        _head = 0;
        _tail = 0;
    }

    public void Push(int temp)
    {
        {
            _queue[_tail] = temp;
            _tail = (_tail + 1)%_queue.Length;
            if (_tail == _head) _head = (_head + 1)%_queue.Length;
        }
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error");
            throw new ApplicationException("Empty queue pop is denied");
        }
        int x = _queue[_head];
        _head = (_head + 1)%_queue.Length;
        return x;
    }

    public int Peek()
    {
        return _queue[_head];
    }

    public bool IsEmpty()
    {
        return _head == _tail;
    }

    public int Size()
    {
        if (_head > _tail) return _queue.Length - _head + _tail;
        return _tail - _head;
    }
}