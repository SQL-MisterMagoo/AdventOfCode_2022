//var scans = File.ReadAllLines("Practice.txt")
var scans = File.ReadAllLines("PuzzleInput.txt")
  .Select(scan => scan.Split(" -> ")
  .Select(coords => (x: int.Parse(coords.Split(',')[0]), y: int.Parse(coords.Split(',')[1])))
  );

HashSet<(int x, int y, char b)> blocks = new();
foreach (var scanList in scans)
{
  var start = scanList.First();
  blocks.Add((start.x, start.y, '#'));
  foreach (var coord in scanList)
  {
    while (start.x != coord.x)
    {
      start.x += Math.Sign(coord.x - start.x);
      blocks.Add((start.x, coord.y, '#'));
    }

    while (start.y != coord.y)
    {
      start.y += Math.Sign(coord.y - start.y);
      blocks.Add((coord.x, start.y, '#'));
    }

  }
}

drawMap();

int sandCounter = 0;
var maxY = blocks.Max(block => block.y) + 2;

bool GetHitPoint((int x, int y) start, int floor)
{
  var hit =
    blocks.Where(block => block.x == start.x && block.y >= start.y)
      .OrderBy(block => block.y)
      .FirstOrDefault();

  if (hit.x == 500 && hit.y == 0)
    return false;

  if (hit.y == 0)
  {
    hit = (start.x, floor, '=');
  }
  if (hit.y > start.y)
  {

    var left = (x: hit.x - 1, y: hit.y);
    var right = (x: hit.x + 1, y: hit.y);
    var top = (x: hit.x, y: hit.y - 1);
    foreach (var place in new[] { left, right })
      if (GetHitPoint(place, floor))
      {
        return true;
      }
    blocks.Add((top.x, top.y, 'o'));
    return true;
  }
  if (hit.y == 0)
    throw new Exception("Sand is spilling.");
  return false;
}
try
{
  while (GetHitPoint((500, 0), maxY))
    sandCounter++;
} 
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
}

drawMap();

void drawMap()
{
  var fname = $"map{DateTime.Now:yyyyMMddHHmmss}.txt";
  using var file = File.CreateText(fname);

  for (int y = 0; y < blocks.Max(block => block.y) + 2; y++)
  {
    file.Write($"{y:000} : ");
    for (int x = blocks.Min(block => block.x) - 10; x <= blocks.Max(block => block.x) + 1; x++)
    {
      var block = blocks.FirstOrDefault(block => block.y == y && block.x == x);
      file.Write($"{(block == default ? '.' : block.b)}");
    }
    file.WriteLine($"{blocks.Max(block => block.x) + 1}");
  }
  file.Flush();
}

Console.WriteLine();
Console.WriteLine(sandCounter);