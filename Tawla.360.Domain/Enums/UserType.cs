namespace Tawla._360.Domain.Enums;

public enum UserType
{
    /// <summary>
    /// this is the Tawla 360 admin
    /// </summary>
    System,
    /// <summary>
    /// this main restaurant admin has access to all branches with all 
    /// </summary>
    RestaurantAdmin,
    /// <summary>
    /// the staff of the restaurant
    /// </summary>
    RestaurantStaff
}
