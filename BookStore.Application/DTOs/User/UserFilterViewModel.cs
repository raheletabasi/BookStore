using BookStore.Application.DTOs.Common;

namespace BookStore.Application.DTOs.User;

public class UserFilterViewModel : BasePaging
{
    public string UserName { get; set; }
    public List<Domain.Entity.User> Users { get; set; }

    public UserFilterViewModel SetUsers(List<Domain.Entity.User> users)
    {
        this.Users = users;
        return this;
    }

    public UserFilterViewModel SetPaging(BasePaging paging)
    {
        this.PageId = paging.PageId;
        this.AllEntityCount = paging.AllEntityCount;
        this.StartPage = paging.StartPage;
        this.EndPage = paging.EndPage;
        this.TakeEntity = paging.TakeEntity;
        this.CountForShowAfterAndBefor = paging.CountForShowAfterAndBefor;
        this.SkipEntitiy = paging.SkipEntitiy;
        this.PageCount = paging.PageCount;

        return this;
    }
}
