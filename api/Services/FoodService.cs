using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<FoodModel>> GetAll() 
        { 
            return await _context.Foods.ToListAsync(); 
        }

        public async Task<FoodModel> GetById(int id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task<FoodModel> Add(IFormCollection data)
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

        public async Task<FoodModel> Update(IFormCollection data, int id)
        {
            try
            {

                var files = data.Files;


                if (data.TryGetValue("foodData", out var someData))
                {
                    string imagePath = "";

                    var newFood = JsonSerializer.Deserialize<FoodModel>(someData);
                    var food = _context.Foods.Find(id);

                    
                    food.Name = newFood.Name;
                    food.Price = newFood.Price;
                    food.SpecialPrice = newFood.SpecialPrice;
                    food.Description = newFood.Description;
                    food.Status = newFood.Status;
                    food.IsDeleted = newFood.IsDeleted;

                    if (files.Count > 0)
                    {
                        imagePath = await ImageHelper.Upload(files[0], _webHostEnvironment);
                        food.Image = imagePath;
                    }

                    await _context.SaveChangesAsync();

                    return food;
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var food = _context.Foods.Find(id);
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
