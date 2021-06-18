# web-store-dotnet
Web store fullstack solution based on Onion architecture


## The Problem

The main goal is to implement administrator portal for online shopping that provides:
- the page for viewing, updating, adding and deleting products
- the page for viewing, updating, adding and deleting orders
- the representation of the 10 best selling products

Communication with database should be provided via API.

#### API specification:

- AddProduct - method for adding product
- EditProduct - method for updating product
- DeleteProduct - method for deleting product based on provided product id
- GetProducts - method for selecting all products that match specified criteria
- GetProductDetails - method that returns data for products representing on Details page that match specified criteria
- AddOrder - method for adding order
- EditOrder - method for updating order
- DeleteOrder - method for deleting order based on provided order id
- GetOrders - method for getting all orders, filter is not important
- GetBestBuyProductsInLastMonth - method that returns 10 best selling products in the previous month


#### Admin portal:

- It is necessary to create login portal feature intended for admins.
- Admin portal consists pages for product viewing, adding, updating and deleting.
- Admin portal consists pages for order viewing, adding, updating and deleting.  
- Create 5 categories of products: Shoes, Clothes, Jackets, Shirts, Sneakers. Each of them should consists of three products each. With the fact that some of the products needs to be located in several categories. For instance, sneakers could be in category Sneakers and in category Shoes. 




## The Solution

