using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mall.Category
{
    public interface ICategoryAppService
    {
        Task Add(CategoryInput input);
        //Task Update(CategoryOutput )
    }

    public class CategoryAppService : MallAppServiceBase, ICategoryAppService
    {
        public Task Add(CategoryInput input)
        {
            throw new NotImplementedException();
        }

        public  Task AddCategory()
        {
            throw new NotImplementedException();
        }

        
    }
}
