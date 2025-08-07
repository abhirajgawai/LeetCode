using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy;

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

