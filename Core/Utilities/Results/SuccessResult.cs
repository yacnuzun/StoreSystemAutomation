namespace Core.Utilities.Results
{
    public class SuccessResult : Result, IResult
    {
        public SuccessResult(string message) : base(true)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
