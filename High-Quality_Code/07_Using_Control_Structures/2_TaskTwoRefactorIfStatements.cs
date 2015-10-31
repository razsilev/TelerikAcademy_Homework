// First one.
Potato potato;
//... 
if (potato != null)
{
	if (!(potato.HasNotBeenPeeled || potato.IsRotten))
	{
		Cook(potato);
	}
}

// Second one.
bool isValid_X = MIN_X <= x && x <= MAX_X;
bool isValid_Y = MIN_Y <= y && y <= MAX_Y;

if (isValid_X && isValid_Y && shouldVisitCell)
{
   VisitCell();
}