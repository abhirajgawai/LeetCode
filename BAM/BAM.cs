namespace LeetCode.BAM;

public class BAM : IBAM
{
    public int[] TwoSum()
    {
        var nums = new int[] { 3, 2, 4 };
        var target = 7;

        Dictionary<int, int> numDict = new();

        for (int i = 0; i < nums.Length; i++)
        {
            // Calculate the complement of the current number 
            // x + nums[i] = target
            // => x = target - nums[i]
            int complement = target - nums[i];

            // Check if the complement exists in the dictionary  
            if (numDict.TryGetValue(complement, out int value))
            {
                // If it exists, return the indices of the complement and the current number  
                return new int[] { value, i };
            }

            // Add the current number and the index of current number into the dictionary
            numDict[nums[i]] = i;
        }
        return new int[0];
    }

    public void SearchInsertPosition()
    {
        var nums = new int[] { 1, 3, 5, 6 };
        var target = 7;
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                Console.WriteLine(mid);
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
        Console.WriteLine(left);
    }

    public bool ValidParantheses()
    {
        var input = "(]";
        var stack = new Stack<char>();

        foreach (char c in input)
        {
            switch (c)
            {
                case '(':
                case '{':
                case '[':
                    stack.Push(c);
                    break;
                case ')':
                    if (stack.Count == 0 || stack.Pop() != '(') return false;
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{') return false;
                    break;
                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[') return false;
                    break;
            }
        }
        return stack.Count == 0; // true
    }

    public bool PalindromeNumber()
    {
        int x = -121;
        var left = 0;
        var right = x.ToString().Length - 1;
        var intToString = x.ToString();

        while (left <= right)
        {
            if (intToString[left] != intToString[right]) return false;
            left++;
            right--;
        }

        return true;
    }

    public int LengthOfLastWord()
    {
        var input = "   fly me   to   the moon  ";
        var splitWord = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var lastword = splitWord.Length - 1;
        var lastWordCount = 0;

        foreach (var word in splitWord[lastword])
        {
            lastWordCount++;
        }

        return lastWordCount;
    }

    public int RemoveDuplicates()
    {
        int[] nums = new int[] { 1, 1, 2 };
        int write = 1;
        int read = 1;

        while (read <= nums.Length)
        {
            if (nums[read] != nums[write])
            {
                nums[write] = nums[read];
                write++;
            }
            read++;
        }
        return write;
    }

    public int StrStr()
    {
        string hayStack = "abc";
        string needle = "c";

        if (needle.Length == 0 || hayStack == needle) return 0;

        var hayLength = hayStack.Length;
        var needleLength = needle.Length;

        for (int i = 0; i <= hayLength - needleLength; i++)
        {
            if (hayStack.Substring(i, needleLength) == needle) return i;
        }
        return -1;
    }

    public int[] TwoSumII()
    {
        int[] nums = [2, 7, 11, 15];
        int target = 9;
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            var sum = nums[left] + nums[target];
            if (sum == target)
            {
                return [left + 1, right + 1];
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return [];
    }

    public int LengthOfLongestSubstring()
    {
        var s = "abcabcbb";
        HashSet<char> charSet = new HashSet<char>();
        int left = 0;
        int max = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // If the character is already in the set, move the left pointer
            while (charSet.Contains(s[right]))
            {
                // Remove the character at the left pointer from the set
                charSet.Remove(s[left]);
                left++;
            }

            // Add the current character to the set
            charSet.Add(s[right]);
            // Update the maximum length
            max = Math.Max(max, getWindowLength(left, right));
        }
        return max;
    }

    int getWindowLength(int l, int r) => r - l + 1;

    public int MaxArea()
    {
        int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            // Calculate the area between the two pointers
            // The area is determined by the width and the height of the shorter line
            int width = right - left;
            // The height is determined by the shorter line
            int minHeight = Math.Min(height[left], height[right]);
            // Calculate the area
            int area = width * minHeight;
            // Update the maximum area
            maxArea = Math.Max(maxArea, area);
            // Move the pointer pointing to the shorter line
            // This is because the area is limited by the shorter line
            // So we want to try to find a taller line
            // to maximize the area
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

    public int MaxProfit()
    {
        int[] price = [1, 2];
        int minPriceSoFar = int.MaxValue;
        int maxProfit = 0;
        for (int i = 0; i <= price.Length - 1; i++)
        {
            if (minPriceSoFar > price[i])
            {
                minPriceSoFar = price[i];
            }
            else
            {
                var profit = price[i] - minPriceSoFar;
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                }
            }
        }
        return maxProfit;
    }

    public int MinAddToMakeValid(string s)
    {
        var open = 0;
        var add = 0;
        foreach (var c in s)
        {
            // Count open parentheses
            if (c == '(')
            {
                open++;
            }

            else if (c == ')')
            {
                // If we have an open parenthesis, match it
                if (open > 0)
                {
                    open--; // match with existing '('
                }
                // If no open parenthesis to match, we need to add one
                else
                {
                    add++; // no '(' to match → need to add one
                }
            }

        }
        // Remaining `open` means we need that many ')'
        return open + add;
    }

    public int FirstUniqChar()
    {
        string s = "loveleetcode";
        // Create dictionary to store character frequencies
        Dictionary<char, int> charCount = new();

        // Count frequency of each character
        foreach (char c in s)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        // Find first character with count of 1
        for (int i = 0; i < s.Length; i++)
        {
            if (charCount[s[i]] == 1)
            {
                return i;
            }
        }

        // Return -1 if no unique character is found
        return -1;
    }

    public char FindTheDifference()
    {
        string s = "";
        string t = "y";
        List<char> toConstruct = s.ToList();

        foreach (char c in t)
        {
            if (!toConstruct.Remove(c))
            {
                return c;
            }
        }
        return default;
    }

    public int LongestValidParantheses()
    {
        string s = "(()";
        Stack<int> stack = new();
        stack.Push(-1);
        int maxLength = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {
                    var validSubStringLenght = i - stack.Peek();
                    maxLength = Math.Max(maxLength, validSubStringLenght);
                }
            }
        }

        return maxLength;
    }

    public bool ContainsDuplicate()
    {
        int[] nums = [1, 1, 1, 3, 3, 4, 3, 2, 4, 2];
        Dictionary<int, int> checkDuplicates = [];

        for (int i = 0; i <= nums.Length - 1; i++)
        {
            if (checkDuplicates.ContainsKey(nums[i]))
            {
                return true;
            }
            checkDuplicates.Add(nums[i], i);
        }
        return false;
    }

    public int ThreeSumClosest()
    {
        int[] nums = [-1, 2, 1, -4];
        int target = 1;
        Array.Sort(nums);
        int closestSum = nums[0] + nums[1] + nums[2];// Initialize with first three numbers
        int minDifference = Math.Abs(closestSum - target);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int currentSum = nums[i] + nums[left] + nums[right];
                int currentDiff = Math.Abs(currentSum - target);

                // Update closest sum if current difference is smaller
                if (currentDiff < minDifference)
                {
                    minDifference = currentDiff;
                    closestSum = currentSum;
                }

                //Adjust pointers based on sum
                if (currentSum < target) { left++; }
                else if (currentSum > target) { right--; }
                else { return currentSum; }
            }
        }
        return closestSum;
    }

    public int SubarraySum()
    {
        int[] nums = [1, -1, 0];
        int target = 0;
        int totalNumberOfSubArrays = 0;
        int left;
        int currentSum;

        for (left = 0; left <= nums.Length - 1; left++)
        {
            currentSum = nums[left];
            if (nums[left] == target) { totalNumberOfSubArrays++; }

            for (int insideLoop = left + 1; insideLoop <= nums.Length - 1;)
            {
                currentSum = currentSum + nums[insideLoop];

                if (currentSum > target) break;

                if (currentSum == target) { totalNumberOfSubArrays++; }

                insideLoop++;
            }
        }
        return totalNumberOfSubArrays;
    }

    public int MajorityElement()
    {
        int[] nums = [2, 2, 1, 1, 1, 2, 2];
        Array.Sort(nums);
        var current = nums[0];
        var count = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (current == nums[i])
            {
                count++;
                if (count > nums.Length / 2)
                    return current;
            }
            else
            {
                current = nums[i];
                count = 1;
            }

        }
        return current;
    }

    public void MoveZeros()
    {
        int[] nums = [0, 1, 0, 3, 12];
        int write = 0;
        // Step 1: Move all non-zero elements to the front
        for (int read = 0; read < nums.Length; read++)
        {
            if (nums[read] != 0)
            {
                nums[write] = nums[read];
                write++;
            }
        }

        // Fill remaining space with zeros
        while (write < nums.Length)
        {
            nums[write] = 0;
            write++;
        }

        Console.WriteLine(string.Join(",", nums)); // Output: 1,3,12,0,0
    }

    public int MajorityElement_BruteForce()
    {
        int[] nums = [2, 2, 1, 1, 1, 2, 2];
        Dictionary<int, int> majorityElement = new();

        for (int i = 0; i <= nums.Length - 1; i++)
        {
            if (majorityElement.ContainsKey(nums[i]))
            {
                majorityElement.TryGetValue(nums[i], out var value);
                var increment = value + 1;
                majorityElement[nums[i]] = increment;
            }
            else
            {
                majorityElement.Add(nums[i], 1);
            }
        }

        var majorityNumber = 0;
        var maxCount = 0;
        foreach (var value in majorityElement)
        {
            if (value.Value > maxCount)
            {
                maxCount = value.Value;
                majorityNumber = value.Key;
            }

        }

        return majorityNumber;
    }

    public int[] ProductExpectSelf()
    {
        var productList = new List<int>();
        int[] nums = [1, 2, 3, 4];
        for (int i = 0; i <= nums.Length - 1; i++)
        {
            int currentProduct = 1;
            for (int j = 0; j <= nums.Length - 1; j++)
            {
                if (i == j) continue;
                currentProduct *= nums[j];
            }
            productList.Add(currentProduct);

        }
        return [.. productList];
    }

    public int[] ProductExceptSelf1()
    {
        int[] nums = [1, 2, 3, 4];
        int n = nums.Length;
        int[] result = new int[n];

        // Step 1: Prefix products
        result[0] = 1;
        for (int i = 1; i < n; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        // Step 2: Suffix products
        int suffix = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] *= suffix;
            suffix *= nums[i];
        }

        return result;
    }
}

