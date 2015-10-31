public class Chef
{
	public void Cook()
	{
		Bowl bowl = GetBowl();

		// processing carrot
		Carrot carrot = GetCarrot();
		var peeledCarrot = Peel(carrot);
		var cuttedCarrot = Cut(peeledCarrot);
		bowl.Add(cuttedCarrot);

		// processing potato
		Potato potato = GetPotato();
		var peeledPotato = Peel(potato);
		var cuttedPotato = Cut(peeledPotato);
		bowl.Add(cuttedPotato);
	}

	private Bowl GetBowl()
	{
		//... 
	}

	private Potato GetPotato()
	{
		//...
	}

	private Carrot GetCarrot()
	{
		//...
	}

	private void Cut(Vegetable potato)
	{
		//...
	}
}