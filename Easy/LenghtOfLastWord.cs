namespace LeetCode.Easy;


/* Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal substring consisting of non-space characters only.

Example 1:

Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.
Example 2:

Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.
Example 3:

Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.

*/

public class LenghtOfLastWord
{

    //Spliting the string to find length of last word
    public int Solution(string s)
    {
        string[] splitWords = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
        var lastWord = splitWords.Last();
        return lastWord.Length;
    }

    //Reverse Transversal
    public int Solution1(string s)
    {
        int length = 0;
        int i = s.Length - 1;

        // Ignore trailing spaces
        while (i >= 0 && s[i] == ' ')
        {
            i--;
        }

        //Count the length of the last word
        while (i >= 0 && s[i] != ' ')
        {
            length++;
            i--;
        }

        return length;
    }
}

