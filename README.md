# Invoice Management System About
Management of dues and common electricity, water and natural gas bills of the apartments in a complex through a system.

# Build With
[![C#](https://img.shields.io/badge/Csharp-563D7C?style=for-the-badge&logo=Csharp&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![.NETCORE](https://img.shields.io/badge/.NET-512bd4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![Postgres](https://img.shields.io/badge/postgreSql-4169E1?style=for-the-badge&logo=postgreSql&logoColor=white)](https://www.postgresql.org/)
[![Entity-Framework](https://img.shields.io/badge/EntityFramework-512bd4?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/tr-tr/ef/)

[![Entity-Framework](https://img.shields.io/badge/FluentValidation-40babd?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/tr-tr/ef/)

## Layers
<details> 
<summary>Toggle Content</summary>

  ### Business

Business Layer created to process or control the incoming information according to the required conditions.

### Core

Core layer containing various particles independent of the project.

### DataAccess

Data Access Layer created to perform database CRUD operations.

### Entities

Entities Layer created for database tables.

### MvcWebUI
Model View Controller Layer that opens the business layer to the internet.
</details>

## Models
<details>
<summary> Toggle Content </summary>

### Apartment

| Name                        | DataType | Allow Nulls | Default |
|:----------------------------|:---------|:------------|:--------|
| Id                          | int      | NotNull     |         |
| NumberOfFloors              | int      | NotNull     |         |
| NumberOfHousesOnTheFloors   | int      | NotNull     |         |
| BlockName                   | string   | NotNull     |         |

### House

| Name          | DataType | Allow Nulls | Default |
|:--------------|:---------|:------------|:--------|
| Id            | int      | NotNull     |         |
| ApartmentId   | int      | NotNull     |         |
| TypeInfo      | string   | NotNull     |         |
| FloorNumber   | int      | NotNull     |         |
| DoorNumber    | int      | NotNull     |         |
| IsOwner       | bool     | NotNull     |         |
| State         | bool     | NotNull     |         |


### Invoice

| Name                 | DataType   | Allow Nulls | Default |
|:---------------------|:-----------|:------------|:--------|
| Id                   | int        | NotNull     |         |
| HouseId              | int        | NotNull     |         |
| InvoiceGenreId       | int        | NotNull     |         |
| InvocingDateTime     | DateTime   | NotNull     |         |
| LastPaymentDate      | DateTime   | NotNull     |         |
| PaymentDate          | DateTime   | NotNull     |         |
| Amount               | Decimal    | NotNull     |         |


### Invoice

| Name                 | DataType   | Allow Nulls | Default |
|:---------------------|:-----------|:------------|:--------|
| Id                   | int        | NotNull     |         |
| Name                 | string     | NotNull     |         |


</details>

