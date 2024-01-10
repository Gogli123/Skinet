namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int index, int size, int count, IReadOnlyList<T> data)
        {
            Index = index;
            Size = size;
            Count = count;
            Data = data;
        }

        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}