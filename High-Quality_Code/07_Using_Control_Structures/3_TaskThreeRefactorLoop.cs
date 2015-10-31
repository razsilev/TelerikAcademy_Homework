int numberOfLoops = 100;
bool isFound = false;

for (int i = 0; i < numberOfLoops; i += 1)
{
	Console.WriteLine(array[i]);

	bool isLastDigitZero = i % 10 == 0;
	bool isEqual = array[i] == expectedValue;

	if (isLastDigitZero && isEqual)
	{
		isFound = true;
		break;
	}
}

// More code here
if (isFound)
{
	Console.WriteLine("Value Found");
}