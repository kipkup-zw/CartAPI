# CartAPI
Generic shopping cart API .NET Core project

Assumptions:

* implemented an internal datastructure, did not use EF DB.
* All Item prices set to 20
* A user can have only one cart, keyed by his userId

Supported routes are:

* /Cart/List/{id}
* /Cart/AddItems (Creates cart if does not exist).
* /Cart/Delete/{id} (Deletes a cart)
* /Cart/DeleteCartItems 

Added swagger interface upon startup.
