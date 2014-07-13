using System;

internal class Vector
{
    private int[] _array;

    public Vector()
    {
        _array = new int[2];
    }

    public Vector(int n)
    {
        _array = new int[n];
    }

    public Vector(int n, int value)
    {
        _array = new int[n];
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = value;
        }
    }

    public Vector(int[] a)
    {
        _array = a;
    }

    public int this[int i]
    {
        get { return _array[i]; }
        set { _array[i] = value; }
    }

    public int Length { get; private set; }

    public int Capacity
    {
        get { return _array.Length; }
    }

    public void ReSize(int n)
    {
        var newArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            newArray[i] = _array[i];
        }
        _array = newArray;
    }

    public void Clear()
    {
        _array = null;
    }

    public void PushBack(int temp)
    {
        if (Capacity == _array.Length)
        {
            var newArray = new int[_array.Length*2];
            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
            PushBack(temp);
        }
        _array[_array.Length] = temp;
    }

    public int PopBack()
    {
        if (_array.Length == 0)
        {
            Console.WriteLine("Error");
            throw new ApplicationException("Empty vector pop is denied");
        }
        int x = _array[_array.Length];

        if (_array.Length < Capacity/2)
        {
            var newArray = new int[_array.Length/2];
            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }
        return x;
    }
}