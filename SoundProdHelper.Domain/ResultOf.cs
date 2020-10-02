namespace SoundProdHelper.Domain
{
    public sealed class ResultOf<T>
    {
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public string ErrorDescription { get; private set; }

        public static ResultOf<T> Ok(T value)
        {
            return new ResultOf<T>
            {
                Value = value,
                IsSuccess = true,
            };
        }

        public static ResultOf<T> BadRequest(string description)
        {
            return new ResultOf<T>
            {
                IsSuccess = false,
                ErrorDescription = description,
            };
        }
    }
}