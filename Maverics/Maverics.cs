namespace LeetCode.Maverics;

public class Maverics
{
    // Example 1:
    // Input: s = ["h","e","l","l","o"]
    // Output: ["o","l","l","e","h"]

    // Example 2:
    // Input: s = ["H","a","n","n","a","h"]
    // Output: ["h","a","n","n","a","H"]

    public void ReverseString()
    {
        char[] s = ['h', 'e', 'l', 'l', 'o'];
        int write = 0;
        int read = s.Length - 1;

        while (write < read)
        {
            var tempLeft = s[write];
            var tempRight = s[read];
            s[write] = tempRight;
            s[read] = tempLeft;
            read--;
            write++;
        }
        Console.WriteLine(new string(s));
    }

    public bool ValidPalindrome1()
    {
        string s = "A man, a plan, a canal: Panama";
        var result = RemoveAlphanumeric(s);
        s = result.ToLower();
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                Console.WriteLine("false");
                return false;
            }
            left++; right--;
        }
        Console.WriteLine("true");
        return true;
    }

    public string RemoveAlphanumeric(string input)
    {
        return new string(input.Where(c => char.IsLetterOrDigit(c)).ToArray());
    }

    private static bool ThreeConsicativeOdds(int[] arr)
    {
        if (arr.Length < 3)
        {
            return false;
        }

        int left = 0;
        var oddCount = 0;
        var isConsicative = false;

        while (left < arr.Length)
        {
            if (arr[left] % 2 != 0)
            {
                oddCount++;
            }
            else
            {
                oddCount = 0;
            }
            if (oddCount == 3)
            {
                isConsicative = true;
                break;
            }
            left++;
        }
        return isConsicative;
    }
}

