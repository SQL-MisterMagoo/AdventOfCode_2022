var result =
	File.ReadAllLines("PuzzleInput.txt")
	.Chunk(3)
	.Sum(i => {
		return i[0].Join(i[1], l => l, r => r, (l, r) => r).Join(i[2], l => l, r => r, (l, r) => r).FirstOrDefault()
		switch
		{
			var c when c >= 'a' && c <= 'z' => c - 'a' + 1,
			var c when c >= 'A' && c <= 'Z' => c - 'A' + 27,
			_ => 0
		};
	});
	Console.WriteLine(result);
