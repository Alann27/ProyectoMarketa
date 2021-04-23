# Supermaket Billing System - Marketa

This is a supermarket billing system allowing add and modify customer, add and modify products, add users (as simple cashier or admin), add product's categories, make reports of sales and products, make sales, print sales tickets, has a dashboard and more.

The system originally was developed for a supermaket called "La Marketa" in Dominican Republic, owned of some relatives. This is the first system I develop, so the code doesn't have the best practice and some architecture implemented.

When I first developed this system, I didn't know how to use ReportViewer, so I used Microsoft.Interop to make the reports with Microsoft Word and save it as PDF. But later I learned how to use ReportViewer and I changed the reports to that framework.

# Screenshots

Login
![Login form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Login.PNG?raw=true)

Menu
![Menu form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Actual%20Menu.PNG?raw=true)

Billings
![Billing form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Billing.PNG?raw=true)

Pay debts
![Pay debts form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Pay%20debts.PNG?raw=true)

Add users
![Add user form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Add%20cashier.PNG?raw=true)

Add products
![Add products form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Add%20product.PNG?raw=true)

Modify products
![Modify products form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Modify%20product.PNG?raw=true)

Add customers
![Add customers form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Add%20customer.PNG?raw=true)

Sales reports
![Sales reports form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Actual%20Sales%20report.PNG?raw=true)

Products reports
![Products reports form](https://github.com/Alann27/ProyectoMarketa/blob/master/Screenshots/Actual%20Product%20report.PNG?raw=true)

# Libraries

  - Windows.Forms
  - Microsoft.ReportViewer
  - log4net
  - Microsoft.Office.Interop.Word
