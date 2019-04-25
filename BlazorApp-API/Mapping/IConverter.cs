namespace BlazorApp_API.Mapping
{
    public interface IConverter<TSource, TDestination>
    {
        TDestination Convert(TSource sourceObject);
        TSource Convert(TDestination sourceObject);
    }
}