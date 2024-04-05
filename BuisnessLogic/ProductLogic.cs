using AutoMapper;
using DataAccess;
using Domain;
using Domain.Models;
using Domain.DtoModels;
using System;

namespace BuisnessLogic
{
    public class ProductLogic
    {
        IRepository db;
        private readonly IMapper _mapper;
        public ProductLogic(IRepository db, IMapper mapper)
        {
            this.db = db;
            _mapper = mapper;
        }
        public async Task<List<DtoProduct>> GetAllProductsAsync()
        {
            var result = await db.GetAllDataListAsync<Product, object>(
                entity => true,
                p => p.Provider);
            db.Dispose();
            return _mapper.Map<List<DtoProduct>>(result);
        }

        public async Task<DtoProduct> GetProductByIdAsync(int id)
        {
            var result = await db.GetDataByIdAsync<Product, object>(
                entity => entity.Id == id,
                p => p.Provider);
            db.Dispose();
            return _mapper.Map<DtoProduct>(result);
        }

        public async Task<DtoProduct> CreateNewProductAsync(DtoProduct dtoProduct)
        {
            var product = _mapper.Map<Product>(dtoProduct);
            if (dtoProduct.ProviderId is not null)
                product.Provider = db.GetDataByIdAsync<Provider, object>(entity => entity.Id == dtoProduct.ProviderId).Result;
            var result = await db.UpdateAsync(product);
            db.Dispose();
            return _mapper.Map<DtoProduct>(result);
        }

        public async Task<DtoProduct> DeleteProductAsync(int id)
        {
            var lockedProduct = await db.GetDataByIdAsync<Product, object>(entity => entity.Id == id);
            lockedProduct.Write = 1;
            var result = await db.UpdateAsync(lockedProduct);
            db.Dispose();
            return _mapper.Map<DtoProduct>(result);
        }

        public async Task<DtoProduct> UpdateProductAsync(DtoProduct dtoProduct)
        {
            //var product = db.GetDataByIdAsync<Product, object>(entity => entity.Id == dtoProduct.Id).Result;
            var product = _mapper.Map<Product>(dtoProduct);
            if (dtoProduct.ProviderId is not null)
                product.Provider = db.GetDataByIdAsync<Provider, object>(entity => entity.Id == dtoProduct.ProviderId).Result;
            var result = await db.UpdateAsync(product);
            db.Dispose();
            return _mapper.Map<DtoProduct>(result);
        }

    }
}
