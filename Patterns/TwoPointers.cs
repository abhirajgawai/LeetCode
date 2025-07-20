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

    /*
     2. Sliding Window Approach
    Input: s = "abcabcbb"
    Output: 3

    Input: s = "bbbbb"
    Output: 1

    Input: s = "pwwkew"
    Output: 3
     */
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> charSet = new HashSet<char>();
        int left = 0;
        int max = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // If the character is already in the set, move the left pointer
            // to the right until the character is removed from the set
            while (charSet.Contains(s[right]))
            {
                // Remove the character at the left pointer from the set
                // and move the left pointer to the right
                charSet.Remove(s[left]);
                left++;
            }

            // Add the current character to the set
            // This ensures that all characters in the set are unique
            charSet.Add(s[right]);
            // Update the maximum length
            max = Math.Max(max, right - left + 1); // Update max length
        }
        return max;
    }

    public static int Max(int[] height)
    {
        var check = new List<int>();

        // Two pointers approach
        int left = 0;
        // Start from the leftmost line
        int right = height.Length - 1;
        int maxArea = 0;

        // While the two pointers do not cross each other
        while (left < right)
        {
            // Calculate the area between the two pointers
            // The area is determined by the width and the height of the shorter line
            // The width is the distance between the two pointers
            int width = right - left;
            // The height is determined by the shorter line
            int minHeight = Math.Min(height[left], height[right]);
            // Calculate the area
            int area = width * minHeight;
            // Update the maximum area
            maxArea = Math.Max(maxArea, area);
            // Move the pointer pointing to the shorter line
            // This is because the area is limited by the shorter line
            // So we want to try to find a taller line to maximize the area
            // If the left line is shorter, move the left pointer to the right
            // If the right line is shorter, move the right pointer to the left
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return maxArea;
    }
}



