using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            //// Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            ////// Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            //// Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            //// Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            //// Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            //// Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            //// Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                HashSet<int> numSet = new HashSet<int>(nums); //Using HashSet for storing the input. This helps reduce the complexity in checking if an element is present in the input
                List<int> result = new List<int>(); //The output list to be returned. Stores the elements missing in the input.

                for (int i = 1; i <= nums.Length; i++) //This loop goes through all the expected integers in the input
                {
                    if (!numSet.Contains(i))
                    {
                        result.Add(i); //If the expected integer is not present in the input it is added to the List
                    }
                }// This logic works for all edge cases such as empty input array

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int[] out_nums = new int[nums.Length]; //Create output array
                int j = 0;
                for (int i = 0; i < nums.Length; i++) //First add all even numbers
                {
                    if (nums[i] % 2 == 0)
                    {
                        out_nums[j] = nums[i];
                        j++;
                    }
                }
                for (int i = 0; i < nums.Length; i++) //Next add all odd numbers
                {
                    if (nums[i] % 2 != 0)
                    {
                        out_nums[j] = nums[i];
                        j++;
                    }
                }
                return out_nums; //The code handles edge cases such as empty input array
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                int[] twosum = new int[2]; //Create an array of length 2, to hold the two sum integers

                for (int i = 0; i < nums.Length; i++)  //Loop through all elements in the input
                {
                    int diff = target - nums[i]; //Assign the difference between current element and target to a variable
                    for (int j = 0; j < nums.Length; j++) //Loop through remaining elements in the input and if an element matches the difference value, assign the appropriate elements to output array and return it
                    {
                        if (i != j && diff == nums[j])
                        {
                            twosum[0] = i;
                            twosum[1] = j;
                            return twosum;
                        }

                    }


                }
                return new int[0]; // Edge case: return empty array if no solution
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); //Sort array to find the candidates in an easier way
                int n = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3]; // Product of the top 3 elements
                int n2 = nums[0] * nums[1] * nums[nums.Length - 1]; // Product of two smallest and the largest (to handle negative cases)
                // Compare the two products and return the maximum
                if (n > n2)
                {
                    return n;
                }
                else
                {
                    return n2;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) // Edge case: if the number is 0, return "0"
                {
                    return "0";
                }
                string binary = ""; // Initialize a string to store the binary representation
                int remainder;
                while (decimalNumber > 0) // Loop until the decimal number is greater than 0
                {
                    remainder = decimalNumber % 2;
                    decimalNumber /= 2;
                    binary = Convert.ToString(remainder) + binary; // Prepend the remainder to the binary string
                }
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                if(nums.Length == 0) // Edge Case: if the array is empty, return 0
                {
                    return 0;
                }
                int min = nums[0];
                for (int i = 1; i < nums.Length; i++) // Linear scan to find the minimum value
                {
                    if (nums[i] < min)
                    {
                        min = nums[i];
                    }
                }
                return min; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) // Edge case: negative numbers are not palindromes
                {
                    return false;
                }
                string a = x.ToString(); // Convert the number to string
                string b = "";
                for (int i = a.Length - 1; i >= 0; i--) // Reverse the string
                {
                    b += a[i];
                }
                if (a == b) //Check if the original string is equal to the reversed string
                {
                    return true;
                }
                return false; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 0) // Edge case: F(0) = 0
                {
                    return 0;
                }
                else if (n == 1) // Edge case: F(1) = 1
                {
                    return 1;
                }
                int[] fib = new int[n + 1]; // Create an array to store Fibonacci numbers
                fib[0] = 0;
                fib[1] = 1;
                for (int i = 2; i <= n; i++) //Looping from the 3rd element to the nth element
                {
                    fib[i] = fib[i - 1] + fib[i - 2];
                }
                return fib[n]; // Return the nth Fibonacci number
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
