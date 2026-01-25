namespace GnsMuhasebe.domain.Enums
{
    public enum BusinessErrorCode
    {
        //Common
        Succes = 200,
        RequestIsEmpty = 1000,
        UnknownError = 9999,
        ValidationError = 9998,

        // 1000 - Product errors
        InvalidProductName = 1002,
        InvalidStockValue = 1003,
        InvalidSalePrice = 1004,
        ProductCouldNotBeAdded = 1005,
        CategoryCouldNotFound = 1006,
        ProductCouldNotFound = 1007,
        NotEnoughProductToSell = 1008,
        ProductCouldNotUpdated = 1009,
        InvalidPurchasePrice = 1010,
        InvalidQuantity = 1011,

        // 1100 - Category errors
        InvalidCategoryName = 1101,
        CategoryCouldNotAdded = 1102,


        
    }
}
