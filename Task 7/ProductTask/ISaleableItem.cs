namespace ProductProject
{
    public interface ISaleableItem
    {
		public string Name { get; }
		public int Price { get; set; }
		public double Weight { get; }
		public void ChangePrice(int percentage);
		public void Parse(string text);
	}
}

