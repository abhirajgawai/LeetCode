// See https://aka.ms/new-console-template for more information
using LeetCode.Easy;

public class Progam
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(new SerchInsertPosition().SearchInsert([1, 3, 5, 6], 4));
        Console.WriteLine(new PalindromeNumber().IsPalindrome(121));
        var result = new TwoSumNumber().TwoSum([2, 7, 11, 15], 9);
        Console.WriteLine("[" + string.Join(",", result) + "]");
        Console.WriteLine(new ValidParentheses().IsValid("()[]{}"));
    }
}