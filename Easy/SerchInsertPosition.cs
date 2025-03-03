namespace LeetCode.Easy;

public class SerchInsertPosition
{
    /*
     * Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, 
     * return the index where it would be if it were inserted in order.
     * Input: nums = [1,3,5,6], target = 5 Output: 2
     * Input: nums = [1,3,5,6], target = 2 Output: 1
     * Input: nums = [1,3,5,6], target = 7 Output: 4
     */

    //Binary Search
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return left;
    }
}

