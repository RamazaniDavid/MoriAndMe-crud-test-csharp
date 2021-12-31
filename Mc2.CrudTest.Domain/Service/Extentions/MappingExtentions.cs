using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devsharp.Core;
using Devsharp.Core.Domian;
using Devsharp.Service.DTOs;
using Mapster;

namespace Devsharp.Service.Extentions
{
    public static class MappingExtentions
    {
        public static TDTO TODTO<TDTO>(this Entity entity) where TDTO : BaseDTO
        {
            if (entity == null)
                return null;

            var dto = entity.Adapt<TDTO>();

            if (entity is Customer && dto is CustomerListItemDTO)
            {
                var customer = entity as Customer;
                var customerDTO = dto as CustomerListItemDTO;
                customerDTO.BirthDate = customer.DateOfBirth.ToShortDateString();
                customerDTO.PhoneNumber =customer.CountryCode+"-"+ customer.PhoneNumber;
            }
            return dto;
        }


        public static TEntity ToEntity<TEntity>(this BaseDTO baseDTO) where TEntity : Entity
        {

            if (typeof(TEntity).GetInterface("IDateEntity") != null)
            {
                TypeAdapterConfig<BaseDTO, TEntity>.NewConfig().Ignore("CreateOn", "UpdateOn", "LocalCreateOn", "LocalUpdateOn");
            }
            var entity = baseDTO.Adapt<TEntity>();


          
            return entity;
        }

    }
}
