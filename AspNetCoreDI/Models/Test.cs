namespace AspNetCoreDI.Models
{
    public class Test
    {
        YasamSureci _ys;
        public Test(YasamSureci ys)
        {
            _ys = ys;
        }

        public Guid RandomDeger
        {
            get
            {
                return _ys.deger;
            }
        }
    }
}
