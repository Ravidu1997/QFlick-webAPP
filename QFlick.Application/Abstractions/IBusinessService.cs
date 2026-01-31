namespace QFlick.Application.Abstractions
{
    public interface IBusinessService
    {
        Task<bool> IsOwnBusiness(string userId, int newBusinessId);

        //Task CreateBusiness(CreateBusinessInputDto businessData, CancellationToken cancellationToken);
    }
}
