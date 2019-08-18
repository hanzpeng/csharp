using NUnit.Framework;

namespace P505_Maze2
{
    public class P505_Maze2
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
            Assert.AreEqual(12, new Maze2(maze).shortestDistance(new int[] { 0, 4 }, new int[] { 4, 4 }));
        }

        public class Maze2
        {
            private int R, C; //maze size
            private int[] dr = { 0, 0, -1, 1 };
            private int[] dc = { -1, 1, 0, 0 };
            private int[,] maze;
            public Maze2(int[,] maze)
            {
                R = maze.GetLength(0);
                C = maze.GetLength(1);
                this.maze = maze;
            }
            public int shortestDistance(int[] start, int[] destination)
            {
                int[,] dist = new int[R, C];
                dfs(start, destination, - 1, 0, dist);
                if (dist[destination[0], destination[1]] > 0)
                    return dist[destination[0], destination[1]];
                else
                    return -1;
            }

            void dfs(int[] start, int[] destination, int preDir, int startDist,int[,] dist)
            {
                if (start[0] == destination[0] && start[1] == destination[1]) return;  //already in destnation, no need to search again
                for (int dir = 0; dir < 4; dir++) //search in all directions (0-left, 1-right, 2-up, 3-down) (The row goes down as r increase)
                {
                    if ((preDir == 0 || preDir == 1) && (dir == 0 || dir == 1)) continue;  //don't go left or right in the same row 
                    if ((preDir == 2 || preDir == 3) && (dir == 2 || dir == 3)) continue;  //don't go up or down in the same column
                    int rNext = start[0];
                    int cNext = start[1];
                    int steps = 0;
                    while (true) // move on the same direction untill wall 
                    {
                        int rTemp = rNext + dr[dir];
                        int cTemp = cNext + dc[dir];
                        if (rTemp < 0 || rTemp == R || cTemp < 0 || cTemp == C || maze[rTemp, cTemp] == 1) break;  // wall
                        rNext = rTemp;
                        cNext = cTemp;
                        steps++;
                    }
                    if (steps == 0) continue;  // did not move, continue to next direction
                    int newDist = startDist + steps;
                    if (dist[rNext, cNext] == 0 || newDist < dist[rNext, cNext])
                    {
                        dist[rNext, cNext] = newDist;
                        int[] newStart = { rNext, cNext };
                        dfs(newStart, destination, dir, newDist, dist);  // Search from r, c since newDist is either the first path or a shorter path
                    }
                    //else // no op, the new distance is not  shorter. Do not search from r, c anymore 
                }
            }
        }
    }
}