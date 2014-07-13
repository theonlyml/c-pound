using System;

internal class ArrayQueueSingleton
{
    private  static readonly  int[] _queue = new int[16];
    private static int _head;
    private static int _tail;

    static ArrayQueueSingleton()
    {
        _head = 0;
        _tail = 0;
    }

    public static void Push(int temp)
    {
        {
            _queue[_tail] = temp;
            _tail = (_tail + 1) % _queue.Length;
            if (_tail == _head) _head = (_head + 1) % _queue.Length;
        }
    }

    public static int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error");
            throw new ApplicationException("Empty queue pop is denied");
        }
        int x = _queue[_head];
        _head = (_head + 1) % _queue.Length;
        return x;
    }

    public static int Peek()
    {
        return _queue[_head];
    }

    public static bool IsEmpty()
    {
        return _head == _tail;
    }

    public static int Size()
    {
        if (_head > _tail) return _queue.Length - _head + _tail;
        return _tail - _head;
    }
}