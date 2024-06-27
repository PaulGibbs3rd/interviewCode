using System;
using System.Numerics;
using System.Runtime.InteropServices;

class Program
{

   static BigInteger[] fib(int n)
    {
        BigInteger[] fibArr = new BigInteger[n];
        fibArr[0] = 1;
        fibArr[1] = 1;

        for (int i = 2; i < n; i++)
        {
            fibArr[i] = fibArr[i - 1] + fibArr[i-2];
        }
        return fibArr;
    }

    static void print(BigInteger[] ints)
    {
        for (int i = 0; i < ints.Length; i++)
        {
            Console.WriteLine("{0} ", ints[i]);
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter which fibonacci number you would like to run up to?");
        int fibNum = Convert.ToInt32(Console.ReadLine());
        BigInteger[] temp = fib(fibNum);
        print(temp);

    }
}