using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly ShoppingCartDBContext _dbContext;

        public AdminService(ShoppingCartDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseModel AdminLogin(LoginModel loginModel)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var userData = _dbContext.AdminInfos.Where(x => x.Email == loginModel.EmailId).FirstOrDefault();
                if (userData != null)
                {
                    if (userData.Password == loginModel.Password)
                    {
                        response.Status = true;
                        response.Message = Convert.ToString(userData.Id) + "|" + userData.Name + "|" + userData.Email;
                    }
                    else
                    {
                        response.Status=false;
                        response.Message = "Your password is incorrect";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Email not registered. Please check your Email Id.";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "An error occurred. Please try again !";
                return response;
            }
        }       
        public CategoryModel SaveCategory(CategoryModel newCategory)
        {
            try
            {
                Category category = new Category();
                category.Name = newCategory.Name;
                _dbContext.Add(category);
                _dbContext.SaveChanges();
                return newCategory;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public List<CategoryModel> GetCategories()
        {
            var data = _dbContext.Categories.ToList();
            List<CategoryModel> categoryList = new List<CategoryModel>();
            foreach (var category in data)
            {
                CategoryModel categoryModel = new CategoryModel();
                categoryModel.Id = category.Id;
                categoryModel.Name = category.Name;
                categoryList.Add(categoryModel);
            }
            return categoryList;
        }

        public bool UpdateCategory(CategoryModel categoryToUpdate)
        {
            bool flag = false;
            var category = _dbContext.Categories.Where(x => x.Id == categoryToUpdate.Id).FirstOrDefault();
            if (category != null)
            {
                category.Name = categoryToUpdate.Name;
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public bool DeleteCategory(CategoryModel categoryToDelete)
        {
            bool flag = false;
            var category = _dbContext.Categories.Where(x => x.Id == categoryToDelete.Id).FirstOrDefault();
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public List<ProductModel> GetProducts()
        {
            List<Category> categoryData = _dbContext.Categories.ToList();
            List<Product> productData = _dbContext.Products.ToList();
            List<ProductModel> _productList = new List<ProductModel>();
            foreach (var p in productData)
            {
                ProductModel productModel = new()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    CategoryName = categoryData.Where(x => x.Id == p.CategoryId).Select(x => x.Name).FirstOrDefault()
                };
                _productList.Add(productModel);
            }

            return _productList;
        }

        public bool DeleteProduct(ProductModel productToDelete)
        {
            bool flag = false;
            var product = _dbContext.Products.Where(x => x.Id == productToDelete.Id).FirstOrDefault();
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public ProductModel SaveProduct(ProductModel newProduct)
        {
            try
            {
                Product product = new()
                {
                    Name = newProduct.Name,
                    Price = newProduct.Price,
                    ImageUrl = newProduct.ImageUrl,
                    CategoryId = newProduct.CategoryId,
                    Stock = newProduct.Stock
                };

                _dbContext.Add(product);
                _dbContext.SaveChanges();
                return newProduct;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int GetNewProductId()
        {
            try
            {
                int nextProductId = _dbContext.Products.ToList().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                return nextProductId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
