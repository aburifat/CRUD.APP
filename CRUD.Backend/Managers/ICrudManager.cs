using CRUD.Backend.Repository.Requests;
using CRUD.Backend.Repository.Responses;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CRUD.Backend.Managers
{
    public interface ICrudManager
    {
        Task<bool> AddItem(AddItemRequest request);

        Task<GetItemResponse> GetItem(int id);

        Task<GetItemListResponse> GetItemList();

        Task<bool> UpdateItem(UpdateItemRequest request);

        Task<bool> DeleteItem(int id);
    }
}
