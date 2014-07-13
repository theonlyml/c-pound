using System;

internal class Vector
{
    private int _capacity;
    private int[] _queue;

    public Vector()
    {
        _queue = new int[2];
        _capacity = -1;
    }

    public Vector(int n)
    {
        _queue = new int[n];
        _capacity = n - 1;
    }

    public Vector(int n, int value)
    {
        _queue = new int[n];
        for (int i = 0; i < _queue.Length; i++)
        {
            _queue[i] = value;
        }
        _capacity = n - 1;
    }

    public Vector(int[] a)
    {
        _queue = a;
        _capacity = a.Length - 1;
    }

    public int this[int i]
    {
        get { return _queue[i]; }
        set { _queue[i] = value; }
    }

    public int Length
    {
        get { return _queue.Length; }
    }

    public int Capacity
    {
        get { return _capacity + 1; }
    }

    public void ReSize(int n)
    {
        _capacity = n - 1;
        Array.Resize(ref _queue, n);
    }

    public void Clear()
    {
        _queue = null;
        _capacity = 0;
    }

    public void PushBack(int temp)
    {
        if (_capacity + 1 == _queue.Length) Array.Resize(ref _queue, _queue.Length*2);
        _capacity = _capacity + 1;
        _queue[_capacity] = temp;
    }

    public int PopBack()
    {
        if (_capacity == -1)
        {
            Console.WriteLine("Error");
            throw new ApplicationException("Empty vector pop is denied");
        }
        if (_capacity + 1 < _queue.Length/2) Array.Resize(ref _queue, _queue.Length/2);
        int x = _queue[_capacity];
        _capacity = _capacity - 1;
        return x;
    }
}