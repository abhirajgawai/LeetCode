namespace LeetCode.Easy;


//https://leetcode.com/problems/two-sum/description/
public class TwoSumNumber
{
    /* Given an array of integers nums and an integer target, return indices of the two numbers such
     * that they add up to target.
     * 
     * You may assume that each input would have exactly one solution, and you may not use the same element twice.
     * 
     * You can return the answer in any order.
     * 
     * Example 1:

        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
     * 
     * Example 2:

        Input: nums = [3,2,4], target = 6
        Output: [1,2]
     *
     * Example 3:

        Input: nums = [3,3], target = 6
        Output: [0,1]
     */

    //Brute Force
    public static int[] TwoSum(int[] nums, int target)
    {
        // Solution 1
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    //Using Dictionary to store the numbers and their indices
    public int[] TwoSumUsingDictionary(int[] nums, int target)
    {
        Dictionary<int, int> numDict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Calculate the complement of the current number
            // The complement is the number that, when added to nums[i], equals the target
            // For example, if nums[i] = 2 and target = 9, then complement = 9 - 2 = 7
            // If nums[i] = 3 and target = 6, then complement = 6 - 3 = 3
            int complement = target - nums[i];

            // Check if the complement exists in the dictionary
            if (numDict.ContainsKey(complement))
            {
                // If it exists, return the indices of the complement and the current number
                return new int[] { numDict[complement], i };
            }

            // Only add to the dictionary if the number is not already present
            if (!numDict.ContainsKey(nums[i]))
            {
                numDict[nums[i]] = i;
            }
        }
        return new int[0];
    }
}

public class TwoSumInputArrayIsSorted
{

    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            // Calculate the sum of the two numbers at the left and right pointers
            int sum = numbers[left] + numbers[right];
            if (sum == target)
            {
                // If the sum is equal to the target, return the indices of the two numbers
                // Note: The problem states that the indices should be 1-based, so we add 1 to each index
                return new int[] { left + 1, right + 1 }; // Return 1-based indices
            }
            else if (sum < target)
            {
                left++; // Move left pointer to the right
            }
            else
            {
                right--; // Move right pointer to the left
            }
        }

        return new int[0]; // No solution found
    }

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

}