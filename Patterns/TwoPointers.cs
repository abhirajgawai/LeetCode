using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Patterns;

public class TwoPointers
{
    /*
     1.Two Ends Approach
        -  One pointer starts from beginning (left)
        -  Another pointer starts from end (right)
        -  Best for sorted arrays
        -  Great for finding pairs that meet certain criteria
     */

    // Two Ends Approach - Finding Pair Sum
    public void FindPairSum(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int sum = arr[left] + arr[right];

            if (sum == target)
            {
                Console.WriteLine($"Found pair: {arr[left]} and {arr[right]}");
                return;
            }
            else if (sum < target)
            {
                left++;  // Move left to increase sum
            }
            else
            {
                right--;  // Move right to decrease sum
            }
        }
    }

    public bool IsStringPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}

