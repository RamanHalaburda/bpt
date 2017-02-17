using System;

namespace ByteProtectTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt64 number = 0; // input number
            Boolean flag = false; //  flag to check the success of the search            

            // safety input
            do
            {
                Console.WriteLine("Добро пожаловать! Программа проверяет, является ли введённое число произведением трех последовательных простых чисел");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Пожалуйста, введите натуральное число (от {0} до {1}):", UInt64.MinValue,UInt64.MaxValue);
                
                if (UInt64.TryParse(Console.ReadLine(), out number))
                    flag = true;
                else
                    Console.Clear();
            }
            while (!flag);
                                    
            // check the number for being the multiplication of three sequence prime numbers
            UInt64 prime = 1, nextPrime = 0, nextNextPrime = 0 ; // the first prime and two next primes
            do
            {
                prime = NextPrime(prime);
                if(number % prime == 0) // check first prime
                {
                    UInt64 temp = number / prime;
                    nextPrime = NextPrime(prime);
                    if (temp % nextPrime == 0) // check second prime
                    {
                        temp /= nextPrime;
                        nextNextPrime = NextPrime(nextPrime);
                        if(temp % nextNextPrime == 0 && temp / nextNextPrime == 1) // check third prime
                        {
                            Console.WriteLine("Да, {0} * {1} * {2} = {3}.", prime, nextPrime, nextNextPrime, number);
                            flag = true;
                            break;
                        }
                    }
                }
            }
            while (prime < Math.Pow(number, 1 / 3f)); 
            /*
             * (prime) * (~prime) * (~prime) = number
             *  then prime < number ^ (1/3)
             */ 

            // check access
            if (!flag)
            {
                Console.WriteLine("Нет.");
            }
        }

        // check _number is prime number or not
        static Boolean IsPrime(UInt64 _number) 
        {
            Boolean flag = true;
            for (UInt64 i = UInt64.MinValue + 2; i < _number / 2 + 1; ++i)
            {
                if (_number % i == 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        // search next number following by _firstPrime
        static UInt64 NextPrime(UInt64 _firstPrime) 
        {
            for (UInt64 i = _firstPrime + 1; i <= UInt64.MaxValue; ++i)
                if (IsPrime(i))
                    return i;
            return 0;
        }
    }
}
