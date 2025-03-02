namespace LeetCode.Easy;

public class PalindromeNumber
{
    /*
     * Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
     * Input: x = 121 Output: true
     * Input: x = -121 Output: false
     * Input: x = 10 Output: false
     */
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
            int digit = x % 10;
            x /= 10;
            reversed = reversed * 10 + digit;
        }
        return original == reversed;
    }
}

