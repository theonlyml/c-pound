using System;

internal class ArrayQueueADT
{
    private readonly int[] _queue = new int[16];
    private static int _head;
    private static int _tail;

    public ArrayQueueADT()
    {
        _head = 0;
        _tail = 0;
    }

    public static void Push(ArrayQueueADT a , int temp)
    {
        {
            a._queue[_tail] = temp;
            _tail = (_tail + 1) % a._queue.Length;
            if (_tail == _head) _head = (_head + 1) % a._queue.Length;
        }
    }

    public static int Pop(ArrayQueueADT a)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error");
            throw new ApplicationException("Empty queue pop is denied");
        }
        int x = a._queue[_head];
        _head = (_head + 1) % a._queue.Length;
        return x;
    }

    public static int Peek(ArrayQueueADT a)
    {
        return a._queue[_head];
    }

    public static bool IsEmpty()
    {
        return _head == _tail;
    }

    public static int Size(ArrayQueueADT a)
    {
        if (_head > _tail) return a._queue.Length - _head + _tail;
        return _tail - _head;
    }
}