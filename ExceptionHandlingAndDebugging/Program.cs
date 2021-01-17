using System;

namespace ExceptionHandlingAndDebugging
{
    class Program
    {
        // This method will prompt a user to enter a number greater that zero. The Convert.ToInt32() method used will convert their input to an integer.
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception genException)
            {
                Console.WriteLine($"Oops, I'm sorry. Something went wrong, I didn't catch that {genException.Message}");
            }
            finally
            {
                Console.WriteLine("The program is complete.");
            }
        }
        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Let's do some math together!");
                Console.WriteLine("Please enter a number greater than 0.. that's a good start");
                string arraySizeInput = Console.ReadLine();
                int arraySize = Convert.ToInt32(arraySizeInput);
                int[] numberArray = new int[arraySize];
                // this will populate our numArray based on the user input and then will set our variables equal to all of the returns of all the other methods.
                Populate(numberArray);
                int sum = GetSum(numberArray);
                int prod = GetProduct(numberArray, sum);
                decimal quot = GetQuotient(prod);
                // this will print user selection to the screen as they exactly entered, since we cannot grab the values from other methods(not public)
                int numberToBeMultiplied = prod / sum;
                int convertedQuot = Convert.ToInt32(quot);
                int numberDivided = prod / convertedQuot;
                // this will print out everything to the screen
                Console.WriteLine($"Your array size is:{arraySize}");
                Console.WriteLine("The number in your array are: {0}", string.Join(", ", numberArray));

                Console.WriteLine($"The sum of your array is: {sum}");
                Console.WriteLine($"{sum} * {numberToBeMultiplied} = {prod}");
                Console.WriteLine($"{prod} / {numberDivided} = {quot}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Oops, sorry that input was not formatted entirely correct{fe.Message}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Oops, sorry that number was a smidge too large {oe.Message}");
            }
        }
        static int[] Populate(int[] arr)
        {
            // while using this counter, it will display out how many numbers a user has selected out of their original number
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Please Enter Number {counter + 1} of {arr.Length} ");
                string userNumberInput = Console.ReadLine();
                int userNumber = Convert.ToInt32(userNumberInput);
                arr[i] = userNumber;
                counter++;
            }
            return arr;
        }
        // in this method, sum will iterate through the array and populate the "sum" variable with the sum of ALL numbers together.
        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum < 20)
            {
                Console.WriteLine($"Value of {sum} is much too low there friend. ");
            }
            return sum;
        }
        static int GetProduct(int[] arr, int sum)
        {
            try
            {
                Console.WriteLine($"Please enter a number between 1 and {arr.Length}");
                string userInput = Console.ReadLine();
                int userNum = Convert.ToInt32(userInput);
                int product = sum * arr[userNum - 1];
                Console.WriteLine(product);

                return product;
            }
            // the "throw" exception will make sure if the sum is less than 20 to show an error message
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine($"Come on now.. that number was out of the specified range..{ioore.Message}");
                throw;
            }
        }
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter in a number to divide the product:{product} by");
                string userInput = Console.ReadLine();
                decimal userDecimal = Convert.ToDecimal(userInput);
                decimal productAsDecimal = Convert.ToDecimal(product);
                // decimal.Divide was a little tricky to figure out but it will take the first dividend and then the divisor afterwards.
                decimal quotient = decimal.Divide(product, userDecimal);
                return quotient;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine($"Silly you, you cannot divide by zero.. {dbze.Message}");
                return 0;
            }
        }
    }
}
