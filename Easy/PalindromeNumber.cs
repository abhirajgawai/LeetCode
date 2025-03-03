namespace LeetCode.Easy;

public class PalindromeNumber
{
    /*
     * Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
     * Input: x = 121 Output: true
     * Input: x = -121 Output: false
     * Input: x = 10 Output: false
     */

    // Using Math
    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }
        int reversed = 0;
        int original = x;
        while (x != 0)
        {
            int digit = x % 10; // Get last digit
            x /= 10; // Remove last digit
            reversed = reversed * 10 + digit; // Append digit to reversed
        }
        return original == reversed;
    }

    // Using String Manipulation
    public bool IsPalindrome2(int x)
    {
        var str = x.ToString();
        var reversedString = new string([.. str.Reverse()]);
        return str == reversedString;
    }

    // Using Two Pointers Method on String
    public bool IsPalindrome3(int x)
    {
        if (x < 0) return false; // Negative numbers are not palindromes

        string str = x.ToString();
        int left = 0, right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right]) return false; // Mismatch, not a palindrome
            left++;
            right--;
        }

        return true; // If we reach here, it is a palindrome
    }

}

