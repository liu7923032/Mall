using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Mall.Domain.Entities;

namespace Mall.Integral
{
    #region 1.0 接口抽象
    public interface IIntegralAppService : IAsyncCrudAppService<IntegralDto, int, GetIntegralsInput, CreateIntegralInput, UpdateIntegralInput>
    {

    }
    #endregion


    #region 2.0 具体实现
    public class IntegralAppService : AsyncCrudAppService<Mall_Integral, IntegralDto, int, GetIntegralsInput, CreateIntegralInput, UpdateIntegralInput>, IIntegralAppService
    {
        public IntegralAppService(IRepository<Mall_Integral> integralRepository) : base(integralRepository)
        {

        }
    } 
    #endregion

}
