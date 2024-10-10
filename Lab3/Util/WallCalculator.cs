namespace Lab3.Util;

public static class WallCalculator
{
    public static int CalculateVisibleWallArea(char[,] labyrinth, int N)
    {
        int visibleArea = 0;
        int wallSize = 5;
        int wallHeight = 5;
        int areaPerWall = wallSize * wallHeight;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (labyrinth[i, j] == '#')
                {
                    if (i == 0 || labyrinth[i - 1, j] == '.')
                        visibleArea += areaPerWall;
                    if (i == N - 1 || labyrinth[i + 1, j] == '.')
                        visibleArea += areaPerWall;
                    if (j == 0 || labyrinth[i, j - 1] == '.')
                        visibleArea += areaPerWall;
                    if (j == N - 1 || labyrinth[i, j + 1] == '.')
                        visibleArea += areaPerWall;
                }
            }
        }

        return visibleArea;
    }
}
