public class MineModule : ModuleBase<SocketCommandContext>
{
    public int NearMines(int x, int y, string[,] map)
    {
        if (!(map[x, y] == null))
        {
            if (map[x, y].Equals(":bomb:"))
            {

                return -1;
            }
        }
        int count = 0;
        for (int i = x - 1; i < x + 2; i++)
        {
            if (i < 0)
            {
                continue;
            }
            else if (i >= map.GetLength(0))
            {
                continue;
            }

            for (int j = y - 1; j < y + 2; j++)
            {
                if (j < 0)
                {
                    continue;
                }
                else if (j >= map.GetLength(1))
                {
                    continue;
                }

                if (!(map[i, j] == null))
                {

                    if (map[i, j].Equals(":bomb:"))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
    [Command("mine")]
    [Summary("Creates a game of minesweeper.")]
    public async Task MineSweeper()
    {
        Console.WriteLine("test");
        int height;
        int width;
        int minecount;
        height = 18;
        width = 12;
        minecount = 45;
        string[,] map = new string[width, height];
        var rand = new Random();
        for(int i = 0; i < minecount; i++)
        { 
            map[rand.Next(0, width), rand.Next(0, height)] = ":bomb:";
        }
        for(int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                int nearmines = NearMines(i, j, map);
                switch (nearmines)
                {
                    case -1:
                        continue;
                    case 0:
                        map[i, j] = ":zero:";
                        break;
                    case 1:
                        map[i, j] = ":one:";
                        break;
                    case 2:
                        map[i, j] = ":two:";
                        break;
                    case 3:
                        map[i, j] = ":three:";
                        break;
                    case 4:
                        map[i, j] = ":four:";
                        break;
                    case 5:
                        map[i, j] = ":five:";
                        break;
                    case 6:
                        map[i, j] = ":six:";
                        break;
                    case 7:
                        map[i, j] = ":seven:";
                        break;
                    case 8:
                        map[i, j] = ":eight:";
                        break;
                    case 9:
                        map[i, j] = ":nine:";
                        break;
                }
            }
        }
        string grid = "";
        for (int i = 0; i < map.GetLength(0); i++)
        {
            string row = "";
            for (int j = 0; j < map.GetLength(1); j++)
            {
                row += "||";
                row += map[i, j];
                row += "||";
            }
            Console.WriteLine(row);
            //await ReplyAsync(row);
            grid += row;
            grid += "\n";
            if((i + 1) % 4 == 0 || i == map.GetLength(0) - 1)
            {
                await ReplyAsync(grid);
                grid = "";
            }
        }
        //await ReplyAsync(grid);
    }
}
