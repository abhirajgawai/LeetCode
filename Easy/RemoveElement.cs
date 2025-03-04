using System.Collections.Generic;

namespace LeetCode.Easy;

public class RemoveElement
{

    //Using List
    public int Solution(int[] nums, int val)
    {
        Console.WriteLine($"initial ==> {"[" + string.Join(",", nums) + "]"}");
        if (nums.Length == 0) return 0;

        var read = 0;
        var write = nums.Length - 1;
        var list = nums.ToList();

        while (read < nums.Length)
        {
            if (nums[read] == val)
            {
                list.Remove(val);
                Console.WriteLine($" ==> {"[" + string.Join(",", list) + "]"}");
            }

            read++;
        }
        Console.WriteLine($"final ==> {"[" + string.Join(",", list) + "]"}");
        return list.Count;
    }

    //Using Two Pointers
    /*
     keep one pointer at the beginning
     if the value is not equal to val, copy the value to the write index and increment the write index
     */
    public int Solution1(int[] nums, int val)
    {
        Console.WriteLine($"initial ==> {"[" + string.Join(",", nums) + "]"}");
        var writeIndex = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[writeIndex] = nums[i];
                writeIndex++;
                Console.WriteLine($" ==> {"[" + string.Join(",", nums) + "]"}");
            }
        }
        Console.WriteLine($"final ==> {"[" + string.Join(",", nums) + "]"}");
        return writeIndex;
    }
}

