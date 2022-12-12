var result =
	File.ReadAllLines("PuzzleInput.txt")
	.Sum(i =>
		(i[0], i[2]) switch 
		{
			('A','X') => 3 + 0,
			('B','Y') => 2 + 3,
			('C','Z') => 1 + 6,
			('A','Y') => 1 + 3,
			('B','Z') => 3 + 6,
			('C','X') => 2 + 0,
			('A','Z') => 2 + 6,
			('B','X') => 1 + 0,
			('C','Y') => 3 + 3,
			(_,_) => 0
	});
Console.WriteLine(result);