Readme File
================
1. Download Project from below GitHub URL
	"https://github.com/sak-zensar/ProductStore.git"
2. Open "Database" folder and Create database with the name "ProductStores" or check and update connection string name value with created database. Then run the script "" on the newely created database.
3. Open the "Code" folder and go to "\Code\ProductStore" folder.
4. Open VS 2017 and open "ProductStore.sln" solution in that and click on run the project under "IIS Express(Google Crome)" or which ever is prefered.
5. Open annother VS 2017 and open "ProductStoreServices.sln" solution in that. Then goto property of "Service" project, then navigate to "Web" menu. Under that change the Server setting to "Local IIS" from "IIS Express". Then replace the Project URL to "http://localhost/Service" under same Server Section and click on "Create Virtual Directory". Verify Virtual Directory is created or not and test it. Then run the service either from IIS or clicking on Run button of VS "Local IIS(Google Crome)"
6. Product Page wil;l be display after both the ProductStore and ProductStoreServices solution are running successfully. 

