namespace HeroesVsDragons.Model
{
    public enum Code
    {
        //If method executed successfully
        Ok = 0,

        //if some error happens
        Error = 1,
        EntityAlreadyExists = 2,
        EntityNotFound = 3,

        // 1000-1999 error for stores

        /// <summary>
        /// Store not found
        /// </summary>
        StoreNotFound = 1000,


        //2000-2999 - attributes
        AttributeNotFound = 2000,
        AttributeRemoveAssignedToItem = 2001,

        //3000-3999 - devices
        DeviceNotFound = 3000,
        DeviceStatusFailMustBeDeactivated = 3001,
        
        //4000-4999 DeviceActivation
        /// <summary>
        /// Sorry, authentication key is invalid.
        /// </summary>
        AuthenticationKeyIsInvalid = 4000,
                       
        /// <summary>
        /// Sorry, your device is assigned to another Business. Please contact your Admin.
        /// </summary>
        DeviceIsAssignedToAnotherBusiness = 4001,
        
        /// <summary>
        /// The license has expired (after 30ty days of unpaid usage)
        /// </summary>
        LicenseIsExpired = 4002,
                
        /// <summary>
        /// Sorry, your device is deactivated. Please contact your Admin.
        /// </summary>
        DeviceIsDeactivated = 4003,
        
        StoreRegisteredInAnotherBusiness = 4004,
        
        /// <summary>
        /// Your device is already added to another store. To change the store please contact your Admin.
        /// </summary>
        DeviceIsAlreadyAddedToAnotherStore = 4005,
        
        /// <summary>
        /// Sorry, there are no available licenses. Please contact your Admin
        /// </summary>
        NoAvailableLicenses = 4006,
        
        //5000-5999 users
        UserNotFound = 5000,
        UserOrPasswordIsInvalid = 5001,
        
        
        //6000-6999 Credit card
        CreditCardIsNotValid = 6000,
        
        //7000-7999 Order
        OrderNotFound = 7000,
        
        /// <summary>
        /// Amount can't be greater then full order amount
        /// </summary>
        AmountCantBeGreaterThenFullOrderAmount = 7001,
    }
}