namespace BaffleTalk.Common.IoC
{
    public interface IIoCContainer
    {
        void Register<TSource, TDestination>(TSource source, TDestination destination);
        TDestination Resolve<TSource, TDestination>(TSource source);
    }
}