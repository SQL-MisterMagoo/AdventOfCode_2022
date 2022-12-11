int c=0;
var result = 
	File
		.ReadAllLines("PuzzleInput.txt")
		.Select((v, i) => v is string x && x.Length == 0 && ++c > 0 ? new { c, v } : new { c, v })
		.Where(t => t.v is string tv && tv.Length > 0)
		.GroupBy(x => x.c)
		.Select(g => new { ElfNumber = g.Key, Calories = g.Sum(c => int.Parse(c.v)) })
		.MaxBy(g => g.Calories);
	
Console.WriteLine($"{result.ElfNumber},{result.Calories}");
