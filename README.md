# Overview

Deploying a .NET Web API with SQL Server Instance to Azure using CI/CD and GitHub Actions.
This API is all about Formula One drivers.

## Environment Setup and Account Setup

The following assumes that you have already installed this on your local machine and created an account.

    NET SDK: 8.0.403
    Docker Desktop: 4.34.3
    SQL Server Management Studio: 20.1.10.0
    Microsoft Account
    Github Account


## Contents
- [Step 1 - Clone Repository](#step-1---clone-repository)
- [Step 2 - Add Docker Support](#step-2---add-docker-support)
- [Step 3 - Enable Microsoft Learn Sandbox](#step-3---enable-microsoft-learn-sandbox)
- [Step 4 - Continuous Integration](#step-4---continuous-integration)
- [Step 5 - Continuous Delivery](#step-5---continuous-delivery)


## Step 1 - Clone Repository

Open your terminal and run the following command to clone the repository.

    git clone https://github.com/alvinyanson/Net.WebApi.CICD.git


After cloning, open the **appSettings.Development.json** file and update the connection string to your own. For reference, this is my connection string. Leave the Initial Catalog value as default **'F1.DriversDB'**.

    "ConnectionStrings": {
    "DefaultConnection": "Data Source=ALAYANSON\\SQLEXPRESS;Initial Catalog=F1.DriversDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
    }


Open **Package Manager Console** and execute the command below. This will apply migrations and seed the **Drivers** table with sample data.



    Update-Database


![Update-Database](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20112814.png)

## Step 2 - Add Docker Support

This step has already been completed for you, so no action is required. If you'd like to apply this to your own project, follow these steps:

Right-click the project, select **Add**, then choose **Add Docker Support**. This will generate a Dockerfile. 

![Add-Docker-Support](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20105217.png)

⚠️Note that the **Dockerfile is located within the project folder**, **NOT** at the solution level. Keep this in mind as we will be needing this later.


## Step 3 - Enable Microsoft Learn Sandbox

Copy and paste this URL to your browser:

    https://learn.microsoft.com/en-us/training/modules/publish-azure-web-app-with-visual-studio/5-exercise-publish-an-asp.net-app-from-visual-studio


Activate the Microsoft Learn Sandbox and follow the subsequent steps provided. Once completed, you will receive 4 hours of access to the Learn Sandbox. We will utilize this resource for deploying to Azure App Services.

⚠️We are given **10 sandboxes** a day. (1 sandbox = 4 hours) 

![Open-Microsoft-Learn-Sandbox](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20105540.png)


## Step 4 - Continuous Integration

Copy and paste this URL to your browser:

    https://portal.azure.com


### Step 1 - Create Container registry

In the search menu, enter **Container Registries** and then click **Create**. Complete the form as shown below. For the registry name, you name whatever you want.


![Open-Microsoft-Learn-Sandbox](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20105802.png)


Once successful, click **Go to Resource**

![Open-Microsoft-Learn-Sandbox](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20105924.png)


Under Settings, Access Keys, **toggle to check** the Admin User.

This will allow our admin user too push our image inside our container. 


![Open-Microsoft-Learn-Sandbox](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20105958.png)


### Step 2 - Publish the App

On Visual Studio, right click on the project and click **Publish** and follow the steps as shown below:

Select Docker Container Registry

![Open-Microsoft-Learn-Sandbox](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20110210.png)

Select Azure Container Registry

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20110233.png)

Select the created registry we created earlier, in our case we name it **formulaoneapi**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20110316.png)

Select the Docker Desktop as Container build 

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20110348.png)

⚠️Make sure **Docker Desktop is running** in your machine


Once finished, click **Close**, then Click on **Publish**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20110523.png)


After publishing, check the Azure Portal. Find your created Container Registry and click on **Repositories**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20111329.png)


### Step 3 - Create App Service

In the search menu, enter **App Services**, click **Create**, and then select **Web App**. Complete the form.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20111627.png)

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20111708.png)


Click **Next: Database** - we will skip this section and leave it at the default settings.

Click **Next: Container** - Complete the form.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20111753.png)


Click **Next: Networking** - we will skip this section and leave it at the default settings.

Click **Next: Monitor + Secure** - we will skip this section and leave it at the default settings.

Click **Next: Review + Create** - Click **Create**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20111946.png)


Once successful, click on **Go to Resource**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20112104.png)

Copy the App URL, then paste it on the browser

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20112223.png)

Verify that our app is working

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20112312.png)


### Step 4 - Create Azure SQL Server

Previously, we cloned the project and executed the command **Update-Database**, which creates a database in SQL Server Management called 'F1.DriversDB'.

Open the SQL Server Management and locate the database created.

Right-click the database and follow the instructions shown in the image below.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20113540.png)

Click **Next**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20113604.png)

Save the **bacpac file** wherever you prefer; in our case, we will save it on the Desktop.


![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20113637.png)

Click **Finish**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20113711.png)

Click **Close**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20113754.png)



Open azure portal again.

    https://portal.azure.com


In the search menu, type **SQL Server** and click on the result. Then click **Create** and complete the form.

⚠️ Take note of the credentials you have created as we will be needing this later.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114015.png)


Click **Next: Networking**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114132.png)


Click **Next: Security** - we will skip this section and leave it at the default settings.

Click **Next: Additional Settings** - we will skip this section and leave it at the default settings.

Click **Next: Tags** - we will skip this section and leave it at the default settings.

Click **Next: Review + Create**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114323.png)


Once successful, click on **Go to Resource**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114517.png)


⚠️ Take note of the Server name as we will be using this to connect to our SQL Server Management in our machine.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20115120.png)


We will allow our IP address to access the Azure SQL Server. Follow the steps below, and then click **Save**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114556.png)


Verify that you can access the Azure SQL Server from your local SQL Server Management Studio. Previously, we created a credential for our SQL Server, so fill in the form with your own credentials.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114723.png)

Once connected, we will import the **bacpac file** we exported earlier into Azure SQL Server. 

Right-click on **Databases** and follow the steps below.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114812.png)


Click **Next**

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114830.png)


Locate the **bacpac file**; in our case, we saved it earlier on Desktop. Then click **Next**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114850.png)


On the database name **leave it as default**, then click **Next**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114915.png)


Click **Finish**, once done click **Close**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20114939.png)


Go to the Azure Portal. 

    https://portal.azure.com

Find the SQL Server you created and verify that our SQL database has been imported into Azure SQL Server. Click on the created database.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20115311.png)


Go to Connection String and update the **appsettings.Production.json** accordingly. Provide the password you have created earlier in the **{your_password}** field. In our case we set the password as 'P@ssw0rd'

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20115401.png)



## Step 5 - Continuous Delivery

### Step 1- Deployment Center

Go to the Azure Portal. 

    https://portal.azure.com

Navigate to **App Services** and click on the App Service we created earlier. Under the **Deployment** tab, follow the steps below and click on the red warning sign.


![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20115623.png)


Have it **turned ON** and click **Save**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20115650.png)

Click **Save** at the top then navigate back.

Follow the steps below. This will generate a GitHub workflow file (**.github/workflow/master_formulaoneapi.yaml**) in your GitHub repository.


![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20115831.png)

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20115852.png)


### Step 2 - Go to your Github repository

In the **Actions tab**, you will see that the workflow has been triggered.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20120106.png)

⚠️Optional: If the workflow failed, **make sure that the Dockerfile is at the solution level** NOT at the root project. Github Action is looking at the root our repository. Push the changes again and wait for the workflow to be successful.

Once **successful**, a deployment url will be shown.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20120247.png)


Open that URL in your browser to verify that it is working.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20120513.png)


Confirm that the records are being retrieved from the Azure SQL Server.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20120528.png)


For your convenience, open it in Postman and verify that all endpoints are functioning correctly.

    POST - /api/drivers - Create New Driver

    Payload 

    {
        "FirstName": "Lewis",
        "LastName": "Hamilton",
        "DriverNumber": 44,
        "DateOfBirth": "1985-01-07T00:00:00"
    }


    PUT - /api/drivers - Update Existing Driver

    Test Payload 

    {
        "DriverID": "113fb646-e703-482e-8c59-78fccccb2859" // make sure this one exist in our table
        "FirstName": "Lewis",
        "LastName": "Hamilton",
        "DriverNumber": 44,
        "DateOfBirth": "1985-01-07T00:00:00"
    }


    GET - /api/drivers - Get All Drivers

    GET - /api/drivers/{driverId} - Get Driver Info



### Step 3 - Trigger again CICD

Let's make some changes to our controller and push them to our GitHub repository. We will create two dummy endpoints: **/api/drivers/TestCICD** and **/api/drivers/TestSQL**.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20120829.png)


This will trigger the GitHub workflow.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20121008.png)


Confirm that our changes have been successfully applied.

![Image](https://raw.githubusercontent.com/gitalvininfo/Net.Api.CICD/refs/heads/master/Screenshots/Screenshot%202024-10-23%20121032.png)



### With this, we can be confident that the CI/CD process is functioning correctly in our project.
