namespace ServiceLayer.ProductService
{
    public class DropdownTuple
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return $"{Value}, {Text}";
        }
    }
}
