function solve(input) {
	var arr = input.map(Number),
		numberOfSequences = 1;
  
	for(var i = 2; i < arr.length; i += 1) {
		if(arr[i - 1] > arr[i]) {
			numberOfSequences += 1;
		}
	}
  
  return numberOfSequences;
}