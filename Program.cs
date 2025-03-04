// See https://aka.ms/new-console-template for more information
using LeetCode.Easy;
using LeetCode.Patterns;

public class Progam
{
    public static void Main()
    {
        Easy();
        //Patterns();
    }

    private static void Easy()
    {
        //Console.WriteLine($"SerchInsertPosition ==> {new SerchInsertPosition().SearchInsert([1, 3, 5, 6], 4)}");
        //Console.WriteLine($"Palindrome Number ==> {new PalindromeNumber().IsPalindrome3(1221)}");
        //var result = new TwoSumNumber().TwoSum([2, 7, 11, 15], 13);
        //Console.WriteLine($"TwoSumNumber ==> {"[" + string.Join(",", result) + "]"}");
        //Console.WriteLine($"ValidParentheses ==> {new ValidParentheses().IsValid("()[]{}")}");
        //Console.WriteLine($"LenghtOfLastWord ==> {new LenghtOfLastWord().Solution1("   fly me   to   the moon  ")}");
        //Console.WriteLine($"RemoveDuplicatesFromSortedArray ==> {new RemoveDuplicatesFromSortedArray().
        //    Solution1([0, 0, 1, 1, 1, 2, 2, 3, 3, 4])}");
        Console.WriteLine($"RemoveElement ==> {new RemoveElement().Solution([3, 2, 2, 3], 3)}");
    }

    private static void Patterns()
    {
        //Patterns
        new TwoPointers().FindPairSum([1, 2, 3, 4, 6, 8, 9, 11], 10);
        Console.WriteLine($"IsStringPalindrome ==> {new TwoPointers().IsStringPalindrome("madam")}");
    }
}