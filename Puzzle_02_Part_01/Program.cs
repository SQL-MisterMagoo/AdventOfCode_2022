var result =
	File.ReadAllLines("PuzzleInput.txt")
	.Sum(i =>
		(i[0], i[2]) switch 
		{
			('A','X') => 1 + 3,
			('B','Y') => 2 + 3,
			('C','Z') => 3 + 3,
			('A','Y') => 2 + 6,
			('B','Z') => 3 + 6,
			('C','X') => 1 + 6,
			('A','Z') => 3 + 0,
			('B','X') => 1 + 0,
			('C','Y') => 2 + 0,
			(_,_) => 0
	});
Console.WriteLine(result);