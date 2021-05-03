using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.SeedData
{
    public class DataContextSeed
    {
        public static async Task  SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
          
                if(!context.Menus.Any()){
                    var menusData = File.ReadAllText("../Infrastructure/Data/SeedData/menus.json");
                    var menus = JsonSerializer.Deserialize<List<Menu>>(menusData);

                    foreach (var item in menus)
                    {
                        context.Menus.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                 if(!context.MenuItems.Any()){
                    var menuItemsData = File.ReadAllText("../Infrastructure/Data/SeedData/menuItems.json");
                    var menuItems = JsonSerializer.Deserialize<List<MenuItem>>(menuItemsData);

                    foreach (var item in menuItems)
                    {
                        context.MenuItems.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }

        }

    }
}