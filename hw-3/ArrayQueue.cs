﻿using System;

internal class ArrayQueue
{
    private int[] _array;
    private int _head;
    private int _tail;

    public int Size
    {
        get
        {
            if (_array == null) return 0;
            return (_tail + 1 + _array.Length - _head)%_array.Length;
        }
    }

    public bool Empty
    {
        get { return _head == _tail; }
    }

    public int Peek()
    {
        if (Empty) throw new ApplicationException("No elements to peek");
        return _array[_head];
    }

    public void Push(int x)
    {
        if (_array == null)
        {
            _array = new[] {x, 0};
        }
        else
        {
            if (_array.Length <= Size + 1)
            {
                var newArray = new int[_array.Length*2];
                int i = 0;
                while (!Empty)
                {
                    newArray[i++] = Peek();
                    _head = (_head + 1)%_array.Length;
                }
                _array = newArray;
                _head = 0;
                _tail = i - 1;
                Push(x);
            }
            else
            {
                _tail = (_tail + 1)%_array.Length;
                _array[_tail] = x;
            }
        }
    }

    public void Pop()
    {
        if (Empty)
        {
            throw new ApplicationException("Pop from empty queue is absurd!");
        }
        _head = (_head + 1)%_array.Length;
        if (Size <= _array.Length/4)
        {
            if (Empty)
            {
                _array = null;
                _head = 0;
                _tail = 0;
            }
            else
            {
                var newArray = new int[_array.Length/2];
                int i = 0;
                while (!Empty)
                {
                    newArray[i++] = Peek();
                    _head = (_head + 1)%_array.Length;
                }
                _array = newArray;
                _head = 0;
                _tail = i - 1;
            }
        }
    }
}