# Licence
### GNU General Public License v3.0
The reason why I decided to use this type of licensing for making public my project is because it is a variant of the Open Software Licence that does not require that the source code of derivative works be disclosed.

## How to build the CAPatient-MVC-Controllers!
This site has been created for recording information about patients. A database has created from script.
The main purpose of this project is to understand how the Model-View and controller are built and how they can be modified in order to accomplish maintenance function.

# How This Project Works:

## Visual Studio 2019 - Project Builder
This is the main screen where the project starts. If we take a look in the right menu, we will find folders:
* Model
* Views
* Controllers
Each of them with their specific subfolders. When the application runs, the Index for the Layout (master page) is executed and the home page is loaded. It is important to know, that each time the program runs, it uses a random port in the localport (ISS)

![MVC1](https://user-images.githubusercontent.com/106482588/170911754-39ff579e-dffa-465b-b319-4974a02359b0.JPG)

## Index
This is the home page for our site. It is only configured with a basic structure, because the main goal is not related to the design, but to the read from a database in order to update information (it reads, we are not validating data at this point of the course)

![MVC2](https://user-images.githubusercontent.com/106482588/170911777-fbe00dfb-6944-4ef3-a8f9-dba91ea5fbd8.JPG)

## Countries Page
Here is the list of countries there are in the database. Take a close look in the fields, so we can understand the information just show up.

![MVC3](https://user-images.githubusercontent.com/106482588/170911788-8bbd3ed8-1248-4c59-bc02-e85c89454147.JPG)

## Concentration Types

it shows us some information than can be Edit, view (detail) or delete. The same structure has been applied to the rest of the pages on the web site.

![MVC4](https://user-images.githubusercontent.com/106482588/170911819-08600e91-dcbe-4132-8600-3832c511ba7e.JPG)

## Diagnosis Categories

We can also edit the Diagnosis Categories. The create button is also available if we want to create new ones.
Keep in mind this comment, because for the countries page is different.

![MVC5](https://user-images.githubusercontent.com/106482588/170911828-868d46a0-a02a-463a-97c4-fa4d4c66e866.JPG)

## Delete

The Country Page let us only create a new information. If we choose Delete or Edit options we will not be able to accomplish neither of those. It is because the information is configured as read only.

![MVC6](https://user-images.githubusercontent.com/106482588/170911834-c02d2700-6315-4773-bbcd-2ee133187f1a.JPG)

## Create
This option, specifically for this control (CACountryController) is the only one that let us to modified this table in the database. It is for a design purpose and to have a better understanding about how it works.

![MVC7](https://user-images.githubusercontent.com/106482588/170911845-9b361077-59f1-40bf-afc5-026ea5dc66c1.JPG)







# HOW THIS PROJECT WORKS:

# CAPatient-MVC-Controllers
Model-Views-Controllers Basic is a sample of a Web Site for a College Clinic. The following instructions will guide you in the process of bulding this SITE Maintance based in MVC.
# Objective
Recording and maintanance the patient information for a community clinic.
We need to install the database from a script, generate the models and create views to display and maintain the non-dependent tables:
* country
* diagnosisCategory
* dispensingUnits
* medicationType
* concentrationType.
# Database
The Database used is call Patients and it is installed from a script, as mentioned before.
![database](https://user-images.githubusercontent.com/106482588/170906819-fe5c65e9-3781-4618-9034-32ed49fd53aa.jpg)

# How to build the project
* Create an ASP.NET Core 3.1 project using MVC.  Call it CAPatients.  
  Remember to change the authentication to Individual User Accounts.
# Load the database to SQL, then generate the models & context for Entity Framework.
* Use SQL Server Management Studio (SSMS) to execute the script and install the database.
* Generate the Entity Framework classes for the database into the project’s Models folder.  Name the context PatientsContext (which is the default for a database named “Patients”).
* Add the connection string to appsettings.json and add a service to Startup.cs to support dependency injection for database context PatientsContext.
# Modify the default layout’s footer.
* Put your name and section on the left side of the footer.  Your name should be a hyperlink causing the user’s e-mail client to create an email directed to your college email account.
* Move the menu’s hyperlinks for “Home” and “Privacy” from the menu bar to the right side of the footer, retaining their horizontal alignment.
![database2](https://user-images.githubusercontent.com/106482588/170906838-fcc0da2d-6e21-4bd3-838f-bc2837b6ba17.jpg)

* Generate a controller called CACountryController along with the required Views to enable full CRUD maintenance on the country table.  
* Add a link to it on the menu.
* Normally, pages do not display keys.  The key to this table is manually entered (and does not end in “ID”), so Razor provides it as an input on the Create view.
* Show the CountryCode on all views for this controller, but only allow the user to modify it on the Create view.  Ensure all views & hyperlinks function correctly: Edit is particularly sensitive to incorrect changes.
* Change the browser window title and the heading on the Index view to “Countries on File” or “List of Countries” instead of “Index” … less ambiguity for the user this way.
* a.	Change the browser titles and headings on the Details, Create, Edit and Delete views as well, to denote the table and action (“Edit Country”, and so on).
![database3](https://user-images.githubusercontent.com/106482588/170906871-b064b248-1653-44aa-8534-a9358260c34e.jpg)

* Add a link for each controller to the menu.  
* Where the key is manually entered (dispensingUnit & concentrationUnit), display the key on all views, but only permit it to be modified on the Create view.
* Modify the browser title and page headings on each view to indicate the object type and the action performed by the page (“Create New Dispensing Unit”, “List of Diagnosis Categories”, etc.).  Generate controllers for the diagnosisCategory table, the concentrationUnit table, the dispensingUnits table, and the medicationType table … with the required Views to enable full CRUD maintenance.  
# In all Controllers:
* Ensure the controllers, their menu entries, and their actions all work.
* Comments are required to describe what each controller does and what each of its methods do.  
* Generated controllers have 9 methods (actions).  
