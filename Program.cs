// See https://aka.ms/new-console-template for more information
using LeetCode.Easy;
using LeetCode.Patterns;
using System.Text;
using System.Text.RegularExpressions;
using static Progam.JuliasBaer;


public class Progam
{
    public static void Main()
    {
        var juliasBaer = new LongestSleepingHours().GetLongestFreeHours();
    }

    public class JuliasBaer
    {
        public class UrlBuilder
        {
            public string EasyUrl(string protocol, string domain, string path)
            {
                var builder = new StringBuilder();
                if (String.IsNullOrEmpty(protocol) || String.IsNullOrEmpty(domain)) return builder.ToString();
                builder.Append($"{protocol}://{domain}");
                if (!String.IsNullOrEmpty(path))
                {
                    builder.Append($"/{path}");
                }
                return builder.ToString();
            }

            public string EasyUrlBuilder()
            {
                var input = "protocol=\"\", domain=\"\", path=\"\"";
                var builder = new StringBuilder();
                var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in split)
                {
                    var kv = item.Split('=');

                    if (kv.Length > 0)
                    {
                        var key = kv[0].Trim();
                        var value = kv[1].Trim('"');
                        if (key == "protocol" && String.IsNullOrEmpty(value)) return builder.ToString();
                        switch (key)
                        {
                            case "protocol":
                                builder.Append($"{value}://");
                                break;
                            case "domain":
                                builder.Append(value);
                                break;
                            case "path":
                                if (!String.IsNullOrEmpty(value))
                                {
                                    builder.Append($"/{value}");
                                }
                                break;
                        }

                    }
                }
                Console.WriteLine(builder.ToString());
                return builder.ToString();
            }

            public string BuildUrl(string baseUrl, Dictionary<string, string> parameters)
            {
                var validParams = parameters
               .Where(p => !string.IsNullOrEmpty(p.Value))
               .Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}")
               .ToList();

                var queryString = string.Join("&", validParams);
                return $"{baseUrl}?{queryString}";
            }

            public string TryBuildUrl()
            {
                var baseUrl = "https://myapp.com/api?ref=abc";
                var parameters = new Dictionary<string, string>
                {
                    { "user", "john doe" },
                    { "role", "admin/user" },
                    { "token", "" }
                };
                var validParams = parameters
                    .Where(x => !string.IsNullOrEmpty(x.Value))
                    .Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}")
                    .ToList();

                if (validParams.Count == 0) return baseUrl;

                var queryString = string.Join("&", validParams);
                var result = $"{baseUrl}&{queryString}";
                return result;
            }

            public string TryBuildMediumProblem()
            {
                var protocol = string.Empty;
                var domain = "test.com";
                var path = string.Empty;
                var queryParams = new Dictionary<string, string> { { "search", "hello world" } };
                var builder = new StringBuilder();

                if (string.IsNullOrEmpty(domain)) return string.Empty;

                var validParams = queryParams?
                                //.Where(p => !string.IsNullOrEmpty(p.Value))
                                .Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}").ToList();

                if (!string.IsNullOrEmpty(protocol))
                {
                    builder.Append($"{protocol}://");
                }

                builder.Append(domain);

                if (!string.IsNullOrEmpty(path))
                {
                    builder.Append($"/{path}");
                }

                if (validParams is not null && validParams.Count > 0)
                {
                    var paramss = string.Join('&', validParams);
                    builder.Append($"?{paramss}");
                }
                return builder.ToString();
            }

            public string TryHardProblem()
            {
                var baseUrl = "https://api.com/data?user=admin&lang=en";
                var parameters = new Dictionary<string, string>
                {
                    { "user", "admin" },     // duplicate key with same value – skip
                    { "lang", "fr" },        // same key, new value – override
                    { "theme", "dark" },     // new key – append
                    { "debug", "" }          // empty value – skip
                };
                var builder = new StringBuilder();
                var split = baseUrl.Split('?', 2);
                var path = split[0];
                var urlParam = split[1].Split('&');

                foreach (var url in urlParam)
                {
                    var urlSplit = url.Split('=');

                    if (!parameters.ContainsKey(urlSplit[0]))
                    {
                        parameters.TryGetValue(urlSplit[0], out var value);
                        value = urlSplit[1];
                    }
                }
                var finalParam = parameters
                    .Where(x => !string.IsNullOrEmpty(x.Value))
                    .Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}")
                    .ToList();
                if (finalParam.Count > 0)
                {
                    var joins = string.Join('&', finalParam);
                    builder.Append($"{path}?{joins}");
                    return builder.ToString();
                }
                return baseUrl;
            }

            public string TryAnotherHardProblem()
            {
                var protocol = "https";
                var domain = "my";
                var path = "";
                var queryParams = new Dictionary<string, string>() { { "search", "hello@world" } };
                var builder = new StringBuilder();
                if (protocol != "http" && protocol != "https")
                {
                    //invalid protocol
                    return string.Empty;
                }
                if (!VerifyInvalidCharacters(domain))
                {
                    //invalid domain
                    return string.Empty;
                }
                if (!VerifyInvalidCharacters(path))
                {
                    //invalid domain
                    return string.Empty;
                }
                if (queryParams.Any(x => string.IsNullOrEmpty(x.Key)))
                {
                    //invalid query
                    return string.Empty;
                }
                var validQuery = queryParams.Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}").ToList();
                var test = String.Join('&', validQuery);
                builder.Append($"{protocol}://{domain}/?{test}");
                return builder.ToString();
            }

            private bool VerifyInvalidCharacters(string input)
            {
                char[] characterToCheck = { '?', '&', '=' };
                if (input.IndexOfAny(characterToCheck) >= 0)
                {
                    return false;
                }
                return true;
            }

            private string RemoveChar(string inputString)
            {
                HashSet<char> skip = new HashSet<char>()
            {
               '\\',
             };

                char[] invalidChars = { '?', '&', '=' };
                if (inputString.IndexOfAny(invalidChars) >= 0)
                    return "";

                string result = string.Concat(inputString
                  .Where(c => !char.IsWhiteSpace(c) && !skip.Contains(c)));
                return Regex.Replace(inputString, "@\\\";'\\\\", string.Empty);
            }
        }

        public class LongestSleepingHours
        {
            public int GetLongestFreeCheck()
            {
                var intervals = new List<(string start, string end)>
                {
                    ("01:00", "02:00"),
                    ("06:00", "07:30"),
                    ("12:00", "13:00")
                };

                var timeToMinutes = intervals
                    .Select(x => (start: TimeToMinutesCheck(x.start), end: TimeToMinutesCheck(x.end)))
                    .OrderBy(x => x.start)
                    .ToList();

                int maxFree = 0;
                int prevEnd = 0;
                foreach (var interval in timeToMinutes)
                {
                    var freeTime = interval.start - prevEnd;
                    if (freeTime > maxFree) maxFree = freeTime;
                    prevEnd = interval.end;
                }

                var endOfDay = 1440;
                var finalGap = endOfDay - maxFree;
                if (finalGap > maxFree) maxFree = finalGap;
                return maxFree;
            }

            int TimeToMinutesCheck(string input)
            {
                var parts = input.Split(':');
                var hours = int.Parse(parts[0]);
                var minutes = int.Parse(parts[1]);
                return hours * 60 + minutes;
            }

            public int GetLongestFreeMinutes()
            {
                var intervals = new List<(string start, string end)>
                {
                    ("01:00", "02:00"),
                    ("06:00", "07:30"),
                    ("12:00", "13:00")
                };

                var minutesList = intervals
                    .Select(x => (start: TimeToMinutes(x.start), end: TimeToMinutes(x.end)))
                    .OrderBy(x => x.start)
                    .ToList();

                var maxFree = 0;
                var prevEnd = 0;

                foreach (var interval in minutesList)
                {
                    int freeTime = interval.start - prevEnd;
                    if (freeTime > maxFree) maxFree = freeTime;
                    prevEnd = interval.end;
                }

                int endOfDaty = 1440;
                int finalGap = endOfDaty - prevEnd;
                if (finalGap > maxFree) maxFree = finalGap;
                return maxFree;
            }

            public int GetLongestFreeHours()
            {
                var intervals = new List<(string start, string end)>
                {
                    ("01:00", "02:00"),
                    ("06:00", "07:30"),
                    ("12:00", "13:00")
                };

                var minutesList = intervals
                    .Select(x => (start: TimeToMinutes(x.start), end: TimeToMinutes(x.end)))
                    .OrderBy(x => x.start)
                    .ToList();

                int maxFree = 0;
                int preEnd = 0;

                foreach (var interval in minutesList)
                {
                    var freeTime = interval.start - preEnd;
                    if (freeTime > maxFree) maxFree = freeTime;
                    preEnd = interval.end;
                }

                int endOfDaty = 1440;
                int finalGap = endOfDaty - preEnd;
                if (finalGap > maxFree) maxFree = finalGap;

                return maxFree / 60;
            }

            int TimeToMinutes(string time)
            {
                var parts = time.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                return hours * 60 + minutes;
            }
        }
    }


    public class Maverics
    {
        // Example 1:
        // Input: s = ["h","e","l","l","o"]
        // Output: ["o","l","l","e","h"]

        // Example 2:
        // Input: s = ["H","a","n","n","a","h"]
        // Output: ["h","a","n","n","a","H"]

        public void ReverseString()
        {
            char[] s = ['h', 'e', 'l', 'l', 'o'];
            int write = 0;
            int read = s.Length - 1;

            while (write < read)
            {
                var tempLeft = s[write];
                var tempRight = s[read];
                s[write] = tempRight;
                s[read] = tempLeft;
                read--;
                write++;
            }
            Console.WriteLine(new string(s));
        }

        public bool ValidPalindrome1()
        {
            string s = "A man, a plan, a canal: Panama";
            var result = RemoveAlphanumeric(s);
            s = result.ToLower();
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    Console.WriteLine("false");
                    return false;
                }
                left++; right--;
            }
            Console.WriteLine("true");
            return true;
        }

        public string RemoveAlphanumeric(string input)
        {
            return new string(input.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        private static bool ThreeConsicativeOdds(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }

            int left = 0;
            var oddCount = 0;
            var isConsicative = false;

            while (left < arr.Length)
            {
                if (arr[left] % 2 != 0)
                {
                    oddCount++;
                }
                else
                {
                    oddCount = 0;
                }
                if (oddCount == 3)
                {
                    isConsicative = true;
                    break;
                }
                left++;
            }
            return isConsicative;
        }

        private static void Easy()
        {
            //var res = new ValidParentheses().Min("())(()");
            //Console.WriteLine($"Min ==> {res}");
            var res = new ValidParentheses().LongestValidParentheses(")()())");
            Console.WriteLine($"LongestValidParentheses ==> {res}");
            //Console.WriteLine($"SerchInsertPosition ==> {new SerchInsertPosition().SearchInsert([1, 3, 5, 6], 4)}");
            //Console.WriteLine($"Palindrome Number ==> {new PalindromeNumber().IsPalindrome3(1221)}");
            //var result = new TwoSumNumber().TwoSum([2, 7, 11, 15], 13);
            //Console.WriteLine($"TwoSumNumber ==> {"[" + string.Join(",", result) + "]"}");
            //Console.WriteLine($"ValidParentheses ==> {new ValidParentheses().IsValid("()[]{]")}");
            //Console.WriteLine($"LenghtOfLastWord ==> {new LenghtOfLastWord().Solution1("   fly me   to   the moon  ")}");
            //Console.WriteLine($"RemoveDuplicatesFromSortedArray ==> {new RemoveDuplicatesFromSortedArray().
            //    Solution1([0, 0, 1, 1, 2])}");
            //Console.WriteLine($"RemoveElement ==> {new RemoveElement().Solution([3, 2, 2, 3], 3)}");
            //var result = new TwoSumNumber().TwoSumUsingDictionary([2, 7, 11, 15], 9);
            //Console.WriteLine($"TwoSumNumber ==> {"[" + string.Join(",", result) + "]"}");
            //var result = new TwoSumInputArrayIsSorted().TwoSum([1, 3, 4, 6, 10], 7);
            //Console.WriteLine($"TwoSumInputArrayIsSorted ==> {"[" + string.Join(",", result) + "]"}");
        }

        private static void Patterns()
        {
            //Patterns
            var patterns = new TwoPointers();
            //new TwoPointers().FindPairSum([1, 2, 3, 4, 6, 8, 9, 11], 10);
            //Console.WriteLine($"IsStringPalindrome ==> {new TwoPointers().IsStringPalindrome("madam")}");

            //new TwoPointers().LengthOfLongestSubstring("abcabcbb");
            //Console.WriteLine($"LengthOfLongestSubstring ==> {new TwoPointers().LengthOfLongestSubstring("abcabcbb")}");

            Console.WriteLine($"Max ==> {TwoPointers.Max([1, 8, 6, 2, 5, 4, 8, 3, 7])}");
        }
    }

    public class RecentCounter
    {
        private Queue<int> queue;

        public RecentCounter()
        {
            queue = new Queue<int>();
        }

        public int Ping(int t)
        {
            queue.Enqueue(t); // Add new ping

            // Remove pings older than 3000ms
            // We only need to check the front of the queue
            // because the queue is ordered by time
            // and we can safely remove all pings older than t - 3000
            // This is efficient because we only check the front of the queue
            // and remove pings until we find one that is within the 3000ms window
            // Remove pings outside the 3000ms window
            while (queue.Peek() < t - 3000)
            {
                queue.Dequeue();
            }

            return queue.Count; // Remaining pings are within the window
        }
    }

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
}
