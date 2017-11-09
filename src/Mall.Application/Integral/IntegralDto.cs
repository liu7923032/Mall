using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace Mall.Integral
{
    public class CreateIntegralInput
    {

    }

    public class UpdateIntegralInput : CreateIntegralInput, IEntityDto<int>
    {
        public int Id { get; set; }

    }


    public class IntegralDto : UpdateIntegralInput
    {
        
    }

    /// <summary>
    /// 通过人员来获取积分
    /// </summary>
    public class GetIntegralsInput 
    {
        //通过人员来获取积分
        public int UserId { get; set; }
    }
}
