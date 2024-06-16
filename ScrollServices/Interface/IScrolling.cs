namespace ScrollServices.Interface
{
    public interface IScrolling
    {
        public Task<List<int>> GetInts(int start, int count, string scrollType);

        public Task<string> Message();
       
    }
}
