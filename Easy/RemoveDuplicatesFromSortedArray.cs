namespace LeetCode.Easy;

public class RemoveDuplicatesFromSortedArray
{
    //Using List
    public int Solution(int[] nums)
    {
        var list = new List<int>();
        foreach (var num in nums)
        {
            if (!list.Contains(num))
            {
                list.Add(num);
            }
        }
        return list.Count;
    }

    //Two pointer approch
    public int Solution1(int[] nums)
    {
        if (nums.Length == 0) return 0;

        // Initialize pointers
        int write = 1;  // Points to where next unique element should go
        int read = 1;   // Scans through array looking for unique elements

        // Iterate through array
        while (read < nums.Length)
        {
            // If current element is different from previous one
            if (nums[read] != nums[read - 1])
            {
                // Place unique element at write position
                nums[write] = nums[read];
                write++;
            }
            read++;
        }

        return write;  // Returns length of unique elements
    }
}

