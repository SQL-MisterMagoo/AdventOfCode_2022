var map = File.ReadAllLines("PuzzleInput.txt");
Queue<(int row, int col, int steps)> queue = new();
List<(int row, int col)> used = new();
int shortest = 9999999;
int GetPlaceFromMap(int row, int col) => map[row][col] switch
{
  'S' => 1,
  'E' => 26,
  char other => other - 'a' + 1
};

// Find start
for (int rows = 0; rows < map.Length; rows++)
{
  for (int cols = 0; cols < map[0].Length; cols++)
    if (map[rows][cols] == 'S' || map[rows][cols] == 'a')
    {
      queue = new();
      used = new();
      queue.Enqueue((rows, cols, 0));

      // Walk the path(s)
      while (queue.TryDequeue(out (int row, int col, int steps) step))
      {
        //Console.WriteLine($"{step.row},{step.col} {step.steps}");
        if (used.Contains((step.row, step.col)) || step.steps>shortest)
        {
          //Console.WriteLine($"Skipping {step.rows},{step.cols}");
          continue;
        }
        used.Add((step.row, step.col));
        if (map[step.row][step.col] == 'E')
        {
          if (step.steps < shortest)
          {
            shortest = step.steps;
            Console.WriteLine(step.steps);
          }
          break;
        }
        foreach (var move in new (int dr, int dc)[] { (1, 0), (0, 1), (-1, 0), (0, -1) })
        {
          var rr = step.row + move.dr;
          var cc = step.col + move.dc;
          if (rr >= 0 && rr < map.Length && cc >= 0 && cc < map[0].Length && GetPlaceFromMap(rr, cc) <= 1 + GetPlaceFromMap(step.row, step.col))
            queue.Enqueue((rr, cc, step.steps + 1));
        }
      }
    }
}
