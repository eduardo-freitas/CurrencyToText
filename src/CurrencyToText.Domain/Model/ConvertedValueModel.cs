namespace CurrencyToText.Domain.Model
{
    public class ConvertedValueModel
    {
        public decimal Value { get; set; }
        public string WordsValue { get; set; }
        public ConvertedValueModel(decimal value, string wordsValue)
        {
            Value = value;
            WordsValue = wordsValue;
        }
    }
}
