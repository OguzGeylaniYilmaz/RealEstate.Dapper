using Dapper;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.StatisticRepository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            var query = "SELECT COUNT(*) FROM Category WHERE Status = 1";
            using var connection = _context.CreateConnection();
            var count = connection.QueryFirstOrDefault<int>(query);
            return count;

        }

        public int ActiveEmployeeCount()
        {
            string query = "SELECT COUNT(*) FROM Employee WHERE Status = 1";
            using var connection = _context.CreateConnection();
            var employeeCount = connection.QueryFirstOrDefault<int>(query);
            return employeeCount;
        }

        public int ApartmentCount()
        {
            string query = "SELECT COUNT(*) FROM Product WHERE Type = 'Apartment'";
            using var connection = _context.CreateConnection();
            var apartmentCount = connection.QueryFirstOrDefault<int>(query);
            return apartmentCount;
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "SELECT AVG(Price) FROM Product WHERE Type = 'Rent'";
            using var connection = _context.CreateConnection();
            var averagePrice = connection.QueryFirstOrDefault<decimal>(query);
            return averagePrice;
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "SELECT AVG(Price) FROM Product WHERE Type = 'Sale'";
            using var connection = _context.CreateConnection();
            var averagePrice = connection.QueryFirstOrDefault<decimal>(query);
            return averagePrice;
        }

        public int AverageRoomCount()
        {
            string query = "SELECT AVG(RoomCount) FROM ProductDetails";
            using var connection = _context.CreateConnection();
            var averageRoomCount = connection.QueryFirstOrDefault<int>(query);
            return averageRoomCount;
        }

        public int CategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category";
            using var connection = _context.CreateConnection();
            var categoryCount = connection.QueryFirstOrDefault<int>(query);
            return categoryCount;
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select Top(1) CategoryName,Count(*) From Product inner join Category on Product.ProductCategory = Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using var connection = _context.CreateConnection();
            var categoryName = connection.QueryFirstOrDefault<string>(query);
            if (categoryName == null)
            {
                return "No categories found";
            }
            return categoryName;
        }

        public string CityWithMostProductsCount()
        {
            string query = "SELECT TOP(1) City, COUNT(*) AS ProductCount FROM Product GROUP BY City ORDER BY ProductCount DESC";
            using var connection = _context.CreateConnection();
            var cityWithMostProducts = connection.QueryFirstOrDefault<string>(query);
            if (cityWithMostProducts == null)
            {
                return "No products found";
            }
            else return cityWithMostProducts;
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "SELECT Name, COUNT(*) AS ProductCount FROM Product INNER JOIN Employee ON Product.EmployeeID = Employee.EmployeeID GROUP BY Name ORDER BY ProductCount DESC";
            using var connection = _context.CreateConnection();
            var employeeName = connection.QueryFirstOrDefault<string>(query);
            if (employeeName == null)
            {
                return "No employees found";
            }
            return employeeName;
        }

        public decimal FinalProductPrice()
        {
            string query = "SELECT TOP(1) Price FROM Product Order By ProductID Desc";
            using var connection = _context.CreateConnection();
            var finalPrice = connection.QueryFirstOrDefault<decimal>(query);
            return finalPrice;
        }

        public string NewestBuildingYear()
        {
            string query = "SELECT TOP(1) BuildingYear FROM ProductDetails ORDER BY BuildYear DESC";
            using var connection = _context.CreateConnection();
            var newestBuildingYear = connection.QueryFirstOrDefault<string>(query);
            if (newestBuildingYear == null)
            {
                return "No buildings found";
            }
            return newestBuildingYear;
        }

        public int NumberOfDifferentCities()
        {
            string query = "SELECT COUNT(DISTINCT City) FROM Product";
            using var connection = _context.CreateConnection();
            var differentCitiesCount = connection.QueryFirstOrDefault<int>(query);
            return differentCitiesCount;
        }

        public string OldestBuildungYear()
        {
            string query = "SELECT TOP(1) BuildingYear FROM ProductDetails ORDER BY BuildYear DESC";
            using var connection = _context.CreateConnection();
            var oldestBuildingYear = connection.QueryFirstOrDefault<string>(query);
            if (oldestBuildingYear == null)
            {
                return "No buildings found";
            }
            return oldestBuildingYear;
        }

        public int PassiveCategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category WHERE Status = 0";
            using var connection = _context.CreateConnection();
            var count = connection.QueryFirstOrDefault<int>(query);
            return count;
        }

        public int ProductCount()
        {
            string query = "SELECT COUNT(*) FROM Product";
            using var connection = _context.CreateConnection();
            var productCount = connection.QueryFirstOrDefault<int>(query);
            return productCount;
        }
    }
}
