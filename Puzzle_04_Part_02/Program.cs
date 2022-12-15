//File.ReadAllLines("Practice.txt")
var result =
	File.ReadAllLines("PuzzleInput.txt")
		.Select(
			line=> (
				left: line.Split(',')[0].Split('-').Select(range=>int.Parse(range)).ToArray(), 
				right: line.Split(',')[1].Split('-').Select(range => int.Parse(range)).ToArray()
				)
			)
		.Where(
			elves=> !(
				(elves.left[0] > elves.right[1])
				||
				(elves.left[1] < elves.right[0])
				)
		)
		.Count();
	Console.WriteLine(result);
