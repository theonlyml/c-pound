using System;

internal class ArrayQueueADT
{
    private static int _head;
    private static int _tail;
    private int[] _array;

    public static bool Empty(ArrayQueueADT a)
    {
        return Size(a) == 0;
    }

    public static int Size(ArrayQueueADT a)
    {
        if (a._array == null) return 0;
        return (_tail + 1 + a._array.Length - _head)%a._array.Length;
    }

    public static int Peek(ArrayQueueADT a)
    {
        if (Empty) throw new ApplicationException("No elements to peek");
        return a._array[_head];
    }

    public static void Push(ArrayQueueADT a, int x)
    {
        if (a._array == null)
        {
            a._array = new[] {x, 0};
        }
        else
        {
            if (a._array.Length <= Size(a) + 1)
            {
                var newArray = new int[a._array.Length*2];
                int i = 0;
                while (!Empty)
                {
                    newArray[i++] = Peek(a);
                    _head = (_head + 1)%a._array.Length;
                }
                a._array = newArray;
                _head = 0;
                _tail = i - 1;
                Push(a, x);
            }
            else
            {
                _tail = (_tail + 1)%a._array.Length;
                a._array[_tail] = x;
            }
        }
    }

    public static void Pop(ArrayQueueADT a)
    {
        if (Empty)
        {
            throw new ApplicationException("Pop from empty queue is absurd!");
        }
        _head = (_head + 1)%a._array.Length;
        if (Size(a) <= a._array.Length/4)
        {
            if (Empty)
            {
                a._array = null;
                _head = 0;
                _tail = 0;
            }
            else
            {
                var newArray = new int[a._array.Length/2];
                int i = 0;
                while (!Empty)
                {
                    newArray[i++] = Peek(a);
                    _head = (_head + 1)%a._array.Length;
                }
                a._array = newArray;
                _head = 0;
                _tail = i - 1;
            }
        }
    }
}