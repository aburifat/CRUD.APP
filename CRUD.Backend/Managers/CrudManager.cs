using CRUD.Backend.Context;
using CRUD.Backend.Repository.Models;
using CRUD.Backend.Repository.Requests;
using CRUD.Backend.Repository.Responses;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Managers
{
    public class CrudManager : ICrudManager
    {
        private readonly AppDbContext _context;

        public CrudManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItem(AddItemRequest request)
        {
            var NewItem = new Crud
            {
                Name = request.Name.Trim(),
                Email = request.Email.Trim(),
                PhoneNumber = request.PhoneNumber.Trim(),
            };

            _context.Add(NewItem);
            var createItemResult = await _context.SaveChangesAsync();

            return createItemResult > 0;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var item = await _context.Crud.FindAsync(id);
            if (item != null)
            {
                _context.Remove(item);
                var deleteResult = await _context.SaveChangesAsync();
                return deleteResult > 0;
            }
            return false;
        }

        public async Task<GetItemResponse> GetItem(int id)
        {
            var item = await _context.Crud
                .Where(x => x.Id == id)
                .Select(x => new GetItemResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                })
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<GetItemListResponse> GetItemList()
        {
            var itemList = new GetItemListResponse
            {
                GetItemList = await _context.Crud.Select(x => new GetItemResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                }).ToListAsync()
            };
            return itemList;
        }

        public async Task<bool> UpdateItem(UpdateItemRequest request)
        {
            var itemToUpdate = await _context.Crud.FindAsync(request.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = request.Name.Trim();
                itemToUpdate.Email = request.Email.Trim();
                itemToUpdate.PhoneNumber = request.PhoneNumber.Trim();

                _context.Crud.Update(itemToUpdate);

                var UpdateResult = await _context.SaveChangesAsync();

                return UpdateResult > 0;
            }
            return false;
        }
    }
}
