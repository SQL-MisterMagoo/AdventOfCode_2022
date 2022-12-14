var map = File.ReadAllLines("PuzzleInput.txt");
Queue<(int row, int col, int steps)> queue = new();
List<(int row, int col)> used = new();

int GetPlaceFromMap(int row, int col) => map[row][col] switch
{
  'S' => 1,
  'E' => 26,
  char other => other - 'a' + 1
};

// Find start
for (int row = 0; row < map.Length; row++)
{
	if (map[row].IndexOf('S') is int column && column >= 0)
	{
		queue.Enqueue((row, column, 0));
		break;
	}
}

// Walk the path(s)
while(queue.TryDequeue(out (int row, int col, int steps) step))
{
	Console.WriteLine($"{step.row},{step.col} {step.steps}");
	if (used.Contains((step.row, step.col)))
	{
		//Console.WriteLine($"Skipping {step.row},{step.col}");
		continue;
  }
  used.Add((step.row, step.col));
	if (map[step.row][step.col] == 'E')
	{
		Console.WriteLine(step.steps);
		break;
	}
	foreach (var move in new (int dr, int dc)[] {(1,0),(0,1),(-1,0),(0,-1)})
	{
		var rr = step.row + move.dr;
		var cc = step.col + move.dc;
		if (rr>=0 && rr<map.Length && cc>=0 && cc<map[0].Length && GetPlaceFromMap(rr,cc)<=1+GetPlaceFromMap(step.row,step.col))
			queue.Enqueue((rr, cc, step.steps + 1));
	}
}
