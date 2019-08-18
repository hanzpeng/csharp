using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            int[,] maze = {
                {0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0},
                {1, 1, 0, 1, 1},
                {0, 0, 0, 0, 0}
            };
            Assert.AreEqual(12, new Solution1().shortestDistance(maze, new int[] { 0, 4 }, new int[] { 4, 4 }));
        }
    }
    public class Solution1
    {
        int R, C;
        int[] dr = { 0, 0, -1, 1 };
        int[] dc = { -1, 1, 0, 0 };
        int[,] maze;
        int[,] dist;
        int[] destination;
        public int shortestDistance(int[,] maze, int[] start, int[] destination)
        {
            R = maze.GetLength(0);
            C = maze.GetLength(1);
            this.destination = destination;
            this.maze = maze;
            dist = new int[R, C];
            dfs(start[0], start[1], -1, 0);

            if (dist[destination[0], destination[1]] > 0)
                return dist[destination[0], destination[1]];
            else
                return -1;
        }

        void dfs(int r1, int c1, int dir, int startDist)
        {
            if (r1 == destination[0] && c1 == destination[1]) return;
            for (int i = 0; i < 4; i++)
            {
                if ((dir == 0 || dir == 1) && (i == 0 || i == 1)) continue;
                if ((dir == 2 || dir == 3) && (i == 3 || i == 3)) continue;

                int r = r1;
                int c = c1;
                int r2 = r;
                int c2 = c;
                int steps = 0;
                while (true)
                {
                    r += dr[i];
                    c += dc[i];
                    if (r < 0 || r == R || c < 0 || c == C || maze[r, c] == 1) break;
                    r2 = r;
                    c2 = c;
                    steps++;
                }
                if (steps == 0) continue;
                int newDist = startDist + steps;
                if (dist[r2, c2] == 0 || newDist < dist[r2, c2])
                {
                    dist[r2, c2] = newDist;
                    dfs(r2, c2, i, newDist);
                }
            }
        }
    }
}