# HospitalPortal

##  System Architecture Diagram
This diagram illustrates the architecture of a hospital portal system, focusing on the interaction between the front-end, back-end, and various services.

![image](https://github.com/user-attachments/assets/6305995e-6bc3-440a-947b-d3cfcd510d93)

The system layout applies to Dev, Test and Production enviroment

### Components

### 1. Hospital Portal (Front-end)
Serves as the user interface where hospital staff or patients interact with the system.
Logs will be collected and sent to Application Insights as the aggregation point for performance and usage analytics.

### 2. Patient (Backend)
Handles the business logic and data processing for the hospital portal.
Communicates with the front-end via gRPC (a high-performance RPC framework) and sends responses back to the front-end.
This backend service is also monitored by Application Insights for diagnostics and performance tracking.

### 3. Azure SQL Database
Used by the backend service to store and retrieve patient data securely.

### 4. Key Vaults
Stores connection strings and other secrets securely.
Accessed by the backend service to securely connect to the database and other services.

### Microsoft Azure Estimate							
![image](https://github.com/user-attachments/assets/dab82c04-b611-46b1-9283-e29a2e4b6692)

##  Setup and running the project
1. Download or clone the project
2. After downloading and extracting open the HospitalPortal.sln to the source code in Visual Studio
3. Build and clean the solution
4. Set multiple running solutions as per the screenshot below
   
   ![image](https://github.com/user-attachments/assets/f6d4d186-bab3-4094-93b4-95eb75365b4a)

   ![image](https://github.com/user-attachments/assets/ea82910a-5d98-419c-95aa-63d9dd717e9a)
   
