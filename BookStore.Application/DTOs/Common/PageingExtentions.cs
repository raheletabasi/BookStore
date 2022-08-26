namespace BookStore.Application.DTOs.Common;

public static class PageingExtentions
{
    public static IEnumerable<T> Paging<T>(this IEnumerable<T> query, BasePaging basePaging)
    {
        return query.Skip(basePaging.SkipEntitiy).Take(basePaging.TakeEntity);
    }
}
