var result =
	File.ReadAllLines("PuzzleInput.txt")
	.Sum(i => {
		var iLen = i.Length/2;
		return i[0..iLen].Join(i[^iLen..], l => l, r => r, (l, r) => r).FirstOrDefault()
		switch
		{
			var c when c >= 'a' && c <= 'z' => c - 'a' + 1,
			var c when c >= 'A' && c <= 'Z' => c - 'A' + 27,
			_ => 0
		};
	});
	Console.WriteLine(result);
