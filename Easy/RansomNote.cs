namespace LeetCode.Easy;

public class RansomNote
{
    //aba aab
    //aab baa
    public bool CanConstruct(string ransomNote, string magazine)
    {
        List<char> magazineLetters = magazine.ToList();

        foreach (char c in ransomNote)
        {
            // Try to remove c from the magazine list
            if (!magazineLetters.Remove(c))
            {
                // If c doesn't exist in magazine list, return false
                return false;
            }
        }

        return true; // All characters were found and used
    }
}

