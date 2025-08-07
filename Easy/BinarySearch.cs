namespace LeetCode.Easy;

public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        var right = 0;
        var left = nums.Length - 1;

        while (right < left)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return nums[mid];
            }

            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }


        }
        return -1;
    }
}

