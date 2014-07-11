using System;

public class ArrayQueue
{
    static int n = 10;
    int head, tail;
    int[] queue = new int[n];
    public void Push(int temp)
    {
        queue[tail] = temp;
        tail = (tail + 1) % n;
    }

    public int Pop()
    {
        int x = queue[head];
        head = (head + 1) % n;
        return x;
    }

    public int Peek()
    {
        return queue[head];
    }

    public bool isEmpty()
    {
        return head == tail;
    }

    public int Size()
    {
        if (head > tail) return n - head + tail;
        return tail - head;
    }

}

class ADT
{
    public int ADTSum(ArrayQueueADT a)
    {
        int sum = 0;
        foreach (int number in a.queue)
        {
            sum += number;
        }
        return sum;
    }
}

public class ArrayQueueSingleton
{

    static int n = 10;
    static int head, tail;
    static int[] queue = new int[n];


    public static void Push(int temp)
    {
        queue[tail] = temp;
        tail = (tail + 1) % n;
    }

    public static int Pop()
    {
        int x = queue[head];
        head = (head + 1) % n;
        return x;
    }

    public static int Peek()
    {
        return queue[head];
    }

    public static bool isEmpty()
    {
        return head == tail;
    }

    public static int Size()
    {
        if (head > tail) return n - head + tail;
        return tail - head;
    }
}
public class ArrayQueueADT
{
    static int n = 10;
    static int head, tail;
    int[] queue = new int[n];

    public static void Push(ArrayQueueADT a,int temp)
    {
        a.queue[tail] = temp;
        tail = (tail + 1) % n;
    }

    public static int Pop(ArrayQueueADT a)
    {
        int x = a.queue[head];
        head = (head + 1) % n;
        return x;
    }

    public static int Peek(ArrayQueueADT a)
    {
        return a.queue[head];
    }

    public static bool isEmpty()
    {
        return head == tail;
    }

    public static int Size()
    {
        if (head > tail) return n - head + tail;
        return tail - head;
    }
}


class Program
{

    
    static void Main(string[] args)
    {
        ArrayQueue a1 = new ArrayQueue();
        a1.Push(3);
        a1.Push(2);
        Console.WriteLine(a1.Peek());
        Console.WriteLine(a1.Pop());
        Console.WriteLine(a1.isEmpty());
        Console.WriteLine(a1.Size());
        ArrayQueueSingleton.Push(4);
        Console.WriteLine(ArrayQueueSingleton.Peek());
        Console.WriteLine(ArrayQueueSingleton.Pop());
        Console.WriteLine(ArrayQueueSingleton.isEmpty());
        Console.WriteLine(ArrayQueueSingleton.Size());
        ArrayQueueADT a = new ArrayQueueADT();
        ArrayQueueADT.Push(a, 1);
        Console.WriteLine(ArrayQueueADT.Peek(a));
        Console.WriteLine(ArrayQueueADT.Pop(a));
        
    }
}
