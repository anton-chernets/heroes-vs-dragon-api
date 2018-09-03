namespace HeroesVsDragons.Model
{
    public interface IAOResultLogger
    {
        void LogAOResult<T>(AOResult<T> aoResult);
    }
}