
using Academy.Service.Services.Implementations;
using Academy.Service.Services.Interfaces;

IMenuService menuService=new MenuService();

await menuService.ShowMenuAsync();