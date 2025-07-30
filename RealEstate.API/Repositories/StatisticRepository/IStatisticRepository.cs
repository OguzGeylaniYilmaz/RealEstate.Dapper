namespace RealEstate.API.Repositories.StatisticRepository
{
    public interface IStatisticRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        string CityWithMostProductsCount();
        int NumberOfDifferentCities();
        decimal FinalProductPrice();
        string OldestBuildungYear();
        string NewestBuildingYear();
        int ActiveEmployeeCount();
        int AverageRoomCount();

    }
}
