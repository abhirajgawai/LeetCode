using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode.JuliasBaer;

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

                if (parameters.ContainsKey(urlSplit[0]))
                {
                    parameters.TryGetValue(urlSplit[0], out var value);
                    value = urlSplit[1];
                }
            }

            var finalParam = parameters
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}")
                .ToList();

            var joins = string.Join('&', finalParam);
            builder.Append($"{path}?{joins}");
            return builder.ToString();
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

        public bool VerifyIfInvalidCharExist(string input)
        {
            char[] invalidCharToValidate = [','];
            if (input.IndexOfAny(invalidCharToValidate) >= 0) return false;
            return true;
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

        public int LongedstSleepingHours()
        {
            var schedule = new List<(int start, int end)>
                {
                   (0,5),
                   (10,15)
                };
            const int weekHours = 168;

            if (schedule == null || schedule.Count == 0)
                return weekHours;

            // Step 1: Sort intervals by start time
            var sorted = schedule.OrderBy(i => i.start).ToList();

            int maxFree = 0;
            int prevEnd = 0;

            // Step 2: Calculate gaps between intervals
            foreach (var interval in sorted)
            {
                int gap = interval.start - prevEnd;
                maxFree = Math.Max(maxFree, gap);
                prevEnd = interval.end;
            }

            // Step 3: Check final gap till end of week
            int lastGap = weekHours - prevEnd;
            maxFree = Math.Max(maxFree, lastGap);

            return maxFree;
        }

        public int MediumLongestSleepingHouseInAWeek()
        {
            List<(string day, string start, string end)> schedule = new()
                {
                    ("Monday", "23:00", "23:45"),
                    ("Tuesday", "00:00", "01:00"),
                    ("Saturday", "21:30", "23:59")
                };

            var dayToIndex = new Dictionary<string, int>
                {
                    { "Monday", 0 },
                    { "Tuesday", 1 },
                    { "Wednesday", 2 },
                    { "Thursday", 3 },
                    { "Friday", 4 },
                    { "Saturday", 5 },
                    { "Sunday", 6 }
                };

            int ToMinutes(string day, string time)
            {
                var parts = time.Split(":");
                int dayOffset = dayToIndex[day] * 1440;
                int hours = int.Parse(parts[0]);
                var minutes = int.Parse(parts[1]);
                return dayOffset + (hours * 60 + minutes);
            }

            var scheduleInMinutes = schedule
                .Select(x => (
                start: ToMinutes(x.day, x.start),
                end: ToMinutes(x.day, x.end)))
                .OrderBy(x => x.start)
                .ToList();

            var maxFree = 0;
            var prevEnd = 0;

            foreach (var interval in scheduleInMinutes)
            {
                var freeTime = interval.start - prevEnd;
                if (freeTime > maxFree) maxFree = freeTime;
                prevEnd = Math.Max(prevEnd, interval.end);
            }

            var minutesInWeek = 1440 * 7;
            var finalGap = minutesInWeek - prevEnd;
            if (finalGap > maxFree) maxFree = finalGap;
            var result = finalGap / 60;
            return result;
        }

        public int LongestSleepinHoursInWeekInputInHours()
        {
            List<(int start, int end)> intervals = new()
                {
                    (0, 10),   // Busy from 00:00 to 10:00
                    (20, 30),  // Busy from 20:00 to 30:00
                    (40, 50)   // Busy from 40:00 to 50:00
                };

            int maxFree = 0;
            int prevEnd = 0;

            foreach (var interval in intervals.OrderBy(x => x.start))
            {
                var freeTime = interval.start - prevEnd;
                if (freeTime > maxFree) maxFree = freeTime;
                prevEnd = interval.end;
            }
            var hoursInWeek = 24 * 7;
            var finalGap = hoursInWeek - prevEnd;
            var result = Math.Max(finalGap, prevEnd);
            return result;
        }

        public int GetLongestSleepWithWraparound(List<(string day, string start, string end)> schedule)
        {
            var dayToIndex = new Dictionary<string, int>
                {
                    { "Monday", 0 },
                    { "Tuesday", 1 },
                    { "Wednesday", 2 },
                    { "Thursday", 3 },
                    { "Friday", 4 },
                    { "Saturday", 5 },
                    { "Sunday", 6 }
                };

            int ToMinutes(string day, string time)
            {
                var parts = time.Split(':');
                int dayOffset = dayToIndex[day] * 1440;
                return dayOffset + int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
            }

            // Step 1: Convert to (start, end) minute intervals
            var intervals = new List<(int start, int end)>();
            foreach (var (day, startStr, endStr) in schedule)
            {
                int start = ToMinutes(day, startStr);
                int end = ToMinutes(day, endStr);

                if (end >= start)
                {
                    intervals.Add((start, end));
                }
                else
                {
                    // Wraparound case: split into two intervals
                    intervals.Add((start, 10080)); // end of week
                    intervals.Add((0, end));       // start of week
                }
            }

            // Step 2: Merge overlapping intervals
            var merged = new List<(int start, int end)>();
            var sorted = intervals.OrderBy(i => i.start).ToList();

            foreach (var current in sorted)
            {
                if (merged.Count == 0 || current.start > merged.Last().end)
                {
                    merged.Add(current);
                }
                else
                {
                    var last = merged.Last();
                    merged[merged.Count - 1] = (last.start, Math.Max(last.end, current.end));
                }
            }

            // Step 3: Find longest free period between merged intervals
            int maxFree = 0;

            for (int i = 1; i < merged.Count; i++)
            {
                int gap = merged[i].start - merged[i - 1].end;
                maxFree = Math.Max(maxFree, gap);
            }

            // Step 4: Check wraparound gap (end of week → start of week)
            int wraparoundGap = (10080 - merged.Last().end) + merged.First().start;
            maxFree = Math.Max(maxFree, wraparoundGap);

            return maxFree;
        }

        public int GetLongestFreeHours(List<(int start, int end)> schedule)
        {
            const int weekHours = 168;

            // Step 1: Normalize wraparound intervals
            var intervals = new List<(int start, int end)>();
            foreach (var (start, end) in schedule)
            {
                if (end >= start)
                {
                    intervals.Add((start, end));
                }
                else
                {
                    // Wraparound: split across week boundary
                    intervals.Add((start, weekHours)); // Sunday → end of week
                    intervals.Add((0, end));           // start of week → Monday
                }
            }

            // Step 2: Sort and merge intervals
            var sorted = intervals.OrderBy(i => i.start).ToList();
            var merged = new List<(int start, int end)>();

            foreach (var interval in sorted)
            {
                if (merged.Count == 0 || interval.start > merged.Last().end)
                {
                    merged.Add(interval);
                }
                else
                {
                    var last = merged.Last();
                    merged[merged.Count - 1] = (last.start, Math.Max(last.end, interval.end));
                }
            }

            // Step 3: Find gaps between merged intervals
            int maxFree = 0;
            for (int i = 1; i < merged.Count; i++)
            {
                int gap = merged[i].start - merged[i - 1].end;
                maxFree = Math.Max(maxFree, gap);
            }

            // Step 4: Check wraparound free time
            int wrapGap = (weekHours - merged.Last().end) + merged.First().start;
            maxFree = Math.Max(maxFree, wrapGap);

            return maxFree;
        }

    }
}

