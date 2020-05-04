select Users.*, Addresses.* from Users 
 left outer join Addresses 
	 on Users.HomeAddressId = Addresses.AddressId