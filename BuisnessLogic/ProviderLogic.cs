using AutoMapper;
using DataAccess;
using Domain;
using Domain.Models;
using Domain.DtoModels;
using System;

namespace BuisnessLogic
{
    public class ProviderLogic
    {
        IRepository db;
        private readonly IMapper _mapper;
        public ProviderLogic(IRepository db, IMapper mapper)
        {
            this.db = db;
            _mapper = mapper;
        }
        public async Task<List<DtoProvider>> GetAllProvidersAsync()
        {
            var result = await db.GetAllDataListAsync<Provider, object>(
                entity => true);
            db.Dispose();
            return _mapper.Map<List<DtoProvider>>(result);
        }

        public async Task<DtoProvider> GetProviderByIdAsync(int id)
        {
            var result = await db.GetDataByIdAsync<Provider, object>(
                entity => entity.Id == id);
            db.Dispose();
            return _mapper.Map<DtoProvider>(result);
        }

        public async Task<DtoProvider> CreateNewProviderAsync(DtoProvider dtoProvider)
        {
            var provider = _mapper.Map<Provider>(dtoProvider);
            var result = await db.CreateAsync(provider);
            db.Dispose();

            return _mapper.Map<DtoProvider>(result);
        }

        public async Task<DtoProvider> DeleteProviderAsync(int id)
        {
            var lockedProvider = await db.GetDataByIdAsync<Provider, object>(entity => entity.Id == id);
            lockedProvider.Write = 1;
            var result = await db.UpdateAsync(lockedProvider);
            db.Dispose();
            return _mapper.Map<DtoProvider>(result);
        }

        public async Task<DtoProvider> UpdateProviderAsync(DtoProvider dtoProvider)
        {
            //var Provider = db.GetDataByIdAsync<Provider, object>(entity => entity.Id == dtoProvider.Id).Result;
            var Provider = _mapper.Map<Provider>(dtoProvider);
            var result = await db.UpdateAsync(Provider);
            db.Dispose();
            return _mapper.Map<DtoProvider>(result);
        }

    }
}
