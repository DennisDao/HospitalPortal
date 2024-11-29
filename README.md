# HospitalPortal

##  System Architecture Diagram
This diagram illustrates the architecture of a hospital portal system, focusing on the interaction between the front-end, back-end, and various services.

![image](https://github.com/user-attachments/assets/6305995e-6bc3-440a-947b-d3cfcd510d93)

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
