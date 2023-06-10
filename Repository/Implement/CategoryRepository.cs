using AutoMapper;
using BussinessObject.Models;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;

        public CategoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CategoryDTO> GetCategories()
        {
            List<Category> list = CategoryDAO.GetCategories();
            return _mapper.Map<List<CategoryDTO>>(list);
        }

        public CategoryDTO GetCategoryById(int id)
        {
            Category category = CategoryDAO.GetCategoryById(id);
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}