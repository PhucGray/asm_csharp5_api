using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace api.Services
{
    public class FoodService : IFood
    {
        protected DataContext _context;
        protected IWebHostEnvironment _webHostEnvironment;

        public FoodService(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<FoodModel> GetAll() 
        { 
            return _context.Foods.ToList(); 
        }

        public FoodModel GetById(int id)
        {
            return _context.Foods.Find(id);
        }

        public async Task<dynamic> Add(IFormCollection data)
        {
            try
            {
                var files = data.Files;


                if (data.TryGetValue("foodData", out var someData))
                {
                    var food = JsonSerializer.Deserialize<FoodModel>(someData);

                    string imagePath = await ImageHelper.Upload(files[0], _webHostEnvironment);

                    food.Image = imagePath;

                    await _context.Foods.AddAsync(food);
                    await _context.SaveChangesAsync();

                    return food;
                }
            }
            catch (Exception)
            {

            }

            return null;


        }

        public FoodModel Update(FoodModel food)
        {
            try
            {
                _context.Update(food);
                _context.SaveChanges();
            }
            catch (Exception) { }

            return food;
        }

        public void Delete(int id)
        {
            var food = _context.Foods.Find(id);
            _context.Foods.Remove(food);
        }
    }
}
