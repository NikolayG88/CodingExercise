using VehicleInventory.Services.Contracts;
using VehicleInventory.Services.DTOs;
using CodingExercise.Data.Models;
using System.Collections.Generic;
using CodingExercise.Data;
using System.Linq;
using AutoMapper;
using System;

namespace VehicleInventory.Services
{
    public class VehicleInventoryService : IVehicleInventoryService
    {

        private readonly IMapper _mapper;
        private readonly VehicleInventoryContext _dbContext;


        public VehicleInventoryService(IVehicleInventoryContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext as VehicleInventoryContext;
        }

        public int AddVehicleInStock(AddVehicleInStockDTO vehicle)
        {
            var toAdd = _mapper.Map<VehicleInStock>(vehicle);

            _dbContext.VehiclesInStock.Add(toAdd);

            return _dbContext.SaveChanges();
        }

        public List<VehicleInStockDTO> GetAllVehiclesInStockFlat()
        {
            var result = _dbContext.VehiclesInStock.Where(vs => vs.IsDeleted == false).ToList();

            var resDto = _mapper.Map<List<VehicleInStockDTO>>(result);

            return resDto;
        }

        public VehicleInStockDTO GetVehicleInStockByIdFlat(int vehicleId)
        {
            var result = _dbContext.VehiclesInStock.Where(v => v.IsDeleted == false).FirstOrDefault(v => v.Id == vehicleId);

            var resDto = _mapper.Map<VehicleInStockDTO>(result);

            return resDto;
        }

        public int RemoveVehicleInStock(int vehicleId)
        {
            var toDelete = _dbContext.VehiclesInStock.Where(v => v.IsDeleted == false).FirstOrDefault(vs => vs.Id == vehicleId);

            if(toDelete == null)
            {
                return 0;
            }

            toDelete.IsDeleted = true;

            return _dbContext.SaveChanges();
        }
    }
}
